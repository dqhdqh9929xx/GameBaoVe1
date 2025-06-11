using UnityEngine;

public class NoteBookx : MonoBehaviour
{
    public GameObject NoteBook1;
    public GameObject NoteBookFullScreenPanel;
    void Start()
    {
        if (NoteBook1 != null)
            NoteBook1.SetActive(true);
        if (NoteBookFullScreenPanel != null)
            NoteBookFullScreenPanel.SetActive(false);
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

}
