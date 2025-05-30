using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public ProgressManager progressManager;

    public void ExitGame()
    {
        try
        {
            if (progressManager != null)
            {
                progressManager.SaveProgress();
                Debug.Log("進行度を保存しました");
            }
            else
            {
                Debug.Log("ProgressManager が設定されていません！");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("進行度の保存中にエラーが発生しました: " + ex.Message);
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.delayCall += () =>
        {
            Debug.Log("ゲームを終了します（エディタ）");
            UnityEditor.EditorApplication.isPlaying = false;
        };
#else
    Debug.Log("ゲームを終了します（ビルド）");
    Application.Quit();
#endif
    }

}
