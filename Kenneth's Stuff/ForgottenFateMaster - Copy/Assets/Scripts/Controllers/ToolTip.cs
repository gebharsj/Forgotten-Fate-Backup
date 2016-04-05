using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ToolTip : MonoBehaviour 
{
    public GameObject _ToolTip;
    public GameObject _player;
    [HideInInspector]
    public AudioSource au_click;
    public Text _ToolTipName;
    public Text _ToolTipDesc;
    public Text _ToolTipAttri;


    public GameObject _defense;
    public GameObject _stamina;
    public GameObject _spell;
    public GameObject _armor;
    public GameObject _damage;
    public GameObject _health;
    public GameObject _dexterity;
    public GameObject _criticalChance;
    int shuffle = 0;

    Vector3 spellScale;
    Vector3 spellScaledUp;
    Vector3 damageScale;
    Vector3 damageScaledUp;

    void Start()
    {
        spellScale = new Vector3(_spell.transform.localScale.x, _spell.transform.localScale.y, 0f);
        spellScaledUp = new Vector3(_spell.transform.localScale.x + 0.10f, _spell.transform.localScale.y + 0.10f, 0f);
        damageScale = new Vector3(_damage.transform.localScale.x, _damage.transform.localScale.y, 0f);
        damageScaledUp = new Vector3(_damage.transform.localScale.x + 0.10f, _damage.transform.localScale.y + 0.10f, 0f);
        au_click = gameObject.AddComponent<AudioSource>();
        AudioClip click;

        // Resources must be in any folder named Resources.  load as type and cast as type because Unity returns Object by default.
        click = (AudioClip)Resources.Load("Audio/UISounds/click4", typeof(AudioClip));
        au_click.clip = click;

    }
    void Update()
    {
        if (shuffle == 1)
        {
            Damage2();
        }
        if (shuffle == 2)
        {
            spell2();
        }
    }

    public void ArmorTipOff()
    {
        //if (_ToolTip.active)
        _ToolTip.SetActive(false);
        au_click.Play();
        _armor.transform.localScale = new Vector3(_armor.transform.localScale.x - 0.10f, _armor.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void LuckTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _criticalChance.transform.localScale = new Vector3(_criticalChance.transform.localScale.x - 0.10f, _criticalChance.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void HealthTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _health.transform.localScale = new Vector3(_health.transform.localScale.x - 0.10f, _health.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void StaminaTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _stamina.transform.localScale = new Vector3(_stamina.transform.localScale.x - 0.10f, _stamina.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void DefenseTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _defense.transform.localScale = new Vector3(_defense.transform.localScale.x - 0.10f, _defense.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void DamageTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _damage.transform.localScale = damageScale;
        shuffle = 0;
    }

    public void SpellTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _spell.transform.localScale = spellScale;
        shuffle = 0;
    }

    public void DexterityTipOff()
    {
        _ToolTip.SetActive(false);
        au_click.Play();
        _dexterity.transform.localScale = new Vector3(_dexterity.transform.localScale.x - 0.10f, _dexterity.transform.localScale.y - 0.10f, 0f);
        shuffle = 0;
    }

    public void ArmorTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Armor";
        _ToolTipDesc.text = "The amount of damage that is reduced.";
        _ToolTipAttri.text = "Armor: " + _player.GetComponent<CombatScript>().armor;
        _armor.transform.localScale = new Vector3(_armor.transform.localScale.x + 0.10f, _armor.transform.localScale.y + 0.10f, 0f);
    }

    public void LuckTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Luck";
        _ToolTipDesc.text = "The chances of landing a critical hit and the amount of damage caused by critical hit.";
        _ToolTipAttri.text = "Critical Chance:      " + _player.GetComponent<CombatScript>().criticalChance * 100 + "%" + " \tCritical Damage: " + _player.GetComponent<CombatScript>().criticalDamage + "00%";
        _criticalChance.transform.localScale = new Vector3(_criticalChance.transform.localScale.x + 0.10f, _criticalChance.transform.localScale.y + 0.10f, 0f);
    }

    public void HealthTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Vitality";
        _ToolTipDesc.text = "The maximum amount of health.";
        _ToolTipAttri.text = "Health: " + _player.GetComponent<CombatScript>().maxHealth;
        _health.transform.localScale = new Vector3(_health.transform.localScale.x + 0.10f, _health.transform.localScale.y + 0.10f, 0f);
    }
    public void StaminaTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Agility";
        _ToolTipDesc.text = "The maximum amount of stamina and the speed at which is travled.";
        _ToolTipAttri.text = "Stamina: " + _player.GetComponent<PlayerMovement>().maxStamina + "              \tSpeed:    " + _player.GetComponent<PlayerMovement>().speed + " - " + _player.GetComponent<PlayerMovement>().speed * _player.GetComponent<PlayerMovement>().sprint;
        _stamina.transform.localScale = new Vector3(_stamina.transform.localScale.x + 0.10f, _stamina.transform.localScale.y + 0.10f, 0f); ;
    }

    public void DefenseTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Defense";
        _ToolTipDesc.text = "Decreases the chances by which you are hit.";
        _ToolTipAttri.text = "Defense: " + _player.GetComponent<CombatScript>().defense;
        _defense.transform.localScale = new Vector3(_defense.transform.localScale.x + 0.10f, _defense.transform.localScale.y + 0.10f, 0f);
    }

    public void DamageTipOn()
    {

        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Damage";
        _ToolTipDesc.text = "The minimum to maximum amount of damage dealt to enemies.";
        _damage.transform.localScale = damageScaledUp;
        shuffle = 1;

    }
    public void Damage2()
    {
        if (_player.GetComponent<CombatScript>().melee == true)
            _ToolTipAttri.text = "Melee Damage: " + _player.GetComponent<CombatScript>().normalDamage * 0.7f + " - " + _player.GetComponent<CombatScript>().normalDamage;
        else
            _ToolTipAttri.text = "Range Damage: " + _player.GetComponent<CombatScript>().rangeDamage * 0.7f + " - " + _player.GetComponent<CombatScript>().rangeDamage + "\tFully Charged: " + _player.GetComponent<CombatScript>().rangeDamage + " - " + _player.GetComponent<CombatScript>().rangeDamage * 2;
    }

    public void SpellTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Magic";
        _ToolTipDesc.text = "The potential of your current equiped spell.";
        shuffle = 2;
    }
    public void spell2()
    {

        if (_player.GetComponent<CombatScript>().spells == 0)
            _ToolTipAttri.text = "Fire Damage: " + _player.GetComponent<CombatScript>().fireDamage;
        if (_player.GetComponent<CombatScript>().spells == 1)
            _ToolTipAttri.text = "Restores health: + " + _player.GetComponent<CombatScript>().healthRestore;
        if (_player.GetComponent<CombatScript>().spells == 2)
            _ToolTipAttri.text = "Absorbs Damage: +" + _player.GetComponent<CombatScript>().shield;
        if (_player.GetComponent<CombatScript>().spells == 3)
            _ToolTipAttri.text = "Shock Damage: " + _player.GetComponent<CombatScript>().lightDamage;
        _spell.transform.localScale = spellScaledUp;
    }

    public void DexterityTipOn()
    {
        _ToolTip.SetActive(true);
        au_click.Play();
        _ToolTipName.text = "Dexterity";
        _ToolTipDesc.text = "Increases the chances of hitting your foes.";
        _ToolTipAttri.text = "Dexterity: " + _player.GetComponent<CombatScript>().dexterity;
        _dexterity.transform.localScale = new Vector3(_dexterity.transform.localScale.x + 0.10f, _dexterity.transform.localScale.y + 0.10f, 0f);
    }
}