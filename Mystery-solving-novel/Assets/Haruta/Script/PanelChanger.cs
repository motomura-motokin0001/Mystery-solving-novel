using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    public GameObject _LeftArrow;  // 左矢印ボタン
    public GameObject _RightArrow; // 右矢印ボタン

    private void Start()
    {
        // 初期状態では左矢印を非表示、右矢印のみ表示
        HideArrows();
        _RightArrow.SetActive(true);
    }

    public void HideArrows()
    {
        // すべての矢印を非表示にする
        _LeftArrow.SetActive(false);
        _RightArrow.SetActive(false);
    }

    public void OnLeftAllow() 
    {
        // 左矢印が押されたとき、room0に移動
        HideArrows();
        _RightArrow.SetActive(true);
        this.transform.localPosition = new Vector2(0, 0);
    }

    public void OnRightAllow() 
    {
        // 右矢印が押されたとき、room1に移動
        HideArrows();
        _LeftArrow.SetActive(true);
        this.transform.localPosition = new Vector2(-3000, 0);
    }
}