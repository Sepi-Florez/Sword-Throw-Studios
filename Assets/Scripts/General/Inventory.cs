using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	public List<Transform> items[but]s = new List<Transform>();
	
	public GameObject invObj;
	
	public bool follow;
	void Start () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			invSlots.Add(invObj.transform.GetChild(0).GetChild(a).GetComponent<Button>());
			invSlots[0].GetChild(0).transform = items[but][0]
		}
		invSlots[0].onClick.AddListener(() => Move1(items[but]));
	}
	void Update () {
		if(follow == true){
			items[but].position = Input.mousePosition;
		}
	}
	public void toggle () {
		invObj.SetActive(!invObj.activeInHierarchy);
	}
	public void Move1 (Transform imag){
		print("move1 activated");
		if(follow == false){
			items[but] = imag;
			follow = true;
			print("Grabed Items");		
			
		}
	}
	public void Move2 (int but){
		print("move2 activated");
		if(follow == false){
			invSlots[but].onClick.RemoveAllListeners();
			print("deleted listener");
		}
		else{
			invSlots[but].onClick.AddListener(() => Move1(items[but]s[but]));
			items[but]s[but].position = invSlots[but].transform.position;
			print("new listener");
			follow = false;
			print("putdown Items[but]");
		}
		
	}
}
 