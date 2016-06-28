using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Transform playerObj;
	public Transform player;
	public Animator anim;
	
	public GameObject vObj;
	public GameObject hObj;
	public float sensitivity;
	public bool lockS;
	
	public float speed;
	
	public float jumpPower;
	public float jumpRayD;
	public Rigidbody playerP;
	
	public bool camMove = true;
	public bool move = true;
	public bool jump = true;

	public Vector3 fallRespawn;
	public Transform teleporter;

	public float updownRange = 90.0f;
 	float verticalRotation = 0;
 	float horizontalRotation = 0;
	public float mouseSensitivity = 4.0f;

	
	void Start () {
		lockS = true;
		Mouse();
	}
	void Update () {
		if(camMove == true){
			CameraMoving();
		}
		if(move == true){
			Moving();
		}
		if(jump == true){
			Jumping();
		}
	}
	void CameraMoving () {
		horizontalRotation -= -Input.GetAxis ("Mouse X") * mouseSensitivity;
		hObj.transform.localRotation = Quaternion.Euler (0, horizontalRotation, 0 );

        verticalRotation -= -Input.GetAxis ("Mouse Y") * mouseSensitivity;
     	verticalRotation = Mathf.Clamp (verticalRotation, -updownRange, updownRange);
        vObj.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

	}
	void Moving () {
		Vector3 mvr = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		playerObj.Translate(mvr * speed * Time.deltaTime);
		if(mvr == Vector3.zero){
			anim.SetBool("Running",false);
		}
		else{
			anim.SetBool("Running",true);
		}
	}
	void Jumping () {
		Vector3 jvr = transform.TransformDirection(-Vector3.up * 10);
		if(Input.GetButtonDown("Jump")){
			if(teleporter != null) {
				teleporter.transform.GetComponent<Teleporter>().Teleport(playerObj );			}
			else{
				if(Physics.Raycast(player.position,jvr,jumpRayD)){
					playerP.AddForce(transform.up*jumpPower);
					print("Jump Accomplished");
				}
			}		
		}
	}
	public void ToggleMovement () {
		camMove = !camMove;
		jump = !jump;
		move = !move;
		lockS = !lockS;
		Mouse();
	}
	public void Mouse () {
		if(lockS == true){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
