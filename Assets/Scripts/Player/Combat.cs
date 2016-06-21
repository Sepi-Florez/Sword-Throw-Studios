using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
	public Transform player;
	public Animator anim;
	public float attRange;
	
	public bool attack;
	public int weaponDamage;
	RaycastHit attacked;
	Vector3 aR;
	Vector3 knockback;
	public float wKnockbackPower;
	public float wKnockbackHeight;
	
	public Image bubble;
	public float hp;
	public float maxHp = 50F;
	
	void Start () {
		hp = maxHp;
	}
	
	void Update () {
		if(attack == false){
			Attack();
		}
		aR = player.TransformDirection(Vector3.forward);
	}
	void Attack () {
		if(Input.GetButtonDown("Fire1")){
			Struck(10);
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
	public void Struck (float damage) {
		hp -= damage;
		float calcHealth = hp / maxHp;
		bubble.fillAmount = calcHealth;
		print(damage + " done to player");
		if(hp <= 0){
			Death();
		}
	}
	void Death(){
		print("Death");
	}
	public void Toggle(){
		attack = !attack;
	}
}
