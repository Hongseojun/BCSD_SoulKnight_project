using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Bar : MonoBehaviour
{
    public Player player;
    public GameObject HP_Bar;
    public GameObject Shield_Bar;
    public GameObject MP_Bar;

    void Start()
    {
        HpBar();
        ShieldBar();
        MpBar();
    }

    void Update()
    {

    }

    void HpBar()
    {
        HP_Bar.transform.localScale = new Vector3(2.28f / player.Player_maxHp, 0.25f, 0);
        for (int i = 0; i < player.Player_curHp; i++)
        {
            GameObject hp_bar = Instantiate(HP_Bar, new Vector2((i * 2.28f / player.Player_maxHp) + (-9.1f), 4.547f), transform.rotation);
            hp_bar.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        }
    }

    void ShieldBar()
    {
        Shield_Bar.transform.localScale = new Vector3(2.28f / player.Player_maxShield, 0.25f, 0);
        for (int i = 0; i < player.Player_curShield; i++)
        {
            GameObject shield_bar = Instantiate(Shield_Bar, new Vector2((i * 2.28f / player.Player_maxShield) + (-9.08f), 4.135f), transform.rotation);
            shield_bar.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        }
    }

    void MpBar()
    {
        MP_Bar.transform.localScale = new Vector3(2.28f / player.Player_maxMp, 0.25f, 0);
        for (int i = 0; i < player.Player_curMp; i++)
        {
            GameObject mp_bar = Instantiate(MP_Bar, new Vector2((i * 2.28f / player.Player_maxMp) + (-9.26f), 3.742f), transform.rotation);
            mp_bar.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        }
    }
}