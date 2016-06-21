using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

	public int soulCount;
	public int soulsObtained;

	public int minValue;
	public int maxValue;

	public GameObject soulCountUI;
	public GameObject soulsObtainedUI;
	Text soulsObtainedText;
	Text soulCountText;
	public float soulsObtainedTime;

	bool gathering;
	float timer;

	void Start () {
		soulsObtainedText = soulsObtainedUI.transform.GetComponent<Text>();
		soulCountText = soulCountUI.transform.GetComponent<Text>();
	}

	void Update () {
		InterFace ();
		Timer();
	}
	void OnTriggerEnter (Collider soul) {
		switch(soul.transform.tag){
			case "Soul01":
				pickUp(5);	
			break;
			case "Soul02":
				pickUp(10);
			break;
		}
	}
	void pickUp (int value) {
		soulCount += value;
		soulsObtained += value;
		timer = 0;
		print(soulCount);
		gathering = true;
		soulsObtainedUI.SetActive(true);
	}
	void InterFace () {
		soulCountText.text = soulCount.ToString();
		soulsObtainedText.text = soulsObtained.ToString();
	}
	void Timer () {
		if(gathering == true){
			timer += Time.deltaTime;
			if(timer >= soulsObtainedTime){
				gathering = false;
			}
		}
		else{
			soulsObtainedUI.SetActive(false);
			soulsObtained = 0;
		}
	}
}
