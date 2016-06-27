using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public string destination;
	public Vector3 destinationCord;
	public Vector3 destinationRespawnPoint;
	public Vector3 destinationTpLocation;

	public GameObject gameManager;

	void Start () {
	gameManager = GameObject.Find("GameManager");
	}

	void Update () {
	
	}
	void OnTriggerEnter(Collider entered){
		if(entered.transform.tag == "Player" ){ 
			entered.transform.parent.GetComponent<Movement>().fallRespawn = destinationRespawnPoint;
			entered.transform.parent.GetComponent<Interactions>().tpLocation = destinationTpLocation;
			gameManager.transform.GetComponent<GameManager>().transport(destinationCord);
			Application.LoadLevel(destination);
		}
	}
}
