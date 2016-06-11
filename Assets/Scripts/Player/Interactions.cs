using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {
	public Transform player;

	public bool input = true;
	public bool interact = true;

	public RaycastHit inFront;
	public float interactRng;

	public GameObject interactTxtObj;
	public string interactString;
	// Use this for initialization
	void Start () {
		interactTxtObj.GetComponent<Text>().text = interactString;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(input == true){
			InputCheck();
		}
		InteractCheck();
	}
	void InputCheck () {
		if(Input.GetButtonDown("Inv")){
				transform.GetComponent<Inventory>().toggle();
		}
		if(interact == true){
			if(Input.GetButtonDown("Interact")){
				inFront.transform.GetComponent<Conversation>().EngageConversation();
			}
		}
	}
	void InteractCheck () {
		if(Physics.Raycast(player.position,player.forward,out inFront,interactRng)){
			if(inFront.transform.tag == "Interactable"){
				interactTxtObj.SetActive(true);
				interact = true;
			}
		}
		else{
			interactTxtObj.SetActive(false);
			interact = false;
		}
	}
}