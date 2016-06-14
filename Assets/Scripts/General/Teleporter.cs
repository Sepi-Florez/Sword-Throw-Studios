using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Vector3 placementFix;
	public Transform destination;

	void OnTriggerEnter (Collider onTele) {
		onTele.transform.parent.GetComponent<Movement>().teleporter = transform;
	}
	void OnTriggerExit (Collider offTele) {
		offTele.transform.parent.GetComponent<Movement>().teleporter = null;
		offTele.transform.parent.transform.GetComponent<Movement>().fallRespawn = transform.position;
	}
	public void Teleport (Transform teleported) {
		teleported.position = destination.position;
		teleported.position += placementFix;
	}
}
