using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class AnimationController3 : MonoBehaviour
{
    public int id = 1;  // biến nhân vật
    public TextMeshProUGUI chatTextComponent;
    public GameObject NvChat;
    public Animator Animator;
    public GameClickManeger GameClickManager1;
    //public bool hasInstantiatedTicket = false;
    public Transform KhayDungDo;
    public GameObject Coin;
    public bool IsTicket = false;
    public bool IsCoin = false;
    public GameObject newPrefabCoin = null;
    // Choice
    public bool isTrueChoiceCome = true;  // biến nhân vật
    public bool isTrueChoiceLeft = true;  // biến nhân vật
    public bool isDetermine = false;
    public bool isTrueChoiceComeGame; // biến game
    public bool isTrueChoiceLeftGame; // biến game
    // Anim
    public bool isCome = true;
    public bool isLeft = false;
    public bool NextNv = false;
    // Nhan Vat 1
    public Image characterImages0;  // biến nhân vật
    public Image characterImagesCay0;   // biến nhân vật
    // Nhan Vat 2
    public Image characterImages1;
    public Image characterImagesCay1;
    // Nhan Vat 3
    public Image characterImages2;
    public Image characterImagesCay2;

    // Khai báo danh sách nhân vật
    //public Character[] characters = new Character[2];
    public Image[] characterImages = new Image[2];          // Mảng chứa các Image của nhân vật
    public Image[] characterImagesCay = new Image[2];       // Mảng chứa các Image cây của nhân vật


    private void Awake()
    {
        // Khởi tạo các nhân vật bằng một hàm chung
        InitializeCharacters();
    }

    private void InitializeCharacters()
    {
        //// Khởi tạo các nhân vật và gán các thuộc tính cần thiết
        //for (int i = 0; i < characters.Length; i++)
        //{
        //    // Gán mỗi nhân vật một Image và một Image cay tương ứng
        //    characters[i] = new Character(id + i, characterImages[i], characterImagesCay[i], isTrueChoiceCome, isTrueChoiceLeft);
        //}

        //characters[0] = new Character(1, characterImages0, characterImagesCay0, isTrueChoiceCome, isTrueChoiceLeft);
        //characters[1] = new Character(2, characterImages1, characterImagesCay1, isTrueChoiceCome, !isTrueChoiceLeft);
        //characters[2] = new Character(3, characterImages2, characterImagesCay2, !isTrueChoiceCome, isTrueChoiceLeft);
    }

    private void Update()
    {
        if (IsCoin == false)
        {
            newPrefabCoin.SetActive(false);
        }
        if (id == 7)
        {
            GameClickManager1.ShowGameWinMenu();
        }

        if (isTrueChoiceComeGame == false && isDetermine == true)
        {
            StartCoroutine(GameClickManager1.ShowGameLoseMenu());
            isDetermine = false;
        }
        if (isTrueChoiceLeftGame == false && isDetermine == true)
        {
            StartCoroutine(GameClickManager1.ShowGameLoseMenu());
            isDetermine = false;
        }
        if (id == 3)
        {
            isCome = false;
            isLeft = true;
        }
    }

    void Start()
    {
        StartCharacterAnimation(id);
    }

    // Hàm khởi tạo và hiển thị hoạt ảnh cho nhân vật theo ID
    private void StartCharacterAnimation(int characterId)
    {
        IsTicket = false;
        if (isCome == true && id != 0)
        {
            NextNv = true;
        }
        else if (isLeft == true)
        {
            NextNv = false;
        }
        SetCharacterState(characterId);
        if (NvChat != null)
            chatTextComponent = NvChat.GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(PlayComeAnimationAndShowChat());
    }

    private void SetCharacterState(int characterId)
    {
        // Thiết lập trạng thái hình ảnh của nhân vật
        for (int i = 0; i < characterImages.Length; i++)
        {
            characterImages[i].enabled = i == characterId - 1; // Chỉ hiển thị hình ảnh của nhân vật có ID tương ứng
            characterImagesCay[i].enabled = false; // Ẩn các hình ảnh cây của các nhân vật
        }
    }

    public IEnumerator PlayComeAnimationAndShowChat()
    {
        if (isCome == true)
        {
            Animator.Play("ComeA");
            yield return new WaitForSecondsRealtime(2.5f);
            ShowNvChat();
        }
        else if (isLeft == true)
        {
            Animator.Play("ComeB");
            yield return new WaitForSecondsRealtime(2.5f);
            IsCoin = true;
            IsTicket = true;
            ShowNvChat();
            InstantiateCoin();
        }
    }

    public void ShowNvChat()
    {
        if (NvChat != null && chatTextComponent != null)
        {
            NvChat.SetActive(true);
            chatTextComponent.text = "Biển số xe tôi là " + id.ToString();
            StartCoroutine(TimeShowChat());
        }
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
            Debug.LogWarning("Lỗi TimeShowChat.");
        }
    }

    // Các hàm để di chuyển qua các nhân vật khác
    public void SwitchCharacter(int id)
    {
        id++;
        StartCharacterAnimation(id);
    }

    public void InstantiateCoin()
    {
        Vector3 localPosCoin = KhayDungDo.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosCoin = new Vector3(localPosCoin.x - 200f, localPosCoin.y - 300f, localPosCoin.z);
        newPrefabCoin = Instantiate(Coin);
        newPrefabCoin.transform.SetParent(KhayDungDo, false);
        newPrefabCoin.GetComponent<RectTransform>().localPosition = spawnLocalPosCoin;
        newPrefabCoin.SetActive(true);
    }

    public IEnumerator SideWayLeft()
    {
        yield return StartCoroutine(PlayLeftAnimationAndShowChat());
        Debug.Log("SideWayLeft called, waiting for animation to finish." + id);
    }

    public IEnumerator PlayLeftAnimationAndShowChat()
    {
        if (isCome == true)
        {
            ShowNvChat();
            Animator.Play("LeftA");
            yield return new WaitForSecondsRealtime(2.5f);
            isDetermine = true;  // nếu nhân vật trong blacklist sẽ thua
            //characters[id - 1].isTrueChoiceCome = isTrueChoiceComeGame;
            SwitchCharacter(id);
        }

        if (isLeft == true)
        {
            ShowNvChat();
            Animator.Play("LeftB");
            yield return new WaitForSecondsRealtime(2.5f);
            isDetermine = true; // quyết định cuối cùng
            //characters[id - 1].isTrueChoiceLeft = isTrueChoiceLeftGame;
            SwitchCharacter(id);
        }
    }


}
