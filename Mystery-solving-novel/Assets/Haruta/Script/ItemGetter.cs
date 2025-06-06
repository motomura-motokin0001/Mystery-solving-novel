using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    // アイテムの種類を定義
    [Serializable]
    public enum Type
    {
        Key,   // 鍵
        Item1, // 他のアイテム（例：ドライバーなど）
        Item2,
        Item3
    }

    public Type type; // このアイテムの種類

    // アイテムをクリックしたときの処理
    public void OnThis()
    {
        // アイテムボックスに追加
        ItemBox.instance.SetItem(type);
        
        // クリックされたアイテムを非表示
        gameObject.SetActive(false);

        // デバッグ用のログ出力
        Debug.Log(type + " をGET");
    }
}