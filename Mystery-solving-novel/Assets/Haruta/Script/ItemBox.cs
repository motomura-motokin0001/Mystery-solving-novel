using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] Boxs; // アイテムボックスのスロット（UI Imageなど）
    public Item.Type[] itemTypes; // 各スロットにどのアイテムが入ってるか記録

    public static ItemBox instance;

    private void Awake()
    {
        instance = this;
        itemTypes = new Item.Type[Boxs.Length];
        for (int i = 0; i < itemTypes.Length; i++)
        {
            itemTypes[i] = (Item.Type)(-1); // 空の状態を -1 で初期化
        }
    }

    public void SetItem(Item.Type type)
    {
        // すでに持っていたら追加しない
        if (HasItem(type)) return;

        for (int i = 0; i < Boxs.Length; i++)
        {
            if (!Boxs[i].activeSelf)
            {
                Boxs[i].SetActive(true);
                itemTypes[i] = type;
                Debug.Log("アイテム " + type + " をスロット " + i + " に追加");
                break;
            }
        }
    }

    public bool CanUseItem(Item.Type type)
    {
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemTypes[i] == type && Boxs[i].activeSelf)
                return true;
        }
        return false;
    }

    public void UseItem(Item.Type type)
    {
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemTypes[i] == type)
            {
                Boxs[i].SetActive(false);
                itemTypes[i] = (Item.Type)(-1);
                Debug.Log("アイテム " + type + " を使用してスロット " + i + " を空にしました");
                break;
            }
        }
    }

    private bool HasItem(Item.Type type)
    {
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemTypes[i] == type)
                return true;
        }
        return false;
    }
}
