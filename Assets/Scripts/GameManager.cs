using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UseTime usetime;
    public GameObject skill;
    public GameObject cooltime;
    public GameObject weapon_skill;
    public GameObject player;
    public GameObject weapon_shark;
    public GameObject weapon;
    public GameObject attack;
    public GameObject inter;
    public GameObject weapon_shark_Obj;
    public GameObject weapon_Obj;
    public TextMeshProUGUI mana_use;

    public bool skill_use;
    public bool weapon_earn;
    public bool weapon_use;
    public bool weapon_shark_use;



    void Start()
    {
        weapon_shark_Obj.GetComponent<weapon_shark>().enabled = false;
        skill_use = false;
        weapon_earn = false;
        cooltime.SetActive(true);
        weapon_shark.SetActive(false);
        weapon.SetActive(true);
        attack.SetActive(true);
        inter.SetActive(false);
        weapon_shark_Obj.SetActive(true);
        weapon_Obj.SetActive(true);
        weapon_use = true;
        mana_use.text = "1";
    }

    void Update()
    {
        Skill();
        Skill_Start();
        Weapon_Earn();
    }

    void Skill()
    {
        if (skill_use == true)
        { 
            skill.SetActive(true);
            weapon_skill.transform.position = player.transform.position;
            weapon_skill.SetActive(true);
        }
        if (skill_use == false)
        {
            skill.SetActive(false);
            weapon_skill.SetActive(false);
        }
    }

    void Skill_Start()
    {
        float left_t = usetime.leftTime;

        if (left_t > 0)
        {
            skill_use = true;
            cooltime.SetActive(true);
        }
        else
        {
            skill_use = false;
            cooltime.SetActive(false);
        }
    }

    public void Weapon_change()
    {
        if (weapon_earn ==  true)
        {
            if (weapon_use == true)
            {
                weapon_shark_Obj.SetActive(true);
                weapon_Obj.SetActive(false);
                weapon.SetActive(false);
                weapon_shark.SetActive(true);
                weapon_use = false;
                weapon_shark_use = true;
                mana_use.text = "2";
                weapon_shark_Obj.GetComponent<weapon_shark>().enabled = true;
                weapon_Obj.GetComponent<weapon>().enabled = false;
            }

            else if (weapon_shark_use == true)
            {
                weapon_shark_Obj.SetActive(false);
                weapon_Obj.SetActive(true);
                weapon.SetActive(true);
                weapon_shark.SetActive(false);
                weapon_use = true;
                weapon_shark_use = false;
                mana_use.text = "1";
                weapon_shark_Obj.GetComponent<weapon_shark>().enabled = false;
                weapon_Obj.GetComponent<weapon>().enabled = true;
            }
        }
    }

    void Weapon_Earn()
    {
        bool isT = player.GetComponent<Player>().isTouch_Weapon_shark;
        if ( isT == true)
        {
            attack.SetActive(false);
            inter.SetActive(true);
        }
        else if (isT == false)
        {
            attack.SetActive(true);
            inter.SetActive(false);
        }
    }

    public void Weapon_get()
    {
        weapon_earn = true;
        weapon_shark_Obj.SetActive(false);
    }
}
