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
	[SerializeField] bool ifPlay = false;
	[SerializeField] SpriteRenderer menuSprite;
	[SerializeField] Button playButton;
	[SerializeField] Canvas animalCanvas;
	// Update is called once per frame
	void Update () {
		if(ifPlay){
			if(menuSprite.color.a < 1.0f){
				menuSprite.color += new Color(0,0,0,0.1f);
			}
			else{
				EventManager.Instance.ClearList();
				playButton.enabled = true;
				animalCanvas.gameObject.SetActive (false);
			}
		}
	}
	public void TurnOnPlayMenu(){
		ifPlay = true;
	}
	public void play_Level(){
		SceneManager.LoadScene("PlaySeaTurtle");
	}
}
