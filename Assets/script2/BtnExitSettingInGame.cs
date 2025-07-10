using UnityEngine;

public class BtnExitSettingInGame : MonoBehaviour
{
    public GameObject menuSetting;

    public void OnClickedBtnExitSetting()
    {
        menuSetting.SetActive(false);
        Time.timeScale = 1f; // Resume the game time when exiting settings
    }
}
