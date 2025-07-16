using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Hoặc dùng TMPro nếu dùng TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Kéo Text UI vào đây trong Inspector

    public static float timeRemaining = 5f;
    public static bool isCounting = false;
    //public DrawOnCanvas DrawOnCanvas; // Kéo đối tượng DrawOnCanvas vào đây trong Inspector
    public static event Action endTimeToDraw;

    void Update()
    {
        if (isCounting)
        {
            if (timeRemaining > 0)
            {
                DrawOnCanvas.isDrawingEnabled = true; // Bật vẽ khi đếm ngược
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timerText.enabled = false; // Ẩn Text khi đếm ngược xong
                isCounting = false;
                UpdateTimerDisplay();
                //endTimeToDraw?.Invoke(); // Gọi sự kiện khi đếm ngược xong
                OnCountdownFinished(); // Gọi hàm khi đếm ngược xong
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = seconds.ToString();
    }

    void OnCountdownFinished()
    {
        Debug.Log("Countdown Finished!");
        DrawOnCanvas.isDrawingEnabled = false;
    }

    public void ResetTimeCount()
    {
        timeRemaining = 5f; // Đặt lại thời gian đếm ngược
        //isCounting = true; // Bắt đầu đếm ngược
        UpdateTimerDisplay(); // Cập nhật hiển thị thời gian
    }    
}
