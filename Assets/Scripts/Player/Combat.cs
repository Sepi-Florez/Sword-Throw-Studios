using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
	public Transform player;
	public Animator anim;
	public float attRange;
	
	public int weaponDamage;
	RaycastHit attacked;
	RaycastHit inFront; 
	Vector3 aR;
	Vector3 knockback;
	public float wKnockbackPower;
	public float wKnockbackHeight;
	
	public float hp;
	public float maxHp = 50F;
	
	void Start () {
		hp = maxHp;
	}
	
	void Update () {
		Attack();
		aR = player.TransformDirection(Vector3.forward);
	}
	void Attack () {
		if(Input.GetButtonDown("Fire1")){
			anim.SetTrigger("struck");
			if(Physics.Raycast(player.position,aR,out attacked,attRange)){
				switch(attacked.transform.tag){
					case "Breakable":
						attacked.transform.GetComponent<Urn>().Break();
						print(attacked.transform.name);
					break;
					case "Enemy":
						knockback += aR;
						knockback.y += wKnockbackHeight;
						attacked.transform.GetComponent<Enemy>().Struck(weaponDamage);
						attacked.transform.GetComponent<Rigidbody>().AddForce(knockback * wKnockbackPower);
						knockback = Vector3.zero;
						
					break;
				}
			}
		}
		if(Input.GetButton("Fire2")){
		}
	}
	void Interaction () {
		if(Physics.Raycast(player.position,aR,out inFront,attRange)){
		}
	}
	public void Struck (float damage) {
		hp -= damage;
		print(damage + "2 player");
		if(hp <= 0){
			Death();
		}
	}
	void Death(){
		print("Death");
	}
}
