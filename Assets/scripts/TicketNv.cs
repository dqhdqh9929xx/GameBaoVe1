using TMPro;
using UnityEngine;

public class TicketNv : MonoBehaviour
{
    public GameObject TicketNv1;
    public AnimationController1 animationController;
    public Transform KhayDungDo;
    private GameObject newPrefabTicket = null;
    public GameObject TicketNvFullScreen;
    public TextMeshProUGUI TicketComponent;
    void Start()
    {
        //if (TicketNv1 != null)
        //    TicketNv1.SetActive(true);
        if (TicketNvFullScreen != null)
            TicketNvFullScreen.SetActive(false);
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
            TicketComponent = TicketNvFullScreen.GetComponentInChildren<TextMeshProUGUI>();
            TicketComponent.transform.SetParent(TicketNvFullScreen.transform, false);
            TicketComponent.text = "#" + animationController.id.ToString();
        }

        if (animationController.IsTicket == false)
        {
            newPrefabTicket?.SetActive(false);
        }
    }
}
