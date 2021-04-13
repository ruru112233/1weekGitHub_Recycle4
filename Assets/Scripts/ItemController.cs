using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // ドロップアイテムの生成
            GameObject item1 = Instantiate(GameManager.instance.dropItem1);
            item1.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            item1.GetComponent<DropItemController>().itemName = GameManager.instance.item.itemList[itemId - 1].dropItemName1;
            item1.GetComponent<DropItemController>().itemId = GameManager.instance.item.itemList[itemId - 1].dropItemId1;

            GameObject item2 = Instantiate(GameManager.instance.dropItem2);
            item2.transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
            item2.GetComponent<DropItemController>().itemName = GameManager.instance.item.itemList[itemId - 1].dropItemName2;
            item2.GetComponent<DropItemController>().itemId = GameManager.instance.item.itemList[itemId - 1].dropItemId2;


            // アイテムボックスを削除
            Destroy(gameObject);
        }
    }
}
