using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemiesReceiveDamage : MonoBehaviour {
    public float maxHp;
    public float hp;
    private bool hit = false;
    public GameObject _player;
    private float damageTaken;
    float criticalHit = 0f;
    public int armor;
    public int defense;
    public int dexterity;
    float defDex_calc;
    public int damage;
    public GameObject CBTPrefab;
    public Image healthBar;
    float calculator;
    public Color32 startColor;
    public Color32 endColor;
    float hitChance;
    [Range(0.03f, 0.08f)]
    public float criticalChance;
    [Range(1, 5)]
    public float criticalDamage;
    public Rigidbody2D rb;
    public GameObject hPBar;
    private float hPTimer;
    private float burning;
    public GameObject burningChild;

    public bool dead = false;
    bool nowDead = true;


    //** SOUNDS **
    [HideInInspector]
    public AudioSource au_miss1;
    [HideInInspector]
    public AudioSource au_arrowhit;
    [HideInInspector]
    public AudioSource au_swordhit;



    void Awake()
    {
        hp = maxHp;
    }


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

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

    // Update is called once per frame
    void Update()
    {
        if (hPTimer <= 0)
        {
            hPBar.SetActive(false);
        }
        if (hPTimer > 0)
        {
            hPTimer -= 1 * Time.deltaTime;
        }

        //enemies catch fire after being burned
        if (burning > 0 && hp > 0)
        {
            hPTimer = 3;
            burning -= 1 * Time.deltaTime;


            if (burningChild != null)
                burningChild.SetActive(true);

            if (burning <= 2.8f)
            {
                hp -= _player.GetComponent<CombatScript>().fireDamage * 4 * Time.deltaTime;
                calculator = hp / maxHp;
                SetHealth(calculator);
            }
        }
        if (burning <= 0)
        {
            if (burningChild != null)
                burningChild.SetActive(false);
        }

        //if health is zero below, object dies
        if (hp <= 0 && nowDead)
        {
            dead = true;
            nowDead = false;
            //Destroy(gameObject);
        }

        //defense cannot be below 1 or else there will be a glitch
        if (defense < 1)
            defense = 1;
        //as long as player is charging, the object will be moveable
        if (_player.GetComponent<CombatScript>().chargeDistance == 0)
        {
            rb.drag = 10000;
            rb.mass = 50;
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        //light damage
        if (col.gameObject.tag == "Mouse" && col.gameObject.GetComponent<MouseScript>().hit == true)
        {
            col.gameObject.GetComponent<MouseScript>().hit = false;
            damageTaken -= _player.GetComponent<CombatScript>().lightDamage;
            InitCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Hit");
            hp += damageTaken;
            calculator = hp / maxHp;
            SetHealth(calculator);
        }

        //fire damage
        if (col.gameObject.tag == "Flame")
        {
            hPTimer = 3;
            hPBar.SetActive(true);
            hp -= _player.GetComponent<CombatScript>().fireDamage * Time.deltaTime;
            calculator = hp / maxHp;
            SetHealth(calculator);
            burning = 3;

        }
        //pysical damage
        if (_player.GetComponent<CombatScript>().splash > 0)
        {
            hPTimer = 3;
            hPBar.SetActive(true);
            //dealing damage to object
            if (col.gameObject.tag == "PlayerMelee" && hit == false && _player.GetComponent<CombatScript>().attackRate > 0)
            {
                //using calculations to determine the chance of landing a hit.
                //this also makes sure that chance of hitting cannot be greater or less than a set amount.
                hitChance = Random.Range(0.0f, 1.0f);
                defDex_calc = (_player.GetComponent<CombatScript>().dexterity - defense) / _player.GetComponent<CombatScript>().dexterity;
                if (defDex_calc > 0.95f)
                    defDex_calc = .95f;
                if (defDex_calc < 0.05f)
                    defDex_calc = .05f;
                _player.GetComponent<CombatScript>().splash -= 1;

                //	Debug.Log (defDex_calc);

                //causing damage and estimating chances

                if (hitChance <= 1 && (hitChance >= defDex_calc))
                {
                    damageTaken = 0;
                    InitCBT("*miss*").GetComponent<Animator>().SetTrigger("Miss");
                    au_miss1.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.0f);
                    au_miss1.GetComponent<AudioSource>().volume = Random.Range(0.8f, 1.0f);
                    au_miss1.Play();
                    hitChance = 2;
                    hit = true;
                }
                if (hitChance <= 1 && (hitChance < defDex_calc))
                {
                    au_swordhit.Play();
                    hitChance = 2;
                    hit = true;
                    damageTaken = _player.GetComponent<CombatScript>().playerDamage;
                    if (damageTaken > armor + 1)
                        damageTaken = damageTaken - armor;
                    else
                        damageTaken = 2;
                    damageTaken = Random.Range(damageTaken * 0.7f, damageTaken);
                    damageTaken = -damageTaken;
                    criticalHit = Random.Range(0, 1.0f);
                    //print ("crit" + criticalHit);

                    //Damage caused by critical hit (critical hits do 5 times more than normal damage)
                    if (criticalHit < 2 && criticalHit <= _player.GetComponent<CombatScript>().criticalChance)
                    {
                        damageTaken = (damageTaken * _player.GetComponent<CombatScript>().criticalDamage);
                        damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                        InitCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Crit");
                        //print ("damageTaken " + damageTaken);
                        hp += damageTaken;
                        calculator = hp / maxHp;
                        SetHealth(calculator);
                        criticalHit = 2;
                        //sound
                    }
                    //Nomal damage
                    if (criticalHit < 2 && criticalHit > _player.GetComponent<CombatScript>().criticalChance) // was originally criticalHit != _player.GetComponent<CombatScript>().criticalChance)
                    {
                        damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                        //print ("damageTaken " + damageTaken);
                        InitCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Hit");
                        hp += damageTaken;
                        calculator = hp / maxHp;
                        SetHealth(calculator);
                        criticalHit = 2;
                        //play sound here
                    }
                }

            }
            //object is immovable as long as player is not charging
            if (_player.GetComponent<CombatScript>().chargeDistance > 0)
            {
                rb.drag = 0;
                rb.mass = 1;
            }
        }
        //resetting the conditions for damage
        if (hit == true && _player.GetComponent<CombatScript>().attackRate == 0)
        {
            hit = false;
        }

    }




    //range damage (very similar to melee).
    void OnTriggerEnter2D(Collider2D ar)
    {

        hPTimer = 3;
        hPBar.SetActive(true);
        //dealing damage to object
        if (ar.gameObject.tag == "Arrow")
        {
            //using calculations to determine the chance of landing a hit.
            //this also makes sure that chance of hitting cannot be greater or less than a set amount.
            hitChance = Random.Range(0.0f, 1.0f);
            defDex_calc = (_player.GetComponent<CombatScript>().dexterity - defense) / _player.GetComponent<CombatScript>().dexterity;
            if (defDex_calc > 0.95f)
                defDex_calc = 0.95f;
            if (defDex_calc < 0.05f)
                defDex_calc = 0.05f;
            _player.GetComponent<CombatScript>().splash -= 1;

            //				Debug.Log (defDex_calc);

            //causing damage and estimating chances

            if (hitChance <= 1 && (hitChance >= defDex_calc))
            {
                damageTaken = 0;
                InitCBT("*miss").GetComponent<Animator>().SetTrigger("Miss");
                hitChance = 2;
            }
            if (hitChance <= 1 && (hitChance < defDex_calc))
            {
                au_arrowhit.Play();
                Destroy(ar.gameObject);
                hitChance = 2;
                //damageTaken = _player.GetComponent<CombatScript>().playerDamage;
                damageTaken = ar.GetComponent<ArrowScript>().myDMG;
                if (damageTaken > armor + 1)
                    damageTaken = damageTaken - armor;
                else
                    damageTaken = 2;
                damageTaken = Random.Range(damageTaken * 0.7f, damageTaken);
                damageTaken = -damageTaken;
                criticalHit = Random.Range(0, 1.0f);


                //Damage caused by critical hit (critical hits do 5 times more than normal damage).
                if (criticalHit < 2 && criticalHit <= _player.GetComponent<CombatScript>().criticalChance)
                {
                    damageTaken = (damageTaken * _player.GetComponent<CombatScript>().criticalDamage);
                    damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                    InitCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Crit");
                    hp += damageTaken;
                    calculator = hp / maxHp;
                    SetHealth(calculator);
                    criticalHit = 2;
                    //play sound
                }
                //Nomal damage
                if (criticalHit < 2 && criticalHit > _player.GetComponent<CombatScript>().criticalChance) // was originally criticalHit != _player.GetComponent<CombatScript>().criticalChance)
                {
                    damageTaken = Mathf.Round(damageTaken * 1.0f) / 1.0f;
                    InitCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Hit");
                    hp += damageTaken;
                    calculator = hp / maxHp;
                    SetHealth(calculator);
                    criticalHit = 2;
                    //play sound
                }
            }
        }
    }

    //this method or function calls for the "CBT" prefab's transforms and animation seuquences.
    // this is used for animating the damage text shown when the player hits a target.
    GameObject InitCBT(string text)
    {
        GameObject temp = Instantiate(CBTPrefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.FindChild("EnemyCanvas"));
        tempRect.transform.localPosition = CBTPrefab.transform.localPosition;
        tempRect.transform.localScale = CBTPrefab.transform.localScale;
        tempRect.transform.localRotation = CBTPrefab.transform.localRotation;

        //Debug.Log(tempRect.transform.localPosition);

        temp.GetComponent<Text>().text = text;
        Destroy(temp.gameObject, 3);
        //temp.GetComponent<Animator>().SetTrigger("Hit");
        return temp;
    }

    public void SetHealth(float myHealth)
    {
        //"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBar.color = Color.Lerp(endColor, startColor, calculator);
    }
}