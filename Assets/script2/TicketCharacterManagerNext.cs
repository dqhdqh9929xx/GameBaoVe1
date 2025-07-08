using System.Collections;
using TMPro;
using UnityEngine;

public class TicketCharacterManagerNext : MonoBehaviour
{
    public GameObject ticketPrefab;
    public static bool isClickedExitTicket = false;
    private GameObject newPrefabTicket;
    //public Vector3 Origin;
    public CharacterManagerNext characterManager;
    public TicketCharacter ticketCharacter = null;
    //public TMP_Text nameText;
    public Transform targetTransform; // Transform của Canvas Ticket 
    public RectTransform CanvasRect; // RectTransform của Canvas Ticket 
    public Transform targetRectTicketFullScreen; // Transform của Canvas TicketFullScreen nối với canvasRect của TicketCharacter.cs
    public RectTransform CanvasRectTicketFullScreen; // RectTransform của Canvas TicketFullScreen



    //private void Start()
    //{
    //    //Origin = GetComponent<RectTransform>().localPosition;
    //    nameText.enabled = false;
    //}
    public void InstantiateTicket()
    {

        // Bước 1: Tạo UI object gắn vào canvas
        newPrefabTicket = Instantiate(ticketPrefab, CanvasRect);
        RectTransform uiRect = newPrefabTicket.GetComponent<RectTransform>();

        // Bước 2: Chuyển WorldPos của đối tượng rỗng → ScreenPoint
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, targetTransform.position);

        // Bước 3: Chuyển ScreenPoint → Local anchoredPosition trong Canvas
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, screenPos, null, out anchoredPos);

        // Bước 4: Gán vị trí
        uiRect.anchoredPosition = anchoredPos;


        //Vector3 localPosTicket = Origin;
        //Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x, localPosTicket.y, localPosTicket.z);
        //newPrefabTicket = Instantiate(ticketPrefab, this.transform);
        //newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
        //ticketCharacter = newPrefabTicket.GetComponent<TicketCharacter>();
        ticketCharacter.canvasRect = CanvasRectTicketFullScreen; // tham chiếu đến RectTransform của Canvas  TicketFullScreen
        ticketCharacter = newPrefabTicket.GetComponent<TicketCharacter>();
        ticketCharacter.TicketClicked += TicketCharacter_TicketClicked;

    }

    private void TicketCharacter_TicketClicked()
    {
        StartCoroutine(ShowLargTicketAndName());
    }

    private IEnumerator ShowLargTicketAndName()
    {
        if (ticketCharacter == null) yield break;

        var nameIndex = CharacterManagerNext.randomIndex;
        var currentChar = characterManager.currentCharacterData;
        ticketCharacter.canvasRect = CanvasRectTicketFullScreen; // tham chiếu đến RectTransform của Canvas  TicketFullScreen
        ticketCharacter.ShowFullscreen(currentChar.Name, targetRectTicketFullScreen.position); // truyền tên nhân vật và vị trí của đối tượng TicketFullScreen
        yield return new WaitForSecondsRealtime(3f);
        ticketCharacter.HideFullscreen();

    }

    public void Destroyticket()
    {
        Destroy(newPrefabTicket);
    }

}
