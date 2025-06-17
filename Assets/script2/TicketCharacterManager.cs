using UnityEngine;

public class TicketCharacterManager : MonoBehaviour
{
    public GameObject ticketPrefab;
    public Transform KhayDungDo;
    public static TicketCharacter TicketCharacter;
    public static bool isClickedExitTicket = false;
    private GameObject newPrefabTicket;
    public void InstantiateTicket()
    {
        Vector3 localPosTicket = KhayDungDo.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x - 500f, localPosTicket.y - 200f, localPosTicket.z);
        newPrefabTicket = Instantiate(ticketPrefab);
        newPrefabTicket.transform.SetParent(KhayDungDo, false);
        newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
    }

    public void Destroyticket()
    {
        Destroy(newPrefabTicket);
    }    

}
