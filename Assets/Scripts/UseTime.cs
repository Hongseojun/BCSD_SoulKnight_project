using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UseTime : MonoBehaviour
{
    public Image image;
    public Button button;
    public float speed;
    public float leftTime;
    public float leftTime2;
    public float coolTime;
    public float coolTime2;

    void Update()
    {
        if (leftTime > 0)
        {
            StartUseFill();
        }
        else if (leftTime < 0)
        {
            Invoke("StartCoolTime", 0.5f);
            leftTime = 0;
        }

        if (leftTime2 > 0)
        {
            StartCoolFill();
        }
        else if (leftTime2 < 0)
        {
            leftTime2 = 0;
            if (button)
            {
                button.enabled = true;
            }
        }
    }

    public void StartUseTime()
    {
        leftTime = coolTime;
        if (button)
        {
            button.enabled = false;
        }

    }

    void StartCoolTime()
    {
        leftTime2 = coolTime2;
    }

    void StartUseFill()
    {
        leftTime -= Time.deltaTime * speed;
        float ratio = 0 + (leftTime / coolTime);
        image.fillAmount = ratio;
    }

    void StartCoolFill()
    {
        leftTime2 -= Time.deltaTime * speed;
        float ratio = 1 - (leftTime2 / coolTime2);
        image.fillAmount = ratio;
    }
}