using UnityEngine;
using System.Collections;

public class ExpSystemEnemy : MonoBehaviour
{

    public GameObject _player;

    public int enemyLevel = 0;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<EnemiesReceiveDamage>().dead)
        {
			_player.GetComponent<ExpSystemPlayer>().CalcExp(enemyLevel);
            this.gameObject.GetComponent<EnemiesReceiveDamage>().dead = false;
            this.gameObject.SetActive(false);
        }
    }
}