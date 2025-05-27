using UnityEngine;
using UnityEngine.EventSystems;

public class GameClickManeger : MonoBehaviour
{
    public GameObject NoteBookFullScreenPanel;
    public GameObject listFullScreenPanel;
    public GameObject NvChat;
    public GameObject OffNvChat;
    public GameObject NoteBook;


    void Start()
    {
        if (NoteBook != null)
            NoteBook.SetActive(true);

        if (NoteBookFullScreenPanel != null)
            NoteBookFullScreenPanel.SetActive(false);

        if (listFullScreenPanel != null)
            listFullScreenPanel.SetActive(false);

    }

    

    public void OnPointerClick(BaseEventData eventData)
    {
        Debug.Log("OnPointerClick");
        PointerEventData pointerData = eventData as PointerEventData;
        // Kiểm tra nếu click không nằm trong NvChat
        if (!RectTransformUtility.RectangleContainsScreenPoint(
                NvChat.GetComponent<RectTransform>(),
                pointerData.position,
                Camera.main))
        {
            Debug.Log("OnPointerClick1");
            NvChat.SetActive(false);
            OffNvChat.SetActive(false);
        }
    }


    public void OpenNoteBookFullScreen()
    {
        if (NoteBookFullScreenPanel != null)
        {
            NoteBookFullScreenPanel.SetActive(true);
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
