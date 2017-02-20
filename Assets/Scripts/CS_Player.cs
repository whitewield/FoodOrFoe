using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour {
	[SerializeField] float mySpeed = 10;

	private GameObject myTarget;
	private bool isMoving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.forward * mySpeed * Time.deltaTime * Input.GetAxis ("Vertical");
	}
}
