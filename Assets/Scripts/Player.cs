using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

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

    public bool isTouch_up;
    public bool isTouch_down;
    public bool isTouch_left;
    public bool isTouch_right;
    public bool isTouch_Weapon_shark;
    public bool isTouch_box;

    public JoyStick joystick;
    public Transform FirePos;
    public Button button;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "경계_위":
                isTouch_up = true;
                break;
            case "경계_아래":
                isTouch_down = true;
                break;
            case "경계_좌":
                isTouch_left = true;
                break;
            case "경계_우":
                isTouch_right = true;
                break;
            case "박스":
                isTouch_box = true;
                break;
        }

        if (collision.gameObject.tag == "무기_상어")
        {
            isTouch_Weapon_shark = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "무기_상어")
        {
            isTouch_Weapon_shark = false;
        }
        if (collision.gameObject.tag == "박스")
        {
            isTouch_box = false;
        }
    }

    void Move()
    {
        float h = joystick.JoyVec.x;
        float v = joystick.JoyVec.y;

        if (isTouch_up == true && v > 0)
        {
            v = 0;
        }
        else if (isTouch_down == true && v < 0)
        {
            v = 0;
        }
        else if (isTouch_left == true && h < 0)
        {
            h = 0;
        }
        else if (isTouch_right == true && h > 0)
        {
            h = 0;
        }
        else if(isTouch_box == true)
        {

        }
        else
        {
            isTouch_up = false;
            isTouch_down = false;
            isTouch_left = false;
            isTouch_right = false;

            Vector3 curPos = transform.position;
            Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

            transform.position = curPos + nextPos;
        }

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
