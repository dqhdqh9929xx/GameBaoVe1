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
    [SerializeField] GameObject CharacterPrefab; // prefab xử lý thay đổi sprites

    private GameObject CurrentCharater;
    public List<CharacterData> characters = new();
    public List<GameObject> oldCharaters = new();
    private System.Random random = new System.Random();
    public static bool createNoteCharacter = false; // Biến này để kiểm tra xem có cần tạo ghi chú cho nhân vật hay không
    public CharacterNoteManager characterNoteManager; // Tham chiếu đến CharacterNoteManager để tạo ghi chú cho nhân vật
    public static bool CanBtnTicket = false; // kiểm tra xem có thể bấm nút Ticket hay không
    public btnTicket btnTicket; // Tham chiếu đến nút Ticket để kiểm tra trạng thái bấm nút

    void Start()
    {
        characters.Add(new CharacterData()
        {
            Id = 1,
            Name = "Name 1 ",
            AttackImage = AttackImages[0],
            NormalImage = NormalImages[0],
            IsTrueChoiceCome = true,
            IsTrueChoiceLeft = true
        });
        characters.Add(new CharacterData()
        {
            Id = 2,
            Name = "Name 2 ",
            AttackImage = AttackImages[1],
            NormalImage = NormalImages[1],
            IsTrueChoiceCome = true,
            IsTrueChoiceLeft = false
        });
        characters.Add(new CharacterData()
        {
            Id = 3,
            Name = "Name 3 ",
            AttackImage = AttackImages[2],
            NormalImage = NormalImages[2],
            IsTrueChoiceCome = false,
            IsTrueChoiceLeft = true
        });

        StartCoroutine(StartFirstCharacterA());
    }

    void Update()
    {
        if (CanBtnTicket == true && btnTicket.btnTicketClicked == true)
        {
            StartCoroutine(CharacterLeftA()); // Bắt đầu rời nhân vật sau khi bấm nút Ticket
            btnTicket.btnTicketClicked = false; // Reset trạng thái nút Ticket sau khi bấm
            CanBtnTicket = false; // Reset trạng thái không cho spam nút Ticket
            btnTicket.btnTicketClicked = false; // Đặt lại trạng thái nút Ticket sau khi bấm
        }
    }


    public IEnumerator StartFirstCharacterA()
    {
        characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
        // Khởi tạo nhân vật đầu tiên
        int randomIndex = random.Next(characters.Count);
        CharacterData randomCharacter = characters[randomIndex];
        characters.RemoveAt(randomIndex); 
        Debug.Log($"RemoveAtIndexList: {randomIndex}");
        CurrentCharater = Instantiate(CharacterPrefab, this.transform);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.normalImage = randomCharacter.NormalImage;
        nv.attackImage = randomCharacter.AttackImage;
        //nv.isTrueChoiceCome = randomCharacter.IsTrueChoiceCome;  // Lưu trạng thái lựa chọn đúng của nhân vật
        nv.OnNormal();
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("ComeA");
        yield return new WaitForSecondsRealtime(5f);
        CanBtnTicket = true; // Cho phép nút Ticket hoạt động sau khi nhân vật đến vị trí đúng
        //OnClickBtnTicket();
    }

  

    public IEnumerator CharacterLeftA()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftA");
        yield return new WaitForSecondsRealtime(5f);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.OnInvisible();
        if (CurrentCharater != null)
        {
            oldCharaters.Add(CurrentCharater); // Lưu nhân vật vào danh sách đã đi qua, xem xét có cần xóa không vì có thể nhân vật có thể ko được đi qua
        }
        //if(nv.isTrueChoiceCome == false)
        //{
        //    Debug.Log($"GameOver.");       // Nếu nhân vật không phải là lựa chọn đúng, có thể xử lý Game Over hoặc thông báo
        //}
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
            int randomIndex = random.Next(characters.Count);
            CharacterData randomCharacter = characters[randomIndex];
            characters.RemoveAt(randomIndex);
            Debug.Log($"RemoveAtIndexList: {randomIndex}");
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = randomCharacter.NormalImage;
            nv.attackImage = randomCharacter.AttackImage;
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeA");
            yield return new WaitForSecondsRealtime(1f); // Đợi 1 giây để tránh hình ảnh giật về từ phải qua trái
            nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            CanBtnTicket = true; // Cho phép nút Ticket hoạt động sau khi nhân vật đến vị trí đúng
            //OnClickBtnTicket();
        }
    }

    public IEnumerator StartFirstCharacterB()
    {
        int randomIndex = random.Next(oldCharaters.Count);
        GameObject randomCharacter = oldCharaters[randomIndex];
        oldCharaters.RemoveAt(randomIndex);
        Debug.Log($"RemoveAt: {randomIndex}");
        CurrentCharater = Instantiate(CharacterPrefab, this.transform); // tạo lại nhân vật mới từ prefab
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.normalImage = NormalImages[randomIndex];
        nv.attackImage = AttackImages[randomIndex];
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("ComeB");
        nv.OnNormal();
        yield return new WaitForSecondsRealtime(5f);
        StartCoroutine(LeftCharacterB());
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
            int randomIndex = random.Next(oldCharaters.Count);
            GameObject randomCharacter = oldCharaters[randomIndex];
            oldCharaters.RemoveAt(randomIndex);
            Debug.Log($"RemoveAt: {randomIndex}");
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = NormalImages[randomIndex];
            nv.attackImage = AttackImages[randomIndex];
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeB");
            yield return new WaitForSecondsRealtime(1f); // Đợi 1 giây để tránh hình ảnh giật về từ phải qua trái
            nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            StartCoroutine(LeftCharacterB());
        }
    }
}
