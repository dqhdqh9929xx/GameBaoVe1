using System.Collections;
using UnityEngine;

public class TicketCharacter : MonoBehaviour
{
    public GameObject ticketPrefabFullScreen;
    public Transform KhayDungDo;
    public Vector3 Origin;

    private void Start()
    {
        Origin = transform.position;
    }

    public void IsClickedTicketAndShowFullScreen()
    {
        Vector3 localPosTicketFull = Origin;
        Vector3 spawnLocalPosTicketFull = new Vector3(localPosTicketFull.x , localPosTicketFull.y, localPosTicketFull.z);
        GameObject newPrefabFullScreen = Instantiate(ticketPrefabFullScreen, this.transform);
        newPrefabFullScreen.transform.SetParent(KhayDungDo, false);
        newPrefabFullScreen.GetComponent<RectTransform>().localPosition = spawnLocalPosTicketFull;
        Destroy(newPrefabFullScreen, 3f);
    }
}
