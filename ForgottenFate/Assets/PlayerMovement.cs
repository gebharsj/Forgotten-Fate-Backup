using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveX;
    public float moveY;
    public float movementSpeed;
    public Rigidbody player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxis("Horizontal") * movementSpeed;
        moveY = Input.GetAxis("Vertical") * movementSpeed;
        player.velocity = new Vector3(moveX, moveY, 0);
	}
}
