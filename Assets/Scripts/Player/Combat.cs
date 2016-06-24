using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
	GameObject gameManager;
	Transform player;
	public Animator anim;
	public float attRange;
	
	public bool attWait;
	public bool attGo;
	public float attWaitTime;

	public bool attack;
	public float timer;
	public int weaponDamage;
	RaycastHit attacked;
	Vector3 aR;
	Vector3 knockback;
	public float wKnockbackPower;
	public float wKnockbackHeight;
	
	public Image hpBubble;
	public float hp;
	public float maxHp = 50F;
	
	void Start () {
		hp = maxHp;
		gameManager = GameObject.Find("GameManager");
		player = gameManager.GetComponent<GameManager>().player;
	}
	
	void Update () {
		if(attack == false){
			AttackInput();
		}
		aR = player.TransformDirection(Vector3.forward);
		if(attWait == true){
			AttackWait();
		}
	}
	void AttackInput () {
		if(attWait == false){
			if(Input.GetButtonDown("Fire1")){
				anim.SetTrigger("struck");
				attWait = true;
			}
		}
	}
	void Attack () {
		if(attGo == true){
			if(Physics.Raycast(player.position,aR,out attacked,attRange)){
				print(attacked.transform.name);
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
			attGo = false;
		}
	}
	public void Struck (float damage) {
		hp -= damage;
		float calcHealth = hp / maxHp;
		hpBubble.fillAmount = calcHealth;
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
	public void AttackWait(){
		timer += Time.deltaTime;
		if(timer >= attWaitTime){
			attWait = false;
			attGo = true;
			timer = 0;
			Attack();

		}
	}
}
