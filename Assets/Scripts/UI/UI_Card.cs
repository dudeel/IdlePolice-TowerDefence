using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Card : MonoBehaviour
{
    public CardInfo CharacterInfo;

    public GlobalAttackType _globalCardType;
    public GlobalRarity _globalRarity;

    [SerializeField] private Image _character;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _rarity;
    [SerializeField] private Image _type;

    public void LoadData()
    {
        _character.sprite = CharacterInfo.Image;
        _name.text = CharacterInfo.Name;
        _rarity.sprite = _globalRarity.GetRaritySprite(CharacterInfo.Rarity);
        _type.sprite = _globalCardType.GetTypeSprite(CharacterInfo.Type);
    }
    
}
