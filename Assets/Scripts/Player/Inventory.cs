using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	Button equipSlot;
	public Transform[] items;
	Transform equipedItem;
	Transform heldItem;
	public Transform heldItemObj;
	int slotNumber;
	
	public GameObject invObj;
	
	public bool follow;

	public bool[] keys;
	public int keysCount;
	public List<Transform> keysSprite = new List<Transform>();

	public GameObject[] itemObjs;
	public Transform[] equipables;
	Transform currEquip;
	public Text buff;
	public float speedBuff;
	public float jumpBuff;


	void Start () {
		invObj.SetActive(false);
		for(int a = 0; a < invObj.transform.FindChild("Button").childCount; a++){
			invSlots.Add(invObj.transform.FindChild("Button").GetChild(a).GetComponent<Button>());
			print(invSlots[a]);
			if(invSlots[a].transform.childCount != 0){
				items[a] = invSlots[a].transform.GetChild(0).transform;
				Transform it = items[a];
				invSlots[a].onClick.RemoveAllListeners();
				invSlots[a].onClick.AddListener(() => Move1(it));
				print(items[a]);
			}
		}
		for(int b = 0; b < keys.Length; b++){
			keysSprite.Add(invObj.transform.FindChild("Keys").GetChild(b));
			keysSprite[b].gameObject.SetActive(false);
		}
		buff = invObj.transform.FindChild("Buffs").GetComponent<Text>();
		buff.transform.gameObject.SetActive(false);
		equipables[0].gameObject.SetActive(false);
		equipables[1].gameObject.SetActive(false);
	}
	void Update () {
		if(follow == true){
			heldItem.position = Input.mousePosition;
		}
	}
	public void Check () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			if(invSlots[a].transform.childCount != 0){
				items[a] = invSlots[a].transform.GetChild(0).transform;
				items[a].position = invSlots[a].transform.position;
				Transform itt = items[a];
				invSlots[a].onClick.RemoveAllListeners();
				invSlots[a].onClick.AddListener(() => Move1(itt));
			}
		}
	}
	public void Toggle () {
		invObj.SetActive(!invObj.activeInHierarchy);
		transform.GetComponent<Movement>().ToggleMovement();
		transform.GetComponent<Interactions>().Toggle();
		transform.GetComponent<Combat>().Toggle();
		Keys();
		Check();
	}
	public void Move1 (Transform item){
		heldItem = item;
		print("Move1" + item);
		if(follow == false){
			heldItem.SetParent(heldItemObj);
			System.Array.Clear(items,slotNumber,1);
			follow = true;
		}
	}
	public void Move2 (int but){
		slotNumber = but;
		print("move2 " + but);
		if(follow == false){
			invSlots[but].onClick.RemoveAllListeners();
		}
		else{
			Transform heldItem2 = heldItem;
			invSlots[but].onClick.AddListener(() => Move1(heldItem2));
			print(invSlots[but].onClick);
			heldItem.position = invSlots[but].transform.position;
			heldItem.SetParent(invSlots[but].transform);
			items[but] = heldItem; 
			follow = false;
		}
	}	
	public void Equip1 (Transform weapon) {
		if(follow == false){
			heldItem = weapon;
			heldItem.SetParent(equipSlot.transform);
			follow = true;
		}
	}
	public void Equip2 (){
		if(heldItem.transform.tag == "Equipable"){
			if(follow == false){
				equipSlot.onClick.RemoveAllListeners();
				equipSwitch(heldItem);
				equipedItem = null;
			}
			else{
				equipSlot.onClick.AddListener(() => Equip1(heldItem));
				heldItem.position = equipSlot.transform.position;
				heldItem.SetParent(equipSlot.transform);
				equipedItem = heldItem;
				equipSwitch(heldItem);
				follow = false;
			}
		}
	}
	public void Keys () {
		for(int a = 0; a < keysCount; a++){
			keys[a] = true;
			keysSprite[a].gameObject.SetActive(true);
		}

	}
	public void addItem (int itemID) {
		GameObject insItem = (GameObject)Instantiate(itemObjs[itemID],invSlots[0].transform.position,Quaternion.identity);
		int b = 0;
		for(int a = 0; b < 1; a++){
			if(items[a] == null){
				insItem.transform.SetParent(invSlots[a].transform);
				insItem.transform.localScale = new Vector3(1, 1, 1);
				b += 1;
			}
		}
	}
	public void equipSwitch (Transform weapon) {
		if(follow == true){
			switch(weapon.name){
				case "Item00(Clone)":
					print("item00");
					currEquip.gameObject.SetActive(false);
					currEquip = equipables[1];
					currEquip.gameObject.SetActive(true);
					transform.GetComponent<Movement>().speed += speedBuff;
					buff.text = "Movement Speed + " + speedBuff;
				break;
				case "Item01(Clone)": 
					currEquip.gameObject.SetActive(false);
					currEquip = equipables[0];
					currEquip.gameObject.SetActive(true);
					transform.GetComponent<Movement>().jumpPower += jumpBuff;
					buff.text = "Jump Speed + " + speedBuff;
				break;
			}
		}
		if(follow == false){
			currEquip.gameObject.SetActive(false);
			buff.text = null;
			switch(weapon.name){
				case "Item00(Clone)":
					transform.GetComponent<Movement>().speed -= speedBuff;
				break;
				case "Item01(Clone)":
					transform.GetComponent<Movement>().jumpPower -= jumpBuff;
				break;
			}
		}
	}
}
