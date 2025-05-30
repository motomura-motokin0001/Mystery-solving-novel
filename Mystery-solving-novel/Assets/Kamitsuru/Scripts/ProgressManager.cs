using UnityEngine;
using System.IO;

public class ProgressManager : MonoBehaviour
{
    public ProgressDataSO progressDataSO;
    private string savePath;

    void Awake()
    {
#if UNITY_EDITOR
        // �J���p�̕ۑ���: Assets/Kamitsuru/PData/progress.json
        string devFolder = Path.Combine(Application.dataPath, "Kamitsuru/PData");
        if (!Directory.Exists(devFolder))
        {
            Directory.CreateDirectory(devFolder);
        }
        savePath = Path.Combine(devFolder, "progress.json");
#else
        // �{�ԃr���h���͒ʏ�̃Z�[�u�̈���g��
        savePath = Path.Combine(Application.persistentDataPath, "progress.json");
#endif

        Debug.Log("�i�s�x�ۑ��p�X: " + savePath);
        LoadProgress();
    }

    public void SaveProgress()
    {
        var data = progressDataSO.ToData();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("�i�s�x��ۑ����܂���");
    }

    public void LoadProgress()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            ProgressData data = JsonUtility.FromJson<ProgressData>(json);
            progressDataSO.FromData(data);
            Debug.Log("�i�s�x��ǂݍ��݂܂���");
        }
        else
        {
            Debug.Log("�ۑ��t�@�C�������݂��܂���B�V�K�X�^�[�g�Ƃ��ď���������܂��B");
        }
    }
}
