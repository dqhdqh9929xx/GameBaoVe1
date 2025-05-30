using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBoxManeger : MonoBehaviour, IPointerClickHandler
{
    public Image checkmarkImage;
    public bool checkmarkEnabled = false;
    public delegate void OnCheckmarkChanged(bool isChecked);
    public event OnCheckmarkChanged CheckmarkChanged;
    //public HistoryList historyList;
    public Image checkmarkMui;
    public Image checkmarkKhuonMat;
    public Image checkmarkMat;
    public Image checkmarkMieng;
    public Image checkmarkMu;
    public Image checkmarkPhuKien;

    public void Start()
    {
        if (checkmarkImage != null)
           checkmarkImage.gameObject.SetActive(checkmarkEnabled);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (checkmarkImage != null)
        {
            checkmarkEnabled = !checkmarkEnabled;
            checkmarkImage.gameObject.SetActive(checkmarkEnabled);

            if (CheckmarkChanged != null)
                CheckmarkChanged(checkmarkEnabled);
        }
    }
    public void ResetCheckBoxMui(Image checkmarkMui)
    {
        checkmarkEnabled = false;
        if (checkmarkMui != null)
            checkmarkMui.gameObject.SetActive(checkmarkEnabled);
    }

    public void ResetCheckBoxkhuonMat(Image checkmarkKhuonMat)
    {
        checkmarkEnabled = false;
        if (checkmarkKhuonMat != null)
            checkmarkKhuonMat.gameObject.SetActive(checkmarkEnabled);
    }

    public void ResetCheckBoxMat(Image checkmarkMat)
    {
        checkmarkEnabled = false;
        if (checkmarkMat != null)
            checkmarkMat.gameObject.SetActive(checkmarkEnabled);
    }
    public void ResetCheckBoxMieng(Image checkmarkMieng)
    {
        checkmarkEnabled = false;
        if (checkmarkMieng != null)
            checkmarkMieng.gameObject.SetActive(checkmarkEnabled);
    }
    public void ResetCheckBoxMu(Image checkmarkMu)
    {
        checkmarkEnabled = false;
        if (checkmarkMu != null)
            checkmarkMu.gameObject.SetActive(checkmarkEnabled);
    }
    public void ResetCheckBoxPhuKien(Image checkmarkPhuKien)
    {
        checkmarkEnabled = false;
        if (checkmarkPhuKien != null)
            checkmarkPhuKien.gameObject.SetActive(checkmarkEnabled);
    }
}
