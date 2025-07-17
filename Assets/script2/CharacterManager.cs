using Assets.script2;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] Sprite[] NormalImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImageFake; // Mảng 2D chứa các Image của nhân vật Out
    [SerializeField] Sprite[] ImageFake; // Mảng 2D chứa các Image của nhân vật In
    [SerializeField] Sprite[] NormalImages2; // Mảng chứa các hình ảnh ghi chú của nhân vật thay đổi diện mạo 2
    [SerializeField] Sprite[] AttackImages2; // Mảng chứa các hình ảnh ghi chú của nhân vật thay đổi diện mạo 2
    [SerializeField] string[] CharacterNames; // Mảng chứa tên của các nhân vật
    [SerializeField] string[] CharacterChatIn; // Mảng chứa lời thoại nhân vật khi vào
    [SerializeField] string[] CharacterChatOut; // Mảng chứa lời thoại nhân vật khi rời đi
    [SerializeField] bool[] IsTrueChangeImage2; // Mảng chứa id nhân vật
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
    //public CharacterNoteManager characterNoteManager; // Tham chiếu đến CharacterNoteManager để tạo ghi chú cho nhân vật
    public CoinCharacterManager CoinCharacterManager; // Tham chiếu đến CoinCharacterManager để tạo tiền cho nhân vật
    public TicketCharacterManager TicketCharacterManager; // Tham chiếu đến TicketCharacterManager để tạo Ticket cho nhân vật
    public static bool CanBtnTicket = false; // kiểm tra xem có thể bấm nút Ticket hay không
    public static bool CanBtnSpray = false; // kiểm tra xem có thể bấm nút Spray hay không
    public btnTicket btnTicket; // Tham chiếu đến nút Ticket để kiểm tra trạng thái bấm nút
    public static int randomIndex; // Khai báo là biến toàn cục để lưu chỉ số ngẫu nhiên của nhân vật hiện tại
    public static int indexCharacterInTicketToCheck = 0; // Chỉ số của nhân vật In cần kiểm tra kết quả lựa chọn khi đến vị trí đúng
    public static int indexCharacterOutCoinToCheck = 0; // Chỉ số của nhân vật Out cần kiểm tra kết quả lựa chọn khi rời đi
    public static int indexCharacterInSprayedToCheck = 0; // Chỉ số của nhân vật In cần kiểm tra kết quả lựa chọn khi bị attack
    public static int indexCharacterOutSprayedToCheck = 0; // Chỉ số của nhân vật Out cần kiểm tra kết quả lựa chọn khi bị attack
    private static bool isSprayed = false; // Biến để kiểm tra xem có nhân vật nào bị attack hay không
    public CharacterData currentCharacterData; // Biến để lưu dữ liệu của nhân vật hiện tại
    public CharacterChatManager characterChatManager; // Tham chiếu đến CharacterChatManager để xử lý lời thoại nhân vật
    public CharacterNoteName CharacterNoteName; // Tham chiếu đến CharacterNoteName để tạo tên cho nhân vật
    //public static int indexWrongChoice = 0; // Biến để lưu chỉ số lựa chọn sai của nhân vật
    //public int endIndexWrongChoice = 0; // Biến để lưu chỉ số lựa chọn sai cuối cùng của người chơi
    public GameObject gameWinMenu; // Tham chiếu đến menu chiến thắng
    public GameOverMenu GameOverMenu; // Tham chiếu đến menu game over
    public GameObject gameOverMenu; // Tham chiếu đến menu game over
    public static int indexWrongChoiceInTicket = 0; // lưu số lần chọn sai khi bấm ticket cho nhân vật in
    public static int indexWrongChoiceOutCoin = 0; // lưu số lần chọn sai khi bấm coin cho nhân vật out
    public static int indexWrongChoiceInSprayed = 0; // lưu số lần chọn sai khi bấm spray cho nhân vật in
    public static int indexWrongChoiceOutSprayed = 0; // lưu số lần chọn sai khi bấm spray cho nhân vật out
    public PlayerData PlayerData; // Tham chiếu đến PlayerData để lưu trữ dữ liệu người chơi
    public WindowView WindowView; // Tham chiếu đến WindowView để thay đổi hình ảnh cửa sổ
    public CountdownTimer countdownTimer; // Kéo đối tượng DrawOnCanvas vào đây trong Inspector

    void Start()
    {
        //PlayerPrefs.DeleteKey("PlayerData"); // Tạm reset để test

        //PlayerData loadedData = PlayerData.LoadFromPrefs();
        //// gán lại level từ dữ liệu load được
        //PlayerData.level = loadedData != null ? loadedData.level : 1;

        PlayerData player = PlayerData.Instance;

        for (int i = 0; i < NormalImages.Length; i++)
        {
            characters.Add(new CharacterData
            {
                IsTrueChoiceChangeImage2 = IsTrueChangeImage2[i],
                Name = CharacterNames[i],
                NormalImage = NormalImages[i],
                AttackImage = AttackImages[i],
                AttackImageFake = AttackImageFake[i],
                ImageFake = ImageFake[i],
                NormalImage2 = NormalImages2[i],
                AttackImage2 = AttackImages2[i],
                IsTrueChoiceCome = ComeBoolens[i],
                IsTrueChoiceOut = LeftBoolen[i],
                CharacterChatIn = CharacterChatIn[i],
                CharacterChatOut = CharacterChatOut[i]
            });
        }
        if (player.level != 1) // Kiểm tra nếu level khác level 1 thì không cần hướng dẫn game
        {
            StartCoroutine(StartCharacterIn());
        }
        //StartCoroutine(StartCharacterIn());
    }

    public void isEndGuidanceGame()
    {
        StartCoroutine(StartCharacterIn());
    }

    public void isTrueChoiceInTicket()
    {
        if (oldCharaters[indexCharacterInTicketToCheck].IsTrueChoiceCome == false)
         {
            //indexWrongChoice++; // Tăng chỉ số lựa chọn sai
            indexWrongChoiceInTicket++; // Tăng chỉ số lựa chọn sai khi bấm Ticket cho nhân vật In
        }
        indexCharacterInTicketToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceInSprayed() // kiểm tra kết quả xem spray có đúng hay không của nhân vật In
    {
        if (SprayedCharacter[indexCharacterInSprayedToCheck].IsTrueChoiceCome == true)
        {
            //indexWrongChoice++; // Tăng chỉ số lựa chọn sai
            indexWrongChoiceInSprayed++; // Tăng chỉ số lựa chọn sai khi bấm Spray cho nhân vật In

        }
        indexCharacterInSprayedToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceOutSprayed() // kiểm tra kết quả xem spray có đúng hay không của nhân vật Out
    {
        if (sprayedOldCharacter[indexCharacterOutSprayedToCheck].IsTrueChoiceOut == true)
        {
            //indexWrongChoice++; // Tăng chỉ số lựa chọn sai
            indexWrongChoiceOutSprayed++; // Tăng chỉ số lựa chọn sai khi bấm Spray cho nhân vật Out

        }
        indexCharacterOutSprayedToCheck++; // Tăng chỉ số để kiểm tra nhân vật tiếp theo
    }

    public void isTrueChoiceOutCoin()
    {
        if (sprayedOldCharacter [indexCharacterOutCoinToCheck].IsTrueChoiceOut == false)
        {
            //indexWrongChoice++; // Tăng chỉ số lựa chọn sai
            indexWrongChoiceOutCoin++; // Tăng chỉ số lựa chọn sai khi bấm Coin cho nhân vật Out

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
            //CountdownTimer.isCounting = true;
            //CountdownTimer.timeRemaining = 5f; // Reset thời gian đếm ngược về 5 giây
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
            //CountdownTimer.isCounting = true;
            //CountdownTimer.timeRemaining = 5f; // Reset thời gian đếm ngược về 5 giây
            //DrawOnCanvas.isDrawingEnabled = true; // Bật vẽ lại sau khi bấm nút Ticket
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
            nv.OnInvisible();
            Destroy(CurrentCharater);
            CurrentCharater = null;
            countdownTimer.ResetTimeCount(); // Reset thời gian đếm ngược về 5 giây
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
            //Debug.Log($"RemoveAtIndexList: {randomIndex}");
            CurrentCharater = Instantiate(CharacterPrefab, this.transform);
            RectTransform rect = CurrentCharater.GetComponent<RectTransform>();
            rect.anchoredPosition =  new Vector3 (0, 50, 0); // Đặt vị trí của nhân vật mới
            rect.sizeDelta = new Vector3 (520, 380);        // kích thước của nhân vật mới

            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.normalImage = randomCharacter.NormalImage;
            nv.attackImage = randomCharacter.AttackImage;
            nv.isTrueChoiceCome = randomCharacter.IsTrueChoiceCome;  // Lấy kết quả lựa chọn khi đến
            nv.OnNormal();
            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeA");
            yield return new WaitForSecondsRealtime(5f);
            //characterNoteManager.InstantiateCharacterNote(); // Tạo ghi chú cho nhân vật nếu cần thiết
            CharacterNoteName.InstantiateCharacterName(); // Tạo tên cho nhân vật nếu cần thiết
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
            WindowView.ChangeWindowView(); // Thay đổi hình ảnh cửa sổ khi không còn nhân vật nào trong danh sách characters
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
            randomIndex = random.Next(oldCharaters.Count);
            CharacterData oldCharacter = oldCharaters[randomIndex];
            currentCharacterData = oldCharacter; // Lưu dữ liệu của nhân vật hiện tại để check kết quả lựa chọn
            sprayedOldCharacter.Add(oldCharacter); // Thêm nhân vật out rời đi bằng sprayed vào danh sách sprayedOldCharacter
            CurrentCharater = Instantiate(CharacterPrefab, this.transform); // tạo lại nhân vật mới từ prefab
            RectTransform rect = CurrentCharater.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector3(0, 50, 0); // Đặt vị trí của nhân vật mới
            rect.sizeDelta = new Vector3(520, 380);        // kích thước của nhân vật mới
            var nv = CurrentCharater.GetComponent<NhanVat>();
            nv.imageFake = oldCharacter.ImageFake; // Lấy hình ảnh fake của nhân vật Out
            nv.attackImageFake = oldCharacter.AttackImageFake; // Lấy hình ảnh fake của nhân vật Out
            nv.normalImage = oldCharacter.NormalImage;
            nv.attackImage = oldCharacter.AttackImage;
            nv.normalImage2 = oldCharacter.NormalImage2; // Lấy hình ảnh bình thường 2 của nhân vật Out
            nv.attackImage2 = oldCharacter.AttackImage2; // Lấy hình ảnh attack 2 của nhân vật Out
            nv.isTrueChoiceOut = oldCharacter.IsTrueChoiceOut; // Lấy kết quả lựa chọn khi rời đi
            nv.isTrueChoiceChangeImage2 = oldCharacter.IsTrueChoiceChangeImage2; // Lấy dữ liệu xử lý thay đổi diện mạo 2 của nhân vật Out
            if (nv.isTrueChoiceOut == false && nv.isTrueChoiceChangeImage2 == false)
            {
                nv.OnImageFake(); // Hiển thị hình ảnh fake nếu kết quả lựa chọn là sai
                Debug.Log("Ảnh nhân vật giả mạo");
            }
            if (nv.isTrueChoiceOut == true && nv.isTrueChoiceChangeImage2 == false)
            {
                nv.OnNormal(); // Hiển thị hình ảnh bình thường nếu kết quả lựa chọn là đúng
                Debug.Log("Ảnh nhân vật đúng");
            }
            if (nv.isTrueChoiceChangeImage2 == true)
            {
                nv.OnNormal2(); // Hiển thị hình ảnh bình thường 2 nếu nhân vật có id là 7
                Debug.Log("Ảnh nhân vật đặc biệt");
            }

            Animator animator = CurrentCharater.GetComponent<Animator>();
            animator.SetTrigger("ComeB");
            //nv.OnNormal();
            yield return new WaitForSecondsRealtime(5f);
            characterChatManager.StartCoroutine(characterChatManager.InstantiateChatOut()); // Tạo lời thoại cho nhân vật khi ra
            CoinCharacterManager.InstantiateCoin();
            CanBtnSpray = true; // Cho phép nút Spray hoạt động sau khi nhân vật đến vị trí đúng
            InvokeRepeating("AcceptCoinToCharacterLeft", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây
            InvokeRepeating("isDeterminedSprayOut", 0f, 1.5f); // Lặp lại kiểm tra nút Spray mỗi 3 giây
            TicketCharacterManager.InstantiateTicket(); // Tạo Ticket cho nhân vật
            oldCharaters.RemoveAt(randomIndex);

        }
        else
        {
            CheckWinOrLose();
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
        if (nv.isTrueChoiceOut == false && nv.isTrueChoiceChangeImage2 == false)
        {
            nv.OnAttackFake(); // Hiển thị hình ảnh attack fake nếu kết quả lựa chọn là sai
            Debug.Log("Ảnh nhân vật giả mạo tấn công");
        }
        else
        {
            nv.OnAttack(); // Hiển thị hình ảnh attack bình thường nếu kết quả lựa chọn là đúng
            Debug.Log("Ảnh nhân vật đúng tấn công");
        }
        if (nv.isTrueChoiceChangeImage2 == true)
        {
            nv.OnAttack2(); // Hiển thị hình ảnh attack 2 nếu nhân vật có id là 7
            Debug.Log("Ảnh nhân vật đặc biệt tấn công");
        }

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

    public void CheckWinOrLose()
    {
        if ((indexWrongChoiceInTicket + indexWrongChoiceInSprayed + indexWrongChoiceOutSprayed + indexWrongChoiceOutCoin) > 0)
        {
            gameOverMenu.SetActive(true);
            GameOverMenu.ShowWrongChoice();
        }
        else
        {
            PlayerData player = PlayerData.Instance;
            player.level++; // Tăng level
            player.SaveToPrefs(); // ✅ Lưu đúng dữ liệu đã tăng

            gameWinMenu.SetActive(true);
        }
    }

}
