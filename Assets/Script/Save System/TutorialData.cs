[System.Serializable]
public class TutorialData : Data
{
    public bool[] alur = new bool[10];
    public TutorialData(bool[] alur)
    {
        if (alur == null) return;
        this.alur = new bool[alur.Length];
        for (int i = 0; i < alur.Length; i++)
        {
            this.alur[i] = alur[i];
        }
    }
}
