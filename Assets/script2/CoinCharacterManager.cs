using System.Drawing;
using UnityEngine;

public class CoinCharacterManager : MonoBehaviour
{
    public GameObject coinPrefab;
    //public Transform KhayDungDo;
    public static CoinCharacter CoinCharacter;
    public static bool isClickedCoinS = false;
    public GameObject newPrefabCoin = null;
    public Vector3 Origin;

    private void Start()
    {
        Origin = GetComponent<RectTransform>().localPosition;
    }

    public void InstantiateCoin()
    {
        Vector3 localPosCoin = Origin;
        Vector3 spawnLocalPosCoin = new Vector3(localPosCoin.x, localPosCoin.y , localPosCoin.z);
        newPrefabCoin = Instantiate(coinPrefab, this.transform);
        newPrefabCoin.GetComponent<RectTransform>().localPosition = spawnLocalPosCoin;
        InvokeRepeating("IsClickedCoin", 0f, 3f); // Lặp lại kiểm tra nút Coin  mỗi 3 giây
    }

    public void IsClickedCoin()
    {
        if (CoinCharacter.isClickedCoin == true)
        {
            isClickedCoinS = true;
            CoinCharacter.isClickedCoin = false;
            CancelInvoke("InstantiateCoin");
        }
    }

    public void DestroyCoin()
    {
        Destroy(newPrefabCoin);
        CancelInvoke("InstantiateCoin");
    }
}
