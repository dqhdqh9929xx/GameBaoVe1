using UnityEngine;

public class TicketCharacterManager : MonoBehaviour
{
    public GameObject ticketPrefab;
    //public Transform KhayDungDo;
    public static TicketCharacter TicketCharacter;
    public static bool isClickedExitTicket = false;
    private GameObject newPrefabTicket;
    public Vector3 Origin;

    private void Start()
    {
        Origin = GetComponent<RectTransform>().localPosition;
    }
    public void InstantiateTicket()
    {
        Vector3 localPosTicket = Origin;
        Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x, localPosTicket.y, localPosTicket.z);
        newPrefabTicket = Instantiate(ticketPrefab, this.transform);
        newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
    }

    public void Destroyticket()
    {
        Destroy(newPrefabTicket);
    }    

}
