using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
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
	
	public Transform pF;
	public float pFH;
	
	void Start () {
		lockS = true;
	}
	void Update () {
		CameraMoving();
		Moving();
		Jumping();
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
		player.Translate(mvr * speed * Time.deltaTime);
		Vector3 pFPos = new Vector3(player.position.x,pFH,player.position.z);
		pF.position = pFPos;
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
			print("HarryProbeert");
			if(Physics.Raycast(player.position,jvr,jumpRayD)){
				GetComponent<Rigidbody>().AddForce(transform.up*jumpPower);
				print(playerP);
			}
		}
	}
}
