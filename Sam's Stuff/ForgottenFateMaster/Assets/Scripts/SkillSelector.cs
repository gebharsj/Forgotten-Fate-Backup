using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour {

	public GameObject whiteBox1, whiteBox2, whiteBox3, whiteBox4;

	void Start ()
	{
		StartCoroutine (Wait ());
	}

	void Update () 
	{
        StopCoroutine(Wait());

	    if (Input.GetKeyUp ("1")) {
            whiteBox1.SetActive(true);
			whiteBox2.SetActive(false);
			whiteBox3.SetActive(false);
			whiteBox4.SetActive(false);
            StartCoroutine(Wait());
		}
		if (Input.GetKeyUp ("2")) {
            whiteBox1.SetActive(false);
			whiteBox2.SetActive(true);
			whiteBox3.SetActive(false);
			whiteBox4.SetActive(false);
            StartCoroutine(Wait());
		}
		if (Input.GetKeyUp ("3")) {
            whiteBox1.SetActive(false);
			whiteBox2.SetActive(false);
			whiteBox3.SetActive(true);
			whiteBox4.SetActive(false);
            StartCoroutine(Wait());
		}
		if (Input.GetKeyUp ("4")) {
            whiteBox1.SetActive (false);
			whiteBox2.SetActive (false);
			whiteBox3.SetActive (false);
			whiteBox4.SetActive (true);
            StartCoroutine(Wait());
		}        
	}

	IEnumerator Wait() {
        yield return new WaitForSeconds(3);
        whiteBox1.SetActive(false);
        whiteBox2.SetActive(false);
        whiteBox3.SetActive(false);
        whiteBox4.SetActive(false);
	}
}