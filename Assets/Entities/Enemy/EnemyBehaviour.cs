using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject Projectile;
	
	public float health = 150;
	public float projectileSpeed = 10;
	public float shotsPerSeconds = 0.5f;
	
	void Update(){
		float probablity = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probablity){
			Fire ();
	
	}
		}
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1, 0);
		GameObject missle = Instantiate(Projectile, startPosition, Quaternion.identity) as GameObject;
		missle.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
	}
	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			health -= missle.GetDamage();
			missle.Hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
			
		}
	}
} 