using UnityEngine;
using TMPro;

public class HistoryList : MonoBehaviour
{
    public AnimationController1 animController;
    public AnimationController2 animController2;

    public CheckBoxManeger CheckBoxManagerMui;
    public CheckBoxManeger CheckBoxManagerMat;
    public CheckBoxManeger CheckBoxManagerKhuonMat;
    public CheckBoxManeger CheckBoxManagerMieng;
    public CheckBoxManeger CheckBoxManagerMu;
    public CheckBoxManeger CheckBoxManagerPhuKien;

    public TMP_Text chatText;

    public bool isSnapshotSaved = false;
    public bool isSnapshotSaved2 = false;

    void Start()
    {
        chatText = GetComponent<TMP_Text>();
        if (chatText == null || animController == null)
        {
            Debug.LogWarning("HistoryList: TMP_Text component or AnimationController missing!");
            return;
        }

        if (animController2 != null || chatText == null )
        {
            Debug.LogWarning("HistoryList: TMP_Text component or AnimationController2 missing!");
            return;
        }

        if (!isSnapshotSaved)
        {
            if (CheckBoxManagerMui != null)
                CheckBoxManagerMui.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMat != null)
                CheckBoxManagerMat.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerKhuonMat != null)
                CheckBoxManagerKhuonMat.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMieng != null)
                CheckBoxManagerMieng.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMu != null)
                CheckBoxManagerMu.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerPhuKien != null)
                CheckBoxManagerPhuKien.CheckmarkChanged += UpdateText;

            UpdateText(true);
        }

        if (!isSnapshotSaved2)
        {
            if (CheckBoxManagerMui != null)
                CheckBoxManagerMui.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMat != null)
                CheckBoxManagerMat.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerKhuonMat != null)
                CheckBoxManagerKhuonMat.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMieng != null)
                CheckBoxManagerMieng.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerMu != null)
                CheckBoxManagerMu.CheckmarkChanged += UpdateText;
            if (CheckBoxManagerPhuKien != null)
                CheckBoxManagerPhuKien.CheckmarkChanged += UpdateText;

            UpdateText2(true);
        }
    }

    void UpdateText(bool _)
    {
        if (isSnapshotSaved) return;

        chatText.text = "#" + animController.id.ToString();

        chatText.text += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
        chatText.text += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
        chatText.text += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
        chatText.text += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
        chatText.text += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
        chatText.text += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";
    }

    void UpdateText2(bool _)
    {
        if (isSnapshotSaved2) return;

        chatText.text = "#" + animController2.id.ToString();

        chatText.text += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
        chatText.text += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
        chatText.text += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
        chatText.text += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
        chatText.text += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
        chatText.text += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";
    }

    public void SaveSnapshot()
    {
        isSnapshotSaved = true;

        string snapshot = "#" + animController.id.ToString();

        snapshot += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
        snapshot += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
        snapshot += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
        snapshot += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
        snapshot += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
        snapshot += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";

        chatText.text = snapshot;

        if (CheckBoxManagerMui != null)
            CheckBoxManagerMui.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMat != null)
            CheckBoxManagerMat.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerKhuonMat != null)
            CheckBoxManagerKhuonMat.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMieng != null)
            CheckBoxManagerMieng.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMu != null)
            CheckBoxManagerMu.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerPhuKien != null)
            CheckBoxManagerPhuKien.CheckmarkChanged -= UpdateText;
    }

    public void SaveSnapshot2()
    {
        isSnapshotSaved2 = true;

        string snapshot = "#" + animController2.id.ToString();

        snapshot += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
        snapshot += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
        snapshot += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
        snapshot += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
        snapshot += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
        snapshot += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";

        chatText.text = snapshot;

        if (CheckBoxManagerMui != null)
            CheckBoxManagerMui.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMat != null)
            CheckBoxManagerMat.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerKhuonMat != null)
            CheckBoxManagerKhuonMat.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMieng != null)
            CheckBoxManagerMieng.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerMu != null)
            CheckBoxManagerMu.CheckmarkChanged -= UpdateText;
        if (CheckBoxManagerPhuKien != null)
            CheckBoxManagerPhuKien.CheckmarkChanged -= UpdateText;
    }

    public void OnDestroy()
    {
        if (!isSnapshotSaved)
        {
            if (CheckBoxManagerMui != null)
                CheckBoxManagerMui.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMat != null)
                CheckBoxManagerMat.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerKhuonMat != null)
                CheckBoxManagerKhuonMat.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMieng != null)
                CheckBoxManagerMieng.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMu != null)
                CheckBoxManagerMu.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerPhuKien != null)
                CheckBoxManagerPhuKien.CheckmarkChanged -= UpdateText;
        }
    }

    public void OnDestroy2()
    {
        if (!isSnapshotSaved2)
        {
            if (CheckBoxManagerMui != null)
                CheckBoxManagerMui.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMat != null)
                CheckBoxManagerMat.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerKhuonMat != null)
                CheckBoxManagerKhuonMat.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMieng != null)
                CheckBoxManagerMieng.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerMu != null)
                CheckBoxManagerMu.CheckmarkChanged -= UpdateText;
            if (CheckBoxManagerPhuKien != null)
                CheckBoxManagerPhuKien.CheckmarkChanged -= UpdateText;
        }
    }
}
