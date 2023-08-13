using UnityEngine;

public class GlobalAttackType : MonoBehaviour
{
    public enum Type
    {
        Melee = 0, // Рукопашный
        Shooter = 1,  // Стрелок
        Doctor = 2,  // Врач
        Tank = 3,  // Танк
        Mage = 4  // Волшебник
    }

    [SerializeField] private Sprite Melee;
    [SerializeField] private Sprite Shooter;
    [SerializeField] private Sprite Doctor;
    [SerializeField] private Sprite Tank;
    [SerializeField] private Sprite Mage;

    public Sprite GetTypeSprite(Type m_type)
    {
        switch (m_type)
        {
            case Type.Melee:
                return Melee;
            case Type.Shooter:
                return Shooter;
            case Type.Doctor:
                return Doctor;
            case Type.Tank:
                return Tank;
            case Type.Mage:
                return Mage;

            default: 
                Debug.LogError("This type character is not found. Set default = Melee");
                return Melee; 
        }
    }
}
