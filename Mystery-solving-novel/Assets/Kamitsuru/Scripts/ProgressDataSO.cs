using UnityEngine;

[CreateAssetMenu(fileName = "ProgressData", menuName = "Game/Progress Data")]
public class ProgressDataSO : ScriptableObject
{
    public bool[] FinishedDays = new bool[7]; // 0 = Day1, ..., 6 = Day7

    public ProgressData ToData()
    {
        return new ProgressData { FinishedDays = (bool[])FinishedDays.Clone() };
    }

    public void FromData(ProgressData data)
    {
        if (data.FinishedDays != null && data.FinishedDays.Length == 7)
        {
            FinishedDays = (bool[])data.FinishedDays.Clone();
        }
        else
        {
            Debug.LogWarning("読み込んだデータが不正です");
        }
    }
}
