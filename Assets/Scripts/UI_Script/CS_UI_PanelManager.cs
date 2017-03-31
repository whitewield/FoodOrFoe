using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CS_UI_PanelManager : MonoBehaviour {
	public Button[] buttons{get; private set;}
	[SerializeField] Image[] Images;
	[SerializeField] Text[] Texts;
	void Start()
	{
		buttons = GetComponentsInChildren<Button>();
	}
	public void TurnOnAllButton()
	{
		for(int i=0;i<buttons.Length;i++)
		{
			buttons[i].enabled = true;
		}
	}
	public void TurnOffAllButton()
	{
		for(int i=0;i<buttons.Length;i++)
		{
			buttons[i].enabled = false;
		}
	}
	public void SetCharacterImage(Sprite characterImage)
	{
		Images[0].sprite = characterImage;
	}
	public void SetRealImage(Sprite realImage)
	{
		Images[1].sprite = realImage;
	}
	public void SetText(string text)
	{
		Texts[0].text = text;
	}
}
