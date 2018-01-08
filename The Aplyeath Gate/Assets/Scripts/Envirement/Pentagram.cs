using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour {

	public GameObject[] points;
	public Transform door;
	private float doorStartY;

	void Start () {
		for(int i = 0; i <= points.Length - 1; i++){
			points [i] = transform.GetChild (i + 1).gameObject;
			points [i].tag = "PentagramDisabled";
			doorStartY = door.position.y;
		}
	}

	void Update () {
		int p = 0;
		for(int i = 0; i <= points.Length - 1; i++){
			if(points[i].tag == "PentagramEnabled"){
				p += 1;
			}
			if(p >= points.Length){
				door.position = Vector3.MoveTowards(door.position ,new Vector3(door.position.x,doorStartY + 3,door.position.z),Time.deltaTime * 6);
			}
		}
	}
}
