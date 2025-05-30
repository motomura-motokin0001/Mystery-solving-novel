using UnityEngine;
using System.IO;

public class ProgressManager : MonoBehaviour
{
    public ProgressDataSO progressDataSO;
    private string savePath;

    void Awake()
    {
#if UNITY_EDITOR
        // 開発用の保存先: Assets/Kamitsuru/PData/progress.json
        string devFolder = Path.Combine(Application.dataPath, "Kamitsuru/PData");
        if (!Directory.Exists(devFolder))
        {
            Directory.CreateDirectory(devFolder);
        }
        savePath = Path.Combine(devFolder, "progress.json");
#else
        // 本番ビルド時は通常のセーブ領域を使う
        savePath = Path.Combine(Application.persistentDataPath, "progress.json");
#endif

        Debug.Log("進行度保存パス: " + savePath);
        LoadProgress();
    }

    public void SaveProgress()
    {
        var data = progressDataSO.ToData();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("進行度を保存しました");
    }

    public void LoadProgress()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            ProgressData data = JsonUtility.FromJson<ProgressData>(json);
            progressDataSO.FromData(data);
            Debug.Log("進行度を読み込みました");
        }
        else
        {
            Debug.Log("保存ファイルが存在しません。新規スタートとして初期化されます。");
        }
    }
}
