using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kumoBullet : MonoBehaviour
{
    

    void Awake()
    {
        
    }

    private void Update()
    {

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.tag == "Bullet" || col.tag == "Burner")
        {
            Destroy(this.gameObject);

        }

    }
}
