using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlayerData PlayerData; // Assuming PlayerData is a scriptable object or singleton containing player data  
    public TMP_Text textContinue; // Corrected type for TextMeshPro text field  

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

    public void UpdateNewOrOld()
    {
        textContinue.text = "Continue Game"; // Assuming this is the text for continuing a game
    }
    
    public void UpdateEndGame()
    {
        textContinue.text = "End Game"; // Assuming this is the text for ending a game
    }

    public void NewGameText()
    {
        textContinue.text = "Start Game"; // Assuming this is the text for starting a new game
    }

    public void OnPlayButtonClickedBattleStart()
    {
        SceneManager.LoadScene("Menu");
    }
}
