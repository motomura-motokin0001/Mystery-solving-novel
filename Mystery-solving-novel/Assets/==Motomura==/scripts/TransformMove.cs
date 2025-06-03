using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformMove : MonoBehaviour
{
    [SerializeField] private RectTransform _TargetRectTransform;
    [SerializeField] private Vector2 _ViewPosition;
    [SerializeField] private Vector2 _HidePosition;
    private bool IsView = false;

    void Start()
    {
        _TargetRectTransform.anchoredPosition = _HidePosition; // 初期位置を非表示位置に設定
    }

    public void View_Hide()
    {
        IsView = !IsView; // 表示状態をトグル
        if (IsView)
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

    public void View_Hide_NotAnimation()
    {
        IsView = !IsView; // 表示状態をトグル
        if (IsView)
        {
            // 表示位置に移動
            _TargetRectTransform.anchoredPosition = _ViewPosition;
        }
        else
        {
            // 非表示位置に移動
            _TargetRectTransform.anchoredPosition = _HidePosition;
        }
    }
}
