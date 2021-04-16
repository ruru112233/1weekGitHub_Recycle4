using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemId;
    public int hPos1;
    public int vPos1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // ドロップアイテムの生成
            GameObject item1 = Instantiate(GameManager.instance.item.itemList[itemId - 1].dropPrefab1);
            item1.transform.position = new Vector3(transform.position.x + hPos1, transform.position.y + vPos1, 0);
            item1.GetComponent<DropItemController>().itemName = GameManager.instance.item.itemList[itemId - 1].dropItemName1;
            item1.GetComponent<DropItemController>().itemId = GameManager.instance.item.itemList[itemId - 1].dropItemId1;

            AudioManager.instance.PlaySE(0);

            /*
            GameObject item2 = Instantiate(GameManager.instance.item.itemList[itemId - 1].dropPrefab2);
            item2.transform.position = new Vector3(transform.position.x + hPos2, transform.position.y + vPos2, 0);
            item2.GetComponent<DropItemController>().itemName = GameManager.instance.item.itemList[itemId - 1].dropItemName2;
            item2.GetComponent<DropItemController>().itemId = GameManager.instance.item.itemList[itemId - 1].dropItemId2;
            */

            // アイテムボックスを削除
            Destroy(gameObject);
        }
    }
}
