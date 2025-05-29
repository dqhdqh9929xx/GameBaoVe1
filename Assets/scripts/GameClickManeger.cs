using UnityEngine;
using UnityEngine.EventSystems;

public class GameClickManeger : MonoBehaviour
{
    public GameObject NoteBookFullScreenPanel;
    public GameObject listFullScreenPanel;
    public GameObject NvChat;
    //public GameObject OffNvChat;
    public GameObject NoteBook;
    public GameObject HistoryList;
    public GameObject Mui;
    public GameObject Mat;
    public GameObject KhuonMat;
    public GameObject Mieng;
    public GameObject Mu;
    public GameObject PhuKien;


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
            //OffNvChat.SetActive(false);
        }
    }


    public void OpenNoteBookFullScreen()
    {
        // fix bug NoteList
        if (NoteBookFullScreenPanel != null)
        {
            NoteBookFullScreenPanel.SetActive(true);
            if (HistoryList != null)
            {
                HistoryList.SetActive(true);
            }
            if (Mui != null)
                Mui.SetActive(false);
            if (Mat != null)
                Mat.SetActive(false);
            if (KhuonMat != null)
                KhuonMat.SetActive(false);
            if (Mieng != null)
                Mieng.SetActive(false);
            if (Mu != null)
                Mu.SetActive(false);
            if (PhuKien != null)
                PhuKien.SetActive(false);

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
