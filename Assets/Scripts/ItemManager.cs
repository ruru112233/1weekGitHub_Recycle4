using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemList")]
public class ItemManager : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}

[System.Serializable]
public class Item
{
    public int itemId;
    public string itemName;
    public int dropItemId1;
    public string dropItemName1;
    public GameObject dropPrefab1;
    public int dropItemId2;
    public string dropItemName2;
    public GameObject dropPrefab2;
}


