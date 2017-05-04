using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasingFunc;


public class CS_UI_PlayCanvasAppear : CS_UI_Appearance {

	// Use this for initialization
	void Start () {
		if(GetComponent<Image>())
		{
			imageComponent = GetComponent<Image>();
			colorTask_Image = new Image_ColorChangingTask(endColor, imageComponent);
			imageComponent.color = originalColor;
		}
		if(GetComponent<Text>())
		{
			textComponent = GetComponent<Text>();
			colorTask_Text = new Text_ColorChangingTask(endColor, textComponent);
			textComponent.color = originalColor;
		}
		EventManager.Instance.Register<InfoScreenEvent>(Appear_In);
		EventManager.Instance.Register<BackButton_In_Info_Screen_Event>(Appear_Out);
		taskManager = new Task_Manager();
	}
}
