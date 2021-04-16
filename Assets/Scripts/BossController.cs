using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    int life;

    [SerializeField]
    private GameObject _burret; 

    private Transform _tf;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isBattleB = true;
        moveEnemy.speedB = 8;
        moveEnemy.searchDistanceB = 25;
        life = 5;

        _tf = this.transform;

    }

    private void Update()
    {
        if (life <= 0)
        {
            life = 0;
            GameManager.instance.clearPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }


    private void FixedUpdate()
    {
        if (moveEnemy.isBattleB)
        {
            moveEnemy.BossBattle();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        life -= 1;
        Debug.Log("ダメージ! 残りHP" + life);
    }
    public void Shot()
    {
        // 弾をプレイヤーと同じ位置/角度で作成
        Instantiate(_burret, _tf.position, _tf.rotation);
    }

}
