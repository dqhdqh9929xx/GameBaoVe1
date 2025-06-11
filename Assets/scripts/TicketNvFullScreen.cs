using TMPro;
using UnityEngine;

public class TicketNvFullScreen : MonoBehaviour
{
    public GameObject TicketNvFullScreen1;
    public GameObject newPrefabTicketFullScreen = null;
    public Transform KhayDungDo;
    public AnimationController1 animationController;
    public TextMeshProUGUI TicketComponent;


    void Start()
    {
        if (TicketNvFullScreen1 != null)
            TicketNvFullScreen1?.SetActive(false);
        if (newPrefabTicketFullScreen == null)
        {
            Vector3 localPosTicketFullScreen = KhayDungDo.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosTicketFullScreen = new Vector3(localPosTicketFullScreen.x, localPosTicketFullScreen.y - 300f, localPosTicketFullScreen.z);
            newPrefabTicketFullScreen = Instantiate(TicketNvFullScreen1);
            newPrefabTicketFullScreen.transform.SetParent(KhayDungDo, false);
            newPrefabTicketFullScreen.GetComponent<RectTransform>().localPosition = spawnLocalPosTicketFullScreen;
            newPrefabTicketFullScreen?.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        TicketComponent = newPrefabTicketFullScreen.GetComponentInChildren<TextMeshProUGUI>();
        TicketComponent.transform.SetParent(newPrefabTicketFullScreen.transform, false);
        TicketComponent.text = "#" + animationController.id.ToString();
    }
}
