﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Food : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
	void OnTriggerEnter (Collider g_collider) {
		if (g_collider.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
