using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformMove : MonoBehaviour
{
    [SerializeField] private RectTransform _TargetRectTransform;
    [SerializeField] private Vector2 _ViewPosition;
    [SerializeField] private Vector2 _HidePosition;
    public static bool InventoryIsView = false;

    void Start()
    {
        _TargetRectTransform.anchoredPosition = _HidePosition; // 初期位置を非表示位置に設定
    }

    public void View_Hide()
    {
        InventoryIsView = !InventoryIsView; // 表示状態をトグル
        if (InventoryIsView)
        {
            // 表示位置に移動
            _TargetRectTransform.DOAnchorPos(_ViewPosition, 0.5f);
        }
        else
        {
            // 非表示位置に移動
            _TargetRectTransform.DOAnchorPos(_HidePosition, 0.5f);
        }
    }
}
