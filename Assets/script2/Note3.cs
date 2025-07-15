using UnityEngine;

public class Note3 : MonoBehaviour
{
    public GameObject note2;
    public GameObject note3; // Reference to the next note panel
    public GameObject note4;

    public void buttonRight()
    {
        note3.SetActive(false); // Hide the current panel
        note4.SetActive(true); // Show the next panel
    }

    public void buttonLeft()
    {
        note3.SetActive(false); // Hide the current panel
        note2.SetActive(true); // Show the previous panel
    }
}
