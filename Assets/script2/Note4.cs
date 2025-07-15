using UnityEngine;

public class Note4 : MonoBehaviour
{
    public GameObject note3;
    public GameObject note4; // Reference to the next note panel
    public GameObject note5;

    public void buttonRight()
    {
        note4.SetActive(false); // Hide the current panel
        note5.SetActive(true); // Show the next panel
    }

    public void buttonLeft()
    {
        note4.SetActive(false); // Hide the current panel
        note3.SetActive(true); // Show the previous panel
    }
}
