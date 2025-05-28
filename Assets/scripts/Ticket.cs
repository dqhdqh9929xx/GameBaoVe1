using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;


public class Ticket : MonoBehaviour, IPointerClickHandler
{
    public GameObject ticket;
    public Animator animator;
    public AnimationController1 animationController;
    public AnimationController2 animationController2;

    public bool isDestroying = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ticket != null && !isDestroying)
        {
            Debug.Log("Ticket clicked");
            animator.SetTrigger("ticket");
            isDestroying = true;
            StartCoroutine(WaitForAnimationEnd());

            if (animationController != null && animationController.enabled==true)
            {
                StartCoroutine(animationController.SideWayLeft());
            }
            else if (animationController2 != null && animationController2.enabled == true)
            {
                StartCoroutine(animationController2.SideWayLeft2());
            }
            else
            {
                Debug.LogWarning("AnimationController is not assigned.");
            }
        }
    }

    public IEnumerator WaitForAnimationEnd()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;
        yield return new WaitForSeconds(animationLength);
        Destroy(ticket);
    }
}

