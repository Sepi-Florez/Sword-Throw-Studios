using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform player;
	public GameObject canvas;

	public Vector3 offset;
	public float respawnHeight;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
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
	public void transport (Vector3 destination) {
		DontDestroyOnLoad(player.gameObject);
		DontDestroyOnLoad(canvas);
		player.position = destination;

	}
}
