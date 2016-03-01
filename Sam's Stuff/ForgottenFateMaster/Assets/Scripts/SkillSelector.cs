using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour {

	public GameObject whiteBox1, whiteBox2, whiteBox3, whiteBox4;
    public bool oneUnlocked, twoUnlocked, threeUnlocked, fourUnlocked = false;

	void Start ()
	{
		//StartCoroutine (Wait ());
	}

	void Update () 
	{
	    if (Input.GetKeyUp ("1") && oneUnlocked)
        {
            whiteBox1.SetActive(true);
			whiteBox2.SetActive(false);
			whiteBox3.SetActive(false);
			whiteBox4.SetActive(false);
        }

		if (Input.GetKeyUp ("2") && twoUnlocked)
        {
            whiteBox1.SetActive(false);
			whiteBox2.SetActive(true);
			whiteBox3.SetActive(false);
			whiteBox4.SetActive(false);
		}

		if (Input.GetKeyUp ("3") && threeUnlocked)
        {
            whiteBox1.SetActive(false);
			whiteBox2.SetActive(false);
			whiteBox3.SetActive(true);
			whiteBox4.SetActive(false);
		}

		if (Input.GetKeyUp ("4") && fourUnlocked)
        {
            whiteBox1.SetActive (false);
			whiteBox2.SetActive (false);
			whiteBox3.SetActive (false);
			whiteBox4.SetActive (true);
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