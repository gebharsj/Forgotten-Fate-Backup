using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatScript : MonoBehaviour 
{
    public GameObject self;
    public MouseScript _mouse;
    public Transform playerPOS;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public float maxMana = 65;
    public float manaRecovery = 1.0f;
    public float mana;
    public float normalDamage = 7;
    public float rangeDamage = 3;
    [HideInInspector]
    public float playerDamage = 3;
    //[HideInInspector]
    public float fireDamage = 0.02f;
    public float lightDamage = 200.0f;
    public float attackSpeed = 5.0f;
    public int defense;
    public int armor;
    public float dexterity; // chance of hitting
    public float meleeRange = 0.8f;
    public float meleeAdjustment = 0.5f;
    public int maxHealth = 65;
    public float health;
    [Range(0.03f, 0.08f)]
    public float criticalChance;
    [Range(2, 5)]
    public int criticalDamage;
    private float chargeMultiplier = 100.0f;
    [HideInInspector]
    public float chargeDistance;
    public bool melee = true;
    public Rigidbody2D projectile;
    public Rigidbody2D flamePrefab;
    [HideInInspector]
    public Transform target;
    public GameObject smokeChild;
    [HideInInspector]
    public float chargeShot;
    public Color32 startColor;
    public Color32 endColor;
    public Image energyBar;
    public GameObject energy;
    public Transform restorationPrefab;
    //***calculators**
    float calculator;
    float calculator2;
    float calculator3;
    float calculator4;
    //[HideInInspector]
    public int spells = 0;
    public GameObject shieldChild;
    public int shield;
    public int healthRestore = 25;

    //**spellcooldowns
    float shieldCoolDown;
    float restoreCoolDown;
    float fireCoolDown;
    float lightCoolDown;
    //**Spell Timers**
    float shieldTimer;
    float restoreTimer;
    float fireTimer;


    //**image cooldowns**
    public Image CoolDownImageShield;
    public Image CoolDownImageRestore;
    public Image CoolDownImageFire;
    public Image CoolDownImageLight;


    [HideInInspector]
    public int splash;
    [HideInInspector]
    public float attackRate;  //rate of attack

    //**AUDIOS SOURCES**
    [HideInInspector]
    public AudioSource au_bow1;
    [HideInInspector]
    public AudioSource au_arrow1;
    [HideInInspector]
    public AudioSource au_arrow2;
    [HideInInspector]
    public AudioSource au_swing1;


    //----------EXP--------
    [HideInInspector]
    public float exp;
    public int playerLevel = 1;
    public float maxExp = 0f;


    void Awake()
    {
        mana = maxMana;
        health = maxHealth;
    }

    // Use this for initialization
    void Start()
    {
        au_bow1 = gameObject.AddComponent<AudioSource>();
        AudioClip bow1;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        bow1 = (AudioClip)Resources.Load("Audio/Combat Sounds/Bow", typeof(AudioClip));
        au_bow1.clip = bow1;

        au_arrow1 = gameObject.AddComponent<AudioSource>();
        AudioClip arrow1;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        arrow1 = (AudioClip)Resources.Load("Audio/Combat Sounds/Arrow 6", typeof(AudioClip));
        au_arrow1.clip = arrow1;

        au_arrow2 = gameObject.AddComponent<AudioSource>();
        AudioClip arrow2;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        arrow2 = (AudioClip)Resources.Load("Audio/Combat Sounds/Arrow 7", typeof(AudioClip));
        au_arrow2.clip = arrow2;

        au_swing1 = gameObject.AddComponent<AudioSource>();
        AudioClip swing1;
        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        swing1 = (AudioClip)Resources.Load("Audio/Combat Sounds/Sword Swish 1", typeof(AudioClip));
        au_swing1.clip = swing1;




    }

    // Update is called once per frame
    void Update()
    {

        //switching from melee to range
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (melee == false)
            {
                melee = true;
                //print ("true");
            }
            //switching from range to melee
            else
            {
                melee = false;
                //print ("false");
            }
        }

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            Application.LoadLevel("GameOverScreen");
            //pay animation
            //pay sound
        }
        if (health > maxHealth)
            health = maxHealth;

        //setting the scale of objects to range of melee weapon
        up.transform.localScale = new Vector3(0, meleeRange, 0);
        up.transform.localPosition = new Vector3(0, meleeAdjustment, 0);
        down.transform.localScale = new Vector3(0, -meleeRange, 0);
        down.transform.localPosition = new Vector3(0, -meleeAdjustment, 0);
        left.transform.localScale = new Vector3(-meleeRange, 0, 0);
        left.transform.localPosition = new Vector3(-meleeAdjustment, 0, 0);
        right.transform.localScale = new Vector3(meleeRange, 0, 0);
        right.transform.localPosition = new Vector3(meleeAdjustment, 0, 0);

        if (criticalChance > 0.08f)
            criticalChance = 0.08f;

        if (Input.GetMouseButtonDown(0) && attackRate == 0) //left click
        {
            if (melee == true)
            {
                //attack whie sprint is not active (normal attack)
                if (!self.GetComponent<PlayerMovement>().isSprinting)
                {
                    playerDamage = normalDamage;
                    splash = 1;
                    attackRate = 5;

                    //the value of this variable,splash, determines how many foes can be hit within a single attack
                    //since it's currently set to 1, only one foe can be hit at a time.
                    //certain spells, such as a multi attack, will require this variable to increase.


                    au_swing1.Play();
                    //attack animation
                }

                //attack during sprint (Dash attack)
                if ((self.GetComponent<PlayerMovement>().isSprinting) && (self.GetComponent<PlayerMovement>().moveX != 0 || self.GetComponent<PlayerMovement>().moveY != 0))
                {
                    chargeDistance = 1.2f;
                    Vector3 playerPOS = self.transform.position;
                    smokeChild.transform.position = playerPOS;
                    playerDamage = normalDamage * chargeMultiplier;
                    splash = 5;
                    self.GetComponent<PlayerMovement>().moveX = self.GetComponent<PlayerMovement>().moveX * 25;
                    self.GetComponent<PlayerMovement>().moveY = self.GetComponent<PlayerMovement>().moveY * 25;
                    smokeChild.SetActive(true);
                }
            }
        }

        //charging the bow
        if (Input.GetMouseButton(0) && melee == false && attackRate == 0)
        {
            self.GetComponent<PlayerMovement>().moveX = 0;
            self.GetComponent<PlayerMovement>().moveY = 0;
            if (chargeShot <= 0)
            {
                au_bow1.Play();
            }


            energy.SetActive(true);
            if (chargeShot < 3)
                chargeShot += 1 * Time.deltaTime;
            if (chargeShot > 3)
                chargeShot = 3;
            playerDamage = rangeDamage * chargeShot * 3;
            calculator = chargeShot / 3;
            SetEnergy(calculator);
            //print ("charge is... " + chargeShot);
        }

        //using arrows
        if (Input.GetMouseButtonUp(0) && melee == false && attackRate == 0)
        {
            au_arrow1.Play();
            au_arrow2.Play();

            energy.SetActive(false);
            attackRate = chargeShot * 3;
            if (attackRate <= 8)
                attackRate = 8;

            if (!target)
                target = GameObject.FindWithTag("Mouse").transform;

            Vector3 v3Pos;
            float fAngle;

            v3Pos = Camera.main.WorldToScreenPoint(target.transform.position);
            v3Pos = Input.mousePosition - v3Pos;
            fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
            if (fAngle < 0.0f) fAngle += 360.0f;

            //instantiate projectile
            Rigidbody2D clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

            //detecting arrow direction with the variable direction
            if (fAngle <= 135.0F && fAngle > 45.0F)
            {
                //print ("up");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(10, 14);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                up.SetActive(true);
            }

            if (fAngle <= 45.0F || fAngle > 315.0F)
            {
                //print ("right");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(10, 14);
                up.SetActive(false);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(true);
            }

            if (fAngle <= 225.0F && fAngle > 135.0F)
            {
                //print ("left");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(10, 14);
                up.SetActive(false);
                down.SetActive(false);
                right.SetActive(false);
                left.SetActive(true);
            }

            if (fAngle <= 315.0F && fAngle > 225.0F)
            {
                //print ("down");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(10, 14);
                up.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                down.SetActive(true);
            }
        }

        //attack speed
        if (attackRate > 0)
        {
            attackRate -= attackSpeed * Time.deltaTime;
            //prevents moving during attack
            self.GetComponent<PlayerMovement>().moveX = 0;
            self.GetComponent<PlayerMovement>().moveY = 0;
        }

        if (attackRate < 0)
            attackRate = 0;
        if (attackSpeed > 50)
            attackSpeed = 50;

        //mana recovery
        if (mana < maxMana && spells == 2)
            mana += manaRecovery * Time.deltaTime;
        if (mana < maxMana && (spells == 0 || spells == 1) && !Input.GetMouseButton(1))
            mana += manaRecovery * Time.deltaTime;
        if (mana > maxMana)
            mana = maxMana;

        if (defense < 1)
            defense = 1;

        //charge recovery
        if (chargeDistance > 1)
            chargeDistance -= chargeDistance * Time.deltaTime;

        if (chargeDistance > 0 && chargeDistance <= 1)
        {
            attackRate = 10;
            chargeDistance = 0;
        }


        //*******MAGIC SPELLS***********

        //casting fire  (Firestorm)
        if (fireTimer > 0)
            fireTimer -= 5 * Time.deltaTime;

        if (fireTimer <= 0 && fireCoolDown > 0)
        {
            fireCoolDown -= 10 * Time.deltaTime;
            calculator4 = fireCoolDown / 100;
            CoolDownFire(calculator4);
        }
        if (fireCoolDown < 0)
        {
            fireCoolDown = 0;
            calculator4 = fireCoolDown / 100;
            CoolDownFire(calculator4);
        }

        if (fireTimer < 0)
            fireTimer = 0;

        if (Input.GetMouseButton(1) && spells == 0 && mana >= 1 && fireCoolDown < 100)  //right click
        {
            if (fireCoolDown < 100)
                fireCoolDown += 40 * Time.deltaTime;
            calculator4 = fireCoolDown / 100;
            CoolDownFire(calculator4);
            fireTimer = 20;

            mana -= 5 * Time.deltaTime;
            //prevent player from moving
            self.GetComponent<PlayerMovement>().moveX = 0;
            self.GetComponent<PlayerMovement>().moveY = 0;

            if (!target)
                target = GameObject.FindWithTag("Mouse").transform;

            Vector3 v3Pos;
            float fAngle;

            v3Pos = Camera.main.WorldToScreenPoint(target.transform.position);
            v3Pos = Input.mousePosition - v3Pos;
            fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;

            Rigidbody2D clone;
            clone = Instantiate(flamePrefab, transform.position, transform.rotation) as Rigidbody2D;

            if (fAngle < 0.0f)
                fAngle += 360.0f;

            //flame goes in the direction of the mouse


            if (fAngle <= 135.0F && fAngle > 45.0F)
            {
                //print ("up");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(3, 5);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                up.SetActive(true);
            }

            if (fAngle <= 45.0F || fAngle > 315.0F)
            {
                //print ("right");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(3, 5);
                up.SetActive(false);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(true);
            }

            if (fAngle <= 225.0F && fAngle > 135.0F)
            {
                //print ("left");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(3, 5);
                up.SetActive(false);
                down.SetActive(false);
                right.SetActive(false);
                left.SetActive(true);
            }

            if (fAngle <= 315.0F && fAngle > 225.0F)
            {
                //print ("down");
                clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range(3, 5);
                up.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                down.SetActive(true);
            }
        }
        //Restoration spell (Revivify)
        if (Input.GetMouseButtonDown(1) && spells == 1 && mana >= 20 && restoreCoolDown <= 0) //right click
        {
            Rigidbody2D clone;
            clone = Instantiate(restorationPrefab, transform.position, transform.rotation) as Rigidbody2D;
            mana -= 20;
            health += healthRestore;
            if (health > maxHealth)
                health = maxHealth;
            restoreTimer = 3;
            restoreCoolDown = 10.0f;
        }

        if (restoreTimer > 0)
        {
            restoreTimer -= 1 * Time.deltaTime;
            //prevent player from moving
            self.GetComponent<PlayerMovement>().moveX = 0;
            self.GetComponent<PlayerMovement>().moveY = 0;
        }
        if (restoreCoolDown > 0)
        {
            restoreCoolDown -= 1 * Time.deltaTime;
            calculator3 = restoreCoolDown / 10;
            CoolDownRestore(calculator3);
        }
        if (restoreCoolDown < 0)
            restoreCoolDown = 0;



        //Cold Spell (StormShield)
        if (Input.GetMouseButton(1) && spells == 2 && mana >= 40 & shieldCoolDown <= 0) //right click
        {
            shieldChild.SetActive(true);
            mana -= 40;
            shieldCoolDown = 50;
            shieldTimer = 18;
            armor += shield;

            //prevent player from moving
            self.GetComponent<PlayerMovement>().moveX = 0;
            self.GetComponent<PlayerMovement>().moveY = 0;
        }
        //turning shield off
        if (shieldChild.activeSelf && shieldTimer != 0 && shieldTimer < 1)
        {
            shieldTimer = 0;
            shieldChild.SetActive(false);
            armor -= shield;
        }
        //shield timer
        if (shieldTimer >= 1)
            shieldTimer -= 1 * Time.deltaTime;
        if (shieldCoolDown > 0)
        {
            calculator2 = shieldCoolDown / 50;
            CoolDownShield(calculator2);
            shieldCoolDown -= 1 * Time.deltaTime;
        }
        if (shieldCoolDown < 0)
            shieldCoolDown = 0;

        //Spell 4 (Shock Wave)
        if (Input.GetMouseButtonDown(1) && spells == 3 && lightCoolDown <= 0)  //right click
        {

            _mouse.Lightning();
            lightCoolDown = 80;


        }
        if (lightCoolDown > 0)
        {
            calculator4 = lightCoolDown / 80;
            CoolDownLight(calculator4);
            lightCoolDown -= 1 * Time.deltaTime;
        }
        if (lightCoolDown < 0)
            lightCoolDown = 0;




        //**directional combat**

        //facing right
        if (self.GetComponent<PlayerMovement>().moveX > 0)
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(true);

        }

        //facing left
        if (self.GetComponent<PlayerMovement>().moveX < 0)
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(true);
            right.SetActive(false);

        }

        //facing up
        if (self.GetComponent<PlayerMovement>().moveY > 0)
        {
            up.SetActive(true);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);

        }

        //facing down
        if (self.GetComponent<PlayerMovement>().moveY < 0)
        {
            up.SetActive(false);
            down.SetActive(true);
            left.SetActive(false);
            right.SetActive(false);
        }
    }

    //de-activating smokeChild

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.tag == "Smoke" && chargeDistance <= 0)
        {
            smokeChild.SetActive(false);
        }
    }
    //charge shot calculations

    public void SetEnergy(float myEnergy)
    {
        energyBar.transform.localScale = new Vector3(myEnergy, energyBar.transform.localScale.y, energyBar.transform.localScale.z);
    }
    //fire cooldown calculations
    public void CoolDownFire(float Fire)
    {
        CoolDownImageFire.transform.localScale = new Vector3(CoolDownImageFire.transform.localScale.x, calculator4, CoolDownImageFire.transform.localScale.z);
    }
    //cooldown for restoration
    public void CoolDownRestore(float Restorex)
    {
        CoolDownImageRestore.transform.localScale = new Vector3(CoolDownImageRestore.transform.localScale.x, calculator3, CoolDownImageRestore.transform.localScale.z);
    }
    //cooldown for shield
    public void CoolDownShield(float Sheildx)
    {
        CoolDownImageShield.transform.localScale = new Vector3(CoolDownImageShield.transform.localScale.x, calculator2, CoolDownImageShield.transform.localScale.z);
    }
    //cooldown for shield
    public void CoolDownLight(float Lightx)
    {
        CoolDownImageLight.transform.localScale = new Vector3(CoolDownImageLight.transform.localScale.x, calculator4, CoolDownImageLight.transform.localScale.z);
    }
}