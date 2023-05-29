using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UseTime usetime;
    public GameObject skill;

    public bool skill_use;

    void Awake()
    {
        skill_use = false;
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
        }
        if (skill_use == false)
        {
            skill.SetActive(false);
        }
    }

    void Skill_Start()
    {
        float left_t = usetime.leftTime;
        if (left_t > 0)
        {
            skill_use = true;
        }
        else
        {
            skill_use = false;
        }

    }
}
