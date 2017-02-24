using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Plant : MonoBehaviour {
	[SerializeField] Vector2 mySizeRange;
	// Use this for initialization
	void Start () {
		float t_size = Random.Range (mySizeRange.x, mySizeRange.y);
		this.transform.localScale = new Vector3 (t_size, t_size, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
