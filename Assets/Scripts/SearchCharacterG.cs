using UnityEngine;
using System.Collections;

public class SearchCharacterG : MonoBehaviour
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
            if (moveEnemy.speedG < 40)
            {
                moveEnemy.speedG += 2;

            }
        }
    }
}