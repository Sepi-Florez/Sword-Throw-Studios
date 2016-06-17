using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	//public List<Transform> items = new List<Transform>();
	public Transform[] items;
	public Transform heldItem;
	public Transform heldItemObj;
	public int slotNumber;
	
	public GameObject invObj;
	
	public bool follow;
	void Start () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			invSlots.Add(invObj.transform.GetChild(0).GetChild(a).GetComponent<Button>());
			if(invSlots[a].transform.childCount != 0){
				//items.Add(invSlots[a].transform.GetChild(0).transform);
				items[a] = invSlots[a].transform.GetChild(0).transform;
			}
		}
		invSlots[0].onClick.AddListener(() => Move1(items[slotNumber]));
	}
	void Update () {
		if(follow == true){
			heldItem.position = Input.mousePosition;
		}
	}
	public void toggle () {
		invObj.SetActive(!invObj.activeInHierarchy);
	}
	public void Move1 (Transform imag){
		print("move1 activated");
		if(follow == false){
			heldItem = imag;
			heldItem.SetParent(heldItemObj);
			System.Array.Clear(items,slotNumber,1);
			follow = true;
			print("Grabed Items");

			
		}
	}
	public void Move2 (int but){
		print("move2 activated");
		slotNumber = but;
		if(follow == false){
			invSlots[but].onClick.RemoveAllListeners();
			print("deleted listener");
		}
		else{
			invSlots[but].onClick.AddListener(() => Move1(heldItem));
			heldItem.position = invSlots[but].transform.position;
			heldItem.SetParent(invSlots[but].transform);
			items[but] = heldItem; 
			print("new listener");
			follow = false;
			print("putdown Items");
		}
		
	}
}
 