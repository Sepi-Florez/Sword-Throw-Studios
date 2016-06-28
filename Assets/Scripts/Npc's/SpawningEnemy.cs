using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawningEnemy : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject>();

	public Vector3[] spawnLocations;

    public GameObject enemy;

    public bool spawn;

	void Start () {
	
	}
	

	void Update () {
	
	}
	void OnTriggerEnter(Collider pass){
		EnemySpawn();
	}
	void EnemySpawn(){
		if(spawn == false){
			spawn = true;
			for(int a = 0; a < spawnLocations.Length; a++){
				enemies.Add((GameObject)Instantiate(enemy,spawnLocations[a],Quaternion.identity));
			}
		}
	}
}
