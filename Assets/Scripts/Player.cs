using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int Player_curHp;
    public int Player_maxHp;
    public int Player_curShield;
    public int Player_maxShield;
    public int Player_curMp;
    public int Player_maxMp;
    public int Player_Gold;
    public JoyStick joystick;

    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = joystick.JoyVec.x;
        float v = joystick.JoyVec.y;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (joystick.JoyVec.x != 0 || joystick.JoyVec.y != 0)
        {
            anim.SetInteger("Input", 1);
        }
        else
        {
            anim.SetInteger("Input", 0);
        }

        if(h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
