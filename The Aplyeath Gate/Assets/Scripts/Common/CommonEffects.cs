using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEffects : MonoBehaviour {

	public float timeScale = 1;
	private bool paused = false;
	private float timeStopTimer = 0;
	private bool timeStopActive = false;
	private float timeStopGoal = 0;
	public GameObject blankAudioObject;

	void Start () {
		
	}

	void Update () {
		if(paused == false){
			Time.timeScale = timeScale;
		} else {
			Time.timeScale = 0;
		}

		if(timeStopActive == true){
			if(timeStopTimer >= timeStopGoal){
				timeScale = 1;
			}
			timeStopTimer += Time.unscaledDeltaTime;
		}
	}

	public void TimeStop(float length,float newTime){
		timeScale = newTime;
		timeStopActive = true;
		timeStopTimer = 0;
		timeStopGoal = length;
	}

	public void PlaySound(AudioClip clip,float volume){
			GameObject p;
			p = Instantiate (blankAudioObject);
			p.GetComponent<AudioSource> ().clip = clip;
			p.GetComponent<AudioSource> ().volume = volume;
			p.GetComponent<AudioSource> ().Play ();
			Destroy (p, clip.length);
	}
}
