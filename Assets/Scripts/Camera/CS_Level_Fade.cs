using UnityEngine;

public class CS_Level_Fade : MonoBehaviour {

	public SpriteRenderer map_Detail;
	public SpriteRenderer map_Rough;
	public SpriteRenderer title_Screen;
	private SpriteRenderer currentMap;
	// Use this for initialization
	void Start () {
		map_Rough.color = Color.white;
		map_Detail.color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	void Update () {
		float alpha = 0;

		alpha = GetComponent<CS_CameraControl>().getDistanceRatio();
		//map_Detail.color = new Color(1,1,1,1-alpha);
		//map_Rough.color = new Color(1,1,1,alpha);
		title_Screen.color = new Color(1,1,1,alpha);
	}
}
