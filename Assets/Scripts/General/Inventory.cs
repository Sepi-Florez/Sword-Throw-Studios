using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Button> invSlots = new List<Button>();
	
	public GameObject invObj;
	public Transform[] item;
	
	public bool follow;
	void Start () {
		for(int a = 0; a < invObj.transform.GetChild(0).childCount; a++){
			invSlots.Add(invObj.transform.GetChild(0).GetChild(a).GetComponent<Button>());
		}
		invSlots[0].onClick.AddListener(() => Move1(item[1]));
	}
	void Update () {
		if(follow == true){
			item[1].position = Input.mousePosition;
		}
	}
	public void toggle () {
		invObj.SetActive(!invObj.activeInHierarchy);
	}
	public void Move1 (Transform imag){
		if(follow == false){
			item[0] = imag;
			//invSlots[0].onClick.RemoveListener(() => Move1(item));
			follow = true;
			print("Grabed Item");		
			
		}
	}
	public void Move2 (int but){
		if(follow == false){
			invSlots[but].onClick.RemoveListener(() => Move1(item[1]));
			print("deleted listener");
		}
		else{
			invSlots[but].onClick.AddListener(() => Move1(item[1]));
			item[1].position = invSlots[but].transform.position;
			print("new listener");
			follow = false;
			print("putdown Item");
		}
		
	}
}
 