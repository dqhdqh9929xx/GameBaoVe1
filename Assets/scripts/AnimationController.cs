using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AnimationController : MonoBehaviour
{
    public int id = 6969; // ID của nhân vật, mặc định là 6969
    public Image imageFace;
    public Image imageSideWay;
    public Image imageSideWayLeft;
    public GameObject targetX;
    public Animator Animator;

    //public GameObject NvBag;
    //public GameObject IDcard;
    public GameObject NvChat;
    public GameObject targetXX;


    void Start()
    {
        if (imageFace != null)
            imageFace.enabled = false;
        if (imageSideWay != null)
            imageSideWay.enabled = true;
        if (NvChat != null)
            NvChat.SetActive(false);
        if (imageSideWayLeft != null)
            imageSideWayLeft.enabled = false;

    }

    bool isReady = false;
    bool isReadyX = false;
    void Update()
    {
        if (imageSideWay != null && targetX != null && !isReady)
        {
            // Lấy vị trí x của imageSideWay trong world space
            float sideWayX = imageSideWay.rectTransform.position.x;
            // Lấy vị trí x của targetX trong world space
            float targetPosX = targetX.transform.position.x;
            // Kiểm tra nếu vị trí x của imageSideWay gần targetX trong khoảng ±5
            if (Mathf.Abs(sideWayX - targetPosX) <= 5f)
            {
                Debug.Log("ImageSideWay đã gần targetX, bật isReady");
                isReady = true;
                if (imageFace != null)
                    imageFace.enabled = true;
                imageSideWay.enabled = false;
                if (NvChat != null)
                {
                    // Hiển thị ID của nhân vật trong NvChat
                    TextMeshProUGUI chatText = NvChat.GetComponentInChildren<TextMeshProUGUI>();
                    NvChat.SetActive(true);
                    if (chatText != null)
                    {
                        chatText.text = "Biển số xe tôi là " + id.ToString();
                    }
                    else
                    {
                        Debug.LogWarning("NvChat does not contain a TextMeshProUGUI component.");
                    }

                }

            }
        }
    }
    public void SideWayLeft()
    {
        if (imageSideWayLeft != null)
        {
            imageSideWayLeft.enabled = true;
            //Debug.Log("SideWayLeft called");
            Animator.SetTrigger("SideWayLeft");
            isReadyX = true;
            if (imageFace != null)
                imageFace.enabled = false;
            if (NvChat != null)
            {
              // Hiển thị ID của nhân vật trong NvChat
                 TextMeshProUGUI chatText = NvChat.GetComponentInChildren<TextMeshProUGUI>();
                    NvChat.SetActive(true);
                    if (chatText != null)
                    {
                        chatText.text = "Cảm ơn bà nha ";
                    }
                    else
                    {
                        Debug.LogWarning("NvChat does not contain a TextMeshProUGUI component.");
                    }
                }
            }
        }
    }    

