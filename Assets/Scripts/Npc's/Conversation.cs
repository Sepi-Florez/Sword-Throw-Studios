using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {
	public Canvas canvas;
	public Transform player;
	public int oRng;

	public GameObject convIns;
	public GameObject convObj;
	public Vector3 convPos;

	public Text npcResponse;
	public Text npcResponseL;
	public Text npcName;
	public Text[] options;

	public Text[] npcResponseN;
	public Text[] optionsN;

	public int fase;

	public string[] answer1;
	public string[] answer2;
	public string[] answer3;

	public string[] response1;
	public string[] response2;
	public string[] response3;



	void Start () {
		oRng = options.Length;
	}

	void Update () {
	
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
	}
	public void ExitConversation(){
		npcResponse = npcResponseL;
		Destroy(convObj);
		player.transform.GetComponent<Movement>().ToggleMovement();
		player.transform.GetComponent<Interactions>().Toggle();
		player.transform.GetComponent<Combat>().Toggle();
	}
	public void Response (int option){
		npcResponse = npcResponseN[option];
		fase += 1;
		switch(option){
			case 0 :
				for(int a0 = 0; a0 < oRng; a0++){
					options[a0] = optionsN[a0];
				}
				switch(fase){
					case 1 :
						for(int a1 = 0; a1  < oRng; a1++){

						}
					break;
					case 2 :
				
					break;						
				}
			break;
			case 1 :
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
