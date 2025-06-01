using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameClickManeger : MonoBehaviour
{
    public GameObject NoteBookFullScreenPanel;
    public GameObject listFullScreenPanel;
    public GameObject NvChat;
    public GameObject NoteBook;
    public GameObject TicketNv;
    public GameObject TicketNvFullScreen;



    void Start()
    {
        if (NoteBook != null)
            NoteBook.SetActive(true);

        if (NoteBookFullScreenPanel != null)
            NoteBookFullScreenPanel.SetActive(false);

        if (listFullScreenPanel != null)
            listFullScreenPanel.SetActive(false);

        if (TicketNv != null)
            TicketNv.SetActive(true);
        if (TicketNvFullScreen != null)
            TicketNvFullScreen.SetActive(false);
    }

    public void OpenTicketNvTrueFullScreen()
    {
        if (TicketNvFullScreen != null)
        {
            TicketNvFullScreen.SetActive(true);
            StartCoroutine(TimeToCheckTicket());

        }
    }

    public IEnumerator TimeToCheckTicket()
    {
        yield return new WaitForSeconds(3);
        TicketNvFullScreen.SetActive(false);
        Debug.Log("TicketNvFullScreen đã được tắt sau 3 giây.");
    }    

    

    //public void OnPointerClick(BaseEventData eventData)
    //{
    //    Debug.Log("OnPointerClick");
    //    PointerEventData pointerData = eventData as PointerEventData;
    //   // Kiểm tra nếu click không nằm trong NvChat
    //    if (!RectTransformUtility.RectangleContainsScreenPoint(
    //            NvChat.GetComponent<RectTransform>(),
    //            pointerData.position,
    //           Camera.main))
    //    {
    //        Debug.Log("OnPointerClick1");
    //        NvChat.SetActive(false);
    //        //OffNvChat.SetActive(false);
    //    }
    //}


    public void OpenNoteBookFullScreen()
    {
        // fix bug NoteList
        if (NoteBookFullScreenPanel != null)
        {
            NoteBookFullScreenPanel.SetActive(true);
            Debug.Log("OpenNoteBookFullScreen called, NoteBookFullScreenPanel is now active: " + NoteBookFullScreenPanel.activeSelf);

        }
    }

    public void CloseNoteBookFullScreen()
    {
        if (NoteBookFullScreenPanel != null)
        {
            NoteBookFullScreenPanel.SetActive(false);
        }
    }

    public void OpenListFullScreen()
    {
        if (listFullScreenPanel != null)
        {
            listFullScreenPanel.SetActive(true);
        }
    }

    public void CloseListFullScreen()
    {
        if (listFullScreenPanel != null)
        {
            listFullScreenPanel.SetActive(false);
        }
    }


}
