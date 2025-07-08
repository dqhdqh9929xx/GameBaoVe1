using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChatManagerNext : MonoBehaviour
{
    public CharacterManagerNext characterManager;
    public int chatIndex;
    public GameObject chatWindow;

    public IEnumerator InstantiateChatIn()
    {
        chatIndex = CharacterManagerNext.randomIndex;
        chatWindow.SetActive(true);
        var currentChatChar = characterManager.characters[chatIndex];
        var chatChar = this.GetComponent<TextMeshProUGUI>();
        chatChar.enabled = true;
        chatChar.text = currentChatChar.CharacterChatIn;
        yield return new WaitForSecondsRealtime(5f);
        chatWindow.SetActive(false);
        chatChar.enabled = false;
    }
    public IEnumerator InstantiateChatOut()
    {
        chatIndex = CharacterManagerNext.randomIndex;
        chatWindow.SetActive(true);
        var currentChatChar = characterManager.oldCharaters[chatIndex];
        var chatChar = this.GetComponent<TextMeshProUGUI>();
        chatChar.enabled = true;
        chatChar.text = currentChatChar.CharacterChatOut;
        yield return new WaitForSecondsRealtime(5f);
        chatWindow.SetActive(false);
        chatChar.enabled = false;
    }
}
