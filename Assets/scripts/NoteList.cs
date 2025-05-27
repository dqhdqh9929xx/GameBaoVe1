using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class NoteList : MonoBehaviour, IPointerClickHandler
{
    public GameObject Mui;
    public GameObject Ruoi;
    public GameObject Beo;
    public GameObject Gay;
    public GameObject Mu;
    public GameObject LongMay;
    public GameObject HistoryList;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mui != null)
            Mui.SetActive(true);
        if (Ruoi != null)
            Ruoi.SetActive(true);
        if (Beo != null)
            Beo.SetActive(true);
        if (Gay != null)
            Gay.SetActive(true);
        if (Mu != null)
            Mu.SetActive(true);
        if (LongMay != null)
            LongMay.SetActive(true);
        if (HistoryList != null)
            HistoryList.SetActive(false);
    }
}
