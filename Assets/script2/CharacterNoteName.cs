using TMPro;
using UnityEngine;

public class CharacterNoteName : MonoBehaviour
{
    private int NameIndex;

    [SerializeField] GameObject prefabsCharacterNoteName;
    public Transform FirstNoteNameCharacter;
    public Transform FirstNoteNameCharacter2;
    public Transform FirstNoteNameCharacter3;
    public Transform FirstNoteNameCharacter4;
    public Transform FirstNoteNameCharacter5;

    public CharacterManager characterManager;

    private int SpawnLocal = 0;

    public void InstantiateCharacterName()
    {
        if (SpawnLocal == 0)
        {
            Vector3 localPosName = FirstNoteNameCharacter.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosName = new Vector3(localPosName.x - 600, localPosName.y + 300, localPosName.z);

            //NameIndex = CharacterManager.randomIndex;
            var currentChar = characterManager.currentCharacterData;


            GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
            newNote.transform.SetParent(FirstNoteNameCharacter, false);

            var textComp = newNote.GetComponent<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = $"{currentChar.Name}:";
            }
        }
        if (SpawnLocal == 1)
        {
            Vector3 localPosName = FirstNoteNameCharacter2.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosName = new Vector3(localPosName.x - 600, localPosName.y + 300, localPosName.z);
            //NameIndex = CharacterManager.randomIndex;
            var currentChar = characterManager.currentCharacterData;



            GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
            newNote.transform.SetParent(FirstNoteNameCharacter2, false);
            var textComp = newNote.GetComponent<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = $"{currentChar.Name}:";
            }
        }
        if (SpawnLocal == 2)
        {
            Vector3 localPosName = FirstNoteNameCharacter3.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosName = new Vector3(localPosName.x - 600, localPosName.y + 300, localPosName.z);
            var currentChar = characterManager.currentCharacterData;



            GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
            newNote.transform.SetParent(FirstNoteNameCharacter3, false);
            var textComp = newNote.GetComponent<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = $"{currentChar.Name}:";
            }
        }
        if (SpawnLocal == 3)
        {
            Vector3 localPosName = FirstNoteNameCharacter4.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosName = new Vector3(localPosName.x - 600, localPosName.y + 300, localPosName.z);
            //NameIndex = CharacterManager.randomIndex;
            var currentChar = characterManager.currentCharacterData;




            GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
            newNote.transform.SetParent(FirstNoteNameCharacter4, false);
            var textComp = newNote.GetComponent<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = $"{currentChar.Name}:";
            }
        }
        if (SpawnLocal == 4)
        {
            Vector3 localPosName = FirstNoteNameCharacter5.InverseTransformPoint(transform.position);
            Vector3 spawnLocalPosName = new Vector3(localPosName.x - 600, localPosName.y + 300, localPosName.z);
            //NameIndex = CharacterManager.randomIndex;
            var currentChar = characterManager.currentCharacterData;



            GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
            newNote.transform.SetParent(FirstNoteNameCharacter5, false);
            var textComp = newNote.GetComponent<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = $"{currentChar.Name}:";
            }
        }
        SpawnLocal += 1;
    }
}
