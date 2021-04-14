using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haeController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    int life;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isSearchH = true;
        moveEnemy.speedH = 2;
        moveEnemy.searchDistanceH = 2;
        life = 5;
    }



    private void FixedUpdate()
    {
        if (moveEnemy.isSearchH)
        {
            moveEnemy.HaeSearch();
        }

        if(life == 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        life -= 1;
        Debug.Log("ダメージ! 残りHP"+ life);
    }
}
