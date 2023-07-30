using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Card : MonoBehaviour
{
    [SerializeField] private CardInfo _characterInfo;
    [SerializeField] private GlobalAttackType _globalCardType;
    [SerializeField] private GlobalRarity _globalRarity;

    [SerializeField] private Image _character;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _rarity;
    [SerializeField] private Image _type;

    private void Awake()
    {
        _character.sprite = _characterInfo.Image;
        _name.text = _characterInfo.Name;
        _rarity.sprite = _globalRarity.GetRaritySprite(_characterInfo.Rarity);
        _type.sprite = _globalCardType.GetTypeSprite(_characterInfo.Type);
    }
    
}
