using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_UI_Manager : MonoBehaviour {
	private Task_Manager taskManager = new Task_Manager();
	private CS_UI_MoveTask UI_Move_Task;
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

		UI_Move_Task = new CS_UI_MoveTask(UI_MoveToPos, GetComponent<RectTransform>());
		taskManager.AddTask(UI_Move_Task);
	}
}
