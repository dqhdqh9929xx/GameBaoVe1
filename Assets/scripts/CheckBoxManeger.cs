using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBoxManeger : MonoBehaviour, IPointerClickHandler
{
    public Image checkmarkImage;
    public bool checkmarkEnabled = false;

    public delegate void OnCheckmarkChanged(bool isChecked);
    public event OnCheckmarkChanged CheckmarkChanged;

    public void Start()
    {
        if (checkmarkImage != null)
            checkmarkImage.gameObject.SetActive(checkmarkEnabled);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (checkmarkImage != null)
        {
            checkmarkEnabled = !checkmarkEnabled;
            checkmarkImage.gameObject.SetActive(checkmarkEnabled);

            if (CheckmarkChanged != null)
                CheckmarkChanged(checkmarkEnabled);
        }
    }
}
