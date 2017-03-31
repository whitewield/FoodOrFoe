using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlantManager : MonoBehaviour {

	private static CS_PlantManager instance = null;

	//========================================================================
	public static CS_PlantManager Instance {
		get { 
			return instance;
		}
	}

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
		} else {
			instance = this;
		}
		//		DontDestroyOnLoad(this.gameObject);
	}
	//========================================================================

	[SerializeField] GameObject[] myPlantPrefabs;
	[SerializeField] int myPlantNumber = 100;
	[SerializeField] Vector3 myPlantPosition;
	private List<GameObject> myPlants = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < myPlantNumber; i++) {
			GameObject t_plant = Instantiate (
				myPlantPrefabs [Random.Range (0, myPlantPrefabs.Length)], 
				CreateRandomPosition (0, myPlantPosition.z),
				Quaternion.identity
			);
			t_plant.transform.SetParent (this.transform);
			myPlants.Add (t_plant);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject t_plant in myPlants) {
			if (CS_Player.Instance.transform.position.z > t_plant.transform.position.z) {
				t_plant.transform.position = CreateRandomPosition (myPlantPosition.z, myPlantPosition.z);
			}

			if (t_plant.transform.position.x - CS_Player.Instance.transform.position.x < myPlantPosition.x * -1) {
				t_plant.transform.position = MovePositionX (t_plant.transform.position, myPlantPosition.x * 2);
			} else if (t_plant.transform.position.x - CS_Player.Instance.transform.position.x > myPlantPosition.x) {
				t_plant.transform.position = MovePositionX (t_plant.transform.position, myPlantPosition.x * -2);
			}
		}
	}

	private Vector3 CreateRandomPosition (float g_zStart, float g_zRange) {
		return new Vector3 (
			Random.Range (-myPlantPosition.x + CS_Player.Instance.transform.position.x, myPlantPosition.x + CS_Player.Instance.transform.position.x),
			myPlantPosition.y, 
			Random.Range (g_zStart, g_zRange + g_zStart) + CS_Player.Instance.transform.position.z
		);
	}

	private Vector3 MovePositionX (Vector3 g_pos, float g_deltaPosX) {
		return new Vector3 (g_pos.x + g_deltaPosX, g_pos.y, g_pos.z);
	}
}
