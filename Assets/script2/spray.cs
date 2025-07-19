using UnityEngine;

public class Spray : MonoBehaviour
{
    public static bool isSprayActive = false;

    public Vector3 Origin;

    public static float timeRemaining = 5f;

    private void Start()
    {
        Origin = transform.position;
    }

    public void SelectSpray()
    {
        isSprayActive = true;
    }

    void Update()
    {
        if (isSprayActive && timeRemaining > 0)
        {
            Vector2 mousePos = Input.mousePosition;
            transform.position = mousePos;
            timeRemaining -= Time.deltaTime; // sau 5 giây sẽ trả lại vị trí ban đầu
        }
        else
        {
            transform.position = Origin;
        }
    }
}


