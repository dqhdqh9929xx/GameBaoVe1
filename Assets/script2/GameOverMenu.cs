using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject IndexWrongChoice;


    public void ShowWrongChoice()
    {
        var indexWrong = IndexWrongChoice.GetComponent<TextMeshProUGUI>();
        //int allIndexWrong = CharacterManager.indexWrongChoice; // tổng số lần người chơi chọn sai
        int indexWrongInTicket = CharacterManager.indexWrongChoiceInTicket; // tổng số lần người chơi chọn sai vé In
        int indexWrongOutTicket = CharacterManager.indexWrongChoiceOutCoin; // tổng số lần người chơi chọn sai tiền Out
        int indexWrongInSpray = CharacterManager.indexWrongChoiceInSprayed; // tổng số lần người chơi chọn sai xịt In
        int indexWrongOutSpray = CharacterManager.indexWrongChoiceOutSprayed; // tổng số lần người chơi chọn sai xịt Out

        int indexAllInTicket = CharacterManager.indexCharacterInTicketToCheck; // tổng số lần người chơi chọn vé In
        int indexAllOutTicket = CharacterManager.indexCharacterOutCoinToCheck; // tổng số lần người chơi chọn tiền Out
        int indexAllInSpray = CharacterManager.indexCharacterInSprayedToCheck; // tổng số lần người chơi chọn xịt In
        int indexAllOutSpray = CharacterManager.indexCharacterOutSprayedToCheck; // tổng số lần người chơi chọn xịt Out


        indexWrong.text = $"Tổng số lần chọn sai của bạn: {indexWrongInTicket + indexWrongOutTicket + indexWrongInSpray + indexWrongOutSpray}." + Environment.NewLine + $"Tổng số lần cho người bị truy nã vào là: {indexWrongInTicket}/{indexAllInTicket}."+ Environment.NewLine + $"Tổng số lần cho người giả mạo qua là: {indexWrongOutTicket}/{indexAllOutTicket}." + Environment.NewLine + $"Tổng số lần xịt nhầm người bị truy nã là: {indexWrongInSpray}/{indexAllInSpray}." + Environment.NewLine + $"Tổng số lần xịt nhầm người giả mạo là: {indexWrongOutSpray}/{indexAllOutSpray}.";
        Console.WriteLine(indexWrong.text);
    }

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
        //CharacterManager.randomIndex = 0;
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    }
}
