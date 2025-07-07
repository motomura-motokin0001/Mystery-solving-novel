using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EffectScene : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private RectTransform _LogoImage;
    [SerializeField] private Image _TextImage;
    [SerializeField] private float _LoadTime = 1f;
    [SerializeField] private string _RoadSceneName;

    void Start()
    {
        var _CanvasGroup = _object.GetComponent<CanvasGroup>();
        _CanvasGroup.alpha = 0f;// 初期状態は透明

        Sequence seq = DOTween.Sequence();

        Load_Animation();// ロードアニメーションを開始
        seq.Append(_CanvasGroup.DOFade(1f, 1));// フェードインして
        seq.AppendInterval(_LoadTime);// 一定時間待機(ロードアニメーションと同じ時間)
        seq.Append(_CanvasGroup.DOFade(0f, 1));// フェードアウトする
        seq.OnComplete(() =>
        {
            SceneManager.UnloadSceneAsync(_RoadSceneName);//ロードシーンを削除
            DOTween.KillAll();
        });
    }

    private void Load_Animation()
    {
        Debug.Log("ロードアニメーション開始");
        _LogoImage.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        _TextImage.DOFillAmount(1f, _LoadTime);
    }
}
