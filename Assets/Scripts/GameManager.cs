using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject itemPanel;
    public GameObject wpnPanel;
    public GameObject syntheticPanel;

    public GameObject clearPanel, gameOverPanel;

    public ItemManager item;
    public ItemManager wpnItem;

    public SelectItem selectItem;
    public SelectItem selectWpn;
    public SyntheticController synthetic;
    public ItemSprite itemSprite;
    private ItemFlagManager itemFlagManager;

    public GameObject itemText;
    public GameObject wpnText;

    // 火縄銃の上下左右フラグ
    public bool upFlag = false;
    public bool downFlag = false;
    public bool rightFlag = false;
    public bool leftFlag = false;

    // アイテム一覧表示/非表示のフラグ
    public bool itemListFlag = false;
    public bool itemFlag2 = false;
    bool itemSelectFlag = true;

    // 武器一覧表示/非表示
    public bool wpnFlag = false;
    public bool wpnFlag2 = false;
    public bool wpnSelectFlag = false;

    // テキスト操作
    public GameObject wpnActionText;

    // プレイヤーの操作制御
    public bool moveFlag = true;

    // ドアの制御
    public bool doorFlag = false;

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
        syntheticPanel.SetActive(false);
        wpnActionText.SetActive(false);
        clearPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        moveFlag = true;

        itemFlagManager = GameObject.Find("ItemFlagManager").GetComponent<ItemFlagManager>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyAction();
    }

    // キー操作
    void KeyAction()
    {
        // 取得アイテム一覧を表示/非表示にするキー
        if (Input.GetKeyDown(KeyCode.I) && !wpnFlag)
        {
            itemListFlag = !itemListFlag;

            // アイテム一覧を閉じた時に、矢印を削除する。
            DestroyArrow();

            itemPanel.SetActive(itemListFlag);
            syntheticPanel.SetActive(itemListFlag);

            wpnFlag = false;
            wpnPanel.SetActive(wpnFlag);
            itemFlag2 = true;
        }

        // 武器一覧を表示/非表示にするキー
        if (Input.GetKeyDown(KeyCode.U) && !itemListFlag)
        {
            wpnFlag = !wpnFlag;

            // アイテム一覧を閉じた時に、矢印を削除する。
            DestroyArrow();

            wpnPanel.SetActive(wpnFlag);
            //selectItem.NewSelectItem();

            itemListFlag = false;
            itemPanel.SetActive(itemListFlag);
            wpnFlag2 = true;
        }

        // spaceでアイテムを選択
        if (itemListFlag)
        {
            if (itemSelectFlag)
            {
                GameObject[] itemsObj = GameObject.FindGameObjectsWithTag("ItemText");
                int currentId = selectItem.currentId;

                if (Input.GetKeyDown(KeyCode.Space) && itemsObj.Length != 0)
                {
                    if (synthetic.synthetic1Id == 0)
                    {
                        GameObject item1 = selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).gameObject;
                        synthetic.synthetic1Id = item1.GetComponent<SelectebleText>().itemId;
                        synthetic.transform.GetChild(0).GetComponent<Image>().sprite = ChengeSprite(synthetic.synthetic1Id);
                        ItemCheck(synthetic.synthetic1Id);
                        Destroy(item1);
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

        // 合成可能な組み合わせの場合、決定ボタンで合成する
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!itemFlagManager.item5_1)
            {
                if (itemFlagManager.wpnItem1)
                {
                    // ガスバーナー
                    WpnText(0);
                    ItemGousei();
                }

                if (itemFlagManager.wpnItem2)
                {
                    // 火縄銃
                    WpnText(1);
                    ItemGousei();
                }

                if (itemFlagManager.wpnItem3)
                {
                    // 弓
                    WpnText(2);
                    ItemGousei();
                }
            }
            else
            {
                // 縄を生成する。
                GameObject itemText = Instantiate(GameManager.instance.itemText) as GameObject;
                itemText.GetComponent<Text>().text = itemSprite.itemName[5];
                itemText.GetComponent<SelectebleText>().itemId = 6;
                itemText.transform.parent = itemPanel.transform.GetChild(2).GetChild(0).GetChild(0);
                itemText.SetActive(true);
                synthetic.transform.GetChild(0).GetComponent<Image>().sprite = null;
                synthetic.synthetic1Id = 0;
                synthetic.transform.GetChild(1).GetComponent<Image>().sprite = null;
                synthetic.synthetic2Id = 0;

                // 矢印を削除する
                GameObject arrowObj1 = GameObject.FindGameObjectWithTag("Arrow");

                Destroy(arrowObj1);

                StartCoroutine(SelectAction());

                itemFlagManager.OffFlag();
            }

        }

        // 合成をキャンセルする
        if (Input.GetKeyDown(KeyCode.C))
        {
            ItemCancel();
        }

        // 武器を装備する
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject[] wpnTexts = GameObject.FindGameObjectsWithTag("WpnText");
            GameObject[] wpnObjs = GameObject.FindGameObjectsWithTag("Wpn");

            // 全ての色を変更する
            foreach (GameObject obj in wpnTexts) obj.GetComponent<Text>().color = Color.white;

            // 装備品を一旦削除する
            foreach (GameObject wpnObj in wpnObjs) Destroy(wpnObj);

            // 武器を１つでも所持していた場合
            if (wpnTexts.Length != 0)
            {
                int itemId = selectWpn.currentId;
                WpnEquipment(wpnTexts[itemId - 1].GetComponent<SelectebleText>().itemId - 1);
                wpnTexts[itemId - 1].GetComponent<Text>().color = Color.yellow;

                WpnSelectAction();
            }
        }
    }

    // キャンセルする時
    public void ItemCancel()
    {

        if (synthetic.synthetic1Id != 0)
        {
            GameObject itemText = Instantiate(GameManager.instance.itemText) as GameObject;
            itemText.GetComponent<Text>().text = itemSprite.itemName[synthetic.synthetic1Id - 1];
            itemText.GetComponent<SelectebleText>().itemId = synthetic.synthetic1Id;
            itemText.transform.parent = GameManager.instance.itemPanel.transform.GetChild(2).GetChild(0).GetChild(0);
            itemText.SetActive(true);
            synthetic.transform.GetChild(0).GetComponent<Image>().sprite = null;
            synthetic.synthetic1Id = 0;
        }

        if (synthetic.synthetic2Id != 0)
        {
            GameObject itemText = Instantiate(GameManager.instance.itemText) as GameObject;
            itemText.GetComponent<Text>().text = itemSprite.itemName[synthetic.synthetic2Id - 1];
            itemText.GetComponent<SelectebleText>().itemId = synthetic.synthetic2Id;
            itemText.transform.parent = GameManager.instance.itemPanel.transform.GetChild(2).GetChild(0).GetChild(0);
            itemText.SetActive(true);
            synthetic.transform.GetChild(1).GetComponent<Image>().sprite = null;
            synthetic.synthetic2Id = 0;
        }

        // 矢印を削除する
        GameObject arrowObj1 = GameObject.FindGameObjectWithTag("Arrow");

        Destroy(arrowObj1);

        StartCoroutine(SelectAction());

        itemFlagManager.OffFlag();
    }

    // アイテムが合成された時
    void ItemGousei()
    {
        if (synthetic.synthetic1Id != 0)
        {
            synthetic.transform.GetChild(0).GetComponent<Image>().sprite = null;
            synthetic.synthetic1Id = 0;
        }

        if (synthetic.synthetic2Id != 0)
        {
            synthetic.transform.GetChild(1).GetComponent<Image>().sprite = null;
            synthetic.synthetic2Id = 0;
        }

        itemFlagManager.OffFlag();
    }

    // 武器の装備
    void WpnEquipment(int itemId)
    {
        wpnActionText.SetActive(true);
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(wpnItem.itemList[itemId].itemPrefab, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
    }

    IEnumerator SelectAction()
    {
        itemSelectFlag = false;
        yield return new WaitForSeconds(0.3f);
        itemSelectFlag = true;
        selectItem.NewSelectItem();
    }

    IEnumerator WpnSelectAction()
    {
        wpnSelectFlag = false;
        yield return new WaitForSeconds(0.3f);
        wpnSelectFlag = true;
        selectItem.NewSelectItem();
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
            case 5:
                if (!itemFlagManager.item5)
                {
                    itemFlagManager.item5 = true;
                }
                else
                {
                    itemFlagManager.item5_1 = true;
                }
                break;
            case 6:
                itemFlagManager.item6 = true;
                break;
        }
    }

    // 合成アイテムのテキストを生成
    void WpnText(int id)
    {
        GameObject wpnText = Instantiate(this.wpnText) as GameObject;
        wpnText.GetComponent<Text>().text = wpnItem.itemList[id].itemName;
        wpnText.GetComponent<SelectebleText>().itemId = wpnItem.itemList[id].itemId;
        wpnText.transform.parent = wpnPanel.transform.GetChild(2).GetChild(0).GetChild(0);
        wpnText.SetActive(true);
    }

    void DestroyArrow()
    {
        if (!itemListFlag)
        {
            itemPanel.SetActive(true);
            GameObject[] arrowsObj = GameObject.FindGameObjectsWithTag("Arrow");

            foreach (GameObject arrowObj in arrowsObj)
            {
                Destroy(arrowObj);
            }

        }

        if (!wpnFlag)
        {
            wpnPanel.SetActive(true);
            GameObject[] arrowsObj = GameObject.FindGameObjectsWithTag("Arrow");

            foreach (GameObject arrowObj in arrowsObj)
            {
                Destroy(arrowObj);
            }
        }
    }

    // Spriteを切り替える
    Sprite ChengeSprite(int syntheicId)
    {
        Sprite chengeSprite = itemSprite.sprites[syntheicId - 1];

        return chengeSprite;
    }

    // 火縄銃のFlag操作
    public void HinawajyuOffFlag()
    {
        upFlag = false;
        downFlag = false;
        rightFlag = false;
        leftFlag = false;
}
}
