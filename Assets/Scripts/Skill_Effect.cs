using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Effect : MonoBehaviour
{
    Animator anim;
    Image image;

    Color color;

    public Player player;
    public JoyStick joystick;

    public Vector3 followPos;
    public Transform parent;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Watch();
        Follow();
    }
    void Watch()
    {

        followPos = parent.position;
    }

    void Follow()
    {
        float x = followPos.x;
        float y = followPos.y;
        if (joystick.JoyVec.x > 0)
        {
            transform.position = new Vector3(x + 0.2f, y + 0.35f, 0);
        }
        else if (joystick.JoyVec.x < 0)
        {
            transform.position = new Vector3(x - 0.2f, y + 0.35f, 0);
        }
        else
        {
            transform.position = new Vector3(x, y + 0.35f, 0);
        }
    }
}
