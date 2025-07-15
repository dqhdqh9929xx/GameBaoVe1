using UnityEngine;

public class Note5 : MonoBehaviour
{
    public GameObject note4;
    public GameObject note5; // Reference to the next note panel

    public void buttonLeft()
    {
        note5.SetActive(false); // Hide the current panel
        note4.SetActive(true); // Show the next panel
    }
}
