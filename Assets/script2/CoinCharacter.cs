using UnityEngine;

public class CoinCharacter : MonoBehaviour
{
    public static bool isClickedCoin = false;

    public void OnClickCoin()
    {
        isClickedCoin = true;
        Destroy(gameObject);
    }
}
