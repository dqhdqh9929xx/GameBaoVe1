using UnityEngine;

public class Spray : MonoBehaviour
{
    public static bool isSprayActive = false;

    public Vector3 Origin;

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
        if (isSprayActive)
        {
            Vector2 mousePos = Input.mousePosition;
            transform.position = mousePos;
        }
        else
        {
            transform.position = Origin;
        }
    }
}


