using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "경계_위":
                Destroy(gameObject);
                break;
            case "경계_아래":
                Destroy(gameObject);
                break;
            case "경계_좌":
                Destroy(gameObject);
                break;
            case "경계_우":
                Destroy(gameObject);
                break;
            case "박스":
                Destroy(gameObject);
                break;
        }
    }
}
