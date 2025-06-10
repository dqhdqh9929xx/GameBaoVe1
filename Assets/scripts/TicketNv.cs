using System.Collections;
using TMPro;
using UnityEngine;

public class TicketNv : MonoBehaviour
{
    public GameObject TicketNv1;
    public AnimationController1 animationController;
    public Transform KhayDungDo;
    private GameObject newPrefabTicket = null;
    //private GameObject newPrefabTicketFull = null;
    public GameObject TicketNvFullScreen;
    public TextMeshProUGUI TicketComponent;
    void Start()
    {
        if (TicketNvFullScreen != null)
            TicketNvFullScreen.SetActive(false);

        Vector3 localPosTicketFull = KhayDungDo.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosTicketFull = new Vector3(localPosTicketFull.x, localPosTicketFull.y - 300f, localPosTicketFull.z);
        GameObject newPrefabTicketFull = Instantiate(TicketNvFullScreen);
        newPrefabTicketFull.transform.SetParent(KhayDungDo, false);
        newPrefabTicketFull.GetComponent<RectTransform>().localPosition = spawnLocalPosTicketFull;
        newPrefabTicketFull.SetActive(false);


    }

    void Update()
    {
        if (animationController.hasInstantiatedTicket == false && animationController.IsTicket == true)
        {
            animationController.hasInstantiatedTicket = true;
            Vector3 localPosTicket = KhayDungDo.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosTicket = new Vector3(localPosTicket.x, localPosTicket.y - 300f, localPosTicket.z);
            newPrefabTicket = Instantiate(TicketNv1);
            newPrefabTicket.transform.SetParent(KhayDungDo, false);
            newPrefabTicket.GetComponent<RectTransform>().localPosition = spawnLocalPosTicket;
            newPrefabTicket.SetActive(true);
            TicketComponent = newPrefabTicket.GetComponentInChildren<TextMeshProUGUI>();
            TicketComponent.transform.SetParent(newPrefabTicket.transform, false);
            TicketComponent.text = "#" + animationController.id.ToString();
        }

        if (animationController.IsTicket == false)
        {
            newPrefabTicket?.SetActive(false);
        }
    }

    public void OpenTicketNvTrueFullScreen()
    {
        if (newPrefabTicket != null)
        {
            newPrefabTicket.SetActive(true);
            StartCoroutine(TimeToCheckTicket());
        }
    }

    public IEnumerator TimeToCheckTicket()
    {
        yield return new WaitForSeconds(3);
        newPrefabTicket.SetActive(false);
        Debug.Log("TicketNvFullScreen đã được tắt sau 3 giây.");
    }
}
