using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveFlag : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    Camera camera;

    private void Start()
    {
        moveEnemy = GameObject.Find("Boss").GetComponent<MoveEnemy>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera.orthographicSize = 15;
            GameManager.instance.enemySlider.SetActive(true);
            AudioManager.instance.PlayBGM(0);
            moveEnemy.isBattleB = true;
        }
    }
}
