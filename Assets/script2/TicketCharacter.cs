using System;
using Unity.VisualScripting;
using UnityEngine;

public class TicketCharacter : MonoBehaviour
{
    public Vector3 Origin;
    public GameObject ticketPrefabFullScreen;
    private GameObject newPrefabFullScreen = null;

    public event Action TicketClicked;

    private TicketCharacterFullScreen ticketCharacterFullScreen;

    public void IsClickedTicketAndShowFullScreen()
    {
        TicketClicked?.Invoke();
    }

    public void ShowFullscreen(string text)
    {
        Vector3 localPosTicket = Origin;
        Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x - 200, localPosTicket.y + 700, localPosTicket.z);
        newPrefabFullScreen = Instantiate(ticketPrefabFullScreen, this.transform);
        newPrefabFullScreen.GetComponent<RectTransform>().anchoredPosition = spawnLocalPosTicket;

        ticketCharacterFullScreen = newPrefabFullScreen.GetComponent<TicketCharacterFullScreen>();
        ticketCharacterFullScreen.SetText(text);
    }


    public void HideFullscreen()
    {
        Destroy(newPrefabFullScreen);
    }
}
