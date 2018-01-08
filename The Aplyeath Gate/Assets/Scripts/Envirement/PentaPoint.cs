using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentaPoint : MonoBehaviour {

	public Material matChange;

	void OnTriggerStay(Collider col){
		if(col.tag == "Player"){
			transform.tag = "PentagramEnabled";
			//transform.GetComponent<Renderer> ().material.color = Color.black;
			transform.GetComponent<Renderer> ().material = matChange;
		}
	}
}
