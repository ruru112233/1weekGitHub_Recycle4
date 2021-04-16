using UnityEngine;
using System.Collections;

public class SearchCharacterH : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("発見");
            if (moveEnemy.speedH < 40)
            {
                moveEnemy.speedH += 4;

            }
        }

    }
}