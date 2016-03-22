using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerReceivesDamage : MonoBehaviour
{
    public GameObject CBTPrefab;
    public GameObject _player;


    [HideInInspector]
    public int meleeHits; //howmany melee hits the player has been attacked with
    [HideInInspector]
    public int rangeHits; //howmany range hits the player has been attacked with
    //[HideInInspector]
    float hitChance;
    float defDex_calc;
    private float damageTaken;
    float criticalHit = 0f;
    public Transform shieldReflectPrefab;
    public GameObject shieldChild;

    //**AUDIO SOURCES**
    [HideInInspector]
    public AudioSource au_miss1;
    [HideInInspector]
    public AudioSource au_arrowhit;
    [HideInInspector]
    public AudioSource au_swordhit;


    // Use this for initialization
    void Start()
    {
        au_miss1 = gameObject.AddComponent<AudioSource>();
        AudioClip miss1;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        miss1 = (AudioClip)Resources.Load("Audio/Combat Sounds/Sword 1", typeof(AudioClip));
        au_miss1.clip = miss1;

        au_arrowhit = gameObject.AddComponent<AudioSource>();
        AudioClip arrowhit;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        arrowhit = (AudioClip)Resources.Load("Audio/Combat Sounds/weaponBowArrowHitSoundEffect", typeof(AudioClip));
        au_arrowhit.clip = arrowhit;

        au_swordhit = gameObject.AddComponent<AudioSource>();
        AudioClip swordhit;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        swordhit = (AudioClip)Resources.Load("Audio/Combat Sounds/weaponSwordHitSoundEffect", typeof(AudioClip));
        au_swordhit.clip = swordhit;

    }
    void Update()
    {

    }

    //pysical damage
    void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.gameObject.GetComponent<EnemiesReceiveDamage>() != null)
        {
            if (meleeHits > 0)
            {
                //print ("deal damage");
                hitChance = Random.Range(0.0f, 1.0f);
                defDex_calc = enemy.gameObject.GetComponent<EnemiesReceiveDamage>().dexterity - _player.GetComponent<CombatScript>().defense;
                defDex_calc = defDex_calc / enemy.gameObject.GetComponent<EnemiesReceiveDamage>().dexterity;
                if (defDex_calc > 0.95f)
                    defDex_calc = .95f;
                if (defDex_calc < 0.05f)
                    defDex_calc = .05f;

                meleeHits -= 1;  //subbtracts from hits

                //	Debug.Log (defDex_calc);

                //causing damage and estimating chances

                if (hitChance <= 1 && (hitChance >= defDex_calc))
                {
                    damageTaken = 0;
                    InitiateCBT("*miss*").GetComponent<Animator>().SetTrigger("Miss");
                    au_miss1.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.0f);
                    au_miss1.GetComponent<AudioSource>().volume = Random.Range(0.8f, 1.0f);
                    au_miss1.Play();
                    hitChance = 2;

                }
                if (hitChance <= 1 && (hitChance < defDex_calc))
                {
                    au_swordhit.Play();
                    hitChance = 2;
                    meleeHits -= 1;
                    damageTaken = enemy.gameObject.GetComponent<EnemiesReceiveDamage>().damage;
                    if (damageTaken > _player.GetComponent<CombatScript>().armor + 1)
                        damageTaken = damageTaken - _player.GetComponent<CombatScript>().armor;
                    else
                        damageTaken = 2;
                    damageTaken = Random.Range(damageTaken * 0.7f, damageTaken);
                    damageTaken = -damageTaken;
                    criticalHit = Random.Range(0, 1.0f);
                    //shield reflects damage
                    if (shieldChild.activeSelf)
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(shieldReflectPrefab, transform.position, transform.rotation) as Rigidbody2D;
                    }
                    //print ("crit" + criticalHit);

                    //Damage caused by critical hit (critical hits do 5 times more than normal damage)
                    if (criticalHit < 2 && criticalHit <= enemy.gameObject.GetComponent<EnemiesReceiveDamage>().criticalChance)
                    {
                        damageTaken = (damageTaken * enemy.gameObject.GetComponent<EnemiesReceiveDamage>().criticalDamage);
                        damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                        InitiateCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Crit");
                        //print ("damageTaken " + damageTaken);
                        _player.GetComponent<CombatScript>().health += damageTaken;
                        //calculator = _player.GetComponent<CombatScript> ().health / _player.GetComponent<CombatScript> ().maxHealth;
                        //SetHealth (calculator);
                        criticalHit = 2;
                        //sound
                    }
                    //Nomal damage
                    if (criticalHit < 2 && criticalHit > _player.GetComponent<CombatScript>().criticalChance)
                    { // was originally criticalHit != _player.GetComponent<CombatScript>().criticalChance)
                        damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                        //print ("damageTaken " + damageTaken);
                        InitiateCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Hit");
                        _player.GetComponent<CombatScript>().health += damageTaken;
                        //calculator = hp / maxHp;
                        //SetHealth (calculator);
                        criticalHit = 2;
                        //play sound here
                    }
                }
            }
        }
    }
    GameObject InitiateCBT(string text)
    {
        GameObject temp = Instantiate(CBTPrefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.FindChild("PlayerCanvas"));
        tempRect.transform.localPosition = CBTPrefab.transform.localPosition;
        tempRect.transform.localScale = CBTPrefab.transform.localScale;
        tempRect.transform.localRotation = CBTPrefab.transform.localRotation;

        //		Debug.Log (tempRect.transform.localPosition);

        temp.GetComponent<Text>().text = text;
        Destroy(temp.gameObject, 3);
        //temp.GetComponent<Animator>().SetTrigger("Hit");
        return temp;
    }
}
