using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public string destination;
	public Vector3 destinationCord;
	public Vector3 destinationRespawnPoint;

	public GameObject gameManager;

	void Start () {
	gameManager = GameObject.Find("GameManager");
	}

	void Update () {
	
	}
	void OnTriggerEnter(Collider entered){
		if(entered.transform.tag == "Player" ){ 
			entered.transform.parent.GetComponent<Movement>().fallRespawn = destinationRespawnPoint;
			gameManager.transform.GetComponent<GameManager>().transport(destinationCord);
			Application.LoadLevel(destination);
		}
	}
}
