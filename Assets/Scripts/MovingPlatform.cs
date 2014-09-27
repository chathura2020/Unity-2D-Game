using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform origin;
	public Transform destination;

	private Transform _myTransform;
	private bool _switching;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
		_myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(_myTransform.position==origin.position){
			_switching = true;
		}

		if(_switching==true){
			_myTransform.position = Vector3.MoveTowards(_myTransform.position,destination.position,speed*Time.deltaTime);
		}


		if(_myTransform.position==destination.position){
			_switching = false;
		}
		
		if(_switching==false){
			_myTransform.position = Vector3.MoveTowards(_myTransform.position,origin.position,speed*Time.deltaTime);
		}
	}


	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player")
		{
			col.transform.parent = transform;
			col.transform.GetComponent<Animator>().SetBool("Jump",false);
		}
		
	}




	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag== "Player")
		{
			col.transform.GetComponent<Animator>().SetBool("Jump",true);
			col.transform.parent = null;

		}
	}


	
	

}
