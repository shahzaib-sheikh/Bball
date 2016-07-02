using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameScript : MonoBehaviour {

	public Light DirectionalLight;


	public Image Pbar;
	public Image Sbar;

	public Text GameOver;

	public GameObject BallPreFab;
	public GameObject Hoop;
	Vector3 BallPosition;
	Vector3 ThrowSpeed;

	public Image PositionVal;
	RectTransform PositionRectTrans;
	float XPositionVal;
	float IncreamentPositionVal;

	public Image SpeedVal;
	RectTransform SpeedRectTrans;
	float IncreamentSpeedVal;
	float YSpeedVal;

	bool IsActivePBar=false;
	bool IsActiveSBar=false;
	bool IsThrown=false;
	GameObject BallClone;

	public Camera TopCamera;
	public Camera RightCamera;
	public Camera MainCamera;

	public Text RemainingThrows;
	public Text SuccessfulThrows;

	int MaxRemainingShots =5;

	bool IsStart;
	int i=0;
	int delay=0;
	int StartDelay=0;
	// Use this for initialization

	void restart(){
		Application.LoadLevel ("MainMenu");
	}

	void Start () {

		Physics.gravity = new Vector3 (0, -980, 0);
		RemainingThrows.text = MaxRemainingShots.ToString();
		SuccessfulThrows.text = (0).ToString ();
		Hoop.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		IsActivePBar = true;
		PositionRectTrans = PositionVal.transform as RectTransform;
		SpeedRectTrans = SpeedVal.transform as RectTransform;
		XPositionVal = PositionRectTrans.position.x;
		IncreamentPositionVal = 10;
		IncreamentSpeedVal = 2;
		YSpeedVal = 0;
		DirectionalLight.enabled = false;
		IsStart = true;
			}


	void ToggleCameras(){
		if(RightCamera.enabled){
			TopCamera.enabled=false;
			RightCamera.enabled=false;
			Pbar.enabled=true;
			PositionVal.enabled=true;
			Sbar.enabled=true;
			SpeedVal.enabled=true;
		}else{
			TopCamera.enabled=true;
			RightCamera.enabled=true;
			Pbar.enabled=false;
			PositionVal.enabled=false;
			Sbar.enabled=false;
			SpeedVal.enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsStart) {
			StartDelay++;
			if (StartDelay > 100) {
				IsStart = false;
			}
			return;
		} else if(!DirectionalLight.enabled) {
			DirectionalLight.enabled=true;
		}




		if(IsActivePBar){
			if(XPositionVal < 440 || XPositionVal >890){
				IncreamentPositionVal*=-1;
			}
			XPositionVal+=IncreamentPositionVal;
			PositionRectTrans.position = new Vector3(XPositionVal, PositionRectTrans.position.y, PositionRectTrans.position.z);
		}

		if(IsActiveSBar){
			if(YSpeedVal < 0 || YSpeedVal >190){
				IncreamentSpeedVal*=-1;
			}
			YSpeedVal+=IncreamentSpeedVal;
			SpeedRectTrans.sizeDelta = new Vector2 (SpeedRectTrans.sizeDelta.x, YSpeedVal);
			SpeedRectTrans.position = new Vector3(SpeedRectTrans.position.x,SpeedRectTrans.position.y + (IncreamentSpeedVal/2), SpeedRectTrans.position.z);
			}


		if (Input.GetButton ("Fire1") && IsActivePBar) {
			IsActivePBar=false;
			IsActiveSBar=true;
			delay=0;
		}
		delay++;
		if (Input.GetButton ("Fire1") && delay >80 && IsActiveSBar && !IsThrown) {
			IsActiveSBar=false;

			IsThrown=true;

			RemainingThrows.text = (Int32.Parse(RemainingThrows.text)-1).ToString();



			BallPosition=new Vector3(XPositionVal-120,-182,90);

			BallClone=Instantiate(BallPreFab,BallPosition,transform.rotation) as GameObject;

			i=0;


			ThrowSpeed =new Vector3(0, float.Parse((1600 + YSpeedVal*1.5).ToString()) , -700);

			BallClone.GetComponent<Rigidbody>().AddForce(ThrowSpeed,ForceMode.Impulse);


			ToggleCameras();
		}

		if(IsThrown && i>300){
			IsThrown=false;
			ToggleCameras();
			Destroy(BallClone);
			if(Int32.Parse(RemainingThrows.text)>0){
				IsActivePBar=true;
			}else{
				DirectionalLight.enabled = false;
				GameOver.enabled=true;
				Invoke("restart",4);
			}
		}

		if(IsThrown){
			i++;
		}

	}
}
