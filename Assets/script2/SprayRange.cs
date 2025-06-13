using UnityEngine;

public class SprayRange : MonoBehaviour
{
    public spray Spray; // Tham chiếu đến đối tượng spray
    public CharacterManager CharacterManager;
    public static bool characterAttacked = false;

    private void Start()
    {
        Debug.Log("SprayRange Start");
    }

    public void SprayClicked()
    {
        Debug.Log("Spray clicked!");
        if (Spray.isSprayActive == true && CharacterManager.CanBtnSpray == true)
        {
            characterAttacked = true;
            Spray.isSprayActive = false;
            Debug.Log("Character attacked by spray!");
        }
    }
}
