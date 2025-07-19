using TMPro;
using UnityEngine;

public class ButtonNoteBook : MonoBehaviour
{
    [SerializeField] GameObject NoteBook;
    public TMP_Text timerText; // Kéo Text UI vào đây trong Inspector
    public static bool isOpen = false; // Biến để theo dõi trạng thái mở của sổ tay



    public void OpenNoteBook()
    {
        NoteBook.SetActive(true);
        CountdownTimer.isCounting = true; // Bắt đầu đếm ngược khi mở sổ tay
        timerText.enabled = true; // Hiển thị Text đếm ngược
        isOpen = true; // Đánh dấu sổ tay đã mở

    }

    public void CloseNoteBook()
    {
        NoteBook.SetActive(false);
        isOpen = false; // Đánh dấu sổ tay đã đóng
        Debug.Log("Sổ tay đã đóng!");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);  // Thay đổi con trỏ ngay khi đóng
    }

}
