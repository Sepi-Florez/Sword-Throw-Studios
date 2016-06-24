using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {
	GameObject gameManager;
	Canvas canvas;
	Transform player;
	public int oRng;

	public GameObject convIns;
	public GameObject convObj;
	public Vector3 convPos;

	public bool exiting;
	public float timer;
	public float exitTime;

	public Text npcResponse;
	public string npcResponseExit;
	Text npcName;
	public string name;
	public Text[] options;

	public string[] npcResponseN;
	public string[] optionsN;

	public string npcResponseStart;
	public string[] optionsStart;

	public int fase;

	public string[] answer1;
	public string[] answer2;
	public string[] answer3;

	public string[] response1;
	public string[] response2;
	public string[] response3;



	void Start () {
		oRng = options.Length;
		gameManager = GameObject.Find("GameManager");
		player = gameManager.GetComponent<GameManager>().player;
		canvas = gameManager.GetComponent<GameManager>().canvas.GetComponent<Canvas>();
	}

	void Update () {
		if(exiting == true){
			timer += Time.deltaTime;
			if(timer >= exitTime){
				ExitConversation();
				timer = 0;
			}
		}
	}
	public void EngageConversation(){
		convObj = (GameObject)Instantiate(convIns,convPos,Quaternion.identity);
		convObj.transform.SetParent(canvas.transform);
		convObj.transform.GetComponent<RectTransform>().anchoredPosition = convPos;
		player.transform.GetComponent<Movement>().ToggleMovement();
		player.transform.GetComponent<Interactions>().Toggle();
		player.transform.GetComponent<Combat>().Toggle();
		for(int a = 0; a < convObj.transform.FindChild("Options").transform.childCount; a++){
			options[a] = convObj.transform.FindChild("Options").GetChild(a).GetComponent<Text>();
		}
		npcName = convObj.transform.FindChild("Npc Name").GetComponent<Text>();
		npcResponse = convObj.transform.FindChild("Npc Text").GetComponent<Text>();
		options[0].transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => Response(0));
		options[1].transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => Response(1));
		options[2].transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ExitConversation());
		canvas.transform.FindChild("TopLeft").gameObject.SetActive(false);
		convObj.transform.localScale = new Vector3(1,1,1);
		for(int b = 0; b < oRng; b++){
			options[b].text = optionsStart[b];
		}
		npcResponse.text = npcResponseStart;
		npcName.text = name;
	}
	public void ExitConversation(){
		npcResponse.text = npcResponseExit;
		if(exiting == true){
			exiting = false;
			player.transform.GetComponent<Movement>().ToggleMovement();
			player.transform.GetComponent<Interactions>().Toggle();
			player.transform.GetComponent<Combat>().Toggle();
			canvas.transform.FindChild("TopLeft").gameObject.SetActive(true);
			Destroy(convObj);
		}
		else{
			for(int a = 0; a < options.Length; a++){
				options[a].transform.gameObject.SetActive(false);
			}
			exiting = true;
		}

	}
	public void Response (int option){
		npcResponse.text = npcResponseN[option];
		fase += 1;
		switch(option){
			case 0 :
				for(int a0 = 0; a0 < oRng; a0++){
					options[a0].text = optionsN[a0];
				}
				switch(fase){
					case 1 :
						for(int a01 = 0; a01  < oRng; a01++){

						}
					break;
					case 2 :
				
					break;						
				}
			break;
			case 1 :
				for(int b1 = 0; b1 < oRng; b1++){
					options[b1].text = optionsN[b1 + 3];
				}
				switch(fase){
					case 1 :

					break;
					case 2 :
				
					break;						
				}
			break;

		}
	}
}
