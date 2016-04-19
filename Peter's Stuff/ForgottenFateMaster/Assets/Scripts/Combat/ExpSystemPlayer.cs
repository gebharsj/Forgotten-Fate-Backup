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
}