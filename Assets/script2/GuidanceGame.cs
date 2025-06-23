using UnityEngine;

public class GuidanceGame : MonoBehaviour
{
    public GameObject guidance1;
    public GameObject guidance2;
    public GameObject guidance3;
    public GameObject guidance4;
    public GameObject guidance5;
    public GameObject guidance6;

    public void OnClickedGuidance1()
    {
        guidance1.SetActive(false);
        guidance2.SetActive(true);
        Destroy(guidance1); // Optionally destroy the first guidance object
    }
    public void OnClickedGuidance2()
    {
        guidance2.SetActive(false);
        guidance3.SetActive(true);
        Destroy(guidance2); // Optionally destroy the second guidance object
    }
    public void OnClickedGuidance3()
    {
        guidance3.SetActive(false);
        guidance4.SetActive(true);
        Destroy(guidance3);
    }
    public void OnClickedGuidance4()
    {
        guidance4.SetActive(false);
        guidance5.SetActive(true);
        Destroy(guidance4);
    }
    public void OnClickedGuidance5()
    {
        guidance5.SetActive(false);
        guidance6.SetActive(true);
        Destroy(guidance5);
    }
    public void OnClickedGuidance6()
    {
        guidance6.SetActive(false);
        // Optionally, you can add code here to indicate the end of the guidance sequence
        Debug.Log("Guidance completed!");
        Destroy(guidance6); // Optionally destroy the last guidance object
    }
}
