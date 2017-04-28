using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_FoodManager : MonoBehaviour {

	private static CS_FoodManager instance = null;

	//========================================================================
	public static CS_FoodManager Instance {
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

	[SerializeField] GameObject[] myFoodPrefabs;
	[SerializeField] GameObject[] myFoePrefabs;
	[SerializeField] int myFoodNumber = 100;
	[SerializeField] Vector3 myFoodPosition;
	[SerializeField] float myFoodRotateAngle = 30;

	private List<GameObject> myFos = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < myFoodNumber; i++) {
			GameObject t_food = Instantiate (
				                    myFoodPrefabs [Random.Range (0, myFoodPrefabs.Length)], 
				                    CreateRandomPosition (0, myFoodPosition.z),
				                    Quaternion.Euler (0, 0, Random.Range (-myFoodRotateAngle, myFoodRotateAngle))
			                    );

			t_food.transform.SetParent (this.transform);
			myFos.Add (t_food);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject t_food in myFos) {
			if (CS_Player.Instance.transform.position.z > t_food.transform.position.z) {
				t_food.transform.position = CreateRandomPosition (myFoodPosition.z, myFoodPosition.z);
			}

			if (t_food.transform.position.x - CS_Player.Instance.transform.position.x < myFoodPosition.x * -1) {
				t_food.transform.position = MovePositionX (t_food.transform.position, myFoodPosition.x * 2);
			} else if (t_food.transform.position.x - CS_Player.Instance.transform.position.x > myFoodPosition.x) {
				t_food.transform.position = MovePositionX (t_food.transform.position, myFoodPosition.x * -2);
			}
		}
	}

	private Vector3 CreateRandomPosition (float g_zStart, float g_zRange) {
		return new Vector3 (
			Random.Range (-myFoodPosition.x + CS_Player.Instance.transform.position.x, myFoodPosition.x + CS_Player.Instance.transform.position.x),
			Random.Range (-myFoodPosition.y, myFoodPosition.y), 
			Random.Range (g_zStart, g_zRange + g_zStart) + CS_Player.Instance.transform.position.z
		);
	}

	private Vector3 MovePositionX (Vector3 g_pos, float g_deltaPosX) {
		return new Vector3 (g_pos.x + g_deltaPosX, g_pos.y, g_pos.z);
	}

	public void RemoveFo (GameObject g_food) {
		myFos.Remove (g_food);
		Destroy (g_food);
	}

	public void CreateFoe () {
		GameObject t_foe = Instantiate (
			                   myFoePrefabs [Random.Range (0, myFoodPrefabs.Length)], 
			                   CreateRandomPosition (myFoodPosition.z, myFoodPosition.z),
			                   Quaternion.Euler (0, 0, Random.Range (-myFoodRotateAngle, myFoodRotateAngle))
		                   );

		t_foe.transform.SetParent (this.transform);
		myFos.Add (t_foe);
	}
	
}
