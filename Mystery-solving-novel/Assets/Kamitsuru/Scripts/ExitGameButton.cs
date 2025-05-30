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
                Debug.Log("�i�s�x��ۑ����܂���");
            }
            else
            {
                Debug.Log("ProgressManager ���ݒ肳��Ă��܂���I");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("�i�s�x�̕ۑ����ɃG���[���������܂���: " + ex.Message);
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.delayCall += () =>
        {
            Debug.Log("�Q�[�����I�����܂��i�G�f�B�^�j");
            UnityEditor.EditorApplication.isPlaying = false;
        };
#else
    Debug.Log("�Q�[�����I�����܂��i�r���h�j");
    Application.Quit();
#endif
    }

}
