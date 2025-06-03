using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//＝＝＝＝メイン画面から一時停止メニューを開く動作＝＝＝＝



public class OpenMenu : MonoBehaviour
{
    //宣言
    [SerializeField] private GameObject _MenuObject;//メニュー本体
    [SerializeField] private Button MenuButton;//メニューボタン
    public static bool isKey = true; //ButtonとEscが押せるかどうかのフラグ




    void Start()//初期化
    {
        _MenuObject.SetActive(false);
        _MenuObject.transform.localScale = Vector3.zero;
        if(MenuButton == null) return;
    }

    public void OnButton_OpenMenu()
    {
        if(MenuButton != null) 
        {
            MenuButton.interactable = false; //Button連打対策
        }
        
            _MenuObject.SetActive(!_MenuObject.activeSelf);//メニューの表示・非表示を切り替え
            _MenuObject.transform.DOScale(new Vector3(2f,2f,2f), 0.5f).OnComplete(() =>//メニューのアニメーション開始 =>アニメーション完了後の処理
            {
                if (_MenuObject.activeSelf == false)//メニューが非表示の時
                {
                    _MenuObject.transform.localScale = Vector3.zero;//アニメーションのために初期化
                }
                isKey = true;
                if(MenuButton == null) return;
                MenuButton.interactable = true; 
            });
    }
}
