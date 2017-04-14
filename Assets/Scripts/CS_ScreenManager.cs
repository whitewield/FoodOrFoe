using UnityEngine;
using System.Collections;

public class CS_ScreenManager : MonoBehaviour {
	public bool resetResolution;
	public int screenX = 640;
	public int screenY = 480;
	public bool fullScreen = true;
	public int refreshRate = 60;
	// Use this for initialization
	void Start () {
		if (resetResolution == false)
			return;
		//if (Application.platform == RuntimePlatform.Android) {
			//Screen.SetResolution(1024, 768, true, 60);
			//Screen.SetResolution (960, 720, true, 60);
		//}

		Screen.SetResolution (screenX, screenY, fullScreen, refreshRate);
		//Screen.SetResolution (960, 720, true, 60);
	}
}
