using TMPro;
using UnityEngine;

public class DayMenu : MonoBehaviour
{
    public TMP_Text dayLevel;

    void Start()
    {
        PlayerData player = PlayerData.Instance;

        dayLevel.text = "Day " + player.level.ToString();
        Debug.Log("Current Day Level: " + player.level);

    }
}
