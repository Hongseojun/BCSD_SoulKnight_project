using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Effect : MonoBehaviour
{
    private bool state;

    Animator anim;
    UseTime usetime;
    Image image;

    Color color;
    public Player player;

    void Start()
    {
        state = false;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 spotpos = player.transform.position;
        float h = spotpos.x;
        float v = spotpos.y;
        float speed = 6;

        
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (state == true)
        {
            color.a = 255;
            image.color = color;
        }
        else if (state == false)
        {
            color.a = 0;
            image.color = color;
        }
    }
    public void skill_start()
    {
        float left_t = usetime.leftTime;
        if (left_t > 0)
        {
            state = true;
        }
        else
        {
            state = false;
        }
    }
}
