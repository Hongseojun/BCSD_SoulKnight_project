using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "���_��":
                Destroy(gameObject);
                break;
            case "���_�Ʒ�":
                Destroy(gameObject);
                break;
            case "���_��":
                Destroy(gameObject);
                break;
            case "���_��":
                Destroy(gameObject);
                break;
            case "�ڽ�":
                Destroy(gameObject);
                break;
        }
    }
}
