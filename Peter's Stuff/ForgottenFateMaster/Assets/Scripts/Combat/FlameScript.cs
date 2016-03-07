using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {
	void Start() {
		
		StartCoroutine(WaitAndPrint(Random.Range (0.5f,1f)));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.2f);		
	}

	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
	}
}