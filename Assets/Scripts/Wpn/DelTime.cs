using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelTime : MonoBehaviour
{
    private float delTimer = 0;

    public float DelTimer
    {
        get { return delTimer; }
        set { delTimer = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        DelTimer += Time.deltaTime;

        Debug.Log(DelTimer);

        if (DelTimer >= 2)
        {
            Destroy(gameObject);
        }
    }
}
