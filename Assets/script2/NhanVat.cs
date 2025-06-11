using UnityEngine;
using UnityEngine.UI;

public class NhanVat : MonoBehaviour
{
    public Sprite normalImage;
    public Sprite attackImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNormal()
    {
        var image = GetComponent<Image>();
        image.sprite = normalImage;
    }

    public void OnAttack()
    {
        var image = GetComponent<Image>();
        image.sprite = attackImage;
    }
}
