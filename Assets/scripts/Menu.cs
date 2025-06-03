using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButtonClickedBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    public void OnPlayButtonClickedBattleStart()
    {
        SceneManager.LoadScene("Start");
    }
}
