﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding =1f;
	public GameObject Projectile;
	public float ProjectileSpeed;
	public float firingRate = 0.2f;
	public float playerHealth = 500f;
	public int healthValue = -100;
	
	public AudioClip fireSound;
	public AudioClip Death;
	public AudioClip hitSound;
	
	private float xMin = -5;
	private float xMax = 5;
	
	private Health healthBar;
	
	void Start() {
		healthBar = GameObject.Find("HealthInt").GetComponent<Health>();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	void Fire () {
			Vector3 offset = new Vector3(0, 1, 0);
			GameObject Beam = Instantiate(Projectile, transform.position + offset, Quaternion.identity) as GameObject;
			Beam.rigidbody2D.velocity = new Vector3(0,ProjectileSpeed, 0);
			AudioSource.PlayClipAtPoint(fireSound, transform.position);
		
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
			}
				if(Input.GetKeyUp(KeyCode.Space)){
					CancelInvoke("Fire");
			}
		
					
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed* Time.deltaTime;
			}else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed* Time.deltaTime;	
	}
		//Restrict the player to the game space
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
 }
 
 	void Die(){
 		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
 		Destroy(gameObject);
 	}
 
	void OnTriggerEnter2D(Collider2D collider) {
		
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			healthBar.HealthBar(healthValue);
			Debug.Log ("Player collided with the missle");
			playerHealth -= missle.GetDamage();
			missle.Hit();
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
			if (playerHealth <= 0) {
				Die ();
			}
			
		}
	}
}
