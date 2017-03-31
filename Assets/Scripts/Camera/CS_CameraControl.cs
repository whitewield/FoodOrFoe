using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CameraControl : MonoBehaviour {

	public Texture2D mouseTex;
	public LayerMask rayCastLayer;
	public float followSpeed;
	public float closeDistance;

	private Ray ray;
	private RaycastHit rayhit;
	private Vector3 originalPosition;
	private Vector3 targetPos;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(mouseTex, Vector2.one * mouseTex.width/2, CursorMode.Auto);
		originalPosition = transform.position;
		targetPos = originalPosition;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2"))
		{
			targetPos = originalPosition;
			GameObject.Find("Canvas").GetComponent<CS_Canvas_Manager>().TriggerUIMove_Back();
		}
		CameraMove(targetPos);
	}

	//Guide The Camera to Location
	void CameraMove(Vector3 _targetPosition)
	{
		transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * followSpeed);
		if((transform.position - _targetPosition).magnitude <= 0.01f)
			transform.position = _targetPosition;
	}

	//Set the Target Of the Camera
	public void SetTargetPos(Vector3 m_position)
	{
		targetPos = m_position;
		targetPos = new Vector3(targetPos.x,targetPos.y,closeDistance);
	}
	public void BackToOrigin()
	{
		SetTargetPos(originalPosition);
	}
	//Get the Distance Ration between (Camera to Target) and Camera Start Point to Target
	public float getDistanceRatio()
	{
		return (closeDistance - transform.position.z)/(closeDistance - originalPosition.z);
	}


	//Old Function
	//Cast ray to select the area
	// void CameraSelect()
	// {
	// 	if(Input.GetButtonDown("Fire1"))
	// 	{
	// 		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	// 		if(Physics.Raycast(ray.origin,ray.direction, out rayhit, 300.0f,rayCastLayer))
	// 		{
	// 			if(rayhit.collider.gameObject.GetComponent<CS_ZoomIntoArea>())
	// 			{
	// 				Debug.Log("Hit UI");
	// 			}
	// 			else
	// 			{
	// 				Debug.Log("Hit something else");
	// 			}
	// 		}
	// 	}
	// }
}
