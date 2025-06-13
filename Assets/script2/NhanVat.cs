using UnityEngine;
using UnityEngine.UI;

public class NhanVat : MonoBehaviour
{
    public Sprite normalImage;
    public Sprite attackImage;

    public bool isTrueChoiceCome { get; internal set; }

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
        image.enabled = true; 
    }

    public void OnAttack()
    {
        var image = GetComponent<Image>();
        image.sprite = attackImage;
        image.enabled = true; 
    }

    public void OnInvisible()
    {
        var image = GetComponent<Image>();
        image.enabled = false;
    }
}
