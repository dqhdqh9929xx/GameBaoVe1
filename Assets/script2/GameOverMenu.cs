using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject IndexWrongChoice;
    [SerializeField] CharacterManager characterManager;


    public void ShowWrongChoice()
    {
        var indexWrong = IndexWrongChoice.GetComponent<TextMeshProUGUI>();
        var indexManager = characterManager.endIndexWrongChoice;
        indexWrong.text = $"{indexManager.ToString()}/10";
    }
}
