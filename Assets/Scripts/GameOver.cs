using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public AudioClip death;
	
	void Start () {
		AudioSource.PlayClipAtPoint(death, transform.position);
	
	}
}