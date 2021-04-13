using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject itemPanel;

    public ItemManager item;

    public SelectItem selectItem;
    public SyntheticController synthetic;
    public ItemSprite itemSprite;

    public GameObject dropItem1, dropItem2;
    public GameObject itemText;

    // アイテム一覧表示/非表示のフラグ
    public bool itemListFlag = false;
    public bool itemFlag2 = false;

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
    }

    // Update is called once per frame
    void Update()
    {

        // 取得アイテム一覧を表示/非表示にするキー
        if (Input.GetKeyDown(KeyCode.I))
        {
            itemListFlag = !itemListFlag;

            // アイテム一覧を閉じた時に、矢印を削除する。
            if (!itemListFlag)
            {
                GameObject arrowObj = GameObject.FindGameObjectWithTag("Arrow");
                Destroy(arrowObj);
            }

            itemPanel.SetActive(itemListFlag);
            itemFlag2 = true;
        }

        // spaceでアイテムを選択
        if (itemListFlag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int currentId = selectItem.currentId;
                Debug.Log(selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).GetComponent<Text>().text);

                if (synthetic.synthetic1Id == 0)
                {
                    synthetic.synthetic1Id = selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).GetComponent<SelectebleText>().itemId;
                    synthetic.transform.GetChild(0).GetComponent<Image>().sprite = ChengeSprite(synthetic.synthetic1Id);
                }
                else if (synthetic.synthetic2Id == 0)
                {
                    synthetic.synthetic2Id = selectItem.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(currentId).GetComponent<SelectebleText>().itemId;
                    synthetic.transform.GetChild(1).GetComponent<Image>().sprite = ChengeSprite(synthetic.synthetic2Id);
                }
            }
        }

    }

    // Spriteを切り替える
    Sprite ChengeSprite(int syntheicId)
    {
        Sprite chengeSprite = itemSprite.sprites[syntheicId - 1];

        return chengeSprite;
    }
}
