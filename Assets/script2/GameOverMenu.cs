using System;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject IndexWrongChoice;
    [SerializeField] CharacterManager characterManager;


    public void ShowWrongChoice()
    {
        var indexWrong = IndexWrongChoice.GetComponent<TextMeshProUGUI>();
        //int allIndexWrong = CharacterManager.indexWrongChoice; // tổng số lần người chơi chọn sai
        int indexWrongInTicket = CharacterManager.indexWrongChoiceInTicket; // tổng số lần người chơi chọn sai vé In
        int indexWrongOutTicket = CharacterManager.indexWrongChoiceOutCoin; // tổng số lần người chơi chọn sai tiền Out
        int indexWrongInSpray = CharacterManager.indexWrongChoiceInSprayed; // tổng số lần người chơi chọn sai xịt In
        int indexWrongOutSpray = CharacterManager.indexWrongChoiceOutSprayed; // tổng số lần người chơi chọn sai xịt Out

        int indexAllInTicket = CharacterManager.indexCharacterInTicketToCheck; // tổng số lần người chơi chọn vé In
        // oldCharaters.count; // 
        int indexAllOutTicket = CharacterManager.indexCharacterOutCoinToCheck; // tổng số lần người chơi chọn tiền Out
        // sprayedOldCharacter.count; //
        int indexAllInSpray = CharacterManager.indexCharacterInSprayedToCheck; // tổng số lần người chơi chọn xịt In
        // SprayedCharacter.count; //
        int indexAllOutSpray = CharacterManager.indexCharacterOutSprayedToCheck; // tổng số lần người chơi chọn xịt Out
        // sprayedOldCharacter.count; //


        indexWrong.text = $"Tổng số lần chọn sai của bạn: {indexWrongInTicket + indexWrongOutTicket + indexWrongInSpray + indexWrongOutSpray}." + Environment.NewLine + $"Tổng số lần cho người bị truy nã vào là: {indexWrongInTicket}."+ Environment.NewLine + $"Tổng số lần cho người giả mạo qua là: {indexWrongOutTicket}." + Environment.NewLine + $"Tổng số lần xịt nhầm người bị truy nã là: {indexWrongInSpray}." + Environment.NewLine + $"Tổng số lần xịt nhầm người giả mạo là: {indexWrongOutSpray}.";
        Console.WriteLine(indexWrong.text);

    }
}
