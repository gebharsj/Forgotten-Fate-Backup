using UnityEngine;
using System.Collections;

public class ExpSystemPlayer : MonoBehaviour
{

    [HideInInspector]
    public float exp;
    [HideInInspector]
    public int playerLevel = 1;
    [HideInInspector]
    public float maxExp = 0f;

    public GameObject _player;

    // Use this for initialization
    void Start()
    {
        maxExp = 100 * playerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        maxExp = 100 * playerLevel;
    }
	public void CalcExp(int enemyLvl)
	{
		exp += (enemyLvl * 10);
		
		maxExp = 100 * playerLevel;
		
		if (exp >= maxExp)
		{
			playerLevel++;
			exp = exp - maxExp;
			_player.GetComponent<CombatScript>().normalDamage++;
		}
	}
}