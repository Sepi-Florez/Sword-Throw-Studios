using UnityEngine;
using System.Collections;

public class Fluxs : MonoBehaviour {
	public float amplitude;
	public float speed;
	
	public Transform standardFocus;
	Transform newFocus;
	Vector3 flux;
	// Use this for initialization
	void Start () {
		flux = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Hover();
		Focus(newFocus);
		
	}
	void Hover(){
		transform.position = flux;
		flux.y += amplitude * Mathf.Sin(speed * Time.time);
	}
	void Focus (Transform focus){
		transform.LookAt(focus);
	}
	void OnTriggerEnter (Collider entered) {
		if(entered.transform.tag == "Player"){
			newFocus = entered.transform;
		}
	}
	void OnTriggerExit (Collider left) {
		if(left.transform.tag == "Player"){
			newFocus = standardFocus;
		}
	}
}
