using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBurner : MonoBehaviour
{
    public GameObject burnerPrefab;
    public Transform burnerPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Instantiate(burnerPrefab, new Vector3(burnerPoint.transform.position.x, burnerPrefab.transform.position.y, 0), Quaternion.identity);
            Instantiate(burnerPrefab, burnerPoint);

            StartCoroutine(DelTime());
        }
    }

    IEnumerator DelTime()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject burnerObj = GameObject.Find("GasuBana_Fire1");

        Destroy(burnerObj);
    }
}
