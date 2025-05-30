using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectScene : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _FadeTime = 1f;

    void Start()
    {
        var _CanvasGroup = _object.GetComponent<CanvasGroup>();
            _CanvasGroup.alpha = 0f;
            _CanvasGroup.DOFade(1f, _FadeTime).OnComplete(() =>
            {
                //DODelay(2f);
            });
    }
}
