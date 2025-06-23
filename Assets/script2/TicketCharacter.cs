using System;
using Unity.VisualScripting;
using UnityEngine;

public class TicketCharacter : MonoBehaviour
{
    //public Vector3 Origin;
    public GameObject ticketPrefabFullScreen;
    private GameObject newPrefabFullScreen = null;

    public RectTransform canvasRect = null; // RectTransform của Canvas FullScreen

    public event Action TicketClicked;

    private TicketCharacterFullScreen ticketCharacterFullScreen;

    public void IsClickedTicketAndShowFullScreen()
    {
        TicketClicked?.Invoke();
    }

    public void ShowFullscreen(string text, Vector3 worldPos)
    {
        // Chuyển World → Screen → Local
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, worldPos);
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out anchoredPos);


        // Instantiate UI
        newPrefabFullScreen = Instantiate(ticketPrefabFullScreen, canvasRect);
        newPrefabFullScreen.GetComponent<RectTransform>().anchoredPosition = anchoredPos;

        // Gán text
        ticketCharacterFullScreen = newPrefabFullScreen.GetComponent<TicketCharacterFullScreen>();
        ticketCharacterFullScreen.SetText(text);
    }



    public void HideFullscreen()
    {
        Destroy(newPrefabFullScreen);
    }
}
