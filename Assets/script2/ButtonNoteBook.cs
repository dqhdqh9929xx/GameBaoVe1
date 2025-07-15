using UnityEngine;

public class ButtonNoteBook : MonoBehaviour
{
    [SerializeField] GameObject NoteBook;
    


    public void OpenNoteBook()
    {
        NoteBook.SetActive(true);
        CountdownTimer.isCounting = true; // Bắt đầu đếm ngược khi mở sổ tay
    }

    public void CloseNoteBook()
    {
        NoteBook.SetActive(false);
    }
}
