using UnityEngine;
using System.Collections;

public class BottomLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		if(col.gameObject.tag=="Player"){
			col.gameObject.collider2D.enabled = false;
			col.gameObject.renderer.enabled = false;
			audio.Play();
		}
		
	}
}
