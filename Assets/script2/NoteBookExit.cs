using UnityEngine;

public class NoteBookExit : MonoBehaviour
{
    [SerializeField] private GameObject notebookUI; // Reference to the notebook UI GameObject
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseNoteBook()
    {
        if (notebookUI != null)
        {
            notebookUI.SetActive(false); // Deactivate the notebook UI
        }
    }
}
