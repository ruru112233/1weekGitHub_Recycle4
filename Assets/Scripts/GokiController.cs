using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokiController : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    private int life;


    // Start is called before the first frame update
    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isSearchG = true;
        moveEnemy.speedG = 2;
        moveEnemy.searchDistanceG = 2;
        life = 5;

    }



    private void FixedUpdate()
    {
        if (moveEnemy.isSearchG)
        {
            moveEnemy.GokiSearch();
        }

        if (life == 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        life -= 1;
        Debug.Log("ダメージ! 残りHP" + life);
    }
}
