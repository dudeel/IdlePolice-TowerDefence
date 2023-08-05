using UnityEngine;

public class GlobalRarity : MonoBehaviour
{
    public enum Rarity
    {
        NORMAL = 0, // Обычная
        RARE = 1, // Редкая
        MAGIC = 2, // Магическая
        LEGENDARY = 3 // Легендарная
    }

    [SerializeField] private Sprite _normal;
    [SerializeField] private Sprite _rare;
    [SerializeField] private Sprite _magic;
    [SerializeField] private Sprite _legendary;

    public Sprite GetRaritySprite(Rarity m_rarity)
    {
        switch (m_rarity)
        {
            case Rarity.NORMAL:
                return _normal;
            case Rarity.RARE:
                return _rare;
            case Rarity.MAGIC:
                return _magic;
            case Rarity.LEGENDARY:
                return _legendary;

            default: 
                Debug.Log("This rarity is not found. Set default = NORMAL");
                return _normal; 
        }
    }
}
