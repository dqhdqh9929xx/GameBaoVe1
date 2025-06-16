using Assets.script2;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] Sprite[] NormalImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImages; // Mảng 2D chứa các Image của nhân vật
    // tạo mảng 2D chứa các kết quả của nhân vật
    [SerializeField] bool [] ComeBoolens; // Mảng chứa các kết quả của nhân vật khi đến vị trí đúng
    [SerializeField] bool [] LeftBoolen; // Mảng chứa các kết quả của nhân vật khi rời đi

    [SerializeField] GameObject CharacterPrefab; // prefab xử lý thay đổi sprites
    public SprayRange SprayRange; // Tham chiếu đến SprayRange để xử lý nhân vật bị attack

    private GameObject CurrentCharater;
    public List<CharacterData> characters = new();
    public List<GameObject> oldCharaters = new();
    private System.Random random = new System.Random();
    public static bool createNoteCharacter = false; // Biến này để kiểm tra xem có cần tạo ghi chú cho nhân vật hay không
    public CharacterNoteManager characterNoteManager; // Tham chiếu đến CharacterNoteManager để tạo ghi chú cho nhân vật
    public CoinCharacterManager CoinCharacterManager; // Tham chiếu đến CoinCharacterManager để tạo tiền cho nhân vật
    public static bool CanBtnTicket = false; // kiểm tra xem có thể bấm nút Ticket hay không
    public static bool CanBtnSpray = false; // kiểm tra xem có thể bấm nút Spray hay không
    public btnTicket btnTicket; // Tham chiếu đến nút Ticket để kiểm tra trạng thái bấm nút
    private static int randomIndex; // Khai báo là biến toàn cục để lưu chỉ số ngẫu nhiên của nhân vật hiện tại

    void Start()
    {
        characters.Add(new CharacterData()
        {
            Id = 1,
            Name = "Name 1 ",
            AttackImage = AttackImages[0],
            NormalImage = NormalImages[0],
            IsTrueChoiceCome = ComeBoolens[0],
            IsTrueChoiceLeft = LeftBoolen[0],
        });
        characters.Add(new CharacterData()
        {
            Id = 2,
            Name = "Name 2 ",
            AttackImage = AttackImages[1],
            NormalImage = NormalImages[1],
            IsTrueChoiceCome = ComeBoolens[1],
            IsTrueChoiceLeft = LeftBoolen[1]
        });
        characters.Add(new CharacterData()
        {
            Id = 3,
            Name = "Name 3 ",
            AttackImage = AttackImages[2],
            NormalImage = NormalImages[2],
            IsTrueChoiceCome = ComeBoolens[2],
            IsTrueChoiceLeft = LeftBoolen[2]
        });

        StartCoroutine(StartFirstCharacterA());
    }

    void Update()
    {
        //if (CanBtnTicket == true && btnTicket.btnTicketClicked == true)
        //{
        //    StartCoroutine(CharacterLeftA()); // Bắt đầu rời nhân vật sau khi bấm nút Ticket
        //    btnTicket.btnTicketClicked = false; // Reset trạng thái nút Ticket sau khi bấm
        //    CanBtnTicket = false; // Reset trạng thái không cho spam nút Ticket
        //}
        //if (SprayRange.characterAttacked == true && CanBtnSpray == true)
        //{
        //    SprayRange.characterAttacked = false;
        //    CanBtnSpray = false;
        //    StartCoroutine(CharacterAttackedAndLeft()); // Khởi động hàm rời nhân vật sau khi bị attack

        //}    
    }

    public void isDeterminedTicket()
    {
        if (CanBtnTicket == true && btnTicket.btnTicketClicked == true)
        {
            StartCoroutine(CharacterLeftA()); // Bắt đầu rời nhân vật sau khi bấm nút Ticket
            btnTicket.btnTicketClicked = false; // Reset trạng thái nút Ticket sau khi bấm
            CanBtnTicket = false; // Reset trạng thái không cho spam nút Ticket
            CancelInvoke("isDeterminedTicket");
        }
    }
    public void isDeterminedSpray()
    {
        if (SprayRange.characterAttacked == true && CanBtnSpray == true)
        {
            SprayRange.characterAttacked = false;
            CanBtnSpray = false;
            StartCoroutine(CharacterAttackedAndLeft()); // Khởi động hàm rời nhân vật sau khi bị attack
            CancelInvoke("isDeterminedSpray");
        }
    }


    public IEnumerator StartFirstCharacterA()
    {
        characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
        // Khởi tạo nhân vật đầu tiên
        randomIndex = random.Next(characters.Count);
        CharacterData randomCharacter = characters[randomIndex];
        characters.RemoveAt(randomIndex); 
        Debug.Log($"RemoveAtIndexList: {randomIndex}");
        CurrentCharater = Instantiate(CharacterPrefab, this.transform);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.normalImage = randomCharacter.NormalImage;
        nv.attackImage = randomCharacter.AttackImage;
        nv.isTrueChoiceCome = randomCharacter.IsTrueChoiceCome;  // Lấy kết quả lựa chọn khi đến
        nv.OnNormal();
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("ComeA");
        yield return new WaitForSecondsRealtime(5f);
        CanBtnTicket = true; // Cho phép nút Ticket hoạt động sau khi nhân vật đến vị trí đúng
        CanBtnSpray = true; // Cho phép nút Spray hoạt động sau khi nhân vật đến vị trí đúng
        InvokeRepeating("isDeterminedTicket", 0f, 3f);
        InvokeRepeating("isDeterminedSpray", 0f, 3f); // Lặp lại kiểm tra nút Ticket và Spray mỗi 3 giây
    }

  

    public IEnumerator CharacterLeftA()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftA");
        yield return new WaitForSecondsRealtime(5f);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        Debug.Log($"nv CharacterLeftA: {nv.name} {nv.isTrueChoiceCome}");
        nv.OnInvisible();
        if (CurrentCharater != null)
        {
            oldCharaters.Add(CurrentCharater); // Lưu nhân vật vào danh sách đã đi qua, xem xét có cần xóa không vì có thể nhân vật có thể ko được đi qua
        }
        if(nv.isTrueChoiceCome == false)
        {
            Debug.Log($"GameOver.");       // Nếu nhân vật không phải là lựa chọn đúng, có thể xử lý Game Over hoặc thông báo
        }
        StartCoroutine(NextCharacterA());
    }

    public IEnumerator CharacterAttackedAndLeft()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftB");
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.OnAttack();
        yield return new WaitForSecondsRealtime(5f);
        StartCoroutine(NextCharacterA());
    }

    public IEnumerator NextCharacterA()
    {
        if (characters.Count <= 0)
        {
            Debug.Log($"oldCharacter has: {oldCharaters.Count}");
            Destroy(CurrentCharater); // Xóa nhân vật hiện tại sau khi rời đi
            StartCoroutine(StartFirstCharacterB()); // Nếu không còn nhân vật nào, bắt đầu nhân vật mới
        }
        else
        {
            characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
            randomIndex = random.Next(characters.Count);
            CharacterData randomCharacter = characters[randomIndex];
            characters.RemoveAt(randomIndex);
            Debug.Log($"RemoveAtIndexList: {randomIndex}");
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = randomCharacter.NormalImage;
            nv.attackImage = randomCharacter.AttackImage;
            nv.isTrueChoiceCome = randomCharacter.IsTrueChoiceCome; // Lấy kết quả lựa chọn khi đến
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeA");
            yield return new WaitForSecondsRealtime(1f); // Đợi 1 giây để tránh hình ảnh giật về từ phải qua trái
            nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            CanBtnTicket = true; // Cho phép nút Ticket hoạt động sau khi nhân vật đến vị trí đúng
            CanBtnSpray = true; // Cho phép nút Spray hoạt động sau khi nhân vật đến vị trí đúng
            InvokeRepeating("isDeterminedTicket", 0f, 3f);
            InvokeRepeating("isDeterminedSpray", 0f, 3f); // Lặp lại kiểm tra nút Ticket và Spray mỗi 3 giây
        }
    }

    public IEnumerator StartFirstCharacterB()
    {
        Debug.Log($"StartFirstCharacterB: {oldCharaters.Count}");
        randomIndex = random.Next(oldCharaters.Count);
        GameObject randomCharacter = oldCharaters[randomIndex];
        oldCharaters.RemoveAt(randomIndex);
        Debug.Log($"RemoveAt: {randomIndex}");
        CurrentCharater = Instantiate(CharacterPrefab, this.transform); // tạo lại nhân vật mới từ prefab
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.normalImage = NormalImages[randomIndex];
        nv.attackImage = AttackImages[randomIndex];
        nv.isTrueChoiceLeft = LeftBoolen[randomIndex]; // Lấy kết quả lựa chọn khi rời đi
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("ComeB");
        nv.OnNormal();
        yield return new WaitForSecondsRealtime(5f);
        CoinCharacterManager.InstantiateCoin();
        InvokeRepeating("AcceptCoinToCharacterLeft", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây

    }
    
    public IEnumerator LeftCharacterB()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftB");
        yield return new WaitForSecondsRealtime(5f);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.OnInvisible();
        StartCoroutine(NextCharacterB());
    }

    public IEnumerator NextCharacterB()
    {
        if (oldCharaters.Count <= 0)
        {
            Debug.Log("No more characters to show in B sequence.");
        }
        else
        {
            randomIndex = random.Next(oldCharaters.Count);
            GameObject randomCharacter = oldCharaters[randomIndex];
            oldCharaters.RemoveAt(randomIndex);
            Debug.Log($"RemoveAt: {randomIndex}");
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = NormalImages[randomIndex];
            nv.attackImage = AttackImages[randomIndex];
            nv.isTrueChoiceLeft = LeftBoolen[randomIndex]; // Lấy kết quả lựa chọn khi rời đi
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeB");
            yield return new WaitForSecondsRealtime(1f); // Đợi 1 giây để tránh hình ảnh giật về từ phải qua trái
            nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            CoinCharacterManager.InstantiateCoin();
            InvokeRepeating("AcceptCoinToCharacterLeft", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây
        }
    }

    public void AcceptCoinToCharacterLeft()
    {
        if (CoinCharacterManager.isClickedCoinS == true)
        {
            CoinCharacterManager.isClickedCoinS = false; // Reset trạng thái sau khi nhận tiền
            StartCoroutine(LeftCharacterB()); // Bắt đầu rời nhân vật sau khi nhận tiền
            CancelInvoke("AcceptCoinToCharacterLeft");
        }
    }
}
