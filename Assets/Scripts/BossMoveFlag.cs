using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveFlag : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    private void Start()
    {
       moveEnemy = GameObject.Find("Boss").GetComponent<MoveEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.enemySlider.SetActive(true);
            AudioManager.instance.PlayBGM(0);
            moveEnemy.isBattleB = true;
        }
    }
}
