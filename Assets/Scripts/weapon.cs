using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    Animator anim;
    Image image;
    SpriteRenderer rend;

    Color color;

    public Player player;
    public JoyStick joystick;

    public Vector3 followPos;
    public Transform player_tf;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Watch();
        Follow();
        //TurnAngle();
    }
    void Watch()
    {

        followPos = player_tf.position;
    }

    void Follow()
    {
        Vector2 dir = joystick.JoyVec.normalized;

        float x = followPos.x;
        float y = followPos.y;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (joystick.JoyVec.x > 0)
        {
            rend.flipX = false;
            transform.rotation = Quaternion.Euler(0f, 0f, z);
            transform.position = new Vector3(x + 0.3f, y + -0.35f, 0);
        }
        else if (joystick.JoyVec.x < 0)
        {
            rend.flipX = true;
            transform.rotation = Quaternion.Euler(0f, 0f, z - 180f);
            transform.position = new Vector3(x - 0.3f, y + -0.35f, 0);
        }
    }

    void TurnAngle()
    {
        Vector2 dir = joystick.JoyVec.normalized;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (-100 <= z && z <= 100)
        {
            rend.flipX = false;
            transform.rotation = Quaternion.Euler(0f, 0f, z);
        }
        else
        {
            rend.flipX = true;
            transform.rotation = Quaternion.Euler(0f, 0f, z - 180f);
        }

    }

    }


