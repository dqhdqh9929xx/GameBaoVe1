using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject IndexWrongChoice;
    //[SerializeField] CharacterManager characterManager;


    public void ShowWrongChoice()
    {
        var indexWrong = IndexWrongChoice.GetComponent<TextMeshProUGUI>();
        var indexManager = CharacterManager.indexWrongChoice;
        indexWrong.text = $"{indexManager}/10";

    }
}
