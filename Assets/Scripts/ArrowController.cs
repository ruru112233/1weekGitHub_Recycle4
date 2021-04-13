using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ItemText");

        /*
        if (objs.Length > 1)
        {
            //GameObject.Destroy(objs[1].transform.GetChild(0).gameObject);
        }
        */
    }

}
