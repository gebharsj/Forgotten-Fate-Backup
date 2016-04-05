using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject,4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
