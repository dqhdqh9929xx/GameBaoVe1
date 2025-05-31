using UnityEngine;

public class PanelPlayerManager : MonoBehaviour
{
    public AnimationController1 animationController;
    public GameObject prefabToInstantiate;
    public Transform NoteBookFull;

    public bool hasInstantiated = false;
    public float SpawnLocal = 0f;


    void Update()
    {
        if (animationController.NextNv == true)
        {
            hasInstantiated = false;
            SpawnLocal += 100f;
            Debug.Log("Da +");
        }

        if (hasInstantiated == false && animationController.id != 1)
        {
            animationController.NextNv = false;
            hasInstantiated = true;
            Vector3 localPos = NoteBookFull.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPos = new Vector3(localPos.x, localPos.y - SpawnLocal, localPos.z);
            GameObject newPrefab = Instantiate(prefabToInstantiate);
            newPrefab.transform.SetParent(NoteBookFull, false);
            newPrefab.GetComponent<RectTransform>().localPosition = spawnLocalPos;
            Debug.Log("Đã instantiate prefab tại vị trí: " + spawnLocalPos);

        }
    }
}
