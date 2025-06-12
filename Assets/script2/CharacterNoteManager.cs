using UnityEngine;

public class CharacterNoteManager : MonoBehaviour
{
    [SerializeField] GameObject prefabsCharacterNote;
    public CharacterManager characterManager;
    private GameObject newPrefabsNote;
    void Start()
    {
        
    }

    void Update()
    {
        if (characterManager.characters.Count > 0)
        {
            newPrefabsNote = Instantiate(prefabsCharacterNote, this.transform);
        }    
    }
}
