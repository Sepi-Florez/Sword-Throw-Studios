using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	public Button equipSlot;
	//public List<Transform> items = new List<Transform>();
	public Transform[] items;
	public Transform equipedItem;
	public Transform heldItem;
	public Transform heldItemObj;
	public int slotNumber;
	
	public GameObject invObj;
	
	public bool follow;
	void Start () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			invSlots.Add(invObj.transform.GetChild(0).GetChild(a).GetComponent<Button>());
			if(invSlots[a].transform.childCount != 0){
				items[a] = invSlots[a].transform.GetChild(0).transform;
				invSlots[a].onClick.AddListener(() => Move1(invSlots[a].transform.GetChild(0).transform));
				print(items[a]);
			}
		}
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
		else{
			
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
			print("putdown Items");
			follow = false;
		}
		
	}	
	public void Equip1 (Transform weapon) {
		print("equip2 activated");
		if(follow == false){
			heldItem = weapon;
			heldItem.SetParent(equipSlot.transform);
			follow = true;
			
		}
		else{
			
		}
	}
	public void Equip2 (){
		if(heldItem.transform.tag == "Equipable"){
			if(follow == false){
				print("Pickedup Equipable");
				equipSlot.onClick.RemoveAllListeners();
				equipedItem = null;
			}
			else{
				print("putdown Equipable");
				equipSlot.onClick.AddListener(() => Equip1(heldItem));
				heldItem.position = equipSlot.transform.position;
				heldItem.SetParent(equipSlot.transform);
				equipedItem = heldItem;
				follow = false;
			}
		}
	}

}
 