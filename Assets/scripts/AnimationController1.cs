using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class AnimationController1 : MonoBehaviour
{
    public int id = 1;
    // Nhan Vat 1
    public Image imageFace;
    public Image imageSideWayCome;
    public Image imageSideWayLeft;
    public Animator AnimatorCome;
    public Animator AnimatorLeft;
    public GameObject NvChat; // Chỉ 1 GameObject duy nhất chứa TextMeshProUGUI
    public HistoryList historyList;
    public bool isCome = false;
    public bool isCome2 = false;
    public TextMeshProUGUI chatTextComponent;

    // Nhan Vat 2
    public Image imageFace2;
    public Image imageSideWayCome2;
    public Image imageSideWayLeft2;
    //public TextMeshProUGUI chatTextComponent2;




    void Start()
    {
        if (id == 1)
        {
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();

            if (imageSideWayCome != null) imageSideWayCome.enabled = true;
            if (imageSideWayLeft != null) imageSideWayLeft.enabled = false;
            if (imageFace != null) imageFace.enabled = false;
            if (imageSideWayLeft2 != null) imageSideWayLeft2.enabled = false;
            if (imageSideWayCome2 != null) imageSideWayCome2.enabled = false;
            if (imageFace2 != null) imageFace2.enabled = false;

            StartCoroutine(PlayComeAnimationAndShowChat());
        }
    }
    public void StartNv2()
    {
        if (id == 2)
        {
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            if (imageSideWayCome2 != null) imageSideWayCome2.enabled = true;
            if (imageSideWayLeft2 != null) imageSideWayLeft2.enabled = false;
            if (imageFace2 != null) imageFace2.enabled = false;
            if (imageSideWayLeft != null) imageSideWayLeft.enabled = false;
            if (imageSideWayCome != null) imageSideWayCome.enabled = false;
            if (imageFace != null) imageFace.enabled = false;
            StartCoroutine(PlayComeAnimationAndShowChat());
        }
    }

    public IEnumerator PlayComeAnimationAndShowChat()
    {
        if(id == 1)
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
        else if (id == 2)
        {
            if (AnimatorCome != null && imageSideWayCome2 != null && !isCome2)
            {
                Debug.Log("Bắt đầu animation Come ID2 " + id);
                AnimatorCome.SetTrigger("Come");
                yield return new WaitForSecondsRealtime(1.8f);
                isCome2 = true;
                imageSideWayCome2.enabled = false;
                if (imageFace2 != null) imageFace2.enabled = true;
                ShowNvChatCome();
            }
        }
        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }

    }

    public IEnumerator PlayLeftAnimationAndShowChat()
    {
        if (id == 1)
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
        else if (id == 2)
        {
            if (AnimatorLeft != null && imageSideWayLeft2 != null)
            {
                yield return new WaitForSecondsRealtime(1.8f);
                Debug.Log("Bắt đầu animation Left ID2 " + id);
                AnimatorLeft.SetTrigger("Left");
                if (imageFace2 != null) imageFace2.enabled = false;
                imageSideWayLeft2.enabled = true;
                ShowNvChatLeft();
            }
        }
        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }
    }

    public IEnumerator SideWayLeft()
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
        if (id == 1)
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
        else if (id == 2)
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
        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }
    }

    public void ShowNvChatLeft()
    {
        if (id == 1)
        {
            if (NvChat != null && chatTextComponent != null)
            {
                NvChat.SetActive(true);
                chatTextComponent.text = "Thanks ";
                StartCoroutine(TimeShowChat());
                imageFace.enabled = false;
                imageSideWayLeft.enabled = false;
                id++;
                StartNv2();
            }
            else
            {
                Debug.LogWarning("Loi ShowNvChatLeft.");
            }
        }
        else if (id == 2)
        {
            if (NvChat != null && chatTextComponent != null)
            {
                NvChat.SetActive(true);
                chatTextComponent.text = "Thanks 2";
                StartCoroutine(TimeShowChat());
                imageFace2.enabled = false;
                imageSideWayLeft2.enabled = false;
                
            }
            else
            {
                Debug.LogWarning("Loi ShowNvChatLeft.");
            }
        }
        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }

    }


}
