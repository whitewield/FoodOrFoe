using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ZoomIntoArea : MonoBehaviour {
	[SerializeField] Transform zoomInTransform;
	// Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }

	public void SendPinPoint()
	{
		Camera.main.GetComponent<CS_CameraControl>().SetTargetPos(zoomInTransform.position);
	}
}
