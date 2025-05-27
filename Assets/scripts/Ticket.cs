using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ticket : MonoBehaviour, IPointerClickHandler
{
    public GameObject ticket;
    public Animator animator;
    public AnimationController1 animationController;

    private bool isDestroying = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ticket != null && !isDestroying)
        {
            Debug.Log("Ticket clicked");
            animator.SetTrigger("ticket");
            isDestroying = true;
            StartCoroutine(WaitForAnimationEnd());
            // Gọi hàm trong AnimationController để thực hiện các hành động khác
            if (animationController != null)
            {
                animationController.SideWayLeft();
            }
            else
            {
                Debug.LogWarning("AnimationController is not assigned.");
            }

        }
    }

    private IEnumerator WaitForAnimationEnd()
    {
        // Lấy trạng thái animation hiện tại ở layer 0
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;

        // Chờ thời gian animation chạy xong
        yield return new WaitForSeconds(animationLength);

        // Destroy object ticket sau khi animation kết thúc
        Destroy(ticket);
    }
}
