using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AnimationController2 : MonoBehaviour
{
    public int id = 2;
    // Nhan Vat 1
    public Image imageFace;
    public Image imageSideWayCome;
    public Image imageSideWayLeft;
    public Animator AnimatorCome;
    public Animator AnimatorLeft;
    public GameObject NvChat; // Chỉ 1 GameObject duy nhất chứa TextMeshProUGUI
    public HistoryList historyList;
    public bool isCome = false;
    public TextMeshProUGUI chatTextComponent;
    void Start()
    {
        if (NvChat != null)
            chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
        //SetActiveById(id);
        if (imageSideWayCome != null) imageSideWayCome.enabled = true;
        if (imageSideWayLeft != null) imageSideWayLeft.enabled = false;
        if (imageFace != null) imageFace.enabled = false;
        StartCoroutine(PlayComeAnimationAndShowChat());
    }
    public IEnumerator PlayComeAnimationAndShowChat()
    {
        if (AnimatorCome != null && imageSideWayCome != null && !isCome)
        {
            Debug.Log("Bắt đầu animation Come ID " + id);
            AnimatorCome.SetTrigger("Come");
            yield return new WaitForSecondsRealtime(1.8f);
            isCome = true;
            imageSideWayCome.enabled = false;
            if (imageFace != null) imageFace.enabled = true;
            ShowNvChatCome();
        }
    }
    public IEnumerator PlayLeftAnimationAndShowChat()
    {
        if (AnimatorLeft != null && imageSideWayLeft != null)
        {
            yield return new WaitForSecondsRealtime(1.8f);
            Debug.Log("Bắt đầu animation Left ID " + id);
            AnimatorLeft.SetTrigger("Left");
            if (imageFace != null) imageFace.enabled = false;
            imageSideWayLeft.enabled = true;
            ShowNvChatLeft();
        }
    }
    public IEnumerator SideWayLeft2()
    {
        if (historyList != null)
        {
            historyList.SaveSnapshot();
        }
        yield return StartCoroutine(PlayLeftAnimationAndShowChat());
    }
    public IEnumerator TimeShowChat()
    {
        yield return new WaitForSeconds(2f);
        if (NvChat != null && chatTextComponent != null)
        {
            NvChat.SetActive(false);
            chatTextComponent.text = "";
        }
        else
        {
            Debug.LogWarning("Loi TimeShowChat.");
        }
    }


    public void ShowNvChatCome()
    {
        if (NvChat != null && chatTextComponent != null)
        {
            NvChat.SetActive(true);
            chatTextComponent.text = "Biển số xe tôi là " + id.ToString();
            StartCoroutine(TimeShowChat());
        }
        else
        {
            Debug.LogWarning("Loi ShowNvChatCome.");
        }
    }

    public void ShowNvChatLeft()
    {
        if (NvChat != null && chatTextComponent != null)
        {
            NvChat.SetActive(true);
            chatTextComponent.text = "Thanks ";
            StartCoroutine(TimeShowChat());
            imageFace.enabled = false;
            imageSideWayLeft.enabled = false;
            imageSideWayLeft.enabled = false;
        }
        else
        {
            Debug.LogWarning("Loi ShowNvChatLeft.");
        }
    }

}
