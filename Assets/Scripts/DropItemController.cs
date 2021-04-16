using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemController : MonoBehaviour
{
    public string itemName;
    public int itemId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySE(0);
            GameObject itemText = Instantiate(GameManager.instance.itemText) as GameObject;
            itemText.GetComponent<Text>().text = itemName;
            itemText.GetComponent<SelectebleText>().itemId = itemId;
            itemText.transform.parent = GameManager.instance.itemPanel.transform.GetChild(2).GetChild(0).GetChild(0);
            itemText.SetActive(true);

            Destroy(gameObject);
        }
    }
}
