using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public void OnClickedBackToMenu()
    {
        // Reset the indexWrongChoiceInTicket and indexWrongChoiceOutCoin to 0
        CharacterManager.indexWrongChoiceInTicket = 0;
        CharacterManager.indexWrongChoiceOutCoin = 0;
        CharacterManager.indexWrongChoiceInSprayed = 0;
        CharacterManager.indexWrongChoiceOutSprayed = 0;
        CharacterManager.indexCharacterInTicketToCheck = 0;
        CharacterManager.indexCharacterOutCoinToCheck = 0;
        CharacterManager.indexCharacterInSprayedToCheck = 0;
        CharacterManager.indexCharacterOutSprayedToCheck = 0;
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    }
}
