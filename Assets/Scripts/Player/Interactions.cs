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

	public GameObject mainMenuObj;

	void Start () {
		gameManager = GameObject.Find("GameManager");
		player = gameManager.GetComponent<GameManager>().player;
		canvas = gameManager.GetComponent<GameManager>().canvas;
		player.FindChild("Main Camera").GetChild(0).gameObject.SetActive(false);
		canvas.transform.FindChild("TopLeft").gameObject.SetActive(false);
		player.transform.GetComponent<Combat>().Toggle();
		player.transform.GetComponent<Movement>().ToggleMovement();
		Toggle();
		interactTxtObj.SetActive(false);
	}

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
		if(Physics.Raycast(player.FindChild("Main Camera").position,player.forward,out inFront,interactRng)){
			print(inFront.transform.tag);
			if(inFront.transform.tag == "Npc" || inFront.transform.tag == "Key" || inFront.transform.tag == "Item0" || inFront.transform.tag == "Item1" || inFront.transform.tag == "Gate" ){
				interactTxtObj.SetActive(true);
				switch(inFront.transform.tag){
					case "Npc":
						interactTxtObj.GetComponent<Text>().text = interactString[0];
						if(Input.GetButtonDown("Interact")){
							inFront.transform.GetComponent<ConversationShop>().EngageConversation();
							conversation = true;
						}
					break;
					case "Key" :
						interactTxtObj.GetComponent<Text>().text = interactString[1];
						if(Input.GetButtonDown("Interact")){
							transform.GetComponent<Inventory>().keysCount +=1;
							transform.GetComponent<Inventory>().Keys();
							Destroy(inFront.transform.gameObject);
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
					case "Gate" :
						interactTxtObj.GetComponent<Text>().text = interactString[2];
						if(transform.GetComponent<Inventory>().keysCount == 4){
							inFront.transform.GetComponent<Animator>().SetBool("Open",true);
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
	public void MainMenu (){
		Destroy(mainMenuObj);
		player.FindChild("Main Camera").GetChild(0).gameObject.SetActive(true);
		player.transform.GetComponent<Movement>().ToggleMovement();
		canvas.transform.FindChild("TopLeft").gameObject.SetActive(true);
		Toggle();
		player.transform.GetComponent<Combat>().Toggle();
	}
}