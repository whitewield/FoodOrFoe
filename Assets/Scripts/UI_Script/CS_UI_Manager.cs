﻿using UnityEngine;
using UnityEngine.UI;

public class CS_UI_Manager : MonoBehaviour {
	private Task_Manager taskManager = new Task_Manager();
	private CS_UI_MoveTask UI_Move_Task;
	[SerializeField] protected AudioClip ClickSound;
	void Start () {
	}
	void Update()
	{
		taskManager.Update();
	}
	public void TriggerUIMove(Vector3 UI_MoveToPos)
	{
		if(UI_Move_Task != null && UI_Move_Task.ifWorking)
			UI_Move_Task.SetStatus(Task.TaskStatus.Aborted);
		// if(GetComponent<Button>().enabled = true){
		// 	Debug.Log("Mamanger");
		// 	GetComponent<Button>().enabled = false;
		// }
		UI_Move_Task = new CS_UI_MoveTask(UI_MoveToPos, GetComponent<RectTransform>());
		taskManager.AddTask(UI_Move_Task);
	}
	public void PlayClickSound(){
		CS_AudioManager.Instance.PlaySFX(ClickSound);
	}
}
