using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TicketCharacterManager : MonoBehaviour
{
    public GameObject ticketPrefab;
    public static bool isClickedExitTicket = false;
    private GameObject newPrefabTicket;
    public Vector3 Origin;
    public CharacterManager characterManager;
    public TicketCharacter ticketCharacter;
    public TextMeshProUGUI nameText;



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
        InvokeRepeating("IsClickedTicketAndShowName", 0f, 3f);
    }

    public void Destroyticket()
    {
        Destroy(newPrefabTicket);
    }


    public void IsClickedTicketAndShowName()
    {
        if (TicketCharacter.isClickedTicketFull == true && nameText != null)
        {
            nameText.enabled = true;
            var nameIndex = characterManager.randomIndex;
            Debug.Log($"NameIndex: {nameIndex}");
            var currentChar = characterManager.currentCharacterData;
            Debug.Log($"Current Character: {currentChar.Name}");
            //var curentCharacterName = currentChar.Name;
            nameText.text = $"{currentChar.Name}";
            StartCoroutine(timeShowNameInTicket());
            nameText.enabled = false;
            TicketCharacter.isClickedTicketFull = false;
            CancelInvoke("IsClickedTicketAndShowName");
        }
    }

    public IEnumerator timeShowNameInTicket()
    {
        yield return new WaitForSecondsRealtime(3f);

    }

}
