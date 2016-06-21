using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour {

	public int soulCount;

	public int minValue;
	public int maxValue;

	void Update () {
		InterFace ();
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
		print(soulCount);
	}
	void InterFace () {

	}
}
