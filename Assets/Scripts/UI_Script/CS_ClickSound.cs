using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ClickSound : MonoBehaviour {
	[SerializeField] protected AudioClip ClickSound;
	public void PlayClickSound(){
		CS_AudioManager.Instance.PlaySFX(ClickSound);
	}
}
