using UnityEngine;

public class Object : MonoBehaviour
{
// ドアを開くために実装した簡単なスクリプト。
// 改良を加え、アイテムを新しくゲットしたりする処理を加える予定
    public void OpenObject()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseObject()
    {
        this.gameObject.SetActive(false);
    }
}