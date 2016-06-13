using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
	public float amplitude;
	public float speed;

	Vector3 hoverable;
	// Use this for initialization
	void Start () {
		hoverable = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Hovering();
	}
	void Hovering () {
		transform.position = hoverable;
		hoverable.y += amplitude * Mathf.Sin(speed * Time.time);
	}
}
