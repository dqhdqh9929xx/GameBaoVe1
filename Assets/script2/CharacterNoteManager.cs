using System;
using TMPro;
using UnityEngine;

public class CharacterNoteManager : MonoBehaviour
{
    [SerializeField] GameObject prefabsCharacterNote;
    private GameObject newPrefabsNote = null;
    private GameObject newPrefabsName = null;
    public Transform FirstNoteCharacter;
    public Transform FirstNoteNameCharacter;
    public CharacterManager characterManager;
    private int NameIndex;
    private int SpawnLocal = 0;
    public void InstantiateCharacterNote()
    {
        Vector3 localPos = FirstNoteCharacter.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPos = new Vector3(localPos.x, localPos.y - SpawnLocal, localPos.z);
        newPrefabsNote = Instantiate(prefabsCharacterNote, spawnLocalPos, Quaternion.identity);
        newPrefabsNote.transform.SetParent(FirstNoteCharacter, false);

        SpawnLocal += 100;
    }

    public void InstantiateCharacterName()
    {
        Vector3 localPosName = FirstNoteNameCharacter.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPosName = new Vector3(localPosName.x, localPosName.y - SpawnLocal, localPosName.z);
        NameIndex = characterManager.randomIndex;
        var currentChar = characterManager.characters[NameIndex];
        var noteName = this.GetComponent<TextMeshProUGUI>();
        noteName.text = currentChar.Name;
        newPrefabsName = Instantiate(noteName.gameObject, spawnLocalPosName, Quaternion.identity);
        newPrefabsName.transform.SetParent(FirstNoteNameCharacter, false);

    }

}
