using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] Boxs;  // アイテムボックスのスロット（配列）
    public static ItemBox instance;  // インスタンスを作成（シングルトン）

    private void Awake()
    {
        instance = this;  // 自身のインスタンスをセット
    }

    public void SetItem(Item.Type type)
    {
        int index = (int)type;  // アイテムの種類に応じたスロットを取得
        Boxs[index].SetActive(true);  // アイテムを取得するとスロットを表示
    }

    public bool CanUseItem(Item.Type type)
    {
        int index = (int)type;
        return Boxs[index].activeSelf;  // アイテムを持っているか確認
    }

    public void UseItem(Item.Type type)
    {
        int index = (int)type;
        Boxs[index].SetActive(false);  // アイテムを使用したら非表示にする
    }
}