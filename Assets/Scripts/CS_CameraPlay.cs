using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CameraPlay : MonoBehaviour {
	[SerializeField] Camera myCamera;
	[SerializeField] Shader myShader;

	// Use this for initialization
	void Start() {
		myCamera.SetReplacementShader (myShader, "RenderType");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
