using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
	void Start() {

		StartCoroutine(WaitAndPrint(Random.Range (3.0f,5.0f)));
	
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
	}
}