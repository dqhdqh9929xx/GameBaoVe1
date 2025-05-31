using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class AnimationController1 : MonoBehaviour
{
    public GameObject Player;
    public int id = 1;
    public TextMeshProUGUI chatTextComponent;
    public GameObject NvChat;
    public Animator Animator;


    // Nhan Vat 1
    public Image image1;
    public bool isCome = false;


    // Nhan Vat 2
    public Image image2;
    public bool isCome2 = false;

    // Nhan Vat 3
    public Image image3;
    public bool isCome3 = false;

    public bool NextNv = false;





    void Start()
    {
        if (id == 1)
        {
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();

            image1.enabled=true;
            image2.enabled = false;
            image3.enabled = false;
            NextNv = false;

            StartCoroutine(PlayComeAnimationAndShowChat());
        }
    }
    public void StartNv2()
    {
        if (id == 2 && image2 != null)
        {
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            image2.enabled = true;
            image1.enabled = false;
            NextNv = true;

            StartCoroutine(PlayComeAnimationAndShowChat());
            //NextNv = true;
        }
    }

    public void StartNv3()
    {
        if (id == 3 && image3 != null)
        {
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            image3.enabled = true;
            image1.enabled = false;
            image2.enabled = false;
            NextNv = true;
            StartCoroutine(PlayComeAnimationAndShowChat());
            //NextNv = true;
        }
    }

    public IEnumerator PlayComeAnimationAndShowChat()
    {
        if(id == 1)
        {
            if (image1 != null && !isCome)
            {
                Animator.Play("ComeA");
                isCome = true;
                yield return new WaitForSecondsRealtime(2.5f);
                ShowNvChatCome();
            }
        }
        else if (id == 2)
        {
            if (image2 != null && !isCome2)
            {
                isCome2 = true;
                Animator.Play("ComeA");
                yield return new WaitForSecondsRealtime(2.5f);
                ShowNvChatCome();
            }
        }
        else if (id == 3)
        {
            if (image3 != null && !isCome3)
            {
                isCome3 = true;
                Animator.Play("ComeA");
                yield return new WaitForSecondsRealtime(2.5f);
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
                ShowNvChatLeft();
                Animator.Play("LeftA");
                yield return new WaitForSecondsRealtime(2.5f);
                image1.enabled = false;
                id++;
                StartNv2();
        }
        else if (id == 2)
        {
                ShowNvChatLeft();
                Animator.Play("LeftA");
                yield return new WaitForSecondsRealtime(2.5f);
                image2.enabled = false;
                id++;
                StartNv3();
        }
        else if (id == 3)
        {
            ShowNvChatLeft();
            Animator.Play("LeftA");
            yield return new WaitForSecondsRealtime(2.5f);
            image2.enabled = false;
        }
        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }
    }

    public IEnumerator SideWayLeft()
    {
        yield return StartCoroutine(PlayLeftAnimationAndShowChat());
    }

    public IEnumerator TimeShowChat()
    {
        yield return new WaitForSeconds(2.5f);
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
        else if (id == 3)
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
            }
            else
            {
                Debug.LogWarning("Loi ShowNvChatLeft.");
            }
        }
        else if (id == 3)
        {
            if (NvChat != null && chatTextComponent != null)
            {
                NvChat.SetActive(true);
                chatTextComponent.text = "Thanks 3";
                StartCoroutine(TimeShowChat());
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
