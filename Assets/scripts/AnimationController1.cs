using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimationController1 : MonoBehaviour
{
    public GameObject Player;
    public int id = 1;
    public TextMeshProUGUI chatTextComponent;
    public GameObject NvChat;
    public Animator Animator;
    public GameClickManeger GameClickManager1;
    public bool hasInstantiatedTicket = false;
    public Transform KhayDungDo;
    public TextMeshProUGUI TicketComponent;
    public GameObject TicketNvFullScreen;
    public GameObject TicketNv;
    public GameObject Coin;
    public bool IsTicket = false;
    public GameObject newPrefabTicket;
    // Nhan Vat 1
    public Image image1;
    public Image image1_cay;
    public bool isCome = false;
    public bool isLeft = false;

    // Nhan Vat 2
    public Image image2;
    public Image image2_cay;
    public bool isCome2 = false;
    public bool isLeft2 = false;

    // Nhan Vat 3
    public Image image3;
    public Image image3_cay;
    public bool isCome3 = false;
    public bool isLeft3 = false;

    public bool NextNv = false;


    private void Update()
    {
        if (hasInstantiatedTicket == false && TicketNv != null && IsTicket == true)
        {
            hasInstantiatedTicket = true;
            Vector3 localPosTicket = KhayDungDo.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x, localPosTicket.y - 300f, localPosTicket.z);
            newPrefabTicket = Instantiate(TicketNv);
            newPrefabTicket.transform.SetParent(KhayDungDo, false);
            newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
            newPrefabTicket.SetActive(true);
            TicketComponent = TicketNvFullScreen.GetComponentInChildren<TextMeshProUGUI>();
            TicketComponent.transform.SetParent(TicketNvFullScreen.transform, false);
            TicketComponent.text = "#" + id.ToString();
        }
        if (IsTicket == false)
        {
            newPrefabTicket.SetActive(false);
        }
    }



    void Start()
    {
        if (id == 1)
        {
            IsTicket = false;
            if (NvChat != null)
                chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();

            image1.enabled=true;
            image2.enabled = false;
            image3.enabled = false;
            image1_cay.enabled=false;
            image2_cay.enabled=false;
            image3_cay.enabled=false;
            NextNv = false;
            //TicketNv.SetActive(true);

            StartCoroutine(PlayComeAnimationAndShowChat());
        }
    }
    public void StartNv2()
    {
        if (id == 2 && image2 != null)
        {
            IsTicket = false;
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
            IsTicket = false;
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

    public void StartNv1B()
    {
        if (id == 4)
        {
            IsTicket = false;
            hasInstantiatedTicket = false;
            chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            image1.enabled = true;
            NextNv = false;
            StartCoroutine(PlayComeAnimationAndShowChatB());
        }
    }
    public void StartNv2B()
    {
        if (id == 5)
        {
            IsTicket = false;
            hasInstantiatedTicket = false;
            Debug.Log("StartNv2B called, id: " + id);
            chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            image2.enabled = true;
            NextNv = false;
            StartCoroutine(PlayComeAnimationAndShowChatB());

        }
    }
    public void StartNv3B()
    {
        if (id == 6)
        {
            hasInstantiatedTicket = false;
            IsTicket = false;
            Debug.Log("StartNv3B called, id: " + id);
            chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            image3.enabled = true;
            NextNv = false;
            StartCoroutine(PlayComeAnimationAndShowChatB());
        }
    }

    

    public void InstantiateCoin()
    {
        Vector3 localPosCoin = KhayDungDo.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosCoin = new Vector3(localPosCoin.x - 200f, localPosCoin.y - 300f, localPosCoin.z);
        GameObject newPrefabCoin = Instantiate(Coin);
        newPrefabCoin.transform.SetParent(KhayDungDo, false);
        newPrefabCoin.GetComponent<RectTransform>().localPosition = spawnLocalPosCoin;
        //newPrefabCoin.SetActive(true);
        Debug.Log("InstantiateCoin called, coin instantiated at position: " + spawnLocalPosCoin);

    }

    public IEnumerator PlayComeAnimationAndShowChatB()
    {
        if (id == 4)
        {
            if (!isLeft)
            {
                Animator.Play("ComeB");
                isLeft = true;
                IsTicket = true;
                yield return new WaitForSecondsRealtime(2.5f);
                //IsTicket = true;
                ShowNvChatLeftB();
                InstantiateCoin();

            }
        }
        else if (id == 5)
        {
            if (!isLeft2)
            {
                Animator.Play("ComeB");
                isLeft2 = true;
                IsTicket = true;
                yield return new WaitForSecondsRealtime(2.5f);
                //IsTicket = true;
                ShowNvChatLeftB();
                InstantiateCoin();
            }
        }
        else if (id == 6)
        {
            if (!isLeft3)
            {
                Animator.Play("ComeB");
                isLeft3 = true;
                IsTicket = true;
                yield return new WaitForSecondsRealtime(2.5f);
                ShowNvChatLeftB();
                InstantiateCoin();
            }
            else
            {
                Debug.LogWarning("ID không hợp lệ: " + id);
            }
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
            image3.enabled = false;
            id++;
            StartNv1B();

        }
        else if (id == 4)
        {
            ShowNvChatLeft();
            Animator.Play("LeftB");
            yield return new WaitForSecondsRealtime(2.5f);
            image1.enabled = false;
            id++;
            StartNv2B();
        }
        else if (id == 5)
        {
            ShowNvChatLeft();
            Animator.Play("LeftB");
            yield return new WaitForSecondsRealtime(2.5f);
            image2.enabled = false;
            id++;
            StartNv3B();
        }
        else if (id == 6)
        {
            ShowNvChatLeft();
            Animator.Play("LeftB");
            yield return new WaitForSecondsRealtime(2.5f);
            image3.enabled = false;

        }

        else
        {
            Debug.LogWarning("ID không hợp lệ: " + id);
        }

    }



    public IEnumerator SideWayLeft()
    {
        yield return StartCoroutine(PlayLeftAnimationAndShowChat());
        Debug.Log("SideWayLeft called, waiting for animation to finish." +id);
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
    
    public void ShowNvChatLeftB()
    {
            if (NvChat != null && chatTextComponent != null)
            {
                NvChat.SetActive(true);
                chatTextComponent.text = "Checkout please ";
                StartCoroutine(TimeShowChat());
            }
            else
            {
                Debug.LogWarning("Loi ShowNvChatComeB.");
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
        else if (id == 4)
        {
            if (NvChat != null && chatTextComponent != null)
            {
                NvChat.SetActive(true);
                chatTextComponent.text = "Thanks 4";
                StartCoroutine(TimeShowChat());
            }
            else
            {
                Debug.LogWarning("Loi ShowNvChatLeft.");
            }
        }
        else
        {
            NvChat.SetActive(true);
            chatTextComponent.text = "Thanks You Sir";
            StartCoroutine(TimeShowChat());
        }

    }


}
