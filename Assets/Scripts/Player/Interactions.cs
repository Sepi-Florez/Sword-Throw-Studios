using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {
	GameObject gameManager;
	Transform player;
	GameObject canvas;

	public bool input = true;
	public bool interact = true;
	public bool conversation = true;

	public RaycastHit inFront;
	public float interactRng;

	public GameObject interactTxtObj;
	public string[] interactString;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
		player = gameManager.GetComponent<GameManager>().player;
		canvas = gameManager.GetComponent<GameManager>().canvas;
	}
	
	// Update is called once per frame
	void Update () {
		if(input == true){
			InteractCheck();
		}
		InputCheck();
	}
	public void Toggle(){
		input = !input;
	}
	void InputCheck () {
		if(Input.GetButtonDown("Inv")){
				transform.GetComponent<Inventory>().Toggle();
				interactTxtObj.SetActive(false);
		}
	}
	void InteractCheck () {
		if(Physics.Raycast(player.position,player.forward,out inFront,interactRng)){
			if(inFront.transform.tag == "Npc" || inFront.transform.tag == "Key" || inFront.transform.tag == "Item0" || inFront.transform.tag == "Item1"  ){
				interactTxtObj.SetActive(true);
				switch(inFront.transform.tag){
					case "Npc":
						interactTxtObj.GetComponent<Text>().text = interactString[0];
						if(Input.GetButtonDown("Interact")){
							inFront.transform.GetComponent<Conversation>().EngageConversation();
							conversation = true;
						}
					break;
					case "Key" :
						interactTxtObj.GetComponent<Text>().text = interactString[1];
						if(Input.GetButtonDown("Interact")){
							transform.GetComponent<Inventory>().keysCount +=1;
							transform.GetComponent<Inventory>().Keys();
						}
					break;
					case "Item0" :
						interactTxtObj.GetComponent<Text>().text = interactString[1];
						if(Input.GetButtonDown("Interact")){
							Destroy(inFront.transform.gameObject);
							transform.GetComponent<Inventory>().addItem(0);
						}
					break;
					case "Item1" :
						interactTxtObj.GetComponent<Text>().text = interactString[1];
						if(Input.GetButtonDown("Interact")){
							Destroy(inFront.transform.gameObject);
							transform.GetComponent<Inventory>().addItem(1);
						}
					break;
				}
			}
			else{
				interactTxtObj.SetActive(false);
				interact = false;
			}
		}
		else{
			interactTxtObj.SetActive(false);
			interact = false;
		}
	}
}