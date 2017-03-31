using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour {

	private static CS_Player instance = null;

	//========================================================================
	public static CS_Player Instance {
		get { 
			return instance;
		}
	}

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
		} else {
			instance = this;
		}
//		DontDestroyOnLoad(this.gameObject);
	}
	//========================================================================

	[SerializeField] Animator myAnimator;

	[SerializeField] float mySpeed = 10;
	[SerializeField] float myDeltaDistance = 1;
	[SerializeField] float myVisionDistance = 20;

	[SerializeField] float myAutoSpeed = 1;

	private Vector3 myTargetPosition;
	private bool isMoving = false;

	[SerializeField] float myEnergyMax = 100;
	[SerializeField] float myEnergyStart = 50;
	[SerializeField] float myEnergyLosePerSecond = 5;
	[SerializeField] float myEnergyLoseFromFoe = 20;
	[SerializeField] float myEnergyGetFromFood = 10;
	[SerializeField] RectTransform myEnergyDisplay;
	private float myEnergyCurrent;

	[SerializeField] float myAgeStart = 10;
	[SerializeField] float myAgePerSecond = 0.5f;
	private float myAge = 0;
	[SerializeField] UnityEngine.UI.Text myAgeDisplay;

	[SerializeField] GameObject myEffectFood;
	[SerializeField] GameObject myEffectFoe;


	private bool isDead = false;

	// Use this for initialization
	void Start () {
		myEnergyCurrent = myEnergyStart;
		myAge = myAgeStart;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isDead)
			return;
		
		this.transform.position += Vector3.forward * mySpeed * Time.deltaTime * Input.GetAxis ("Vertical");

		if (isMoving) {
			this.transform.position = Vector3.Lerp (
				this.transform.position, myTargetPosition, Time.deltaTime * mySpeed * Time.deltaTime
			);
			if (Vector3.Distance (this.transform.position, myTargetPosition) < myDeltaDistance) {
				isMoving = false;
				myAnimator.SetBool ("isIdle", true);
			}
		} else if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			int t_layerMask = (int)Mathf.Pow (2, 8);
			if (Physics.Raycast (ray, out hit, myVisionDistance, t_layerMask))
			if (hit.collider.tag == "Food") {
				myTargetPosition = hit.transform.position;
				isMoving = true;
				myAnimator.SetBool ("isIdle", false);
				myAnimator.SetFloat ("velocityX", myTargetPosition.x - this.transform.position.x);
			}
		} else {
			this.transform.position += Vector3.forward * myAutoSpeed * Time.deltaTime;
		}

		UpdateEnergy ();
		UpdateAge ();
	}

	public void UpdateAge () {
		if (isDead)
			return;

		myAge += Time.deltaTime * myAgePerSecond;
		ShowAge ();
	}

	public void UpdateEnergy () {
		if (isDead)
			return;

		myEnergyCurrent -= Time.deltaTime * myEnergyLosePerSecond;
		CheckIsDead ();
		ShowEnergy ();
	}



	public void EatFoe () {
		GameObject t_effect = Instantiate (myEffectFoe, this.transform.position, Quaternion.identity) as GameObject;
		t_effect.transform.SetParent (this.transform);
		myEnergyCurrent -= myEnergyLoseFromFoe;
		CheckIsDead ();
		ShowEnergy ();
	}

	public void EatFood () {
		GameObject t_effect = Instantiate (myEffectFood, this.transform.position, Quaternion.identity) as GameObject;
		t_effect.transform.SetParent (this.transform);
		myEnergyCurrent += myEnergyGetFromFood;
		if (myEnergyCurrent > myEnergyMax) {
			myEnergyCurrent = myEnergyMax;
		}
		ShowEnergy ();
	}

	public void ShowEnergy () {
		myEnergyDisplay.localScale = new Vector3 (myEnergyCurrent / myEnergyMax, 1, 1);
	}

	public void ShowAge () {
		myAgeDisplay.text = myAge.ToString ("#");
	}

	private void CheckIsDead () {
		if (myEnergyCurrent < 0) {
			myEnergyCurrent = 0;
			isDead = true;
		}
	}

}
