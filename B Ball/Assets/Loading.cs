using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Loading : MonoBehaviour {

	public Image LoadingImage;
	public RectTransform RectTrans;
	public float Width;
	public float XPosition;
	// Use this for initialization
	void Start () {
		Width = 0;
		RectTrans = LoadingImage.transform as RectTransform;
		XPosition = RectTrans.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		RectTrans.sizeDelta = new Vector2 (Width, RectTrans.sizeDelta.y);
		RectTrans.position = new Vector3(XPosition, RectTrans.position.y, RectTrans.position.z);
		Width++;
		XPosition+=0.5F;
		if(Width>175){
			Application.LoadLevel("Game");
		}
	}
}
