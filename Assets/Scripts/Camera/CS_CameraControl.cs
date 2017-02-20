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
		CameraSelect();
		CameraMove(targetPos);
	}

	//Guide The Camera
	void CameraMove(Vector3 _targetPosition)
	{
		transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * followSpeed);
		if((transform.position - _targetPosition).magnitude <= 0.01f)
			transform.position = _targetPosition;
	}

	//Cast ray to select the area
	void CameraSelect()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray.origin,ray.direction, out rayhit, 300.0f,rayCastLayer))
			{
				targetPos = new Vector3(rayhit.collider.transform.position.x, rayhit.collider.transform.position.y, closeDistance);
				Debug.Log("Hit");
			}
		}

		if(Input.GetButtonDown("Fire2"))
		{
			targetPos = originalPosition;
		}
	}

	public float getDistanceRatio()
	{
		return (closeDistance - transform.position.z)/(closeDistance - originalPosition.z);
	}
}
