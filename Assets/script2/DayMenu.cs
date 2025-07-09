using TMPro;
using UnityEngine;

public class DayMenu : MonoBehaviour
{
    public TMP_Text dayLevel;
    public Menu Menu; // Reference to the Menu script

    void Start()
    {
        PlayerData player = PlayerData.Instance;

        dayLevel.text = "Day " + player.level.ToString();
        Debug.Log("Current Day Level: " + player.level);

        if (player.level > 1 || player.level < 5)
        {
            Menu.UpdateNewOrOld();
        }
        if (player.level == 5)
        {
            Menu.UpdateEndGame();
        }

    }
}
