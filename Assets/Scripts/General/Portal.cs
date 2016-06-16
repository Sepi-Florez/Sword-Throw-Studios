using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public string destination;
	public Vector3 destinationCord;

	public GameObject gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider entered){
		if(entered.transform.tag == "Player" ){ 
			gameManager.transform.GetComponent<GameManager>().transport(destinationCord);
			Application.LoadLevel(destination);

		}
	}
}
