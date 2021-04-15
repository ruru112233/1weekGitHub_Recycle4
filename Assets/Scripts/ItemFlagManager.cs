using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlagManager : MonoBehaviour
{
    public bool item1 = false; // ライター
    public bool item2 = false; // 鉄くず
    public bool item3 = false; // ガス缶
    public bool item4 = false; // 木の棒
    public bool item5 = false; // 植物のつる
    public bool item5_1 = false; // 植物のつるが2つ選択された時
    public bool item6 = false; // 縄

    public bool wpnItem1 = false; // ガスバーナー
    public bool wpnItem2 = false; // 火縄銃
    public bool wpnItem3 = false; // 弓

    private void Update()
    {
        if (item1 && item3)
        {
            wpnItem1 = true;
        }
        else if (item4 && item5)
        {
            wpnItem3 = true;
        }
        else if (item6 && item2)
        {
            wpnItem2 = true;
        }
        else
        {
            wpnItem1 = false;
            wpnItem2 = false;
            wpnItem3 = false;
        }
    }

    public void OffFlag()
    {
        item1 = false; // ライター
        item2 = false; // 鉄くず
        item3 = false; // ガス缶
        item4 = false; // 木の棒
        item5 = false; // 植物のつる
        item5_1 = false; // 植物のつるが2つ選択されえた時
        item6 = false; // 縄

        wpnItem1 = false; // ガスバーナー
        wpnItem2 = false; // 火縄銃
        wpnItem3 = false; // 弓
    }

}
