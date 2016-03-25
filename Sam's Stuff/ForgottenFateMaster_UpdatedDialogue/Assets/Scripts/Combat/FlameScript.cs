using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {
	void Start() {
        StartCoroutine(WaitAndPrint(0.85f));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.2f);
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}