using TMPro;
using UnityEngine;

public class CharacterNoteName : MonoBehaviour
{
    private int NameIndex;

    [SerializeField] GameObject prefabsCharacterNoteName;
    public Transform FirstNoteNameCharacter;
    public CharacterManager characterManager;

    private int SpawnLocal = 0;

    public void InstantiateCharacterName()
    {
        Vector3 localPosName = FirstNoteNameCharacter.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosName = new Vector3(localPosName.x, localPosName.y - SpawnLocal, localPosName.z);

        NameIndex = characterManager.randomIndex;
        var currentChar = characterManager.characters[NameIndex];

        GameObject newNote = Instantiate(prefabsCharacterNoteName, spawnLocalPosName, Quaternion.identity);
        newNote.transform.SetParent(FirstNoteNameCharacter, false);

        var textComp = newNote.GetComponent<TextMeshProUGUI>();
        if (textComp != null)
        {
            textComp.text = currentChar.Name;
        }

        SpawnLocal += 100;
    }
}
