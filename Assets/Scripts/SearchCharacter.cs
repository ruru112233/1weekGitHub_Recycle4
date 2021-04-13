using UnityEngine;
using System.Collections;

public class SearchCharacter : MonoBehaviour
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
            Debug.Log("発見");
            moveEnemy.isSearch = false;
            moveEnemy.isChase = true;
        }
        
    }
}