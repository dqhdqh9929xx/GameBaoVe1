using UnityEngine;

public class btnSetting : MonoBehaviour
{
    
    public GameObject settingMenu; 

    public void OnClickedBtnSetting()
    {
        settingMenu.SetActive(true);
        Time.timeScale = 0; // Pause the game when the settings menu is opened
    }


}
