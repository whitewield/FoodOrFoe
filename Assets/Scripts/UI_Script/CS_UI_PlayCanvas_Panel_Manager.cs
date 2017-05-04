using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum AnimalState{
		Turtle,
		Seal,
		Manatee
}
[System.SerializableAttribute]
public struct AnimalPic
{
	public Sprite TitleBond_Manatee;
	public Sprite TitleBond_Seal;
	public Sprite TitleBond_Turtle;
	public Sprite TitleImage_Manatee;
	public Sprite TitleImage_Seal;
	public Sprite TitleImage_Turtle;
	public Sprite ScaleImage_Manatee;
	public Sprite ScaleImage_Seal;
	public Sprite ScaleImage_Turtle;
	public Sprite StateImage_Manatee;
	public Sprite StateImage_Seal;
	public Sprite StateImage_Turtle;
	public Sprite PlayButton_Manatee;
	public Sprite PlayButton_Seal;
	public Sprite PlayButton_Turtle;

}
public class CS_UI_PlayCanvas_Panel_Manager : CS_UI_PanelManager {
	[SerializeField] AnimalPic animalPic;
	public AnimalState animalState;
	[SerializeField] RectTransform Panel_Transform;
	private Task_Manager taskManager;
	private CS_UI_MoveTask UI;
	private CS_UI_MoveTask UI_Move_Task;
	void Start(){
		base.Start();
		taskManager = new Task_Manager();
		EventManager.Instance.Register<InfoScreenEvent>(MoveDownCanvas);
		EventManager.Instance.Register<BackButton_In_Info_Screen_Event>(MoveUpCanvas);
	}
	void Update(){
		taskManager.Update();
	}
	public void OnPlayClick(){
		EventManager.Instance.ClearList();
		levelLoader.LoadLevel_Name();
	}
	public void OnBackClick()
	{
		Debug.Log("Back");
		BackButton_In_Info_Screen_Event tempEvent = new BackButton_In_Info_Screen_Event();
		EventManager.Instance.FireEvent(tempEvent);
	}
	public void MoveDownCanvas(Event e){
		SetPic();
		SetText();
		TriggerUIMove(Vector3.zero);
	}
	public void MoveUpCanvas(Event e){
		TriggerUIMove(Vector3.up * 800);
	}
	public void TriggerUIMove(Vector3 UI_MoveToPos)
	{
		if(UI_Move_Task != null && UI_Move_Task.ifWorking)
			UI_Move_Task.SetStatus(Task.TaskStatus.Aborted);

		UI_Move_Task = new CS_UI_MoveTask(UI_MoveToPos, Panel_Transform);
		taskManager.AddTask(UI_Move_Task);
	}
	private void SetPic(){
		switch (animalState)
		{
			case AnimalState.Manatee:
				SetImage(0,animalPic.TitleImage_Manatee);
				SetImage(1,animalPic.PlayButton_Manatee);
				SetImage(2,animalPic.ScaleImage_Manatee);
				SetImage(3,animalPic.StateImage_Manatee);
				SetImage(4,animalPic.TitleBond_Manatee);
				return;
			case AnimalState.Seal:
				SetImage(0,animalPic.TitleImage_Seal);
				SetImage(1,animalPic.PlayButton_Seal);
				SetImage(2,animalPic.ScaleImage_Seal);
				SetImage(3,animalPic.StateImage_Seal);
				SetImage(4,animalPic.TitleBond_Seal);
				return;
			case AnimalState.Turtle:
				SetImage(0,animalPic.TitleImage_Turtle);
				SetImage(1,animalPic.PlayButton_Turtle);
				SetImage(2,animalPic.ScaleImage_Turtle);
				SetImage(3,animalPic.StateImage_Turtle);
				SetImage(4,animalPic.TitleBond_Turtle);
				return;
			default:
				return;
		}
	}
	private void SetText(){
		switch (animalState)
		{
			case AnimalState.Manatee:
				SetText(0,"800-1,200 lbs/ 10 feet");
				SetText(1,"Threatened");
				return;
			case AnimalState.Seal:
				SetText(0, "245 lbs/ 6 feet");
				SetText(1, "Least Concern");
				return;
			case AnimalState.Turtle:
				SetText(0, "100-150 lbs/ 24-45 feet");
				SetText(1, "Critically Endangered");
				return;
			default:
				return;
		}
	}
	protected void SetText(int index, string discription){
		Texts[index].text = discription;
	}
}
