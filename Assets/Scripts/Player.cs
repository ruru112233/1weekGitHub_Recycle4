using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        if (!GameManager.instance.itemListFlag && !GameManager.instance.wpnFlag)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // 左右移動
            if (x > 0)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.rightFlag = true;
            }

            if (x < 0)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.leftFlag = true;
            }


            // 上下移動
            if (y > 0)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.upFlag = true;
            }

            if (y < 0)
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.downFlag = true;
            }
        }

    }
}
