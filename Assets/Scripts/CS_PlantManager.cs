using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlantManager : MonoBehaviour {
	[SerializeField] GameObject[] myPlantPrefabs;
	[SerializeField] int myPlantNumber = 100;
	[SerializeField] Vector3 myPlantPosition;
	private List<GameObject> myPlants = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < myPlantNumber; i++) {
			GameObject t_plant = Instantiate (
				myPlantPrefabs [Random.Range (0, myPlantPrefabs.Length)], 
				CreateRandomPosition (0),
				Quaternion.identity
			);
			myPlants.Add (t_plant);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject t_plant in myPlants) {
			if (CS_Player.Instance.transform.position.z > t_plant.transform.position.z) {
				t_plant.transform.position = CreateRandomPosition (myPlantPosition.z);
			}
		}
	}

	private Vector3 CreateRandomPosition (float g_z) {
		return new Vector3 (
			Random.Range (-myPlantPosition.x, myPlantPosition.x), 
			myPlantPosition.y, 
			Random.Range (g_z, myPlantPosition.z + g_z) + CS_Player.Instance.transform.position.z
		);
	}
}
