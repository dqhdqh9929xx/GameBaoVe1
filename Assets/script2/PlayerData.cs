using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level = 1;

    private static PlayerData _instance;

    // Truy cập PlayerData hiện tại
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = LoadFromPrefs();
            }
            return _instance;
        }
    }

    public PlayerData(int level)
    {
        this.level = level;
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData FromJson(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public void SaveToPrefs()
    {
        PlayerPrefs.SetString("PlayerData", ToJson());
        PlayerPrefs.Save();
    }

    public static PlayerData LoadFromPrefs()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string json = PlayerPrefs.GetString("PlayerData");
            return FromJson(json);
        }
        else
        {
            return new PlayerData(1); // mặc định nếu chưa có dữ liệu
        }
    }
}
