using System;
using UnityEngine;

namespace Assets.script2
{
    public class CharacterData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Sprite NormalImage { get; set; }
        public Sprite AttackImage { get; set; }
        public bool IsTrueChoiceCome { get; set; } = true;
        public bool IsTrueChoiceOut { get; set; } = true;

        public string CharacterChatIn { get; set; }
        public string CharacterChatOut { get; set; }




        public static implicit operator CharacterData(GameObject v)
        {
            throw new NotImplementedException();
        }
    }
}
