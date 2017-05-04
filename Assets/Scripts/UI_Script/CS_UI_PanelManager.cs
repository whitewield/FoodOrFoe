using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CS_UI_PanelManager : MonoBehaviour {
	public Button[] buttons{get; private set;}
	[SerializeField] protected Image[] Images;
	[SerializeField] protected Text[] Texts;
	[SerializeField] protected CS_LevelLoader levelLoader;
	protected void Start(){
		buttons = GetComponentsInChildren<Button>();
	}
	public void TurnOnAllButton(){
		for(int i=0;i<buttons.Length;i++)
		{
			buttons[i].enabled = true;
		}
	}
	public void TurnOffAllButton(){
		for(int i=0;i<buttons.Length;i++)
		{
			buttons[i].enabled = false;
		}
	}
	public void SetCharacterImage(Sprite characterImage){Images[0].sprite = characterImage;}
	// public void SetRealImage(Sprite realImage){Images[1].sprite = realImage;}
	public void SetButtonImage(Sprite buttonImage){Images[1].sprite = buttonImage;}
	public void SetImage(int index, Sprite _Image){Images[index].sprite = _Image;}
	public void SetText(string text){Texts[0].text = text;}
	public void SetLevel(int m_levelIndex){
		levelLoader.setLevel(m_levelIndex);
	}
	public void SetLevel(string m_levelName){
		levelLoader.setLevel(m_levelName);
	}
}
