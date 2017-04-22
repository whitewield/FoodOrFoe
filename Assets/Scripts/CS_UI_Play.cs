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

	public Text myTextAge;
	public Text myTextFood;
	public Text myTextFoe;
	public Text myTextAccuracy;
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
	}

	public void Replay () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void LoadMenu () {
		Debug.Log ("Menu");
		SceneManager.LoadScene ("Map");
	}
}

