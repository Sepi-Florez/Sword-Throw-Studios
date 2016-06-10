using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float hp;
	public float maxHp = 50F;
	public float speed = 10F;
	public bool chase;
	public RaycastHit ground;
	
	public Transform player;
	
	public float timer;
	
	RaycastHit attacked;
	public float attackD;
	public float attackR;
	public float damage;
	public float knockbackHeight;
	public float knockbackPower;
	
	// Use this for initialization
	void Start () {
	hp = maxHp;
	}
	// Update is called once per frame
	void Update () {
		if(chase == true){
			Chase();
		}
		Attack();
	}
	void Attack () {
		if(Physics.Raycast(transform.position,transform.forward,out attacked,attackD)){
			chase = false;
			timer += Time.deltaTime;
			if(timer >= attackR){
				Vector3 knockback = transform.forward;
				knockback.y += knockbackHeight;
				attacked.transform.GetComponent<Combat>().Struck(damage);
				attacked.transform.GetComponent<Rigidbody>().AddForce(knockback * knockbackPower);
				timer = 0;
			}
		}
		else{
			chase = true;
		}
	}
	public void Struck (int damage) {
		hp -= damage;
		print(damage);
		if(hp <= 0){
			Death();
		}
	}
	public void Death (){
		Destroy(gameObject);
	}
	public void Chase () {
		transform.LookAt(player);
		Vector3 cha = new Vector3(0,0,1);
		transform.Translate(cha * speed * Time.deltaTime);
	}
}
