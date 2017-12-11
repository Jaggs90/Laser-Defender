using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public static int health = 500;
	private Text myText;
	
	void Start(){
		myText = GetComponent<Text>();
		Reset ();
	}
	
	public void HealthBar(int healthBar){
		Debug.Log("test");
		health += healthBar;
		myText.text = health.ToString();
	}
	
	public static void Reset(){
		health = 500;
		
	}
}