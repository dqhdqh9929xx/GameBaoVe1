using UnityEngine;

public class PanelPlayerManager : MonoBehaviour
{
    public AnimationController1 animationController;
    public GameObject prefabToInstantiate;
    public Transform NoteBookFull;

    public bool hasInstantiated = false;
    public float SpawnLocal = 100f;




    void Update()
    {

        if (animationController.NextNv == true)
        {
            hasInstantiated = false;
            SpawnLocal += 100f;
        }

        if (hasInstantiated == false)
        {
            animationController.NextNv = false;
            hasInstantiated = true;
            if (NoteBookFull == null)
            {
                Debug.LogWarning("NoteBookFull chưa được gán!");
                return;
            }
            // Lấy vị trí local của PanelPlayerManager so với NoteBookFull
            Vector3 localPos = NoteBookFull.InverseTransformPoint(transform.position);
            // Giảm y đi 100 đơn vị trong local space
            Vector3 spawnLocalPos = new Vector3(localPos.x, localPos.y - SpawnLocal, localPos.z);
            // Instantiate prefab (UI) làm con của NoteBookFull, không làm thay đổi scale/rotation
            GameObject newPrefab = Instantiate(prefabToInstantiate);
            newPrefab.transform.SetParent(NoteBookFull, false);
            // Đặt vị trí local
            newPrefab.GetComponent<RectTransform>().localPosition = spawnLocalPos;

            Debug.Log("Đã instantiate prefab tại vị trí: " + spawnLocalPos);

        }
    }
}
