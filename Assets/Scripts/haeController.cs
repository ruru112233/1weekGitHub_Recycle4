using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haeController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    public int life;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isSearchH = true;
        life = 8;
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
        if (col.tag == "Yumiya" || col.tag == "Bullet" || col.tag == "Burner")
        {
            life -= 3;

            Debug.Log("ダメージ"+ life);

        }
    }
    
}
