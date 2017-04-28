using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_UI_Play_Breathing : MonoBehaviour {
	
	private static CS_UI_Play_Breathing instance = null;

	//========================================================================
	public static CS_UI_Play_Breathing Instance {
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
	
	[SerializeField] Animator myBreathingAnimator;
	[SerializeField] Text myQuestionText;
	[SerializeField] CS_Question[] myQuestions;
	private CS_Question myCurrentQuestion;
	private bool isAnswered = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ShowQuestion () {
		this.gameObject.SetActive (true);
		myCurrentQuestion = myQuestions [Random.Range (0, myQuestions.Length)];
		myQuestionText.text = myCurrentQuestion.myQuestion;
		isAnswered = false;
		myBreathingAnimator.SetTrigger ("ask");
	}

	public void AnswerQuestion (bool g_answer) {
		if (isAnswered)
			return;

		if (myCurrentQuestion.myAnswer == g_answer) {
			myBreathingAnimator.SetTrigger ("isRight");
			CS_Player.Instance.AnswerRight ();
		} else {
			myBreathingAnimator.SetTrigger ("isWrong");
		}
		isAnswered = true;
	}

	public void BackToGame () {
		CS_Player.Instance.BreathingDone ();
		this.gameObject.SetActive (false);
	}
}

[System.Serializable]
public class CS_Question {
	public string myQuestion = "";
	public bool myAnswer = true;
}