using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour {

    public GameObject player;
	public GameObject whiteBox1, whiteBox2, whiteBox3, whiteBox4;
    public GameObject oneUnlocked, twoUnlocked, threeUnlocked, fourUnlocked;

    void Start()
    {
		player.GetComponent<CombatScript>().spells = -1;
        //StartCoroutine (Wait ());
    }

    void Update()
    {
        if (Input.GetKeyUp("1") && oneUnlocked.activeSelf)
        {
            player.GetComponent<CombatScript>().spells = 0;
            whiteBox1.SetActive(true);
            whiteBox2.SetActive(false);
            whiteBox3.SetActive(false);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("2") && twoUnlocked.activeSelf)
        {
            player.GetComponent<CombatScript>().spells = 1;
            whiteBox1.SetActive(false);
            whiteBox2.SetActive(true);
            whiteBox3.SetActive(false);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("3") && threeUnlocked.activeSelf)
        {
            player.GetComponent<CombatScript>().spells = 2;
            whiteBox1.SetActive(false);
            whiteBox2.SetActive(false);
            whiteBox3.SetActive(true);
            whiteBox4.SetActive(false);
        }

        if (Input.GetKeyUp("4") && fourUnlocked.activeSelf)
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