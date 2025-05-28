using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class HistoryBookManeger : MonoBehaviour, IPointerClickHandler
{
    public GameObject Mui;
    public GameObject Mat;
    public GameObject KhuonMat;
    public GameObject Mieng;
    public GameObject Mu;
    public GameObject PhuKien;
    public GameObject HistoryList;
    void Start()
    {
        if (HistoryList != null)
            HistoryList.SetActive(false);
        if (Mui != null)
            Mui.SetActive(true);
        if (Mat != null)
            Mat.SetActive(true);
        if (KhuonMat != null)
            KhuonMat.SetActive(true);
        if(Mieng != null)
            Mieng.SetActive(true);
        if (Mu != null)
            Mu.SetActive(true);
        if (PhuKien != null)
            PhuKien.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mui != null)
            Mui.SetActive(false);
        if (Mat != null)
            Mat.SetActive(false);
        if (KhuonMat != null)
            KhuonMat.SetActive(false);
        if (Mieng != null)
            Mieng.SetActive(false);
        if (Mu != null)
            Mu.SetActive(false);
        if (PhuKien != null)
            PhuKien.SetActive(false);
        if (HistoryList != null)
            HistoryList.SetActive(true);
    }
}
