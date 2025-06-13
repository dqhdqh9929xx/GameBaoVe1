using UnityEngine;

public class spray : MonoBehaviour
{
    public bool isSprayActive = false;
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
            SprayT.position = new Vector2(1500, 200);
        }
    }
}


