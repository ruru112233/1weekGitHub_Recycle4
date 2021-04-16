using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kumoController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    private int life;

    [SerializeField]
    private GameObject _burret;

    private Transform _tf;


    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isSearchK = true;
        moveEnemy.speedK = 2;
        moveEnemy.searchDistanceK = 2;
        life = 5;
    }



    private void FixedUpdate()
    {
        if (moveEnemy.isSearchK)
        {
            moveEnemy.kumoSearch();
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
    public void ShotK()
    {
        // 弾をプレイヤーと同じ位置/角度で作成
        Instantiate(_burret, _tf.position, _tf.rotation);
    }
}
