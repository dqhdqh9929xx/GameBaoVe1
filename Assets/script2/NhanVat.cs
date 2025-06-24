using UnityEngine;
using UnityEngine.UI;

public class NhanVat : MonoBehaviour
{
    public Sprite normalImage;
    public Sprite attackImage;
    public Sprite attackImageFake;
    public Sprite imageFake;

    public bool isTrueChoiceCome { get; internal set; }
    public bool isTrueChoiceOut { get; internal set; }

    public string characterNames { get; internal set; }
    public int characterId { get; internal set; }
    public string characterChatIn { get; internal set; }
    public string characterChatOut { get; internal set; }



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

    public void OnAttackFake()
    {
        var image = GetComponent<Image>();
        image.sprite = attackImageFake;
        image.enabled = true;
    }

    public void OnInvisible()
    {
        var image = GetComponent<Image>();
        image.enabled = false;
    }

    public void OnImageFake()
    {
        var image = GetComponent<Image>();
        image.sprite = imageFake;
        image.enabled = true;
    }
}
