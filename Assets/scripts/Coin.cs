using UnityEngine;

public class Coin : MonoBehaviour
{
    public AnimationController1 animationController;
    public GameObject Coin1;
    void Start()
    {
       if (Coin1 != null)
           Coin1.SetActive(true);
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
}
