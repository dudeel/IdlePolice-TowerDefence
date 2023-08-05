using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Card/CardInfo", order = 0)]
public class CardInfo : ScriptableObject
{
    public int ID = 0;
    public Sprite Image = null;

    public string Name = "Null";

    public GlobalRarity.Rarity Rarity;
    public GlobalAttackType.Type Type;

    public float Health;
    public float Damage;
    public float ShootingSpeed ;
}