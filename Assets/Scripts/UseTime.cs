using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UseTime : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime;
    public bool isClicked = false;
    public float speed;
    public float leftTime;

    void Update()
    {
        if (isClicked)
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if (leftTime < 0)
                {
                    leftTime = 0;
                    if (button)
                    {
                        button.enabled = true;
                    }
                    isClicked = true;
                }

                float ratio = 0 + (leftTime / coolTime);

                if (image)
                    image.fillAmount = ratio;
            }
    }

    public void StartCoolTime()
    {
        leftTime = coolTime;
        isClicked = true;
        if (button)
        {
            button.enabled = false;
        }

    }
}