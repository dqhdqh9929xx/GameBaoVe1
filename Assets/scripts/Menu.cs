using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlayerData PlayerData; // Giả sử PlayerData là một scriptable object hoặc singleton chứa dữ liệu người chơi
    
    public void OnPlayButtonClickedBattle()
    {
        PlayerData player = PlayerData.Instance;

        if (player.level == 1)
        {
            SceneManager.LoadScene("Day1");
        }

        else if (player.level == 2)
        {
            SceneManager.LoadScene("Day2");
        }
        else if (player.level == 3)
        {
            SceneManager.LoadScene("Day3");
        }
        else if (player.level == 4)
        {
            SceneManager.LoadScene("Day4");
        }
        else if (player.level == 5)
        {
            SceneManager.LoadScene("Day5");
        }
        else
        {
            Debug.LogError("Invalid level: " + player.level);
        }

    }

    public void OnPlayButtonClickedBattleStart()
    {
        SceneManager.LoadScene("Menu");
    }
}
