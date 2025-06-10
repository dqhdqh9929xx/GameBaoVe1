using UnityEngine;

public class Coin : MonoBehaviour
{
    public AnimationController1 animationController;
    public GameObject Coin1;
    public Transform KhayDungDo;
    private GameObject newPrefabCoin;
    void Start()
    {
       if (Coin1 != null)
           Coin1.SetActive(true);
    }
    private void Update()
    {
        if (animationController.IsCoin == false)
        {
            newPrefabCoin?.SetActive(false);
        }
    }

    public void AcceptCoinToLeft()
    {
        if (animationController != null)
        {
            StartCoroutine(animationController.SideWayLeft());
            Coin1.SetActive(false);
            animationController.IsTicket = false;
        }
        else
        {
            Debug.LogWarning("AnimationController1 is not assigned.");
        }
    }

    public void InstantiateCoin()
    {
        Vector3 localPosCoin = KhayDungDo.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosCoin = new Vector3(localPosCoin.x - 200f, localPosCoin.y - 300f, localPosCoin.z);
        newPrefabCoin = Instantiate(Coin1);
        newPrefabCoin.transform.SetParent(KhayDungDo, false);
        newPrefabCoin.GetComponent<RectTransform>().localPosition = spawnLocalPosCoin;
        newPrefabCoin.SetActive(true);
    }
}
