using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSystem : MonoBehaviour
{
    public enum SpriteType { Unit, Spawner, Tower }

    [SerializeField] private SpriteSet[] spriteSets;

    public Sprite GetSprite(SpriteType spriteType, int playerId)
    {
        foreach (SpriteSet set in spriteSets)
        {
            if (set.spriteType == spriteType)
            {
                if (playerId >= 0)
                {
                    return set.playerSprites[playerId];
                }
                else
                {
                    return set.neutralSprite;
                }
            }
        }
        return null;
    }

    [System.Serializable]
    public class SpriteSet
    {
        public SpriteType spriteType;
        public Sprite neutralSprite;
        public Sprite[] playerSprites;
    }
}
