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
            _player.GetComponent<ExpSystemPlayer>().exp += (enemyLevel * 10);

            _player.GetComponent<ExpSystemPlayer>().maxExp = 100 * _player.GetComponent<ExpSystemPlayer>().playerLevel;

            if (_player.GetComponent<ExpSystemPlayer>().exp >= _player.GetComponent<ExpSystemPlayer>().maxExp)
            {
                _player.GetComponent<ExpSystemPlayer>().playerLevel++;
                _player.GetComponent<ExpSystemPlayer>().exp =
                            _player.GetComponent<ExpSystemPlayer>().exp - _player.GetComponent<ExpSystemPlayer>().maxExp;
                _player.GetComponent<CombatScript>().normalDamage++;
            }
            this.gameObject.GetComponent<EnemiesReceiveDamage>().dead = false;
            this.gameObject.SetActive(false);
        }
    }
}