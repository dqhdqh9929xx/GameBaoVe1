using System;
using UnityEngine;

public class btnTicket : MonoBehaviour
{
    public static bool btnTicketClicked = false;
    public CharacterManager characterManager; // Tham chiếu đến CharacterManager để kiểm tra trạng thái nút Ticket
    public void OnClickedBtnTicket()
    {
        Animator animator = GetComponent<Animator>();
        if (CharacterManager.CanBtnTicket == true)
        {
            animator.SetTrigger("btnTicket");
            btnTicketClicked = true;
        }          
    }
}
