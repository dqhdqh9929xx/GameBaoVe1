using Assets.script2;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] Sprite[] NormalImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] string[] CharacterNames; // Mảng chứa tên của các nhân vật
    [SerializeField] string[] CharacterChatIn; // Mảng chứa lời thoại nhân vật khi vào
    [SerializeField] string[] CharacterChatOut; // Mảng chứa lời thoại nhân vật khi rời đi
    [SerializeField] int[] CharacterId; // Mảng chứa id nhân vật
    [SerializeField] bool[] ComeBoolens; // Mảng chứa các kết quả của nhân vật khi đến vị trí đúng
    [SerializeField] bool[] LeftBoolen; // Mảng chứa các kết quả của nhân vật khi rời đi
    [SerializeField] GameObject CharacterPrefab; // prefab xử lý thay đổi sprites
    public SprayRange SprayRange; // Tham chiếu đến SprayRange để xử lý nhân vật bị attack
    private GameObject CurrentCharater;
    public List<CharacterData> characters = new();
    public List<CharacterData> oldCharaters = new();
    public List<CharacterData> sprayedOldCharacter = new(); //  danh sách nhân vật out đã rời đi bằng sprayed
    public List<CharacterData> SprayedCharacter = new(); //  danh sách nhân vật in đã rời đi bằng sprayed
    private System.Random random = new System.Random();
    public static bool createNoteCharacter = false; // Biến này để kiểm tra xem có cần tạo ghi chú cho nhân vật hay không
    public CharacterNoteManager characterNoteManager; // Tham chiếu đến CharacterNoteManager để tạo ghi chú cho nhân vật
    public CoinCharacterManager CoinCharacterManager; // Tham chiếu đến CoinCharacterManager để tạo tiền cho nhân vật
    public TicketCharacterManager TicketCharacterManager; // Tham chiếu đến TicketCharacterManager để tạo Ticket cho nhân vật
    public static bool CanBtnTicket = false; // kiểm tra xem có thể bấm nút Ticket hay không
    public static bool CanBtnSpray = false; // kiểm tra xem có thể bấm nút Spray hay không
    public btnTicket btnTicket; // Tham chiếu đến nút Ticket để kiểm tra trạng thái bấm nút
    public int randomIndex; // Khai báo là biến toàn cục để lưu chỉ số ngẫu nhiên của nhân vật hiện tại
    private static int indexCharacterInTicketToCheck = 0; // Chỉ số của nhân vật In cần kiểm tra kết quả lựa chọn khi đến vị trí đúng
    private static int indexCharacterOutCoinToCheck = 0; // Chỉ số của nhân vật Out cần kiểm tra kết quả lựa chọn khi rời đi
    private static int indexCharacterInSprayedToCheck = 0; // Chỉ số của nhân vật In cần kiểm tra kết quả lựa chọn khi bị attack
    private static int indexCharacterOutSprayedToCheck = 0; // Chỉ số của nhân vật Out cần kiểm tra kết quả lựa chọn khi bị attack
    private static bool isSprayed = false; // Biến để kiểm tra xem có nhân vật nào bị attack hay không
    CharacterData currentCharacterData; // Biến để lưu dữ liệu của nhân vật hiện tại
    public CharacterChatManager characterChatManager; // Tham chiếu đến CharacterChatManager để xử lý lời thoại nhân vật
    void Start()
    {
        for (int i = 0; i < NormalImages.Length; i++)
        {
            characters.Add(new CharacterData
            {
                Id = CharacterId[i],
                Name = CharacterNames[i],
                NormalImage = NormalImages[i],
                AttackImage = AttackImages[i],
                IsTrueChoiceCome = ComeBoolens[i],
                IsTrueChoiceOut = LeftBoolen[i],
                CharacterChatIn = CharacterChatIn[i],
                CharacterChatOut = CharacterChatOut[i]
            });
        }
        StartCoroutine(StartCharacterIn());
    }

    public void isTrueChoiceInTicket()
    {
        if (oldCharaters[indexCharacterInTicketToCheck].IsTrueChoiceCome == false)
         {
             Debug.Log("GameOver!");
         }
        indexCharacterInTicketToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceInSprayed() // kiểm tra kết quả xem spray có đúng hay không của nhân vật In
    {
        if (SprayedCharacter[indexCharacterInSprayedToCheck].IsTrueChoiceCome == true)
        {
            Debug.Log("GameOver!");
        }   
        indexCharacterInSprayedToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceOutSprayed() // kiểm tra kết quả xem spray có đúng hay không của nhân vật Out
    {
        if (sprayedOldCharacter[indexCharacterOutSprayedToCheck].IsTrueChoiceOut == true)
        {
            Debug.Log("GameOver!");
        }
        indexCharacterOutSprayedToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceOutCoin()
    {
        if (sprayedOldCharacter[indexCharacterOutCoinToCheck].IsTrueChoiceOut == false)
        {
            Debug.Log("GameOver!");
        }
        indexCharacterOutCoinToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isDeterminedTicket()
    {
        if (CanBtnTicket == true && btnTicket.btnTicketClicked == true)
        {
            StartCoroutine(StartCharacterIn()); // Bắt đầu rời nhân vật sau khi bấm nút Ticket
            btnTicket.btnTicketClicked = false; // Reset trạng thái nút Ticket sau khi bấm
            CanBtnTicket = false; // Reset trạng thái không cho spam nút Ticket
            CancelInvoke("isDeterminedTicket");
        }
    }
    public void isDeterminedSprayIn()
    {
        if (SprayRange.characterAttacked == true && CanBtnSpray == true)
        {
            SprayRange.characterAttacked = false;
            CanBtnSpray = false;
            oldCharaters.RemoveAt(indexCharacterInTicketToCheck);
            isSprayed = true; // Đánh dấu là đã có nhân vật bị attack
            StartCoroutine(CharacterAttackedAndLeftIn()); // Khởi động hàm rời nhân vật sau khi bị attack
            CancelInvoke("isDeterminedSprayIn");
        }
    }
    public void isDeterminedSprayOut()
    {
        if (SprayRange.characterAttacked == true && CanBtnSpray == true)
        {
            SprayRange.characterAttacked = false;
            CanBtnSpray = false;
            sprayedOldCharacter.RemoveAt(indexCharacterOutCoinToCheck);
            isSprayed = true; // Đánh dấu là đã có nhân vật bị attack
            CoinCharacterManager.DestroyCoin(); // Xóa Coin khi nhân vật bị attack
            StartCoroutine(CharacterAttackedAndLeftOut()); // Khởi động hàm rời nhân vật sau khi bị attack
            CancelInvoke("isDeterminedSprayOut");
        }
    }

    public IEnumerator StartCharacterIn()
    {
        if (CurrentCharater != null)
        {
            // nhân vật rời đi
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("LeftA");
            yield return new WaitForSecondsRealtime(5f);
            var nv = CurrentCharater.GetComponent<NhanVat>();
            Debug.Log($"nv CharacterLeftA: {nv.name} {nv.isTrueChoiceCome}");
            nv.OnInvisible();
            Destroy(CurrentCharater);
            CurrentCharater = null;
            if (isSprayed == true)
            {
                SprayedCharacter.Add(currentCharacterData); // Thêm nhân vật In đã rời đi bằng sprayed vào danh sách SprayedCharacter
                isSprayed = false; // Reset trạng thái sau khi nhân vật đã bị attack
                CancelInvoke("isDeterminedSprayIn"); // 1
                isTrueChoiceInSprayed(); // Nếu nhân vật bị attack, kiểm tra kết quả lựa chọn
            }
            else
            {
                isTrueChoiceInTicket(); // Nếu nhân vật không bị attack, kiểm tra kết quả lựa chọn 
                CancelInvoke("isDeterminedSprayIn");
            }
        }
        if (characters.Any())
        {
            //characterNoteManager.InstantiateCharacterNoteAndName(); // Tạo ghi chú cho nhân vật nếu cần thiết
            randomIndex = random.Next(characters.Count);
            CharacterData randomCharacter = characters[randomIndex];
            currentCharacterData = randomCharacter; // Lưu dữ liệu của nhân vật hiện tại để check kết quả lựa chọn
            //characters.RemoveAt(randomIndex);
            oldCharaters.Add(randomCharacter);
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
            characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
            characterNoteManager.InstantiateCharacterName(); // Tạo tên cho nhân vật nếu cần thiết
            characterChatManager.StartCoroutine(characterChatManager.InstantiateChatIn()); // Tạo lời thoại cho nhân vật khi vào
            CanBtnTicket = true; // Cho phép nút Ticket hoạt động sau khi nhân vật đến vị trí đúng
            CanBtnSpray = true; // Cho phép nút Spray hoạt động sau khi nhân vật đến vị trí đúng
            InvokeRepeating("isDeterminedTicket", 0f, 3f);
            InvokeRepeating("isDeterminedSprayIn", 0f, 1.5f); // Lặp lại kiểm tra nút Ticket và Spray mỗi 3 giây
            characters.RemoveAt(randomIndex);

        }
        else
        {
            StartCoroutine(StartCharacterOut());
        }
    }
    public IEnumerator StartCharacterOut()
    {
        if (CurrentCharater != null)
        {
            TicketCharacterManager.Destroyticket(); // Xóa Ticket khi nhân vật rời đi
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("LeftB");
            yield return new WaitForSecondsRealtime(5f);
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.OnInvisible();
            Destroy(CurrentCharater);
            CurrentCharater = null;
            if (isSprayed == true)
            {
                sprayedOldCharacter.Add(currentCharacterData); // Thêm nhân vật out đã rời đi bằng sprayed vào danh sách sprayedOldCharacter
                isSprayed = false; // Reset trạng thái sau khi nhân vật đã bị attack
                isTrueChoiceOutSprayed(); // Nếu nhân vật bị attack, kiểm tra kết quả lựa chọn
                CancelInvoke("isDeterminedSprayOut"); // 2
            }
            else
            {
                isTrueChoiceOutCoin(); // Nếu nhân vật không bị attack, kiểm tra kết quả lựa chọn
                CancelInvoke("isDeterminedSprayOut"); // 3
            }
        }
        if (oldCharaters.Any())
        {
            Debug.Log($"StartFirstCharacterB: {oldCharaters.Count}");
            randomIndex = random.Next(oldCharaters.Count);
            CharacterData oldCharacter = oldCharaters[randomIndex];
            currentCharacterData = oldCharacter; // Lưu dữ liệu của nhân vật hiện tại để check kết quả lựa chọn
            //oldCharaters.RemoveAt(randomIndex);
            sprayedOldCharacter.Add(oldCharacter); // Thêm nhân vật out rời đi bằng sprayed vào danh sách sprayedOldCharacter
            Debug.Log($"RemoveAt: {randomIndex}");
            CurrentCharater = Instantiate(CharacterPrefab, this.transform); // tạo lại nhân vật mới từ prefab
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = oldCharacter.NormalImage;
            nv.attackImage = oldCharacter.AttackImage;
            nv.isTrueChoiceOut = oldCharacter.IsTrueChoiceOut; // Lấy kết quả lựa chọn khi rời đi
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeB");
            nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            characterChatManager.StartCoroutine(characterChatManager.InstantiateChatOut()); // Tạo lời thoại cho nhân vật khi ra
            CoinCharacterManager.InstantiateCoin();
            CanBtnSpray = true; // Cho phép nút Spray hoạt động sau khi nhân vật đến vị trí đúng
            InvokeRepeating("AcceptCoinToCharacterLeft", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây
            TicketCharacterManager.InstantiateTicket(); // Tạo Ticket cho nhân vật
            InvokeRepeating("isDeterminedSprayOut", 0f, 1.5f); // Lặp lại kiểm tra nút Spray mỗi 3 giây
            oldCharaters.RemoveAt(randomIndex);

        }
        else
        {
            Debug.Log("No more characters to show in B sequence.");
        }
    }
    public IEnumerator CharacterAttackedAndLeftIn()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftB");
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.OnAttack();
        yield return new WaitForSecondsRealtime(5f);
        nv.OnInvisible(); // ẩn nhân vật sau khi bị attack
        StartCoroutine(StartCharacterIn());
    }
    public IEnumerator CharacterAttackedAndLeftOut()
    {
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("LeftB");
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.OnAttack();
        yield return new WaitForSecondsRealtime(5f);
        nv.OnInvisible(); // ẩn nhân vật sau khi bị attack
        StartCoroutine(StartCharacterOut());
    }
    public void AcceptCoinToCharacterLeft()
    {
        if (CoinCharacterManager.isClickedCoinS == true)
        {
            CoinCharacterManager.isClickedCoinS = false; // Reset trạng thái sau khi nhận tiền
            StartCoroutine(StartCharacterOut()); // Bắt đầu rời nhân vật sau khi nhận tiền
            CancelInvoke("AcceptCoinToCharacterLeft");
        }
    }
}
