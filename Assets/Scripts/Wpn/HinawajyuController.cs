using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinawajyuController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    public int speed;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GameManager.instance.upFlag)
        {
            transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y + 1, 0);
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        else if(GameManager.instance.downFlag)
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
            transform.position = new Vector3(player.transform.position.x - 1f, player.transform.position.y -0.2f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }


        // 銃弾の発射
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject bulletPrefab = Instantiate(bullet) as GameObject;

            Vector3 force = this.gameObject.transform.up * -speed;

            bulletPrefab.GetComponent<Rigidbody2D>().AddForce(force);
            bulletPrefab.transform.position = firePoint.position;

        }
    }
}
