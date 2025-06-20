using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class TicketCharacter : MonoBehaviour
{
    public Vector3 Origin;
    public GameObject ticketPrefabFullScreen;
    private GameObject newPrefabFullScreen = null;
    public static bool isClickedTicketFull = false;

    public void IsClickedTicketAndShowFullScreen()
    {
        isClickedTicketFull = true;
        Vector3 localPosTicket = Origin;
        Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x - 200, localPosTicket.y + 700, localPosTicket.z);
        newPrefabFullScreen = Instantiate(ticketPrefabFullScreen, this.transform);
        newPrefabFullScreen.GetComponent<RectTransform>().anchoredPosition = spawnLocalPosTicket;

        Destroy(newPrefabFullScreen, 3f);
    }
}
