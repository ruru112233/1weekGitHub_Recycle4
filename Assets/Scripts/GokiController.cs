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
        
        life = 8;

    }



    private void FixedUpdate()
    {
        if (moveEnemy.isSearchG)
        {
            moveEnemy.GokiSearch();
        }

        if( life < 3)
        {
            //Debug.Log("確認");
            moveEnemy.speedG = 10;

        }

        if (life <= 0)
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
