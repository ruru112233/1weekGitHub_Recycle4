using UnityEngine;
using System.Collections;

public class SearchCharacterB : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    private BossController bossController;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        bossController = GetComponentInParent<BossController>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("発見");
            bossController.Shot();

        }
        
    }
}