using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    Animator anime;

    Slider slider;

    int maxHp = 5;
    int nowHp = 5;

    private void Start()
    {
        anime = transform.GetComponent<Animator>();
        slider = GameObject.Find("PlayerSlider").GetComponent<Slider>();
        slider.maxValue = maxHp;
        slider.value = nowHp;
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.itemListFlag && 
            !GameManager.instance.wpnFlag &&
            GameManager.instance.moveFlag)
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

        // プレイヤーのHP
        slider.value = nowHp;

        if (nowHp == 0)
        {
            nowHp = -1;
            GameManager.instance.enemySlider.SetActive(false);
            AudioManager.instance.PlayBGM(2);
            GameManager.instance.gameOverPanel.SetActive(true);
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        nowHp -= 1;
        anime.SetTrigger("damage");
        AudioManager.instance.PlaySE(7);
        GameManager.instance.moveFlag = false;

        yield return new WaitForSeconds(0.6f);

        GameManager.instance.moveFlag = true;
    }
}
