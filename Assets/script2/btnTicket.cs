using System;
using UnityEngine;

public class btnTicket : MonoBehaviour
{
    public static bool btnTicketClicked = false;
    public void OnClickedBtnTicket()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("btnTicket");
        btnTicketClicked = true;
    }
}
