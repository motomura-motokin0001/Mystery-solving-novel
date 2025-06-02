using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [Tooltip("ロードシーンの名前")]
    [SerializeField] private string _RoadSceneName = "EffectScene";
    [Tooltip("遷移先のシーンの名前")]
    [SerializeField] private string NextSceneName;
    [Tooltip("遷移元のシーンの名前")]
    [SerializeField] private string DestroySceneName;

    private float _EffectTime = 1.0f;

    public void Load()
    {
        SceneManager.LoadScene(_RoadSceneName, LoadSceneMode.Additive);//ロードシーンを召喚

        StartCoroutine(IE());
    }

    IEnumerator IE()
    {
        Debug.Log("IE");
        yield return new WaitForSeconds(_EffectTime);
        SceneManager.LoadScene(NextSceneName,LoadSceneMode.Additive);//遷移先のシーンを召喚
        SceneManager.UnloadSceneAsync(DestroySceneName);//遷移元のシーンを削除
        SceneManager.UnloadSceneAsync(_RoadSceneName);//ロードシーンを削除
        Debug.Log("complete!!");
    }
}

