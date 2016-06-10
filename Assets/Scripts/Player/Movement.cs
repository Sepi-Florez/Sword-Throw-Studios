using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Transform playerObj;
	public Transform player;
	public Animator anim;
	
	public GameObject vObj;
	public GameObject hObj;
	public float sensitivity;
	bool lockS;
	
	public float speed;
	
	public float jumpPower;
	public float jumpRayD;
	public Rigidbody playerP;
	
	public bool camMove = true;
	public bool move = true;
	public bool jump = true;

	
	void Start () {
		lockS = true;
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
		Vector3 vRot = new Vector3(Input.GetAxis("Mouse Y"),0,0);
		Vector3 hRot = new Vector3(0,Input.GetAxis("Mouse X"),0);
		vObj.transform.Rotate(vRot * sensitivity * Time.deltaTime ) ;
		hObj.transform.Rotate(hRot * sensitivity * Time.deltaTime ) ;
		if(lockS == true){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
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
			print("Jump try");
			if(Physics.Raycast(player.position,jvr,jumpRayD)){
				playerP.AddForce(transform.up*jumpPower);
				print("Jump Accomplished");
			}
		}
	}
}
