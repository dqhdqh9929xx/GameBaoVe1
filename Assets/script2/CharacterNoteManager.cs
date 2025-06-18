using System;
using TMPro;
using UnityEngine;

public class CharacterNoteManager : MonoBehaviour
{
    [SerializeField] GameObject prefabsCharacterNote;
    private GameObject newPrefabsNote = null;
    public Transform FirstNoteCharacter;
    public CharacterManager characterManager;
    
    private int SpawnLocal = 0;
    public void InstantiateCharacterNote()
    {
        Vector3 localPos = FirstNoteCharacter.InverseTransformPoint(transform.position);
        Vector3 spawnLocalPos = new Vector3(localPos.x, localPos.y - SpawnLocal, localPos.z);
        newPrefabsNote = Instantiate(prefabsCharacterNote, spawnLocalPos, Quaternion.identity);
        newPrefabsNote.transform.SetParent(FirstNoteCharacter, false);

        SpawnLocal += 100;
    }


}
