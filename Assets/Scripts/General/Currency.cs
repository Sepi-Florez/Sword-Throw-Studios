using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {
	GameObject gameManager;
	GameObject canvas;
	Transform player;

	public int[] soulValue;

	public int soulCount;
	public int soulsObtained;

	public GameObject soulCountUI;
	public GameObject soulsObtainedUI;
	Text soulsObtainedText;
	Text soulCountText;
	public float soulsObtainedTime;

	bool gathering;
	float timer;

	void Start () {
		gameManager = GameObject.Find("GameManager");
		player = gameManager.GetComponent<GameManager>().player;
		canvas = gameManager.GetComponent<GameManager>().canvas;
		soulsObtainedUI = canvas.transform.FindChild("TopLeft").FindChild("Currency").transform.FindChild("AddedSouls").gameObject;
		soulCountUI = canvas.transform.FindChild("TopLeft").FindChild("Currency").transform.FindChild("SoulCount").gameObject;
		soulsObtainedText = soulsObtainedUI.transform.GetComponent<Text>();
		soulCountText = soulCountUI.transform.GetComponent<Text>();	
		soulsObtainedText.text = soulCount.ToString();
	}

	void Update () {
		InterFace ();
		Timer();
	}
	void OnTriggerStay (Collider soul) {
		switch(soul.transform.tag){
			case "Soul01":
				pickUp(soulValue[0]);
				Destroy(soul.transform.gameObject);	
			break;
			case "Soul02":
				pickUp(soulValue[0]);
				Destroy(soul.transform.gameObject);
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
		soulsObtainedText.text = "+" + soulsObtained.ToString();
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
