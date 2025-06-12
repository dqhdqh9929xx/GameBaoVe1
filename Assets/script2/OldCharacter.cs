using UnityEngine;

namespace Assets.script2
{
    public class OldCharacterData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Sprite NormalImage { get; set; }
        public Sprite AttackImage { get; set; }
        public bool IsTrueChoiceCome { get; set; } = true;
        public bool IsTrueChoiceLeft { get; set; } = true;
    }
}