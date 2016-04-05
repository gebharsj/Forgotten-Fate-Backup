using UnityEngine;
using System.Collections;

public class CheckForEnemies : MonoBehaviour {

    public GameObject _NPC;
    public int targetIndex;
    public GameObject[] enemies;
    public int counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        counter = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy == false)
            {
                counter++;
                if (counter == enemies.Length)
                {
                    _NPC.GetComponent<TriggerText>().index = targetIndex;
                }
            }
        }
	}
}
