using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ActiveSave : MonoBehaviour 
{
	public float currentHealth;		//declaring players health
	public int currentLevel;
	public float currentExp;

	public float enemyHealth;
	public float enemyHealth1;
	public float enemyHealth2;
	public float enemyHealth3;
	public float enemyHealth4;
	public float enemyHealth5;
	private float xposition;		//declaing players position
	private float yposition;
	private float xpositionE0;		//declaing Enemy 0 position
	private float ypositionE0;
	private float xpositionE1;		//declaing Enemy 1 position
	private float ypositionE1;
	private float xpositionE2;		//declaing Enemy 2 position
	private float ypositionE2;
	private float xpositionE3;		//declaing Enemy 3 position
	private float ypositionE3;
	private float xpositionE4;		//declaing Enemy 4 position
	private float ypositionE4;
	private float xpositionE5;		//declaing Enemy 5 position
	private float ypositionE5;

	public GameObject player;
	public GameObject enemy0;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;




	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Save()
	{
		currentHealth = player.GetComponent<CombatScript> ().health;		//looking at health variable in CombatScript
		PlayerPrefs.SetFloat ("Health", currentHealth);		//Setting the current health of the player when save button hit

		enemyHealth = enemy0.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth", enemyHealth);		

		enemyHealth1 = enemy1.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth1", enemyHealth1);

		enemyHealth2 = enemy2.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth2", enemyHealth2);

		enemyHealth3 = enemy3.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth3", enemyHealth3);

		enemyHealth4 = enemy4.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth4", enemyHealth4);

		enemyHealth5 = enemy5.GetComponent<EnemiesReceiveDamage> ().hp;		
		PlayerPrefs.SetFloat ("EHealth5", enemyHealth5);

		currentLevel = player.GetComponent<ExpSystemPlayer> ().playerLevel;		
		PlayerPrefs.SetInt ("Level", currentLevel);

		currentExp = player.GetComponent<ExpSystemPlayer> ().exp;		
		PlayerPrefs.SetFloat ("Exp", currentExp);

		xposition = player.transform.position.x;
		PlayerPrefs.SetFloat ("x", xposition);
		yposition = player.transform.position.y;
		PlayerPrefs.SetFloat ("y", yposition);

		xpositionE0 = enemy0.transform.position.x;
		PlayerPrefs.SetFloat ("xE0", xpositionE0);
		ypositionE0 = enemy0.transform.position.y;
		PlayerPrefs.SetFloat ("yE0", ypositionE0);

		xpositionE1 = enemy1.transform.position.x;
		PlayerPrefs.SetFloat ("xE1", xpositionE1);
		ypositionE1 = enemy1.transform.position.y;
		PlayerPrefs.SetFloat ("yE1", ypositionE1);

		xpositionE2 = enemy2.transform.position.x;
		PlayerPrefs.SetFloat ("xE2", xpositionE2);
		ypositionE2 = enemy2.transform.position.y;
		PlayerPrefs.SetFloat ("yE2", ypositionE2);

		xpositionE3 = enemy3.transform.position.x;
		PlayerPrefs.SetFloat ("xE3", xpositionE3);
		ypositionE3 = enemy3.transform.position.y;
		PlayerPrefs.SetFloat ("yE3", ypositionE3);

		xpositionE4 = enemy4.transform.position.x;
		PlayerPrefs.SetFloat ("xE4", xpositionE4);
		ypositionE4 = enemy4.transform.position.y;
		PlayerPrefs.SetFloat ("yE4", ypositionE4);

		xpositionE5 = enemy5.transform.position.x;
		PlayerPrefs.SetFloat ("xE5", xpositionE5);
		ypositionE5 = enemy5.transform.position.y;
		PlayerPrefs.SetFloat ("yE5", ypositionE5);
	}

	public void Load()
	{
		player.GetComponent<CombatScript> ().health = PlayerPrefs.GetFloat("Health");	//Loading the current health of the player

		enemy0.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth");
		if (enemy0.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy0.SetActive(true);}

		enemy1.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth1");
		if (enemy1.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy1.SetActive(true);}

		enemy2.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth2");
		if (enemy2.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy2.SetActive(true);}

		enemy3.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth3");
		if (enemy3.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy3.SetActive(true);}

		enemy4.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth4");
		if (enemy4.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy4.SetActive(true);}

		enemy5.GetComponent<EnemiesReceiveDamage> ().hp = PlayerPrefs.GetFloat("EHealth5");
		if (enemy5.GetComponent<EnemiesReceiveDamage> ().hp >= 1.0f) {enemy5.SetActive(true);}

		player.GetComponent<ExpSystemPlayer> ().playerLevel = PlayerPrefs.GetInt("Level");

		player.GetComponent<ExpSystemPlayer> ().exp = PlayerPrefs.GetInt("Exp");

		xposition = PlayerPrefs.GetFloat ("x");
		yposition = PlayerPrefs.GetFloat ("y");
		player.transform.position = new Vector2 (xposition ,yposition);

		xpositionE0 = PlayerPrefs.GetFloat ("xE0");
		ypositionE0 = PlayerPrefs.GetFloat ("yE0");
		enemy0.transform.position = new Vector2 (xpositionE0, ypositionE0);

		xpositionE1 = PlayerPrefs.GetFloat ("xE1");
		ypositionE1 = PlayerPrefs.GetFloat ("yE1");
		enemy1.transform.position = new Vector2 (xpositionE1, ypositionE1);

		xpositionE2 = PlayerPrefs.GetFloat ("xE2");
		ypositionE2 = PlayerPrefs.GetFloat ("yE2");
		enemy2.transform.position = new Vector2 (xpositionE2, ypositionE2);

		xpositionE3 = PlayerPrefs.GetFloat ("xE3");
		ypositionE3 = PlayerPrefs.GetFloat ("yE3");
		enemy3.transform.position = new Vector2 (xpositionE3, ypositionE3);

		xpositionE4 = PlayerPrefs.GetFloat ("xE4");
		ypositionE4 = PlayerPrefs.GetFloat ("yE4");
		enemy4.transform.position = new Vector2 (xpositionE4, ypositionE4);

		xpositionE5 = PlayerPrefs.GetFloat ("xE5");
		ypositionE5 = PlayerPrefs.GetFloat ("yE5");
		enemy5.transform.position = new Vector2 (xpositionE5, ypositionE5);
	}
}