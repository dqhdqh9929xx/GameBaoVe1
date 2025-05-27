using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class HistoryBookManeger : MonoBehaviour, IPointerClickHandler
{
    public GameObject Mui;
    public GameObject Ruoi;
    public GameObject Beo;
    public GameObject Gay;
    public GameObject Mu;
    public GameObject LongMay;
    public GameObject HistoryList;
    void Start()
    {
        if (HistoryList != null)
            HistoryList.SetActive(false);
        if (Mui != null)
            Mui.SetActive(true);
        if (Ruoi != null)
            Ruoi.SetActive(true);
        if (Beo != null)
            Beo.SetActive(true);
        if(Gay != null)
            Gay.SetActive(true);
        if (Mu != null)
            Mu.SetActive(true);
        if (LongMay != null)
            LongMay.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mui != null)
            Mui.SetActive(false);
        if (Ruoi != null)
            Ruoi.SetActive(false);
        if (Beo != null)
            Beo.SetActive(false);
        if (Gay != null)
            Gay.SetActive(false);
        if (Mu != null)
            Mu.SetActive(false);
        if (LongMay != null)
            LongMay.SetActive(false);
        if (HistoryList != null)
            HistoryList.SetActive(true);
    }
}
