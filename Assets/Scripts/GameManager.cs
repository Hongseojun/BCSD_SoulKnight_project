using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UseTime usetime;
    public GameObject skill;
    public GameObject cooltime;
    public GameObject weapon_skill;
    public GameObject player;

    public bool skill_use;

    void Awake()
    {
        skill_use = false;
        cooltime.SetActive(true);
    }

    void Update()
    {
        Skill();
        Skill_Start();
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
}
