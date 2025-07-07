using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] private GameObject _CountdownPopup;
    [SerializeField] private float _CountdownTime = 3f; // (M)
    [SerializeField] private string _GoalText = "クリア条件";
    [SerializeField] private TextMeshProUGUI _GoalTextUI;
    [SerializeField] private TextMeshProUGUI _TimeTextUI;
    private bool _StartTimer = false;

    private void Start()
    {
        _CountdownPopup.SetActive(false);
        _TimeTextUI.text = "制限時間: " + _CountdownTime.ToString() + "分";
        _GoalTextUI.text = _GoalText;
    }


    // Update is called once per frame
    public void PopUp()
    {
        _CountdownPopup.SetActive(true);
        _CountdownPopup.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);
    }

    public void StartTimer()
    {
        _StartTimer = true;
        _CountdownPopup.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);
    }
    
    private void Update()
    {
        if (_StartTimer)
        {
            _CountdownTime -= Time.deltaTime;
            if (_CountdownTime <= 0)
            {
                _CountdownTime = 0;
                _StartTimer = false;
                _CountdownPopup.SetActive(false);
            }
            _TimeTextUI.text = "制限時間: " + Mathf.CeilToInt(_CountdownTime).ToString() + "秒";
        }
    }
}
