using UnityEngine;
using TMPro;

public class HistoryList : MonoBehaviour
{
    public AnimationController animController;

    public CheckBoxManeger CheckBoxManagerMui;
    public CheckBoxManeger CheckBoxManagerRuoi;
    public CheckBoxManeger CheckBoxManagerBeo;
    public CheckBoxManeger CheckBoxManagerGay;
    public CheckBoxManeger CheckBoxManagerMu;
    public CheckBoxManeger CheckBoxManagerLongMay;

    private TMP_Text chatText;

    void Start()
    {
        chatText = GetComponent<TMP_Text>();
        if (chatText == null || animController == null)
        {
            Debug.LogWarning("HistoryList: TMP_Text component or AnimationController missing!");
            return;
        }

        // Đăng ký lắng nghe sự kiện thay đổi trạng thái checkbox
        if (CheckBoxManagerMui != null)
            CheckBoxManagerMui.CheckmarkChanged += UpdateText;

        if (CheckBoxManagerRuoi != null)
            CheckBoxManagerRuoi.CheckmarkChanged += UpdateText;

        if (CheckBoxManagerBeo != null)
            CheckBoxManagerBeo.CheckmarkChanged += UpdateText;

        if (CheckBoxManagerGay != null)
            CheckBoxManagerGay.CheckmarkChanged += UpdateText;

        if (CheckBoxManagerMu != null)
            CheckBoxManagerMu.CheckmarkChanged += UpdateText;

        if (CheckBoxManagerLongMay != null)
            CheckBoxManagerLongMay.CheckmarkChanged += UpdateText;

        // Cập nhật lần đầu
        UpdateText(true);
    }

    // Hàm này sẽ được gọi khi bất kỳ checkbox nào thay đổi trạng thái
    void UpdateText(bool _)
    {
        chatText.text = "Khách hàng biển " + animController.id.ToString();

        chatText.text += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " - Đã chọn Mũi" : " - Chưa chọn Mũi";
        chatText.text += CheckBoxManagerRuoi != null && CheckBoxManagerRuoi.checkmarkEnabled ? " - Đã chọn Ruồi" : " - Chưa chọn Ruồi";
        chatText.text += CheckBoxManagerBeo != null && CheckBoxManagerBeo.checkmarkEnabled ? " - Đã chọn Béo" : " - Chưa chọn Béo";
        chatText.text += CheckBoxManagerGay != null && CheckBoxManagerGay.checkmarkEnabled ? " - Đã chọn Gầy" : " - Chưa chọn Gầy";
        chatText.text += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " - Đã chọn Mũ" : " - Chưa chọn Mũ";
        chatText.text += CheckBoxManagerLongMay != null && CheckBoxManagerLongMay.checkmarkEnabled ? " - Đã chọn Long Mày" : " - Chưa chọn Long Mày";
    }

    // Nên unsubscribe event khi object bị hủy để tránh lỗi
    private void OnDestroy()
    {
        if (CheckBoxManagerMui != null)
            CheckBoxManagerMui.CheckmarkChanged -= UpdateText;

        if (CheckBoxManagerRuoi != null)
            CheckBoxManagerRuoi.CheckmarkChanged -= UpdateText;

        if (CheckBoxManagerBeo != null)
            CheckBoxManagerBeo.CheckmarkChanged -= UpdateText;

        if (CheckBoxManagerGay != null)
            CheckBoxManagerGay.CheckmarkChanged -= UpdateText;

        if (CheckBoxManagerMu != null)
            CheckBoxManagerMu.CheckmarkChanged -= UpdateText;

        if (CheckBoxManagerLongMay != null)
            CheckBoxManagerLongMay.CheckmarkChanged -= UpdateText;
    }
}
