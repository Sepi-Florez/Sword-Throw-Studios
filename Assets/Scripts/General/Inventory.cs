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
			follow = true;
			item = imag;

		}
		else{
			
			follow = false;
			
		}
	}
	public void Move2 (int but){
		if(follow == false){
			
		}
		else{
			item.position = invSlots[but].transform.position;
		}
		
	}
}
 