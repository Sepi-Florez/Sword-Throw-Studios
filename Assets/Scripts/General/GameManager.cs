using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform player;
	public Vector3 offset;
	public float respawnHeight;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		FallCheck();
	}
	void FallCheck () {
		if(player.position.y <= respawnHeight ){
			player.position = player.transform.GetComponent<Movement>().fallRespawn + offset;
		}
	}
}
