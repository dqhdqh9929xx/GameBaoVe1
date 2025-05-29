using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HistoryList : MonoBehaviour
{
    public AnimationController1 animController;
    //public AnimationController2 animController2;

    public CheckBoxManeger CheckBoxManagerMui;
    public CheckBoxManeger CheckBoxManagerMat;
    public CheckBoxManeger CheckBoxManagerKhuonMat;
    public CheckBoxManeger CheckBoxManagerMieng;
    public CheckBoxManeger CheckBoxManagerMu;
    public CheckBoxManeger CheckBoxManagerPhuKien;
    //public Image checkmarkImage;
    //public CheckBoxManeger checkBoxManeger;
    public TMP_Text NoteText;
    public TMP_Text NoteText2;

    public bool isSnapshotSaved = false;
    public GameObject HistoryList2;

    public bool isSnapshotSaved2 = false;

    //string snapshot;

    void Start()
    {
        if (animController.id == 1)
        {
            NoteText = GetComponent<TMP_Text>();
            if (NoteText == null || animController == null)
            {
                Debug.LogWarning("HistoryList: TMP_Text component or AnimationController missing!");
                return;
            }
            HistoryList2.SetActive(false);
        }
        if (animController.id == 2)
        {
            HistoryList2.SetActive(true);
            NoteText2 = GetComponent<TMP_Text>();
            if (NoteText2 == null || animController == null)
            {
                Debug.LogWarning("HistoryList: TMP_Text2 component or AnimationController missing!");
                return;
            }
        }



        if (animController.id == 1)
        {
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
        }
        if (animController.id == 2)
        {
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
                UpdateText(true);
            }
        }

    }

    void UpdateText(bool _)
    {
        if ( animController.id == 1)
        {
            if (isSnapshotSaved) return;

            NoteText.text = "#" + animController.id.ToString();

            NoteText.text += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
            NoteText.text += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
            NoteText.text += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
            NoteText.text += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
            NoteText.text += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
            NoteText.text += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";
        }
        if (animController.id == 2)
        {
            if (isSnapshotSaved) return;
            NoteText2.text = "#" + animController.id.ToString();
            NoteText2.text += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
            NoteText2.text += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
            NoteText2.text += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
            NoteText2.text += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
            NoteText2.text += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
            NoteText2.text += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";
        }

    }


    public void SaveSnapshot()
    {
        if (animController.id == 1)
        {
            isSnapshotSaved = true;

            string snapshot = "#" + animController.id.ToString();

            snapshot += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
            snapshot += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
            snapshot += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
            snapshot += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
            snapshot += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
            snapshot += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";


            NoteText.text = snapshot;


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
        if (animController.id == 2)
        {
            isSnapshotSaved2 = true;
            string snapshot2 = "#" + animController.id.ToString();
            snapshot2 += CheckBoxManagerMui != null && CheckBoxManagerMui.checkmarkEnabled ? " /V Nose/ " : " /X Nose/ ";
            snapshot2 += CheckBoxManagerMat != null && CheckBoxManagerMat.checkmarkEnabled ? " /V Eyes/ " : " /X Eyes/ ";
            snapshot2 += CheckBoxManagerKhuonMat != null && CheckBoxManagerKhuonMat.checkmarkEnabled ? " /V Face/ " : " /X Face/ ";
            snapshot2 += CheckBoxManagerMieng != null && CheckBoxManagerMieng.checkmarkEnabled ? " /V Mouth/ " : " /X Mouth/ ";
            snapshot2 += CheckBoxManagerMu != null && CheckBoxManagerMu.checkmarkEnabled ? " /V Cap/ " : " /X Cap/ ";
            snapshot2 += CheckBoxManagerPhuKien != null && CheckBoxManagerPhuKien.checkmarkEnabled ? " /V Jewelry / " : " /X Jewelry/ ";
            NoteText2.text = snapshot2;
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


    public void OnDestroy()
    {
        if (animController.id == 1)
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
        if (animController.id == 2)
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






}
