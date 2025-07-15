using UnityEngine;

public class Note2 : MonoBehaviour
{
    public GameObject note1;
    public GameObject note2; // Reference to the next note panel
    public GameObject note3;

    public void buttonRight()
    {
        note2.SetActive(false); // Hide the current panel
        note3.SetActive(true); // Show the next panel
    }

    public void buttonLeft()
    {
        note2.SetActive(false); // Hide the current panel
        note1.SetActive(true); // Show the previous panel
    }
}
