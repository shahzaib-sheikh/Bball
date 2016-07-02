using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Hoop : MonoBehaviour {

	public Text SuccessfulThrows;
	public AudioClip Success;
	public AudioClip Applause;
	
	void OnCollisionEnter()
	{
		GetComponent<AudioSource>().Play();
	}
	
	void OnTriggerEnter()
	{
		SuccessfulThrows.text = (Int32.Parse(SuccessfulThrows.text)+1).ToString();
		AudioSource.PlayClipAtPoint(Success, transform.position);
		AudioSource.PlayClipAtPoint (Applause, transform.position);

	}

}
