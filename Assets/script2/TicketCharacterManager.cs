using System.Collections;
using TMPro;
using UnityEngine;

public class TicketCharacterManager : MonoBehaviour
{
    public GameObject ticketPrefab;
    public static bool isClickedExitTicket = false;
    private GameObject newPrefabTicket;
    public Vector3 Origin;
    public CharacterManager characterManager;
    public TicketCharacter ticketCharacter = null;
    public TMP_Text nameText;



    private void Start()
    {
        Origin = GetComponent<RectTransform>().localPosition;
        nameText.enabled = false;
    }
    public void InstantiateTicket()
    {
        Vector3 localPosTicket = Origin;
        Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x, localPosTicket.y, localPosTicket.z);
        newPrefabTicket = Instantiate(ticketPrefab, this.transform);
        newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
        ticketCharacter = newPrefabTicket.GetComponent<TicketCharacter>();

        ticketCharacter.TicketClicked += TicketCharacter_TicketClicked;
        //InvokeRepeating("IsClickedTicketAndShowName", 0f, 4f);
        //Invoke("IsClickedTicketAndShowName", 0);
    }

    private void TicketCharacter_TicketClicked()
    {
        StartCoroutine(ShowLargTicketAndName());
    }

    private IEnumerator ShowLargTicketAndName()
    {
        if(ticketCharacter == null) yield break;

        var nameIndex = characterManager.randomIndex;
        var currentChar = characterManager.currentCharacterData;
        ticketCharacter.ShowFullscreen(currentChar.Name);
        yield return new WaitForSecondsRealtime(3f);
        ticketCharacter.HideFullscreen();

    }

    public void Destroyticket()
    {
        Destroy(newPrefabTicket);
    }


    //public void IsClickedTicketAndShowName()
    //{

    //    Debug.Log($"TicketCharacter.isClickedTicketFul = {TicketCharacter.isClickedTicketFull}");
    //    if (TicketCharacter.isClickedTicketFull == true && nameText != null)
    //    {
    //        Debug.Log("IsClickedTicketAndShowName nameText.enabled = true");
    //        nameText.enabled = true;
    //        var nameIndex = characterManager.randomIndex;
    //        Debug.Log($"NameIndex: {nameIndex}");
    //        var currentChar = characterManager.currentCharacterData;
    //        Debug.Log($"Current Character: {currentChar.Name}");
    //        //var curentCharacterName = currentChar.Name;
    //        nameText.text = $"{currentChar.Name}";
    //        StartCoroutine(timeShowNameInTicket());
    //    }
    //}

    //public IEnumerator timeShowNameInTicket()
    //{
    //    yield return new WaitForSecondsRealtime(3f);
    //    Debug.Log("IsClickedTicketAndShowName nameText.enabled = false");
    //    nameText.enabled = false;
    //    TicketCharacter.isClickedTicketFull = false;
    //    CancelInvoke("IsClickedTicketAndShowName");

    //}

}
