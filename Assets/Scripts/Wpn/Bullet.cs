using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 上に発射
        if (player.transform.position.x > transform.position.x && player.transform.position.y < transform.position.y)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        // 下に発射
        if (player.transform.position.x < transform.position.x && player.transform.position.y > transform.position.y)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        // 右に発射
        if (player.transform.position.x < transform.position.x && player.transform.position.y < transform.position.y)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        // 左に発射
        if (player.transform.position.x > transform.position.x && player.transform.position.y > transform.position.y)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        */

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
