using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_LevelLoader : MonoBehaviour {
	[SerializeField] int _NextLevelIndex;
	[SerializeField] string _NextLevelName;
	public string NextLevelName{get{return _NextLevelName;}}
	public int NextLevelIndex{get{return _NextLevelIndex;}}
	// Use this for initialization

	public void setLevel(int _levelIndex){
		_NextLevelIndex = _levelIndex;
	}
	public void setLevel(string _levelName){
		_NextLevelName = _levelName;
	}
	public void LoadLevel(){
		EventManager.Instance.ClearList();
		// SceneManager.LoadScene(_NextLevelIndex);
		SceneManager.LoadScene("PlaySeaTurtle");
	}
	public void LoadLevel_Name(){
		EventManager.Instance.ClearList();
		SceneManager.LoadScene(_NextLevelName);
	}
	public void LoadLevel_Index(){
		EventManager.Instance.ClearList();
		SceneManager.LoadScene(_NextLevelIndex);
	}
}
