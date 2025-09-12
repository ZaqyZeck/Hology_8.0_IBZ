

[System.Serializable]
public class GameData : Data
{
    public int day;
    public int GW_level;

    public GameData(int day, int gW_level)
    {
        this.day = day;
        GW_level = gW_level;
    }
}
