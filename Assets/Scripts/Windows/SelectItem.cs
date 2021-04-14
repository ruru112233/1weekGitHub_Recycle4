using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    // 矢印のプレハブ
    [SerializeField] GameObject arrowObj;
    // 矢印を生成した後の位置
    [SerializeField] Transform arrow = default;

    [SerializeField] List<SelectebleText> selectableTexts = new List<SelectebleText>();

    // 取得アイテムの要素番号
    public int currentId;

    void SetMoveArrowFunction()
    {
        foreach (SelectebleText selectableText in selectableTexts)
        {
            selectableText.OnSelectItem = MoveArrowTo;
        }

        // 最初に何を選択状態にするのか。
        EventSystem.current.SetSelectedGameObject(selectableTexts[0].gameObject);
    }


    // カーソルの移動をする：親を変更する
    public void MoveArrowTo(Transform parent)
    {
        // Debug.Log("カーソル移動");
        arrow.SetParent(parent);

        // GetSiblingIndexは、親からみて何番目の要素か？
        currentId = parent.GetSiblingIndex();
    }


    private void Update()
    {
        if (GameManager.instance.itemFlag2)
        {
            NewSelectItem();

            GameManager.instance.itemFlag2 = false;
        }
    }

    public void NewSelectItem()
    {

        // 一旦全て削除する
        selectableTexts.Clear();

        
        

        // アイテムテキストを全て取得
        GameObject[] itemsObj = GameObject.FindGameObjectsWithTag("ItemText");

        // アイテムを１つでも所持していた場合
        if (itemsObj.Length != 0)
        {
            // 取得したアイテムテキストをselectebleTextリストへ格納
            foreach (GameObject selectebleText in itemsObj)
            {
                selectableTexts.Add(selectebleText.GetComponent<SelectebleText>());
            }

            // 矢印を生成し、一番上の選択肢に矢印を付ける
            GameObject arrowObj = Instantiate(this.arrowObj);
            arrowObj.transform.parent = itemsObj[0].transform;

            // 矢印をSelectItemのarrow変数へ代入
            this.arrow = GameObject.FindGameObjectWithTag("Arrow").transform;

            // 関数を実行
            SetMoveArrowFunction();
        }
        
    }

}
