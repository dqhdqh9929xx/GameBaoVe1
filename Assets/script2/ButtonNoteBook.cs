using TMPro;
using UnityEngine;

public class ButtonNoteBook : MonoBehaviour
{
    [SerializeField] GameObject NoteBook;
    public TMP_Text timerText; // Kéo Text UI vào đây trong Inspector



    public void OpenNoteBook()
    {
        NoteBook.SetActive(true);
        CountdownTimer.isCounting = true; // Bắt đầu đếm ngược khi mở sổ tay
        timerText.enabled = true; // Hiển thị Text đếm ngược
    }

    public void CloseNoteBook()
    {
        NoteBook.SetActive(false);
    }
}
