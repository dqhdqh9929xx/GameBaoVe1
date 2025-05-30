using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayer : MonoBehaviour
{
    public AnimationController1 animationController;
    public TMPro.TextMeshProUGUI textMeshProUGUI;
    public CheckBoxManeger checkBoxManegerMui;
    public CheckBoxManeger checkBoxManegerKhuonMat;
    public CheckBoxManeger checkBoxManegerMat;
    public CheckBoxManeger checkBoxManegerMieng;
    public CheckBoxManeger checkBoxManegerMu;
    public CheckBoxManeger checkBoxManegerPhuKien;
    public bool checkmarkEnabled = false;
    public Image checkmarkMui;
    public Image checkmarkKhuonMat;
    public Image checkmarkMat;
    public Image checkmarkMieng;
    public Image checkmarkMu;
    public Image checkmarkPhuKien;



    void Awake()
    {
        if (animationController != null)
        {
            checkBoxManegerMui.ResetCheckBoxMui(checkmarkMui);
            checkBoxManegerKhuonMat.ResetCheckBoxkhuonMat(checkmarkKhuonMat);
            checkBoxManegerMat.ResetCheckBoxMat(checkmarkMat);
            checkBoxManegerMieng.ResetCheckBoxMieng(checkmarkMieng);
            checkBoxManegerMu.ResetCheckBoxMu(checkmarkMu);
            checkBoxManegerPhuKien.ResetCheckBoxPhuKien(checkmarkPhuKien);


            textMeshProUGUI.text = "#" + animationController.id + "/";
        }    
    }

}
