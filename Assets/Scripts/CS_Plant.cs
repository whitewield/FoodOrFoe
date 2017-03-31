using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Plant : MonoBehaviour {
	[SerializeField] Vector2 mySizeRange;
	// Use this for initialization
	void Start () {
		float t_size = Random.Range (mySizeRange.x, mySizeRange.y);
		this.transform.localScale = new Vector3 (t_size * (Random.Range (0, 2) * 2 - 1), t_size, 1);

	}
	
	// Update is called once per frame
	void Update () {
		float t_distance = this.transform.position.z - CS_Player.Instance.transform.position.z;
		if (t_distance < 2) {
			this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, t_distance / 2f);
		}
	}
}
