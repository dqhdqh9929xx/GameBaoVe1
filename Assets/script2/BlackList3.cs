using UnityEngine;

public class BlackList3 : MonoBehaviour
{
    public GameObject blackList2; // Reference to the blacklist panel
    public GameObject blackList3; // Reference to the blacklist panel

    public void buttonLeft()
    {
        blackList3.SetActive(false); // Hide the current panel
        blackList2.SetActive(true); // Show the previous panel
    }

    public void buttonExit()
    {
        blackList3.SetActive(false); // Show the previous panel
    }
}
