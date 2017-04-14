using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CS_UI_PanelManager : MonoBehaviour {
	public Button[] buttons{get; private set;}
	[SerializeField] Image[] Images;
	[SerializeField] Text[] Texts;
	[SerializeField] int NextLoadScene;
	[SerializeField] string NextLoadScene_Name;
	void Start(){
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
	public void SetText(string text){Texts[0].text = text;}
	public void SetLevel(int m_levelIndex){NextLoadScene = m_levelIndex;}
	public void SetLevel(string m_levelName){NextLoadScene_Name = m_levelName;}
	public void LoadScene(){
		SceneManager.LoadScene(NextLoadScene);
	}
	public void LoadScene_Name(){
		SceneManager.LoadScene(NextLoadScene_Name);
	}
}
