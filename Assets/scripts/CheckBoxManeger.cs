using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBoxManeger : MonoBehaviour, IPointerClickHandler
{
    public Image checkmarkImage; // Kéo thả Image Checkmark từ Inspector
    public bool checkmarkEnabled = false; // Mặc định chưa chọn (false)

    // Định nghĩa delegate và event để thông báo khi trạng thái thay đổi
    public delegate void OnCheckmarkChanged(bool isChecked);
    public event OnCheckmarkChanged CheckmarkChanged;

    private void Start()
    {
        if (checkmarkImage != null)
            checkmarkImage.gameObject.SetActive(checkmarkEnabled); // Ẩn hoặc hiện checkmark theo trạng thái ban đầu
    }

    // Khi click vào checkbox
    public void OnPointerClick(PointerEventData eventData)
    {
        if (checkmarkImage != null)
        {
            checkmarkEnabled = !checkmarkEnabled; // Đảo trạng thái
            checkmarkImage.gameObject.SetActive(checkmarkEnabled); // Bật/tắt checkmark

            // Gọi event thông báo cho các listener
            if (CheckmarkChanged != null)
                CheckmarkChanged(checkmarkEnabled);
        }
    }
}
