using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour {

	CharacterController cc;
	private Transform camNoY;
	public float speed = 5;
	public float ghostJumpTime = 0;
	private float curYVel = -9.81f;
	public string state = "normal";

	void Start () {
		cc = transform.GetComponent<CharacterController> ();
		camNoY = transform.GetChild (1);
		curYVel = -9.81f;
	}

	void Update () {
		if(state != "cutscene"){
		camNoY.eulerAngles = new Vector3 (0,Camera.main.transform.eulerAngles.y,0);
		//if (ghostJumpTime > 0.5f) {
		cc.Move (camNoY.TransformDirection (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, curYVel * Time.deltaTime, Input.GetAxis ("Vertical") * speed * Time.deltaTime));
		curYVel = Mathf.MoveTowards (curYVel, -9.81f, Time.deltaTime * 20);
		//} else {
			//cc.Move (camNoY.TransformDirection (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, -Time.deltaTime / 10, Input.GetAxis ("Vertical") * speed * Time.deltaTime));
		//}
		RaycastHit hit;
		if (Physics.SphereCast (new Ray (transform.position, Vector3.down),transform.lossyScale.x,out hit,0.09f)) {
			ghostJumpTime = 0;
			if(hit.distance < 1.1f){
				if(curYVel < 0){
					curYVel = -1;
				}
			}
		} else {
			ghostJumpTime += Time.deltaTime;
		}

		if(Input.GetButtonDown("Jump")){
			if(ghostJumpTime < 0.1f){
				//cc.Move (new Vector3(0,7.5f * Time.deltaTime,0));
				curYVel = 7.5f;
				ghostJumpTime = 1;
			}
			}
		}
	}
}
