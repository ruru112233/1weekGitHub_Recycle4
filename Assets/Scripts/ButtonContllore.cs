using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContllore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySE(2);
            GameManager.instance.doorFlag = true;
            
            Destroy(gameObject);
        }
    }
}
