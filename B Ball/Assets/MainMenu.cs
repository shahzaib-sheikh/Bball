using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button PlayButton;
	public Button HTWButton;
	public Button CreditsButton;
	public Button ExitButton;

	// Use this for initialization
	void Start () {
	
		PlayButton.onClick.AddListener (() => {
			Application.LoadLevel("Loading");
		});
		
		HTWButton.onClick.AddListener (() => {
			Application.LoadLevel("HTW");
		});
		
		CreditsButton.onClick.AddListener (() => {
			Application.LoadLevel("Credits");
		});
		
		ExitButton.onClick.AddListener (() => {
			Application.Quit();
		});
	}

	// Update is called once per frame
	void Update () {
	
	}
}
