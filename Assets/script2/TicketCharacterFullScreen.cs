using TMPro;
using UnityEngine;

public class TicketCharacterFullScreen : MonoBehaviour
{
    public TMP_Text nameText;

    public void SetText(string text)
    {
        if (nameText == null) return;
        nameText.text = text;
    }
}
