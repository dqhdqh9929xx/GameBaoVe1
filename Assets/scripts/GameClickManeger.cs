using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class GameClickManeger : MonoBehaviour
{
    public AnimationController1 animationController;
    //public GameObject NoteBookFullScreenPanel;
    //public GameObject listFullScreenPanel;
    public GameObject NvChat;
    //public GameObject NoteBook;
    //public GameObject TicketNv;
    public GameObject TicketNvFullScreen;
    //public GameObject Coin;
    //public GameObject BinhXitCay;
    //public Transform BinhXitCayT;
    public GameObject GameWinMenu;
    public GameObject GameLoseMenu;
    //public GameObject BinhXitPoint;
    //public static bool isBinhXit = false;


    void Start()
    {
        //if (NoteBook != null)
        //    NoteBook.SetActive(true);

        //if (NoteBookFullScreenPanel != null)
        //    NoteBookFullScreenPanel.SetActive(false);

        //if (listFullScreenPanel != null)
        //    listFullScreenPanel.SetActive(false);

        //if (TicketNv != null)
        //    TicketNv.SetActive(true);
        //if (TicketNvFullScreen != null)
        //    TicketNvFullScreen.SetActive(false);
        //if (Coin != null)
        //    Coin.SetActive(true);
        //if (BinhXitCay != null)
        //    BinhXitCay.SetActive(true);
        if(GameWinMenu != null)
            GameWinMenu.SetActive(false);
        if (GameLoseMenu != null)
        {
            Debug.Log($"GameLoseMenu is not null, setting it to inactive. from {gameObject.name}");
            GameLoseMenu.SetActive(false);
        }
    }


    private void Update()
    {
        //if (isBinhXit == true)
        //{
        //    Vector2 mousePos = Input.mousePosition;
        //    BinhXitCayT.position = mousePos;
        //}
        //if (isBinhXit == false)
        //{
        //    BinhXitCayT.position = new Vector2(1500, 300);
        //}
    }
    //public void BinhXitPointClicked()
    //{
    //    if (isBinhXit == true && animationController.isLeft == true && animationController.image1.enabled == true)
    //    {
    //        animationController.image1.enabled = false;
    //        animationController.image1_cay.enabled = true;
    //        isBinhXit = false;
    //        StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
    //        AnimationController1.isTrueChoice = false;
    //    }
    //    else if (isBinhXit == true && animationController.isLeft2 == true && animationController.image2.enabled == true)
    //    {
    //        animationController.image2.enabled = false;
    //        animationController.image2_cay.enabled = true;
    //        isBinhXit = false;
    //        StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
    //    }
    //    else if (isBinhXit == true && animationController.isLeft3 == true && animationController.image3.enabled == true)
    //    {
    //        animationController.image3.enabled = false;
    //        animationController.image3_cay.enabled = true;
    //        isBinhXit = false;
    //        AnimationController1.isTrueChoice = false;
    //        StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
    //    }
    //}

    //public void SelectBinhXitHoiCay()
    //{
    //    isBinhXit = true;
    //}

    //public void OpenTicketNvTrueFullScreen()
    //{
    //    if (TicketNvFullScreen != null)
    //    {
    //        TicketNvFullScreen.SetActive(true);
    //        StartCoroutine(TimeToCheckTicket());
    //    }
    //}

    //public IEnumerator TimeToCheckTicket()
    //{
    //    yield return new WaitForSeconds(3);
    //    TicketNvFullScreen.SetActive(false);
    //    Debug.Log("TicketNvFullScreen đã được tắt sau 3 giây.");
    //}    

    //public void AcceptCoinToLeft()
    //{
    //    if (animationController != null)
    //    {
    //        StartCoroutine(animationController.SideWayLeft());
    //        Coin.SetActive(false);
    //        animationController.IsTicket = false;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("AnimationController1 is not assigned.");
    //    }
    //}

    public void ShowGameWinMenu()
    {
         GameWinMenu.SetActive(true);
    }
    public IEnumerator ShowGameLoseMenu()
    {
        Debug.Log($"ShowGameLoseMenu called, setting GameLoseMenu to active. from {gameObject.name}");
        GameLoseMenu.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }



    //public void OpenNoteBookFullScreen()
    //{
    //    if (NoteBookFullScreenPanel != null)
    //    {
    //        NoteBookFullScreenPanel.SetActive(true);
    //    }
    //}

    //public void CloseNoteBookFullScreen()
    //{
    //    if (NoteBookFullScreenPanel != null)
    //    {
    //        NoteBookFullScreenPanel.SetActive(false);
    //    }
    //}

    //public void OpenListFullScreen()
    //{
    //    if (listFullScreenPanel != null)
    //    {
    //        listFullScreenPanel.SetActive(true);
    //    }
    //}

    //public void CloseListFullScreen()
    //{
    //    if (listFullScreenPanel != null)
    //    {
    //        listFullScreenPanel.SetActive(false);
    //    }
    //}


}
