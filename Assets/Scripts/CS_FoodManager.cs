using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_FoodManager : MonoBehaviour {
	[SerializeField] GameObject[] myFoodPrefabs;
	[SerializeField] int myFoodNumber = 100;
	[SerializeField] Vector3 myFoodPosition;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < myFoodNumber; i++) {
			Instantiate (
				myFoodPrefabs [Random.Range (0, myFoodPrefabs.Length)], 
				new Vector3 (Random.Range (-myFoodPosition.x, myFoodPosition.x), Random.Range (-myFoodPosition.y, myFoodPosition.y), Random.Range (0, myFoodPosition.z)),
				Quaternion.identity
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
