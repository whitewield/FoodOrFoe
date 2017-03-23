using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CS_Canvas_Manager : MonoBehaviour {
	public List<GameObject> animalList;
	public CS_UI_PanelManager PanelManager;
	public bool ifMenu{get; private set;}
	public Sprite[] images;
	private List<Vector3> UI_MoveToPos_List = new List<Vector3>()
	{
		Vector3.zero,
		Vector3.zero,
		Vector3.zero
	};

	void Start()
	{
		PanelManager = GetComponentInChildren<CS_UI_PanelManager>();
	}
	public void TriggerUIMove_Left()
	{
		SetPosition(-200, 400,600);
		PanelManager.SetCharacterImage(images[0]);
		PanelManager.SetRealImage(images[0]);
		PanelManager.SetText("Left");
		TriggerMoveTask();
	}
	public void TriggerUIMove_Middle()
	{
		SetPosition(-400, -200,400);
		PanelManager.SetCharacterImage(images[1]);
		PanelManager.SetRealImage(images[1]);
		PanelManager.SetText("Middle");
		TriggerMoveTask();
	}	
	public void TriggerUIMove_Right()
	{
		SetPosition(-600, -400,-200);
		PanelManager.SetCharacterImage(images[2]);
		PanelManager.SetRealImage(images[2]);
		PanelManager.SetText("Right");
		TriggerMoveTask();
	}
	public void TriggerUIMove_Back()
	{
		SetPosition(-200, 0,200);
		TriggerMoveTask();
	}
	private void SetPosition(float XPos_Left, float XPos_Mid, float XPos_Right)
	{
		UI_MoveToPos_List[0] = new Vector3(XPos_Left, 300, 0);
		UI_MoveToPos_List[1] = new Vector3(XPos_Mid, 300, 0);
		UI_MoveToPos_List[2] = new Vector3(XPos_Right, 300, 0);
	}
	private void TriggerMoveTask()
	{
		for(int i = 0; i< animalList.Count; i++)
		{
			animalList[i].GetComponent<CS_UI_Manager>().TriggerUIMove(UI_MoveToPos_List[i]);
		}
	}
	private void TriggerMenuPopOut()
	{
		PanelManager.TurnOnAllButton();
	}
	private void TriggerMenuDisappear()
	{
		PanelManager.TurnOffAllButton();
	}
}
