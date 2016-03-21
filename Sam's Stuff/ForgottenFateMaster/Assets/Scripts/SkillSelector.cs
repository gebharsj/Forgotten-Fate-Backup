using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour {

    public GameObject player;
	public GameObject whiteBox1, whiteBox2, whiteBox3, whiteBox4;
    public bool oneUnlocked, twoUnlocked, threeUnlocked, fourUnlocked = false;

    void Start()
    {
        //StartCoroutine (Wait ());
    }

    void Update()
    {
        if (Input.GetKeyUp("1") && oneUnlocked)
        {
            player.GetComponent<CombatScript>().spells = 0;
            whiteBox1.SetActive(true);
            whiteBox2.SetActive(false);
            whiteBox3.SetActive(false);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("2") && twoUnlocked)
        {
            player.GetComponent<CombatScript>().spells = 1;
            whiteBox1.SetActive(false);
            whiteBox2.SetActive(true);
            whiteBox3.SetActive(false);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("3") && threeUnlocked)
        {
            player.GetComponent<CombatScript>().spells = 2;
            whiteBox1.SetActive(false);
            whiteBox2.SetActive(false);
            whiteBox3.SetActive(true);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("4") && fourUnlocked)
        {
            player.GetComponent<CombatScript>().spells = 3;
            whiteBox1.SetActive(false);
            whiteBox2.SetActive(false);
            whiteBox3.SetActive(false);
            whiteBox4.SetActive(true);
        }
    }

    //IEnumerator Wait() {
    //       yield return new WaitForSeconds(3);
    //       whiteBox1.SetActive(false);
    //       whiteBox2.SetActive(false);
    //       whiteBox3.SetActive(false);
    //       whiteBox4.SetActive(false);
    //}
}