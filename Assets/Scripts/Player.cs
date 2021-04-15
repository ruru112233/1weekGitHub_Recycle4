using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Animator anime;

    private void Start()
    {
        anime = transform.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.itemListFlag && !GameManager.instance.wpnFlag)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // 左右移動
            if (x > 0)
            {
                MoveAnime("rightMoveFlag");
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.rightFlag = true;
            }

            if (x < 0)
            {
                MoveAnime("leftMoveFlag");
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.leftFlag = true;
            }


            // 上下移動
            if (y > 0)
            {
                MoveAnime("upMoveFlag");
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.upFlag = true;
            }

            if (y < 0)
            {
                MoveAnime("downMoveFlag");
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                GameManager.instance.HinawajyuOffFlag();
                GameManager.instance.downFlag = true;
            }

            // 移動していない時はアイドル状態となる
            if (x == 0 && y == 0)
            {
                MoveAnime("idleFlag");
            }
        }

    }

    // プレイヤーのアニメーション
    void MoveAnime(string flagName)
    {
        anime.SetBool("idleFlag", false);
        anime.SetBool("upMoveFlag", false);
        anime.SetBool("downMoveFlag", false);
        anime.SetBool("leftMoveFlag", false);
        anime.SetBool("rightMoveFlag", false);

        anime.SetBool(flagName ,true);

    }
}
