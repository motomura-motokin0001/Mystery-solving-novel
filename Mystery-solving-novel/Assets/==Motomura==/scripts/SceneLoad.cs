using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//ボタン押したら最初のシーンでフェードインしロードシーンを上書き召喚！それと同時に最初のシーンのを削除＆遷移先のシーンと差し替え。ロードシーンがフェードアウトしたらロードシーンを削除してあたかも遷移先のシーンがあったように見せる。
public class SceneLoad : MonoBehaviour
{
    [SerializeField] private string _RoadSceneName;
    [SerializeField] private string NextSceneName;
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

