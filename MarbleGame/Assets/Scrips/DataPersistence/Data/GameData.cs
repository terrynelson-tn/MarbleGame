//Final Project --- GameData.cs by Sebastian Ulloa

[System.Serializable]

public class GameData
{
    public long lastUpdated;
    public bool Level1;

    public int MarbleVariant;

    public GameData()
    {
        MarbleVariant = 0;
        Level1 = false;
    }
}