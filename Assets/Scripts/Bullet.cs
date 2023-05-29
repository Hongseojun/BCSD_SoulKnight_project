using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed = 10f;
    private float lifetime = 5f;
    private float spawnTime;

    public JoyStick joystick;

    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        transform.position += new Vector3(0, bullet_speed * Time.deltaTime, 0);
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "°æ°è")
        {
            Destroy(gameObject);
        }
    }
}
