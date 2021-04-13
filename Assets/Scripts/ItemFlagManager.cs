using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlagManager : MonoBehaviour
{
    public bool item1 = false; // 着火装置
    public bool item2 = false; // 油
    public bool item3 = false; // 鉄くず
    public bool item4 = false; // ガス缶

    public bool wpnItem1 = false; // ガスバーナー

    private void Update()
    {
        if (item1 && item4)
        {
            wpnItem1 = true;
        }
        else
        {
            wpnItem1 = false;
        }
    }

}
