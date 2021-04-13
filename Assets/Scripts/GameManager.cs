using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject itemPanel;
    public GameObject wpnPanel;

    public ItemManager item;
    public ItemManager wpnItem;

    public SelectItem selectItem;
    public SyntheticController synthetic;
    public ItemSprite itemSprite;
    private ItemFlagManager itemFlagManager;

    public GameObject itemText;

    // アイテム一覧表示/非表示のフラグ
    public bool itemListFlag = false;
    public bool itemFlag2 = false;
    bool itemSelectFlag = true;

    // 武器一覧表示/非表示
    public bool wpnFlag = false;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        itemPanel.SetActive(false);
        wpnPanel.SetActive(false);

        itemFlagManager = GameObject.Find("ItemFlagManager").GetComponent<ItemFlagManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // 取得アイテム一覧を表示/非表示にするキー
        if (Input.GetKeyDown(KeyCode.I))
        {
            itemListFlag = !itemListFlag;

            // アイテム一覧を閉じた時に、矢印を削除する。
            DestroyArrow();

            itemPanel.SetActive(itemListFlag);

            wpnFlag = false;
            wpnPanel.SetActive(wpnFlag);
            itemFlag2 = true;
        }

        // 武器一覧を表示/非表示にするキー
        if (Input.GetKeyDown(KeyCode.U))
        {
            wpnFlag = !wpnFlag;

            // アイテム一覧を閉じた時に、矢印を削除する。
            itemListFlag = false;
            DestroyArrow();

            wpnPanel.SetActive(wpnFlag);
            itemPanel.SetActive(itemListFlag);
        }


        // spaceでアイテムを選択
        if (itemListFlag)
        {
            if (itemSelectFlag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    int currentId = selectItem.currentId;

                    if (synthetic.synthetic1Id == 0)
                    {

                        GameObject item1 = selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).gameObject;
                        synthetic.synthetic1Id = item1.GetComponent<SelectebleText>().itemId;
                        synthetic.transform.GetChild(0).GetComponent<Image>().sprite = ChengeSprite(synthetic.synthetic1Id);
                        ItemCheck(synthetic.synthetic1Id);
                        Destroy(item1);
                        //selectItem.NewSelectItem();
                        StartCoroutine(SelectAction());
                    }
                    else if (synthetic.synthetic2Id == 0)
                    {

                        GameObject item2 = selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).gameObject;
                        synthetic.synthetic2Id = item2.GetComponent<SelectebleText>().itemId;
                        synthetic.transform.GetChild(1).GetComponent<Image>().sprite = ChengeSprite(synthetic.synthetic2Id);
                        ItemCheck(synthetic.synthetic2Id);
                        Destroy(item2);
                        StartCoroutine(SelectAction());
                    }
                }
            }
        }

        IEnumerator SelectAction()
        {
            itemSelectFlag = false;
            yield return new WaitForSeconds(0.3f);
            itemSelectFlag = true;
            selectItem.NewSelectItem();
        }

        // 合成可能な組み合わせの場合、決定ボタンで合成する
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (itemFlagManager.wpnItem1)
            {
                GameObject wpnText = Instantiate(GameManager.instance.itemText) as GameObject;
                wpnText.GetComponent<Text>().text = wpnItem.itemList[0].itemName;
                wpnText.transform.parent = wpnPanel.transform.GetChild(2).GetChild(0).GetChild(0);
                wpnText.SetActive(true);
            }
        }

    }

    // 合成アイテムの判定
    void ItemCheck(int itemId)
    {
        switch (itemId)
        {
            case 1:
                itemFlagManager.item1 = true;
                break;
            case 2:
                itemFlagManager.item2 = true;
                break;
            case 3:
                itemFlagManager.item3 = true;
                break;
            case 4:
                itemFlagManager.item4 = true;
                break;
        }
    }

    void DestroyArrow()
    {
        itemPanel.SetActive(true);
        if (!itemListFlag)
        {
            GameObject arrowObj = GameObject.FindGameObjectWithTag("Arrow");
            Destroy(arrowObj);
        }
    }

    // Spriteを切り替える
    Sprite ChengeSprite(int syntheicId)
    {
        Sprite chengeSprite = itemSprite.sprites[syntheicId - 1];

        return chengeSprite;
    }
}
