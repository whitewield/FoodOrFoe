using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ZoomIntoArea : MonoBehaviour {
	[SerializeField] Transform zoomInTransform;
	public void SendPinPoint()
	{
		Camera.main.GetComponent<CS_CameraControl>().SetTargetPos(zoomInTransform.position);
	}
}
