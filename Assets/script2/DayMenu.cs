using TMPro;
using UnityEngine;

public class DayMenu : MonoBehaviour
{
    public TMP_Text dayLevel;
    void Start()
    {
        dayLevel.text = "Day " + PlayerData.level.ToString(); // Sử dụng PlayerData.level để lấy cấp độ hiện tại
    }

}
