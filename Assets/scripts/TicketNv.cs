using System.Collections;
using TMPro;
using UnityEngine;

public class TicketNv : MonoBehaviour
{
    public GameObject TicketNv1;
    public AnimationController1 animationController;
    public Transform KhayDungDo;
    private GameObject newPrefabTicket = null;
    public TicketNvFullScreen ticketNvFullScreen;
    //public GameObject TicketNvFullScreen;
    //private GameObject newPrefabTicketFullScreen = null;
    //public TextMeshProUGUI TicketComponent;
    void Start()
    {
        //if (TicketNv1 != null)
        //    TicketNv1.SetActive(true);
        //if (TicketNvFullScreen != null)
        //    TicketNvFullScreen.SetActive(false);
        //if (newPrefabTicketFullScreen == null)
        //{
        //    Vector3 localPosTicketFullScreen = KhayDungDo.InverseTransformPoint(transform.position);
        //    Vector3 spawnLocalPosTicketFullScreen = new Vector3(localPosTicketFullScreen.x, localPosTicketFullScreen.y - 300f, localPosTicketFullScreen.z);
        //    newPrefabTicketFullScreen = Instantiate(TicketNvFullScreen);
        //    newPrefabTicketFullScreen.transform.SetParent(KhayDungDo, false);
        //    newPrefabTicketFullScreen.GetComponent<RectTransform>().localPosition = spawnLocalPosTicketFullScreen;
        //    newPrefabTicketFullScreen.SetActive(false);

        //}    

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
            newPrefabTicket?.SetActive(true);
            //TicketComponent = newPrefabTicketFullScreen.GetComponentInChildren<TextMeshProUGUI>();
            //TicketComponent.transform.SetParent(newPrefabTicketFullScreen.transform, false);
            //TicketComponent.text = "#" + animationController.id.ToString();
        }

        if (animationController.IsTicket == false)
        {
            newPrefabTicket?.SetActive(false);
        }
    }

    public void OpenTicketNvTrueFullScreen()
    {
        if (ticketNvFullScreen.newPrefabTicketFullScreen != null)
        {
            Debug.Log("OpenTicketNvTrueFullScreen đã được gọi.");
            ticketNvFullScreen.newPrefabTicketFullScreen?.SetActive(true);
            StartCoroutine(TimeToCheckTicket());
        }
    }

    public IEnumerator TimeToCheckTicket()
    {
        yield return new WaitForSeconds(3);
        ticketNvFullScreen.newPrefabTicketFullScreen.SetActive(false);
        Debug.Log("TicketNvFullScreen đã được tắt sau 3 giây.");
    }
}
