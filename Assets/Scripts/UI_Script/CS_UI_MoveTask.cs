using UnityEngine;
using EasingFunc;

public class CS_UI_MoveTask : Task {
	public Vector3 ToPosition{get; private set;}
	private RectTransform moveTrans;
	private Vector3 startPos;
	private float timer = 0.0f;

	public CS_UI_MoveTask(Vector3 m_ToPosition, RectTransform m_moveTrans)
	{
		ToPosition = m_ToPosition;
		moveTrans = m_moveTrans;
	}
	override protected void Init()
	{
		startPos = moveTrans.localPosition;
		timer = 0.0f;
	}
	override internal void TUpdate()
	{
		timer += Time.deltaTime;
		moveTrans.localPosition = Vector3.Lerp(startPos, ToPosition, Easing.ExpoEaseOut(timer));

		if(moveTrans.localPosition == ToPosition)
		{
			SetStatus(TaskStatus.Success);
		}
	}
	override protected void OnSuccess()
	{
		Debug.Log(moveTrans.gameObject.name + " Done Moving");
	}
	override protected void CleanUp()
	{
		moveTrans = null;
		timer = 0.0f;
	}
}
