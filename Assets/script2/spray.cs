using UnityEngine;

public class spray : MonoBehaviour
{
    private bool isSprayActive = false;
    [SerializeField] Transform SprayT;
    public void SelectSpray()
    {
        isSprayActive = true;
    }
    void Update()
    {
        if (isSprayActive == true)
        {
            Vector2 mousePos = Input.mousePosition;
            SprayT.position = mousePos;
        }
        if (isSprayActive == false)
        {
            SprayT.position = SprayT.transform.position;
        }
    }
}


