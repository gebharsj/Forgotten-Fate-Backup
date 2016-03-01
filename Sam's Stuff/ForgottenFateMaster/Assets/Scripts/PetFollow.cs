using UnityEngine;
using System.Collections;

public class PetFollow : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x - 2, target.position.y - 1, transform.position.z), Time.deltaTime * 5f);
    }
}
