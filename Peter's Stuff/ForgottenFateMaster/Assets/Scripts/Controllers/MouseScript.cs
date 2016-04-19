using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
    // public float distance = 11.05f;
    public Rigidbody2D strikePrefab;
    public Rigidbody2D sparksPrefab;
    public bool hit = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z += 18;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);


        //if (eventData.pointerCurrentRaycast.gameObject.tag == "InventorySlot") {
        //	}
    }
    public void Lightning()
    {
        Rigidbody2D spark;
        spark = Instantiate(sparksPrefab, transform.position, transform.rotation) as Rigidbody2D;
        Rigidbody2D strike;
        strike = Instantiate(strikePrefab, transform.position, transform.rotation) as Rigidbody2D;
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && hit == true)
            hit = false;
    }
}