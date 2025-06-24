using UnityEngine;

public class btnBlackList : MonoBehaviour
{
    public GameObject blackList; // Reference to the blacklist panel


    public void OpenBlackList()
    {
         blackList.SetActive(true); // Show the blacklist panel
    }    
}
