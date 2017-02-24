using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour {
	[SerializeField] float mySpeed = 10;
	[SerializeField] float myDeltaDistance = 1;

	private Vector3 myTargetPosition;
	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.forward * mySpeed * Time.deltaTime * Input.GetAxis ("Vertical");

		if (isMoving) {
			this.transform.position = Vector3.Lerp (
				this.transform.position, myTargetPosition, Time.deltaTime * mySpeed * Time.deltaTime
			);
			if (Vector3.Distance (this.transform.position, myTargetPosition) < myDeltaDistance) {
				isMoving = false;
			}
		} else if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast (ray, out hit, 100.0F);
			if (hit.collider.tag == "Food") {
				myTargetPosition = hit.transform.position;
				isMoving = true;
			}
		}
	}


}
