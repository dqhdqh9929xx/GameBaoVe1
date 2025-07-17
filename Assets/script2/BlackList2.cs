using UnityEngine;

public class BlackList2 : MonoBehaviour
{
    public GameObject blackList2; // Reference to the blacklist panel
    public GameObject blackList1; // Reference to the blacklist panel
    public GameObject blackList3; // Reference to the blacklist panel
    public void buttonRight()
    {
        blackList2.SetActive(false); // Hide the current panel
        blackList3.SetActive(true); // Show the next panel
    }

    public void buttonLeft()
    {
        blackList2.SetActive(false); // Hide the current panel
        blackList1.SetActive(true); // Show the previous panel
    }

    public void buttonExit()
    {
        blackList2.SetActive(false); // Hide the current panel
        // Optionally, you can add logic to return to the main menu or another scene
    }


}
