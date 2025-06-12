using UnityEngine;

public class ButtonNoteBook : MonoBehaviour
{
    [SerializeField] GameObject NoteBook;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenNoteBook()
    {
        NoteBook.SetActive(true);
    }

    public void CloseNoteBook()
    {
        NoteBook.SetActive(false);
    }
}
