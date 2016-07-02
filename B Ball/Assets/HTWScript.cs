using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HTWScript : MonoBehaviour {

	public Button BackButton;
	// Use this for initialization
	void Start () {
	
		BackButton.onClick.AddListener (() => {
			Application.LoadLevel("MainMenu");
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
