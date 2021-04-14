using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokiController : MonoBehaviour
{

    private MoveEnemy moveEnemy;

    // Start is called before the first frame update
    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.isSearchG = true;
        moveEnemy.speedG = 2;
        moveEnemy.searchDistanceG = 2;

    }

    

    private void FixedUpdate()
    {
        if (moveEnemy.isSearchG)
        {
            moveEnemy.GokiSearch();
        }

    }
}
