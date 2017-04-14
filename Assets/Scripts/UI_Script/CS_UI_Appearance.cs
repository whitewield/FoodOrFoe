using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasingFunc;

public class CS_UI_Appearance : MonoBehaviour {
	[SerializeField] Color endColor;
	[SerializeField] Color originalColor;
	[SerializeField] float UI_Appear_Wait_Time;
	protected Image imageComponent;
	protected Text textComponent;
	protected Task_Manager taskManager;
	protected Text_ColorChangingTask colorTask_Text;
	protected Image_ColorChangingTask colorTask_Image;

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
		EventManager.Instance.Register<AnimalSelect_Event>(Appear_In);
		EventManager.Instance.Register<BackBottun_Event>(Appear_Out);
		taskManager = new Task_Manager();
	}
	// Update is called once per frame
	void Update () {
		taskManager.Update();
	}

	//When selected one Animal, Do this
	public void Appear_In(Event e)
	{
		wait_Task wait = new wait_Task(UI_Appear_Wait_Time);
		Debug.Log("Name:" + gameObject.name);
		if(gameObject.name != "Text")
		{
			colorTask_Image.ResetColor(endColor);
			if(colorTask_Image.ifDetached)
			{
				wait.Then(colorTask_Image);
				taskManager.AddTask(wait);
			}
		}
		if(gameObject.name == "Text")
		{
			colorTask_Text.ResetColor(endColor);
			if(colorTask_Text.ifDetached)
			{
				wait.Then(colorTask_Text);
				taskManager.AddTask(wait);
			}
		}
	}

	//When go back to the Animal SelectState, Do this
	public virtual void Appear_Out(Event e)
	{
		if(GetComponent<Image>())
		{
			colorTask_Image.ResetColor(originalColor);
			if(colorTask_Image.ifDetached)
				taskManager.AddTask(colorTask_Image);
		}
		if(GetComponent<Text>())
		{
			colorTask_Text.ResetColor(originalColor);
			if(colorTask_Text.ifDetached)
				taskManager.AddTask(colorTask_Text);
		}
	}

	//Basic Class For Changing The UI Color
	public abstract class ColorChangingTask<TContext>: Task where TContext: MaskableGraphic {
		public TContext context;
		protected Color tarColor;
		protected Color oriColor;
		protected float timer;
		
		protected override void Init()
		{
			timer = 0.0f;
			oriColor = context.color;
		}
		internal override void TUpdate()
		{
			timer += Time.deltaTime;
			context.color = Color.Lerp(oriColor, tarColor, Easing.BackEaseOut(timer));

			if(context.color == tarColor)
				SetStatus(TaskStatus.Success);
		}
    	protected override void OnAbort()
    	{
			tarColor = Color.white;
			oriColor = Color.white;
		}
		public void ResetColor(Color m_Color)
		{
			timer = 0.0f;
			tarColor = m_Color;
		}
	}
	
	//Class for Changing the Image Color
	public class Image_ColorChangingTask: ColorChangingTask<Image>{
		public Image_ColorChangingTask(Color m_EndColor, Image image)
		{
			tarColor = m_EndColor;
			context = image;
		}
	}
	
	//Class for Changing the Text Color
	public class Text_ColorChangingTask: ColorChangingTask<Text>{
		public Text_ColorChangingTask(Color m_EndColor, Text text)
		{
			tarColor = m_EndColor;
			context = text;
		}
	}
}
