using TMPro;
using UnityEngine;

public class TicketCharacterFullScreen : MonoBehaviour
{
    public TMP_Text nameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        if (nameText == null) return;

        nameText.text = text;
    }
}
