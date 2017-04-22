using System.Collections.Generic;
using UnityEngine;

public class CS_Canvas_Manager : MonoBehaviour {
	public List<GameObject> animalList;
	public CS_UI_PanelManager PanelManager;
	public bool ifMenu{get; private set;}
	public Sprite[] images;
	public Sprite[] Button_Image;
	public string[] Text_Collection;
	private List<Vector3> UI_MoveToPos_List = new List<Vector3>()
	{
		Vector3.zero,
		Vector3.zero,
		Vector3.zero
	};

	void Awake()
	{
		PanelManager = GetComponentInChildren<CS_UI_PanelManager>();
	}
	public void TriggerUIMove_Left()
	{
		SetPosition(0, 400,600);
		// PanelManager.SetCharacterImage(images[0]);
		PanelManager.SetButtonImage(Button_Image[0]);
		PanelManager.SetText(Text_Collection[0]);
		PanelManager.SetLevel(1);
		TriggerMoveTask();
	}
	public void TriggerUIMove_Middle()
	{
		SetPosition(-400, 0,400);
		// PanelManager.SetCharacterImage(images[1]);
		PanelManager.SetButtonImage(Button_Image[1]);
		PanelManager.SetText(Text_Collection[1]);
		PanelManager.SetLevel(1);
		TriggerMoveTask();
	}	
	public void TriggerUIMove_Right()
	{
		SetPosition(-600, -400,0);
		// PanelManager.SetCharacterImage(images[2]);
		PanelManager.SetButtonImage(Button_Image[2]);
		PanelManager.SetText(Text_Collection[2]);
		PanelManager.SetLevel(1);
		TriggerMoveTask();
	}
	public void TriggerUIMove_Back()
	{
		SetPosition(-200, 0,200);
		TriggerMoveTask();
	}
	private void SetPosition(float XPos_Left, float XPos_Mid, float XPos_Right)
	{
		UI_MoveToPos_List[0] = new Vector3(XPos_Left, 0, 0);
		UI_MoveToPos_List[1] = new Vector3(XPos_Mid, 0, 0);
		UI_MoveToPos_List[2] = new Vector3(XPos_Right, 0, 0);
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
	public void OnAnimalSelect()
	{
		AnimalSelect_Event tempEvent = new AnimalSelect_Event();
		EventManager.Instance.FireEvent(tempEvent);
	}
	public void OnBackClick()
	{
		BackBottun_Event tempEvent = new BackBottun_Event();
		EventManager.Instance.FireEvent(tempEvent);
	}
	
}
