using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_UI_Play : MonoBehaviour {

	private static CS_UI_Play instance = null;

	//========================================================================
	public static CS_UI_Play Instance {
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

	[SerializeField] GameObject UI_Breathing;
	[SerializeField] GameObject UI_End;
	[SerializeField] GameObject UI_Help;
	[SerializeField] RectTransform myEnergyRectTransform;
	[SerializeField] Image myEnergyImage;
	[SerializeField] Gradient myEnergyColor;

	public Text myTextFood;
	public Text myTextFoe;
	// Use this for initialization
	void Start () {
		UI_End.SetActive (false);
		UI_Help.SetActive (false);
		UI_Breathing.SetActive (false);
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void ShowEnd () {
		UI_End.SetActive (true);
	}

	public void ShowHelp () {
		UI_Help.SetActive (true);
		UI_End.SetActive (false);
	}

	public void Replay () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ShowEnergy (float g_percent) {
		myEnergyRectTransform.localScale = new Vector3 (g_percent, 1, 1);
		myEnergyImage.color = myEnergyColor.Evaluate (g_percent);
	}

	public void SetFoodNFoe (int g_food, int g_foe) {
		if (g_food != 0) 
			myTextFood.text = g_food.ToString ("#");
		else 
			myTextFood.text = "0";

		if (g_foe != 0)
			myTextFoe.text = g_foe.ToString ("#");
		else 
			myTextFoe.text = "0";
	}

	public void LoadMenu () {
		Debug.Log ("Menu");
		SceneManager.LoadScene ("Map");
	}
}

