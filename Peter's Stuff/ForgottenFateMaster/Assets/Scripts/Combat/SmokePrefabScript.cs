using UnityEngine;
using System.Collections;

public class SmokePrefabScript : MonoBehaviour {

		void Start() {
			
			StartCoroutine(Evaporate(3f));
			
		}
		
		
		IEnumerator Evaporate(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			Destroy (gameObject);
		}
	}