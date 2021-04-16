using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBurner : MonoBehaviour
{
    public GameObject burnerPrefab;
    public Transform burnerPoint;

    GameObject player;

    // Start is called before the first frame update
    void Start()
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject burnerObj = GameObject.FindGameObjectWithTag("Burner");

            if (burnerObj == null)
            {
                AudioManager.instance.PlaySE(3);
                //Instantiate(burnerPrefab, new Vector3(burnerPoint.transform.position.x, burnerPrefab.transform.position.y, 0), Quaternion.identity);
                Instantiate(burnerPrefab, burnerPoint);

                StartCoroutine(DelTime());
            }
            
        }
    }

    IEnumerator DelTime()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject burnerObj = GameObject.FindGameObjectWithTag("Burner");

        Destroy(burnerObj);
    }
}
