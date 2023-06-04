using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class weapon_skill : MonoBehaviour
{
    SpriteRenderer rend;

    public Player player;
    public JoyStick joystick;

    public Vector3 followPos;
    public Transform player_tf;
    public GameObject bulletObj;

    public float bullet_speed;
    private Rigidbody2D rigid;

    public float fireRate = 0.5f;
    private float nextFire;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Watch();
        Follow();
        Fire();
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
            transform.position = new Vector3(x + 0.7f, y + -0.35f, 0);
        }
        else if (joystick.JoyVec.x < 0)
        {
            rend.flipX = true;
            transform.rotation = Quaternion.Euler(0f, 0f, z - 180f);
            transform.position = new Vector3(x - 0.7f, y + -0.35f, 0);
        }
    }
    public void Fire()
    {
        Vector2 dir = joystick.JoyVec.normalized;

        if (Input.GetKey("a") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (dir.x != 0 && dir.y != 0)
            {
                GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = dir * bullet_speed;
            }
        }
    }

}


