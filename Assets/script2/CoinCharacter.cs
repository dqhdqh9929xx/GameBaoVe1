using UnityEngine;

public class CoinCharacter : MonoBehaviour
{
    public static bool isClickedCoin = false;

    public void OnClickCoin()
    {
        isClickedCoin = true;
        Destroy(gameObject);
    }
    public void DestroyCoin()
    {
        isClickedCoin = false;
        Destroy(gameObject);
    }
}
