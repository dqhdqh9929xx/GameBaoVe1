using UnityEngine;
using UnityEngine.UI;

public class WindowView : MonoBehaviour
{
    public Sprite sprite;

    public void ChangeWindowView()
    {
        GetComponent<Image>().sprite = sprite;
        Debug.Log("Window view changed to: " + sprite.name);
    }    
}
