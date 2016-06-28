using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	GameObject gameManager;
	public Transform player;

	public float hp;
	public float maxHp = 50F;
	public float speed = 10F;
	public bool chase;
	public RaycastHit ground;
	
	public Animator anim;
	
	public float timer;
	public bool death;
	
	RaycastHit attacked;
	public float attackRng;
	public float attackRate;
	public float damage;
	public float knockbackHeight;
	public float knockbackPower;
	
	public float LookAtOffset;

	void Start () {
	hp = maxHp;
	gameManager = GameObject.Find("GameManager");
	player = gameManager.GetComponent<GameManager>().player;

	}

	void Update () {
		if(death == false){
			if(chase == true){
				Chase();
			}
			Attack();
			anim.SetBool("Chase",chase);
		}
	}
	void Attack () {
		if(Physics.Raycast(transform.position,transform.forward,out attacked,attackRng)){
			if(attacked.transform.tag == "Player"){
				chase = false;
				timer += Time.deltaTime;
				if(timer >= attackRate){
					anim.SetTrigger("Attacking");
					Vector3 knockback = -player.forward;
					knockback.y += knockbackHeight;
					attacked.transform.GetComponent<Combat>().Struck(damage);
					attacked.transform.GetComponent<Rigidbody>().AddForce(knockback * knockbackPower);
					timer = 0;
					chase = true;
				}
			}
			else{
				chase = true;
			}
		}
		else{
			chase = true;
		}
	}
	public void Struck (int damage) {
		anim.SetTrigger("Struck");
		hp -= damage;
		print(damage);
		if(hp <= 0){
			Death();
		}
	}
	public void Death (){
		death = true;
		anim.SetTrigger("Death");
	}
	public void Chase () {
		Vector3 playerVect = new Vector3(player.position.x,LookAtOffset,player.position.z);
		transform.LookAt(playerVect);
		Vector3 cha = new Vector3(0,0,1);
		transform.Translate(cha * speed * Time.deltaTime);
	}
}
