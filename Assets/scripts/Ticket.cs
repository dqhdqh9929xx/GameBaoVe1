using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;


public class Ticket : MonoBehaviour, IPointerClickHandler
{
    public GameObject ticket;
    public Animator animator;
    public AnimationController1 animationController;
    //public AnimationController2 animationController2;
    public CheckBoxManeger checkBoxManeger;

    public bool isDestroying = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ticket != null)
        {
            ticket.SetActive(true);
            Debug.Log("Ticket clicked");
            animator.SetTrigger("ticket");
            StartCoroutine(WaitForAnimationEnd());

            if (animationController != null && animationController.enabled==true)
            {
                StartCoroutine(animationController.SideWayLeft());
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
        ticket.SetActive(false);
    }
}

