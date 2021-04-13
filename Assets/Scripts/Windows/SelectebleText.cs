using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectebleText : Selectable
{
    public UnityAction<Transform> OnSelectItem = null;

    // ドロップアイテムのID
    public int itemId = 0;

    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.GetComponent<Text>().text}が選択された");

        OnSelectItem.Invoke(transform);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnDeselect(eventData);
        Debug.Log($"{GetComponent<Text>().text}の選択が外れた");
    }

}
