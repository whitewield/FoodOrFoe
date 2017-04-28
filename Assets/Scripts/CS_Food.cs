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

//	// Use this for initialization
	void Start () {
		this.GetComponent<Animator> ().speed = Random.Range (myMovementSpeedRange.x, myMovementSpeedRange.y);
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
