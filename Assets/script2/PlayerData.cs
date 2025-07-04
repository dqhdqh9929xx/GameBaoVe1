using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public static int level = 1;

    public PlayerData(int level)
    {
        PlayerData.level = level; // Fixed: Access static member using the class name
    }

    // Convert object thành JSON
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    // Convert JSON thành object
    public static PlayerData FromJson(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    // Lưu vào PlayerPrefs
    public void SaveToPrefs()
    {
        PlayerPrefs.SetString("PlayerData", ToJson());
        PlayerPrefs.Save();
    }

    // Tải từ PlayerPrefs
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