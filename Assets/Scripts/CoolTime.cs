using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime2;
    public float speed;
    public float leftTime2;

    void Update()
    {
        if (leftTime2 > 0)
        {
            leftTime2 -= Time.deltaTime * speed;
            float ratio = 1 - (leftTime2 / coolTime2);
            image.fillAmount = ratio;
        }
        else if (leftTime2 < 0)
        {
            leftTime2 = 0;
        }
    }

    public void StartCoolTime()
    {
        leftTime2 = coolTime2;
    }
}
