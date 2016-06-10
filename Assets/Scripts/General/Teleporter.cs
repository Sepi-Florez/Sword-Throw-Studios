using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Vector3 placementFix;
	public Transform destination;
	public GameObject particleFX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerStay (Collider onTele) {
		onTele.transform.parent.GetComponent<Movement>().jump = false;
		Instantiate(particleFX,transform.position,Quaternion.identity);
		if(Input.GetButtonDown("Jump")){
			onTele.transform.parent.transform.position = destination.position;
			onTele.transform.parent.transform.position += placementFix;
		}
	}
	void OnTriggerExit (Collider offTele) {
		offTele.transform.parent.GetComponent<Movement>().jump = true;
	}
}
