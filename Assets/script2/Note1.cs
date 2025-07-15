using UnityEngine;

public class Note1 : MonoBehaviour
{
    public GameObject note1;
    public GameObject note2; // Reference to the next note panel

    public void buttonRight()
    {
        note1.SetActive(false); // Hide the current panel
        note2.SetActive(true); // Show the next panel
    }

    //public void buttonLeft()
    //{
    //    note1.SetActive(false); // Hide the current panel
    //    blackList1.SetActive(true); // Show the previous panel
    //}

}
