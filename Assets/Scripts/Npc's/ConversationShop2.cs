using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationShop2 : MonoBehaviour {
	GameObject gameManager;
	Canvas canvas;
	Transform player;
	public int oRng;

	public GameObject convIns;
	public GameObject convObj;
	public Vector3 convPos;

	public bool exiting;
	public float timer;
	public float exitTime = 2;

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

	public string[] answer22;
	public string[] answer33;

	public string[] response1;
	public string[] response2;
	public string[] response3;

	public string[] response22;
	public string[] response33;

	public bool[] path1;



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
		for(int c = 0; c < oRng + oRng; c++){
			if(c < oRng){
				npcResponseN[c] = response1[c];
			}
			optionsN[c] = answer1[c];	
		}
		path1[0] = false;
		path1[1] = false;
	}
	public void ExitConversation(){
		npcResponse.text = npcResponseExit;
		fase = 0;
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
		if(fase > 1){
			ExitConversation();
		}
		else{
			switch(option){
				case 0 :
					npcResponse.text = npcResponseN[option];
					for(int a0 = 0; a0 < oRng; a0++){
						options[a0].text = optionsN[a0];

					}
					//Changes next options/respones.
					switch(fase){
						case 1 :
							path1[option] = true;
							for(int a01 = 0; a01  < oRng + oRng; a01++){
								//optionsN[a01] = answer2[a01];
								//if(a01 < oRng){
									player.GetComponent<Inventory>().AddItem(1);
									player.GetComponent<Currency>().soulCount = 0;
									npcResponseN[a01] = response2[a01];
								
							}
						break;
						case 2 :
							if(path1[0] == true){
								for(int a02 = 0; a02  < oRng + oRng; a02++){
									optionsN[a02] = answer3[a02];
									if(a02 < oRng){
										ExitConversation();
									}
								}
							}
							else{
								for(int b12 = 0; b12  < oRng + oRng; b12++){
									optionsN[b12] = answer33[b12];
									if(b12 < oRng){
										ExitConversation();
									}
								}
							}
						break;						
					}
				break;
				case 1 :
					//Changes the current options to the next option depending on the choice made.
					for(int b1 = 0; b1 < oRng; b1++){
						options[b1].text = optionsN[b1 + 3];
					}
					//Changes next options/respones.
					switch(fase){
						case 1 :
							path1[option] = true;
							for(int b01 = 0; b01  < oRng + oRng; b01++){
								player.GetComponent<Inventory>().AddItem(1);
								player.GetComponent<Currency>().soulCount = 0;
								optionsN[b01] = answer22[b01];
								if(b01 < oRng){	
									npcResponseN[b01] = response2[b01];
								}
							}
						break;
						case 2 :
							if(path1[0] == true){
								for(int a12 = 0; a12  < oRng + oRng; a12++){
									//optionsN[a12] = answer3[a12 + 6];
									//if(a12 < oRng){
										ExitConversation();
								}

							}
							else{
								for(int b02 = 0; b02  < oRng + oRng; b02++){
									optionsN[b02] = answer33[b02 + 6];
									if(b02 < oRng){
										ExitConversation();
									}
								}
							}
						break;						
					}
				break;

			}
		}
	}
}
