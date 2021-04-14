using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinawajyuController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        // 銃弾の発射
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(bullet, firePoint);
        }
    }
}
