using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlagManager : MonoBehaviour
{
    public bool item1 = false; // ライター
    public bool item2 = false; // 鉄くず
    public bool item3 = false; // ガス缶
    public bool item4 = false; // 

    public bool wpnItem1 = false; // ガスバーナー
    public bool wpnItem2 = false; // 火縄銃

    private void Update()
    {
        if (item1 && item3)
        {
            wpnItem1 = true;
        }
        else if (item1 && item2)
        {
            wpnItem2 = true;
        }
        else
        {
            wpnItem1 = false;
            wpnItem2 = false;
        }
    }

}
