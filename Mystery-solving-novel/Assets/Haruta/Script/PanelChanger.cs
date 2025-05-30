using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    public GameObject _LeftArrow;   // 左矢印ボタン
    public GameObject _RightArrow;  // 右矢印ボタン
    public int roomCount = 2;       // 部屋の数（Inspectorで設定可能）

    private int currentRoomIndex = 0;     // 現在の部屋番号
    private const float ROOM_WIDTH = 3000f; // 各部屋の横幅

    private void Start()
    {
        UpdatePanel();
    }

    public void OnLeftAllow()
    {
        if (currentRoomIndex > 0)
        {
            currentRoomIndex--;
            UpdatePanel();
        }
    }

    public void OnRightAllow()
    {
        if (currentRoomIndex < roomCount - 1)
        {
            currentRoomIndex++;
            UpdatePanel();
        }
    }

    private void UpdatePanel()
    {
        // 部屋の位置を更新
        this.transform.localPosition = new Vector2(-ROOM_WIDTH * currentRoomIndex, 0);

        // 矢印の表示状態を更新
        _LeftArrow.SetActive(currentRoomIndex > 0);
        _RightArrow.SetActive(currentRoomIndex < roomCount - 1);
    }
}
