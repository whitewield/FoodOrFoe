using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Food : MonoBehaviour {

	enum Type : byte {
		Food,
		Foe
	}

	[SerializeField] Vector2 myMovementSpeedRange = Vector2.up;
	[SerializeField] Type myType = Type.Food;
	[SerializeField] Vector2 mySizeRange = new Vector2 (1, 1);

//	// Use this for initialization
	void Start () {
		this.GetComponent<Animator> ().speed = Random.Range (myMovementSpeedRange.x, myMovementSpeedRange.y);
		float t_size = Random.Range (mySizeRange.x, mySizeRange.y);
		this.transform.localScale = new Vector3 (t_size * (Random.Range (0, 2) * 2 - 1), t_size, t_size);
	}
	
	// Update is called once per frame
	void Update () {
		if ((CS_Player.Instance.transform.position - this.transform.position).sqrMagnitude < CS_Player.Instance.GetMyDeltaDistance ()) {
			CS_FoodManager.Instance.CreateFoe ();
			CS_FoodManager.Instance.RemoveFo (this.gameObject);
			if (myType == Type.Food) {
				CS_Player.Instance.EatFood ();
			} else {
				CS_Player.Instance.EatFoe ();
			}
		}
	}



//	void OnTriggerEnter (Collider g_collider) {
//		CS_FoodManager.Instance.CreateFoe ();
//		CS_FoodManager.Instance.RemoveFo (this.gameObject);
//		if (myType == Type.Food) {
//			CS_Player.Instance.EatFood ();
//		} else {
//			CS_Player.Instance.EatFoe ();
//		}
//	}
}
