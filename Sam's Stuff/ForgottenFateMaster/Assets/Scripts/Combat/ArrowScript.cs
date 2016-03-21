using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
    bool aqcuireDMG;
    [HideInInspector]
    public float myDMG;
    private float myWait = 5;

    void Start()
    {

    }

    void update()
    {

    }

    IEnumerator WaitAndPrint(float myWait)
    {
        yield return new WaitForSeconds(myWait);
        //	print(myWait);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D charge)
    {
        if (charge.gameObject.tag == "Player")
        {
            if (charge.gameObject.GetComponent<CombatScript>().playerDamage != null)
            {
                //acquiring the variable playerDamage and setting the value of myDamage to that
                //so that it can later be passed into the EnemieRecievesDamageScript of an object
                myDMG = charge.gameObject.GetComponent<CombatScript>().playerDamage;
                //print("dmg " + myDMG);
                //acquiring the "chargeShot" variable and setting the courotine to that value.
                myWait = (charge.gameObject.GetComponent<CombatScript>().chargeShot * 1.0f) + 0.3f;
                charge.gameObject.GetComponent<CombatScript>().chargeShot = 0;
                //print("charge " + myWait);
                StartCoroutine(WaitAndPrint(myWait));
            }
        }
    }
}