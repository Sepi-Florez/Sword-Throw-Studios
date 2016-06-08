using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Urn : MonoBehaviour {
	public List<Transform> piece = new List<Transform>();
	public List<Rigidbody> rigidPiece = new List<Rigidbody>();
	public Transform expPos;
	public float radius = 5.0F;
    public float power = 10.0F;

	// Use this for initialization
	void Start () {
		GetObjects();
		Break();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Break () {
		Vector3 explosition = expPos.transform.position;
		for(int a = 0; a < piece.Count; a++){
			rigidPiece[a].useGravity = true;
			rigidPiece[a].isKinematic = false;
			rigidPiece[a].AddExplosionForce(power, explosition, radius, 3.0F);
			Destroy(transform.GetComponent<Collider>());
			print("boom");
		}

	}
	public void GetObjects(){
		int a = 0;
		foreach(Transform child in transform){
			piece.Add(child);
			rigidPiece.Add(piece[a].GetComponent<Rigidbody>());
			rigidPiece[a].useGravity = false; 	
			rigidPiece[a].isKinematic = true;
			a++;
		}
		expPos = piece[0];
	}
}
