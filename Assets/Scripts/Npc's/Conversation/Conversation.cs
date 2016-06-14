using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {
	public Canvas canvas;

	public GameObject convIns;
	public GameObject convObj;
	public Vector3 convPos;

	public Text NpcResponse;
	public Text[] Options;

	void Start () {
		convObj.SetActive(false);
	}

	void Update () {
	
	}
	public void EngageConversation(){
		//convObj = Instantiate(convIns,convPos,Quaternion.identity)GameObject;
	}
	public void Response (int option){

	}
}
