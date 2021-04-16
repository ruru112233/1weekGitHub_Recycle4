using UnityEngine;
using System.Collections;

public class SearchCharacterK : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    private kumoController kumoController;


    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        kumoController = GetComponentInParent<kumoController>();


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("発見");
            kumoController.ShotK();
        }

    }
}