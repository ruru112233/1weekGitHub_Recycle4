using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumiController : MonoBehaviour
{
    public GameObject yumiya;
    public Transform firePoint;

    public float waitCount;
    float waitTime = 0;
    bool waitFlag = false;

    public int speed;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y - 1, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.upFlag)
        {
            transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y + 1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (GameManager.instance.downFlag)
        {
            transform.position = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y - 1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (GameManager.instance.rightFlag)
        {
            transform.position = new Vector3(player.transform.position.x + 1f, player.transform.position.y + 0.2f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (GameManager.instance.leftFlag)
        {
            transform.position = new Vector3(player.transform.position.x - 1f, player.transform.position.y - 0.2f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        // 弓矢が連射出来ないように制御する
        if (waitFlag)
        {
            waitTime += Time.deltaTime;

            if (waitTime > waitCount)
            {
                waitFlag = false;
                waitTime = 0;
            }
        }

        // 弓矢の発射
        if (Input.GetKeyDown(KeyCode.G))
        {
            waitFlag = true;

            if (waitTime == 0)
            {
                AudioManager.instance.PlaySE(3);
                GameObject yumiyaPrefab = Instantiate(yumiya) as GameObject;

                Vector3 force = this.gameObject.transform.up * -speed;

                if (GameManager.instance.upFlag)
                {
                    yumiyaPrefab.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else if (GameManager.instance.downFlag)
                {
                    yumiyaPrefab.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (GameManager.instance.rightFlag)
                {
                    yumiyaPrefab.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (GameManager.instance.leftFlag)
                {
                    yumiyaPrefab.transform.rotation = Quaternion.Euler(0, 0, 270);
                }

                yumiyaPrefab.GetComponent<Rigidbody2D>().AddForce(force);
                yumiyaPrefab.transform.position = firePoint.position;
            }

        }
    }

}
