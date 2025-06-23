using UnityEngine;

public class CoinCharacterManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform targetTransform;
    public RectTransform canvasRect;         
    public static CoinCharacter CoinCharacter;
    public static bool isClickedCoinS = false;
    public GameObject newPrefabCoin = null;

    public void InstantiateCoin()
    {
        //Vector3 localPosCoin = targetTransform.localPosition; 
        //Vector3 spawnLocalPosCoin = new Vector3(localPosCoin.x, localPosCoin.y, localPosCoin.z);
        //newPrefabCoin = Instantiate(coinPrefab, canvasRect);
        //newPrefabCoin.GetComponent<RectTransform>().localPosition = spawnLocalPosCoin;
        //InvokeRepeating("IsClickedCoin", 0f, 3f); // Lặp lại kiểm tra nút Coin mỗi 3 giây


        // Bước 1: Tạo UI object gắn vào canvas
        GameObject uiObject = Instantiate(coinPrefab, canvasRect);
        RectTransform uiRect = uiObject.GetComponent<RectTransform>();

        // Bước 2: Chuyển WorldPos của đối tượng rỗng → ScreenPoint
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, targetTransform.position);

        // Bước 3: Chuyển ScreenPoint → Local anchoredPosition trong Canvas
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out anchoredPos);

        // Bước 4: Gán vị trí
        uiRect.anchoredPosition = anchoredPos;

        InvokeRepeating("IsClickedCoin", 0f, 3f); // Lặp lại kiểm tra nút Coin mỗi 3 giây
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
