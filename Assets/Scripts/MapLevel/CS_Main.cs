using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CS_Main : MonoBehaviour {
	public enum LevelState{
		BigMap,
		AnimalMap,
		PlayMenu
	}
	[SerializeField] Canvas animalCanvas;
	private CS_LevelLoader levelLoader;
	protected int LevelIndex;
	// Update is called once per frame
	void Start(){
		levelLoader = GetComponent<CS_LevelLoader>();
	}
	public void TurnOnPlayMenu(){
		InfoScreenEvent tempEvent = new InfoScreenEvent();
		EventManager.Instance.FireEvent(tempEvent);
	}
	public void TurnOffSelectMenu(){

	}
	public void TurnOffPlayMenu(){

	}
	public void TurnOnSelectMenu(){

	}
	public void play_Level(){
		EventManager.Instance.ClearList();
		levelLoader.LoadLevel();
	}
}
public class InfoScreenEvent: Event{

} 
