using UnityEngine;

public class PanelPlayerManager : MonoBehaviour
{
    public AnimationController1 animationController;
    public GameObject prefabToInstantiate;
    public Transform NoteBookFull;  // biến tham chiếu parent trong Canvas UI

    public bool hasInstantiated = false;

    void Update()
    {
        if (animationController.isCome2 && hasInstantiated == false)
        {
            hasInstantiated = true;
            if (NoteBookFull == null)
            {
                Debug.LogWarning("NoteBookFull chưa được gán!");
                return;
            }

            // Lấy vị trí local của PanelPlayerManager so với NoteBookFull
            Vector3 localPos = NoteBookFull.InverseTransformPoint(transform.position);

            // Giảm y đi 100 đơn vị trong local space
            Vector3 spawnLocalPos = new Vector3(localPos.x, localPos.y - 100f, localPos.z);

            // Instantiate prefab (UI) làm con của NoteBookFull, không làm thay đổi scale/rotation
            GameObject newPrefab = Instantiate(prefabToInstantiate);
            newPrefab.transform.SetParent(NoteBookFull, false);

            // Đặt vị trí local
            newPrefab.GetComponent<RectTransform>().localPosition = spawnLocalPos;


        }
    }
}
