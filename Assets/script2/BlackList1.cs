using UnityEngine;

public class BlackList1 : MonoBehaviour
{
    public GameObject blackList2; // Reference to the blacklist panel
    public GameObject blackList1; // Reference to the blacklist panel
    public void buttonRight()
    {
        blackList1.SetActive(false); // Hide the current panel
        blackList2.SetActive(true); // Show the next panel
    }

    public void buttonExit()
    {
        blackList1.SetActive(false); // Show the previous panel
    }
}
