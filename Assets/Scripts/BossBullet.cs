using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private const int SPEED = 10; //弾の速さ

    private Rigidbody2D _rb;
    private Transform _tf;
    private float time;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tf = this.transform;

        // 弾を上に移動させる
        _rb.velocity = _tf.right.normalized * SPEED;
        time = 0;
    }

    private void Update()
    {
        
        time += Time.deltaTime;
        if (time > 1)
        {
            Destroy(this.gameObject);
        }
    }

}
