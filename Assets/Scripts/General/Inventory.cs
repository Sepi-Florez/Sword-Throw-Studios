using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	
	public GameObject invObj;
	public Transform item;
	
	public bool follow;
	void Start () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			invSlots.Add(invObj.transform.GetChild(0).GetChild(a).GetComponent<Button>());
		}
		invSlots[0].onClick.AddListener(() => Move1(item));
	}
	void Update () {
		if(follow == true){
			item.position = Input.mousePosition;
		}
	}
	public void toggle () {
		invObj.SetActive(!invObj.activeInHierarchy);
	}
	public void Move1 (Transform imag){
		if(follow == false){
			item = imag;
			follow = true;
			print("Grabed Item");		
			invSlots[0].onClick.RemoveListener(() => Move1(item));
		}
		else{
			follow = false;
			print("putdown Item");
		}
	}
	public void Move2 (int but){
		if(follow == false){
			//invSlots[but].onClick.RemoveListener(() => Move1(item));
			print("deleted listener");
		}
		else{
			//invSlots[but].onClick.AddListener(() => Move1(item));
			item.position = invSlots[but].transform.position;
			print("new listener");
		}
		
	}
}
 