using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    public Slider bossSlider;

    int MaxLife;
    int nowLife;

    public Animator anime;

    [SerializeField]
    private GameObject _burret; 

    private Transform _tf;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isBattleB = false;
        moveEnemy.speedB = 8;
        moveEnemy.searchDistanceB = 25;
        MaxLife = 30;
        nowLife = MaxLife;

        bossSlider = GameObject.Find("EnemySlider").GetComponent<Slider>();

        bossSlider.maxValue = MaxLife;
        bossSlider.value = nowLife;

        _tf = this.transform;

    }

    private void Update()
    {
        if (nowLife <= 0)
        {
            nowLife = 0;
            GameManager.instance.enemySlider.SetActive(false);
            GameManager.instance.clearPanel.SetActive(true);
            AudioManager.instance.PlayBGM(1);
            Destroy(this.gameObject);
        }
        bossSlider.value = nowLife;
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
        //nowLife -= 1;
        //Debug.Log("ダメージ! 残りHP" + nowLife);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Burner" || other.gameObject.tag == "Yumiya" || other.gameObject.tag == "Bullet")
        {
            nowLife -= 1;
            Debug.Log("ダメージ! 残りHP" + nowLife);
        }
    }

    public void Shot()
    {
        anime.SetTrigger("Shot");
        StartCoroutine(ShotWaitTime());
    }

    IEnumerator ShotWaitTime()
    {
        yield return new WaitForSeconds(0.5f);

        // 弾をプレイヤーと同じ位置/角度で作成
        Instantiate(_burret, _tf.position, _tf.rotation);
    }

}
