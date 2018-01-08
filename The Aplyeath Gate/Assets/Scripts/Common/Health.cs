using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public float health = 100;
	public float maxHealth = 100;
	public RectTransform healthBar;
	public Transform healthBarTR;
	public Transform healthBarTRPivot;
	private Vector3 healthBarScaleStart;
	public string deathAction = "reload";
	private float timer = 0;
	public bool enemy = false;
	public bool player = false;
	public int[] item;
	public Text[] itemUI;
	public AudioClip heal;

	void Start () {
		if(healthBar != null){
		healthBarScaleStart = healthBar.localScale;
		}
		if(healthBarTR != null){
			healthBarScaleStart = healthBarTR.localScale;
		}
	}
		
	void Update () {
		if(healthBar != null){
		healthBar.localScale = new Vector3 (healthBarScaleStart.x / (maxHealth / health),healthBarScaleStart.y,healthBarScaleStart.z);
		}
		if(healthBarTR != null){
			healthBarTR.localScale = new Vector3 (healthBarScaleStart.x / (maxHealth / health),healthBarScaleStart.y,healthBarScaleStart.z);
			//healthBarTR.LookAt (Camera.main.transform.position);
			healthBarTRPivot.LookAt (Camera.main.transform.position);
		}

		if(health <= 0){
			if(deathAction == "reload"){
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			} else if(deathAction == "destroy"){
				Destroy (gameObject);
			}
		}
		if (player == true) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				if(item[1] == 1){
					health = maxHealth;
					item [0] = 0;
					itemUI [0].text = "None";
					GameObject.FindObjectOfType <CommonEffects> ().PlaySound (heal,1);
				}
			}

			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				if(item[2] == 1){
					health = maxHealth;
					item [1] = 0;
					itemUI [1].text = "None";
					GameObject.FindObjectOfType <CommonEffects> ().PlaySound (heal,1);
				}
			}

			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				if(item[2] == 1){
					health = maxHealth;
					item [2] = 0;
					itemUI [2].text = "None";
					GameObject.FindObjectOfType <CommonEffects> ().PlaySound (heal,1);
				}
			}
			for(int i = 0; i < item.Length; i++){
				if(item[i] == 0){
					itemUI[i].text = "None";
				} else if(item[i] == 1){
					itemUI[i].text = "Potion";
				}
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "HitBox"){
			health -= 10;
		} 
		if(health <= 0){
			if(deathAction == "reload"){
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			} else if(deathAction == "destroy"){
				Destroy (gameObject);
			}
		}
	}

	public void DoDamage(float dmg,float multiplier,Vector2 enemyLook){
		health -= dmg * multiplier;
		if(enemyLook != Vector2.zero){
			transform.LookAt (new Vector3(enemyLook.x,transform.position.y,enemyLook.y));
			transform.eulerAngles -= new Vector3 (0,90,0);
			transform.GetComponent<Enemy> ().sightRangeMuliplier = 3;
			transform.GetComponent<Enemy> ().sightMultiTimer = 3;
		}
	}
}
