using UnityEngine;

public class DanhSachBlackList : MonoBehaviour
{
    public GameObject listFullScreenPanel;
    void Start()
    {
        if (listFullScreenPanel != null)
            listFullScreenPanel.SetActive(false);
    }


    public void OpenListFullScreen()
    {
        if (listFullScreenPanel != null)
        {
            listFullScreenPanel.SetActive(true);
        }
    }

    public void CloseListFullScreen()
    {
        if (listFullScreenPanel != null)
        {
            listFullScreenPanel.SetActive(false);
        }
    }
}
