using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

	public bool open = false;
	public AudioClip sfxChestOpen;
	private float timer = 0;
	public int[] treasure;
	private GameObject uiFindObject;

	void Start(){
		uiFindObject = GameObject.Find ("ItemGot");
		uiFindObject.SetActive (false);
	}

	void OnTriggerStay(Collider col){
		if(Input.GetButtonDown("Fire1")){
			if(col.tag == "Player"){
				if (open == false) {
					for (int i = 0; i < col.GetComponent<Health> ().item.Length; i++) {
						if (treasure [i] != 0) {
							col.GetComponent<Health> ().item [i] = treasure [i];
							treasure [i] = 0;
						}
					}
					open = true;
					GameObject.FindObjectOfType<CommonEffects> ().PlaySound (sfxChestOpen,0.4f);
					GameObject.FindObjectOfType<PlayerMovement> ().state = "cutscene";
					timer += Time.deltaTime;
				}
			}
		}
		if(timer != 0){
			if (timer < 0.75f) {
				if(open == true){
					transform.GetChild (0).localRotation = Quaternion.Lerp(transform.GetChild (0).localRotation ,Quaternion.Euler (27,0,0),Time.deltaTime * 10);
				}
				uiFindObject.SetActive (true);
				timer += Time.deltaTime;
			} else {
				uiFindObject.SetActive (false);
				GameObject.FindObjectOfType<PlayerMovement> ().state = "normal";
			}
		}
	}
}
