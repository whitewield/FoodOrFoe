using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GroundLoop : MonoBehaviour {
	[SerializeField] Vector2 myLoopSize;
	private Vector3 myStartPosition;
	// Use this for initialization
	void Start () {
		myStartPosition = this.transform.position;
		Vector3 t_position = CS_Player.Instance.transform.position + myStartPosition;
		t_position = new Vector3 (t_position.x, myStartPosition.y, t_position.z);
		this.transform.position = t_position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((CS_Player.Instance.transform.position.x - this.transform.position.x) > myLoopSize.x) {
			this.transform.position += Vector3.right * myLoopSize.x;
		} else if ((this.transform.position.x - CS_Player.Instance.transform.position.x) > myLoopSize.x) {
			this.transform.position += Vector3.left * myLoopSize.x;
		}

		if ((CS_Player.Instance.transform.position.z - this.transform.position.z + myStartPosition.z) > myLoopSize.y) {
			this.transform.position += Vector3.forward * myLoopSize.y;
		} else if ((this.transform.position.z - CS_Player.Instance.transform.position.z - myStartPosition.z) > myLoopSize.y) {
			this.transform.position += Vector3.forward * myLoopSize.y;
		}
	}
}
