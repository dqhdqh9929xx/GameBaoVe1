using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AnimationController1 : MonoBehaviour
{
    public int id = 6969; // ID của nhân vật, mặc định là 6969
    public Image imageFace;
    public Image imageSideWayCome;
    public Image imageSideWayLeft;
    public Animator AnimatorCome;
    public Animator AnimatorLeft;
    public GameObject NvChat;

    bool isCome = false;

    void Start()
    {
        if (imageFace != null)
            imageFace.enabled = false;
        if (imageSideWayCome != null)
            imageSideWayCome.enabled = true;
        if (NvChat != null)
            NvChat.SetActive(false);
        if (imageSideWayLeft != null)
            imageSideWayLeft.enabled = false;
    }

    void Update()
    {
        if (imageSideWayCome != null && isCome == false)
        {
            AnimatorCome.SetTrigger("Come");
            StartCoroutine(WaitForAnimationEnd(AnimatorCome));
            isCome = true;
            imageSideWayCome.enabled = false;

            if (imageFace != null)
                imageFace.enabled = true;

            if (NvChat != null)
            {
                TextMeshProUGUI chatText = NvChat.GetComponentInChildren<TextMeshProUGUI>();
                NvChat.SetActive(true);
                if (chatText != null)
                    chatText.text = "Biển số xe tôi là " + id.ToString();
                else
                    Debug.LogWarning("NvChat does not contain a TextMeshProUGUI component.");
            }
        }
    }

    public void SideWayLeft()
    {
        if (imageSideWayLeft != null)
        {
            imageFace.enabled = false;
            imageSideWayLeft.enabled = true;
            AnimatorLeft.SetTrigger("Left");
            StartCoroutine(WaitForAnimationEnd(AnimatorLeft));
        }
        else
        {
            Debug.LogWarning("imageSideWayLeft is not assigned.");
        }

        if (NvChat != null)
        {
            TextMeshProUGUI chatText = NvChat.GetComponentInChildren<TextMeshProUGUI>();
            NvChat.SetActive(true);
            if (chatText != null)
                chatText.text = "Cảm ơn bà nha ";
            else
                Debug.LogWarning("NvChat does not contain a TextMeshProUGUI component.");
        }
    }

    private IEnumerator WaitForAnimationEnd(Animator animator)
    {
        if (animator == null)
            yield break;

        // Đợi animation hiện tại chạy xong
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Lặp lại mỗi frame cho đến khi animation kết thúc
        while (stateInfo.normalizedTime < 1f)
        {
            yield return null;
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }
    }
}
