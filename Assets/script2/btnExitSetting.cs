using UnityEngine;

public class btnExitSetting : MonoBehaviour
{
    public GameObject menuSetting;

    public void OnClickedBtnExitSetting()
    {
        menuSetting.SetActive(false);
    }
}
