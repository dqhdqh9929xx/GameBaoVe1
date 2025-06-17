using Assets.script2;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] Sprite[] NormalImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImages; // Mảng 2D chứa các Image của nhân vật
    // tạo mảng 2D chứa các kết quả của nhân vật
    [SerializeField] bool[] ComeBoolens; // Mảng chứa các kết quả của nhân vật khi đến vị trí đúng
    [SerializeField] bool[] LeftBoolen; // Mảng chứa các kết quả của nhân vật khi rời đi

    [SerializeField] GameObject CharacterPrefab; // prefab xử lý thay đổi sprites
    public SprayRange SprayRange; // Tham chiếu đến SprayRange để xử lý nhân vật bị attack

    private GameObject CurrentCharater;
    public List<CharacterData> characters = new();
    public List<CharacterData> oldCharaters = new();
    public List<CharacterData> oldOldCharaters = new(); // Trả về danh sách nhân vật đã rời đi để có thể sử dụng ở nơi khác
    private System.Random random = new System.Random();
    public static bool createNoteCharacter = false; // Biến này để kiểm tra xem có cần tạo ghi chú cho nhân vật hay không
    public CharacterNoteManager characterNoteManager; // Tham chiếu đến CharacterNoteManager để tạo ghi chú cho nhân vật
    public CoinCharacterManager CoinCharacterManager; // Tham chiếu đến CoinCharacterManager để tạo tiền cho nhân vật
    public TicketCharacterManager TicketCharacterManager; // Tham chiếu đến TicketCharacterManager để tạo Ticket cho nhân vật
    public static bool CanBtnTicket = false; // kiểm tra xem có thể bấm nút Ticket hay không
    public static bool CanBtnSpray = false; // kiểm tra xem có thể bấm nút Spray hay không
    public btnTicket btnTicket; // Tham chiếu đến nút Ticket để kiểm tra trạng thái bấm nút
    private static int randomIndex; // Khai báo là biến toàn cục để lưu chỉ số ngẫu nhiên của nhân vật hiện tại
    private static int characterToRemove; // Biến để lưu chỉ số của nhân vật cần xóa khỏi danh sách
    private static int indexCharacterInToCheck = 0; // Chỉ số của nhân vật cần kiểm tra
    private static int indexCharacterOutToCheck = 0; // Chỉ số của nhân vật cần kiểm tra kết quả lựa chọn khi rời đi
    private static bool isSprayed = false; // Biến để kiểm tra xem có nhân vật nào bị attack hay không


    void Start()
    {
        characters.Add(new CharacterData()
        {
            Id = 1,
            Name = "Name 1 ",
            AttackImage = AttackImages[0],
            NormalImage = NormalImages[0],
            IsTrueChoiceCome = ComeBoolens[0],
            IsTrueChoiceOut = LeftBoolen[0],
        });
        characters.Add(new CharacterData()
        {
            Id = 2,
            Name = "Name 2 ",
            AttackImage = AttackImages[1],
            NormalImage = NormalImages[1],
            IsTrueChoiceCome = ComeBoolens[1],
            IsTrueChoiceOut = LeftBoolen[1]
        });
        characters.Add(new CharacterData()
        {
            Id = 3,
            Name = "Name 3 ",
            AttackImage = AttackImages[2],
            NormalImage = NormalImages[2],
            IsTrueChoiceCome = ComeBoolens[2],
            IsTrueChoiceOut = LeftBoolen[2]
        });

        StartCoroutine(StartCharacterIn());
    }

    public void isTrueChoiceIn()
    {
        if (oldCharaters[indexCharacterInToCheck].IsTrueChoiceCome == false)
         {
             Debug.Log("GameOver!");
         }
        indexCharacterInToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceOut()
    {
        if (oldOldCharaters[indexCharacterOutToCheck].IsTrueChoiceOut == false)
        {
            Debug.Log("GameOver!");
        }
        indexCharacterOutToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
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
            oldCharaters.RemoveAt(indexCharacterInToCheck);
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
            oldOldCharaters.RemoveAt(indexCharacterOutToCheck);
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
                isSprayed = false; // Reset trạng thái sau khi nhân vật đã bị attack
            }
            else
            {
                isTrueChoiceIn(); // Nếu nhân vật không bị attack, kiểm tra kết quả lựa chọn 
                CancelInvoke("isDeterminedSprayIn");
            }
        }

        if (characters.Any())
        {
            characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
                                                             // Khởi tạo nhân vật đầu tiên
            randomIndex = random.Next(characters.Count);
            CharacterData randomCharacter = characters[randomIndex];
            characters.RemoveAt(randomIndex);
            oldCharaters.Add(randomCharacter);
            characterToRemove = randomIndex; // Lưu chỉ số của nhân vật đã được chọn để nếu cần thì xóa khỏi danh sách
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
            InvokeRepeating("isDeterminedSprayIn", 0f, 1.5f); // Lặp lại kiểm tra nút Ticket và Spray mỗi 3 giây
            
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
                isSprayed = false; // Reset trạng thái sau khi nhân vật đã bị attack
            }
            else
            {
                isTrueChoiceOut(); // Nếu nhân vật không bị attack, kiểm tra kết quả lựa chọn
                //CancelInvoke("isDeterminedSprayOut");
            }
        }

        if (oldCharaters.Any())
        {
            Debug.Log($"StartFirstCharacterB: {oldCharaters.Count}");
            randomIndex = random.Next(oldCharaters.Count);
            CharacterData oldCharacter = oldCharaters[randomIndex];
            oldCharaters.RemoveAt(randomIndex);
            oldOldCharaters.Add(oldCharacter); // Thêm nhân vật đã rời đi vào danh sách oldOldCharaters
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
            CoinCharacterManager.InstantiateCoin();
            InvokeRepeating("AcceptCoinToCharacterLeft", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây
            TicketCharacterManager.InstantiateTicket(); // Tạo Ticket cho nhân vật
            InvokeRepeating("isDeterminedSprayOut", 0f, 1.5f); // Lặp lại kiểm tra nút Spray mỗi 3 giây

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
