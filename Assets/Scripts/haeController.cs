﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haeController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    private int life;

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

        if(life <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "yumiya" || col.tag == "Bullet" || col.tag == "Burner")
        {
            life -= 3;

        }

    }
}
