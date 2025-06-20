using UnityEngine;
using UnityEngine.Events;

public class BlockObject : MonoBehaviour
{
// 鍵のかかったドアなどの、アイテムを使用するオブジェクトにアタッチして使用する。
// アイテムがインベントリに入っている場合使用したオブジェクトを破棄し、クリアイベントを呼び出す

    public Item.Type type = default; // 使用するアイテムの種類（インスペクターで設定可能）
    public UnityEvent ClearIvent = default; // アイテムを使った後の処理。ほかのスクリプトのメソッドを呼び出すことが可能

    public void Onthis()
    {
        // アイテムを持っているか判定
        bool hasItem = ItemBox.instance.CanUseItem(type);
        if (hasItem == true)
        {
            Debug.Log("アイテムを使用しました");
            // アイテムを使用（消費）
            ItemBox.instance.UseItem(type);
            // クリアイベントを実行（ドアを開ける）
            ClearIvent.Invoke();
        }
        else
        {
            Debug.Log("アイテムが足りません");
        }
    }
}