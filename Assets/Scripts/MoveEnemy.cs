using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{


    //ゴキ
    GameObject goik;
    public float speedG;
    public bool isSearchG;
    public int searchDistanceG;
    bool isUpG;
    bool isDownG;
    bool isRightG;
    bool isLeftG;
    float startPositionYG;
    float startPositionXG;
    float nowPositionG;

    //ハエ
    public float speedH;
    public bool isSearchH;
    public int searchDistanceH;
    bool isRightUpH;
    bool isRightDownH;
    bool isLeftUpH;
    bool isLeftDownH;
    float startPositionYH;
    float nowPositionH;
    int countRight;
    int countLeft;

    void Start()
    {
        //ゴキ
        isSearchG = true;
        isUpG = true;
        isDownG = false;
        isLeftG = false;
        isRightG = false;
        startPositionYG = transform.position.y;
        startPositionXG = transform.position.x;
        //ハエ
        isSearchH = true;
        isRightUpH = true;
        isRightDownH = false;
        isLeftUpH = false;
        isLeftDownH = false;
        startPositionYH = transform.position.y;
        countRight = 0;
        countLeft = 0;
    }



    
    //ゴキ見回り
    public void GokiSearch()
    {
        if (isUpG)
        {
            //Debug.Log("上");
            nowPositionG = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            if (nowPositionG - startPositionYG < searchDistanceG)
                transform.position += new Vector3(0, speedG * Time.deltaTime, 0);
            else
            {
                startPositionXG = transform.position.x;
                isUpG = false;
                isRightG = true;
            }
        }
        if (isRightG)
        {
            //Debug.Log("右");
            nowPositionG = transform.position.x;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (nowPositionG - startPositionXG < searchDistanceG)
                transform.position += new Vector3(speedG* Time.deltaTime, 0, 0);
            else
            {
                startPositionYG = transform.position.y;
                isRightG = false;
                isDownG = true;
            }
        }
        if (isDownG)
        {
            //Debug.Log("下");
            nowPositionG = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, -90f);
            if (nowPositionG - startPositionYG > -searchDistanceG )
                transform.position += new Vector3(0, -speedG * Time.deltaTime, 0);
            else
            {
                startPositionXG = transform.position.x;
                isDownG = false;
                isLeftG = true;
            }
        }
        if (isLeftG)
        {
            //Debug.Log("左");
            nowPositionG = transform.position.x;
            transform.eulerAngles = new Vector3(0f, 0f, -180f);
            if (nowPositionG - startPositionXG > -searchDistanceG )
                transform.position += new Vector3(-speedG * Time.deltaTime, 0, 0);
            else
            {
                startPositionYG = transform.position.y;
                isLeftG = false;
                isUpG = true;
            }
        }
    }

    //ハエ見回り
    public void HaeSearch()
    {
        if (isRightUpH)
        {
            nowPositionH = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, 45f);
            //Debug.Log("右上");
            if (nowPositionH - startPositionYH < searchDistanceH)
                transform.position += new Vector3(speedH * Time.deltaTime, speedH * Time.deltaTime, 0);
            else
            {
                startPositionYH = transform.position.y;
                isRightUpH = false;
                isRightDownH = true;
            }
        }
        if (isRightDownH)
        {
            //Debug.Log("右下");
            nowPositionH = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, -45f);
            if (nowPositionH - startPositionYH > -searchDistanceH)
                transform.position += new Vector3(speedH * Time.deltaTime, -speedH * Time.deltaTime, 0);
            else
            {
                startPositionYH = transform.position.y;
                if(countRight == 0)
                {
                    countRight = 1;
                    isRightDownH = false;
                    isRightUpH = true;

                }
                else
                {
                    countRight = 0;
                    isRightDownH = false;
                    isLeftUpH = true;
                }
                
            }
        }
        if (isLeftUpH)
        {
            //Debug.Log("左上");
            nowPositionH = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, 135f);
            if (nowPositionH - startPositionYH < searchDistanceH)
                transform.position += new Vector3(-speedH * Time.deltaTime, speedH * Time.deltaTime, 0);
            else
            {
                startPositionYH = transform.position.y;
                isLeftUpH = false;
                isLeftDownH = true;
            }
        }
        if (isLeftDownH)
        {
            //Debug.Log("左下");
            nowPositionH = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, -135f);
            if (nowPositionH - startPositionYH > -searchDistanceH)
                transform.position += new Vector3(-speedH * Time.deltaTime, -speedH * Time.deltaTime, 0);
            else
            {
                startPositionYH = transform.position.y;
                if (countLeft == 0)
                {
                    countLeft = 1;
                    isLeftDownH = false;
                    isLeftUpH = true;

                }
                else
                {
                    countLeft = 0;
                    isLeftDownH = false;
                    isRightUpH = true;
                }
            }
        }
    }

}
