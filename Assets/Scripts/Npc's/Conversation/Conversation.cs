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
	}

	void Update () {
	
	}
	public void EngageConversation(){
		convObj = (GameObject)Instantiate(convIns,convPos,Quaternion.identity);
		convObj.transform.SetParent(canvas.transform);
		convObj.transform.GetComponent<RectTransform>().anchoredPosition = convPos;
	}
	public void Response (int option){

	}
}
