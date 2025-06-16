using System.Collections;
using UnityEngine;

public class TicketCharacter : MonoBehaviour
{
    public GameObject ticketPrefabFullScreen;

    public void IsClickedTicketAndShowFullScreen()
    {
        GameObject newPrefabFullScreen = Instantiate(ticketPrefabFullScreen, this.transform);
        Destroy(newPrefabFullScreen, 3f);
    }
}
