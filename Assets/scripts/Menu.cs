using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButtonClickedBattle()
    {
        if (PlayerData.level == 1)
        {
            SceneManager.LoadScene("Day1");
        }

        else if (PlayerData.level == 2)
        {
            SceneManager.LoadScene("Day2");
        }
        else if (PlayerData.level == 3)
        {
            SceneManager.LoadScene("Day3");
        }
        else if (PlayerData.level == 4)
        {
            SceneManager.LoadScene("Day4");
        }
        else if (PlayerData.level == 5)
        {
            SceneManager.LoadScene("Day5");
        }
        else
        {
            Debug.LogError("Invalid level: " + PlayerData.level);
        }

    }

    public void OnPlayButtonClickedBattleStart()
    {
        SceneManager.LoadScene("Start");
    }
}
