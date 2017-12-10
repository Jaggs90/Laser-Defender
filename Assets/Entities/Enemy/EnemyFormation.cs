using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {
	public GameObject Projectile;
	
	public float health = 150;
	public float projectileSpeed = 10;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update(){
		float probablity = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probablity){
			Fire ();
	
	}
		}
	void Fire(){
		GameObject missle = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
		missle.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			health -= missle.GetDamage();
			missle.Hit();
			if (health <= 0) {
			Die ();
				
			}
			
		}
	}
	
		void Die(){
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		scoreKeeper.Score(scoreValue);
		Destroy(gameObject);
	}
} 