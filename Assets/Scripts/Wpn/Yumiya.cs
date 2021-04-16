using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yumiya : DelTime
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Kumonosu")
        {
            Destroy(gameObject);
        }
    }
}
