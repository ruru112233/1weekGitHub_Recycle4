using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{


    //ゴキ
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

    //ハエ
    public float speedK;
    public bool isSearchK;
    public int searchDistanceK;
    bool isRightUpK;
    bool isRightDownK;
    bool isLeftUpK;
    bool isLeftDownK;
    float startPositionYK;
    float nowPositionK;
    int countRightK;
    int countLeftK;

    //ボス
    public float speedB;
    public bool isBattleB;
    public int searchDistanceB;
    bool isUpB;
    bool isDownB;
    bool isRightB;
    bool isLeftB;
    float startPositionYB;
    float startPositionXB;
    float nowPositionB;
    int bossRightCount; 

    void Start()
    {
        //ゴキ
        isUpG = true;
        isDownG = false;
        isLeftG = false;
        isRightG = false;
        startPositionYG = transform.position.y;
        startPositionXG = transform.position.x;
        //ハエ
        isRightUpH = true;
        isRightDownH = false;
        isLeftUpH = false;
        isLeftDownH = false;
        startPositionYH = transform.position.y;
        countRight = 0;
        countLeft = 0;
        //蜘蛛
        isRightUpK = true;
        isRightDownK = false;
        isLeftUpK = false;
        isLeftDownK = false;
        startPositionYK = transform.position.y;
        countRightK = 0;
        countLeftK = 0;
        //ボス
        isRightB = true;
        isDownB = false;
        isLeftB = false;
        isUpB = false;
        bossRightCount = 0;
        startPositionYB = transform.position.y;
        startPositionXB = transform.position.x;

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
            {
                transform.position += new Vector3(0, speedG * Time.deltaTime, 0);
            }
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
            {
                transform.position += new Vector3(speedG * Time.deltaTime, 0, 0);
            }
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
            if (nowPositionG - startPositionYG > -searchDistanceG)
            {
                transform.position += new Vector3(0, -speedG * Time.deltaTime, 0);
            }
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
            if (nowPositionG - startPositionXG > -searchDistanceG)
            {
                transform.position += new Vector3(-speedG * Time.deltaTime, 0, 0);
            }
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
            {
                transform.position += new Vector3(speedH * Time.deltaTime, speedH * Time.deltaTime, 0);
            }
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
            {
                transform.position += new Vector3(speedH * Time.deltaTime, -speedH * Time.deltaTime, 0);
            }
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
            {
                transform.position += new Vector3(-speedH * Time.deltaTime, speedH * Time.deltaTime, 0);
            }
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
            {
                transform.position += new Vector3(-speedH * Time.deltaTime, -speedH * Time.deltaTime, 0);
            }
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
    //蜘蛛見回り
    public void kumoSearch()
    {
        if (isRightUpK)
        {
            nowPositionK = transform.position.y;
            //Debug.Log("右上");
            if (nowPositionK - startPositionYK < searchDistanceK)
            {
                transform.position += new Vector3(speedK * Time.deltaTime, speedK * Time.deltaTime, 0);
            }
            else
            {
                startPositionYK = transform.position.y;
                isRightUpK = false;
                isRightDownK = true;
            }
        }
        if (isRightDownK)
        {
            //Debug.Log("右下");
            nowPositionK = transform.position.y;
            if (nowPositionK - startPositionYK > -searchDistanceK)
            {
                transform.position += new Vector3(speedK * Time.deltaTime, -speedK * Time.deltaTime, 0);
            }
            else
            {
                startPositionYK = transform.position.y;
                if (countRightK == 0)
                {
                    countRightK = 1;
                    isRightDownK = false;
                    isRightUpK = true;

                }
                else
                {
                    countRightK = 0;
                    isRightDownK = false;
                    isLeftUpK = true;
                }

            }
        }
        if (isLeftUpK)
        {
            //Debug.Log("左上");
            nowPositionK = transform.position.y;
            if (nowPositionK - startPositionYK < searchDistanceK)
            {
                transform.position += new Vector3(-speedK * Time.deltaTime, speedK * Time.deltaTime, 0);
            }
            else
            {
                startPositionYK = transform.position.y;
                isLeftUpK = false;
                isLeftDownK = true;
            }
        }
        if (isLeftDownK)
        {
            //Debug.Log("左下");
            nowPositionK = transform.position.y;
            if (nowPositionK - startPositionYK > -searchDistanceK)
            {
                transform.position += new Vector3(-speedK * Time.deltaTime, -speedK * Time.deltaTime, 0);
            }
            else
            {
                startPositionYK = transform.position.y;
                if (countLeftK == 0)
                {
                    countLeftK = 1;
                    isLeftDownK = false;
                    isLeftUpK = true;

                }
                else
                {
                    countLeftK = 0;
                    isLeftDownK = false;
                    isRightUpK = true;
                }
            }
        }
    }

    //ボス
    public void BossBattle()
    {
        if (isRightB)
        {
            if(bossRightCount == 0)
            {

                //Debug.Log("右１回目");
                nowPositionB = transform.position.x;
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
                if (nowPositionB - startPositionXB < searchDistanceB / 2)
                {
                    transform.position += new Vector3(speedB * Time.deltaTime, 0, 0);
                }
                else
                {
                    bossRightCount = 1;
                    startPositionYB = transform.position.y;
                    isRightB = false;
                    isDownB = true;
                }
            }
            else
            {
                //Debug.Log("右2回目");
                nowPositionB = transform.position.x;
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
                if (nowPositionB - startPositionXB < searchDistanceB)
                {
                    transform.position += new Vector3(speedB * Time.deltaTime, 0, 0);
                }
                else
                {
                    startPositionYB = transform.position.y;
                    isRightB = false;
                    isDownB = true;
                }
            }
            
        }
        if (isDownB)
        {
            //Debug.Log("下");
            nowPositionB = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, -180f);
            if (nowPositionB - startPositionYB > -searchDistanceB)
            {
                transform.position += new Vector3(0, -speedB * Time.deltaTime, 0);
            }
            else
            {
                startPositionXB = transform.position.x;
                isDownB = false;
                isLeftB = true;
            }
        }
        if (isLeftB)
        {
            //Debug.Log("左");
            nowPositionB = transform.position.x;
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            if (nowPositionB - startPositionXB > -searchDistanceB)
            {
                transform.position += new Vector3(-speedB * Time.deltaTime, 0, 0);
            }
            else
            {
                startPositionYB = transform.position.y;
                isLeftB = false;
                isUpB = true;
            }
        }
        if (isUpB)
        {
            //Debug.Log("上");
            nowPositionB = transform.position.y;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (nowPositionB - startPositionYB < searchDistanceB)
            {
                transform.position += new Vector3(0, speedB * Time.deltaTime, 0);
            }
            else
            {
                startPositionXB = transform.position.x;
                isUpB = false;
                isRightB = true;
            }
        }
    }

}
