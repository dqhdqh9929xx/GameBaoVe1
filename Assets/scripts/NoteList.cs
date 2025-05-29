using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class NoteList : MonoBehaviour, IPointerClickHandler
{
    public GameObject Mui;
    public GameObject Mat;
    public GameObject KhuonMat;
    public GameObject Mieng;
    public GameObject Mu;
    public GameObject PhuKien;
    public GameObject HistoryList;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mui != null)
            Mui.SetActive(true);
        if (Mat != null)
            Mat.SetActive(true);
        if (KhuonMat != null)
            KhuonMat.SetActive(true);
        if (Mieng != null)
            Mieng.SetActive(true);
        if (Mu != null)
            Mu.SetActive(true);
        if (PhuKien != null)
            PhuKien.SetActive(true);
        if (HistoryList != null)
            HistoryList.SetActive(false);


    }
}
