using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	private Rigidbody2D _myRigidBody;
	private Animator _anim;
	private bool _facingRight = true;
	private bool _canJump=true;
	public float speed;
	public Transform startPos;
	public Transform endPos;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
		_myRigidBody = this.rigidbody2D;
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//get the current velocity = new velocity
		float move = Input.GetAxisRaw("Horizontal");
		_anim.SetFloat("Speed",Mathf.Abs(move)); 
		_myRigidBody.velocity = new Vector2(move*speed,_myRigidBody.velocity.y);


		// if _facingRight = true and move is less than 0
		// _facingRight = false
		//transform.rotation.y = 180

		//if _facingLeft  = false and  move greater then 0
		// _facingRight  = true
		//transform.rotation.y = 0

		if(_facingRight && move<0){
			_facingRight=false;
			transform.rotation = Quaternion.Euler(transform.rotation.x,180,transform.rotation.z);
		}
		else if(_facingRight==false && move>0){
			_facingRight=true;
			transform.rotation  = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);;
		}



		RaycastHit2D hitInfo = Physics2D.Linecast(startPos.position,endPos.position,groundLayer.value);

		Debug.DrawLine(startPos.position,endPos.position);

		if(hitInfo.collider != null){

			_canJump = true;

			_anim.SetBool("Jump",false);

		}

		if(Input.GetKeyDown(KeyCode.Space) && _canJump==true){
			_anim.SetBool("Jump",true);
			_canJump = false;
			_myRigidBody.velocity = new Vector2(_myRigidBody.velocity.x,10);
		}

	}



	void OnCollisionEnter2D(Collision2D col) {

		if(col.gameObject.tag=="Coin"){
			col.gameObject.collider2D.enabled = false;
			col.gameObject.renderer.enabled = false;
			audio.Play();
		}


	}


}
