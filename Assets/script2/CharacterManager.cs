using Assets.script2;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] Sprite[] NormalImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] Sprite[] AttackImages; // Mảng 2D chứa các Image của nhân vật
    [SerializeField] GameObject CharacterPrefab;

    private GameObject CurrentCharater;
    private List<CharacterData> characters = new();
    private List<GameObject> oldCharaters = new();
    private System.Random random = new System.Random();

    void Start()
    {
        characters.Add(new CharacterData()
        {
            Id = 1,
            Name = "Name 1 ",
            AttackImage = AttackImages[0],
            NormalImage = NormalImages[0],
            IsTrueChoiceCome = true,
            IsTrueChoiceLeft = true
        });
        characters.Add(new CharacterData()
        {
            Id = 2,
            Name = "Name 2 ",
            AttackImage = AttackImages[1],
            NormalImage = NormalImages[1],
            IsTrueChoiceCome = true,
            IsTrueChoiceLeft = false
        });
        characters.Add(new CharacterData()
        {
            Id = 3,
            Name = "Name 3 ",
            AttackImage = AttackImages[2],
            NormalImage = NormalImages[2],
            IsTrueChoiceCome = false,
            IsTrueChoiceLeft = true
        });

        StartFirstCharacter();
    }

    void Update()
    {
        
    }

    private void StartFirstCharacter()
    {
        // Khởi tạo nhân vật đầu tiên
        int randomIndex = random.Next(characters.Count);
        CharacterData randomCharacter = characters[randomIndex];
        characters.RemoveAt(randomIndex);

        if(CurrentCharater != null)
        {
            oldCharaters.Add(CurrentCharater);
        }

        CurrentCharater = Instantiate(CharacterPrefab, this.transform);
        var nv = CurrentCharater.GetComponent<NhanVat>();
        nv.normalImage = randomCharacter.NormalImage;
        nv.attackImage = randomCharacter.AttackImage;
        nv.OnNormal();
        Animator animator = CurrentCharater.GetComponent<Animator>();
        animator.SetTrigger("ComeA");
        






    }
}
