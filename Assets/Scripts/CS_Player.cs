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


	[SerializeField] float mySpeed = 10;
	[SerializeField] float myDeltaDistance = 1;
	[SerializeField] float myVisionDistance = 20;

	private Vector3 myTargetPosition;
	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.forward * mySpeed * Time.deltaTime * Input.GetAxis ("Vertical");

		if (isMoving) {
			this.transform.position = Vector3.Lerp (
				this.transform.position, myTargetPosition, Time.deltaTime * mySpeed * Time.deltaTime
			);
			if (Vector3.Distance (this.transform.position, myTargetPosition) < myDeltaDistance) {
				isMoving = false;
			}
		} else if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			int t_layerMask = (int) Mathf.Pow (2, 8);
			if (Physics.Raycast (ray, out hit, myVisionDistance, t_layerMask))
			if (hit.collider.tag == "Food") {
				myTargetPosition = hit.transform.position;
				isMoving = true;
			}
		}
	}


}
