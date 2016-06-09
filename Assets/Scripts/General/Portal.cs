using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public string destination;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision entered){
		if(entered.transform.tag == "Player" ){
			Application.LoadLevel(destination);
		}
	}
}
