using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Card : MonoBehaviour
{
    public CardInfo CharacterInfo;

    public GlobalAttackType GlobalCardType;
    public GlobalRarity GlobalRarity;
    public UI_CardPopUp PopUp;

    public CardHandler.CardFormattedData CardFormattedData;

    [SerializeField] private Image _character;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _rarity;
    [SerializeField] private Image _type;

    public void LoadData()
    {
        _character.sprite = CharacterInfo.Image;
        _name.text = CharacterInfo.Name;
        _rarity.sprite = GlobalRarity.GetRarityCardSprite(CharacterInfo.Rarity);
        _type.sprite = GlobalCardType.GetTypeSprite(CharacterInfo.Type);
    }

    public void OpenPopUp()
    {
        PopUp.OpenMenu();

        switch (CardFormattedData.cardStatus)
        {
            case CardHandler.CardStatus.Select:
                PopUp.SetCardData(CardFormattedData);
                break;
            case CardHandler.CardStatus.Collect:
                PopUp.SetCardData(CardFormattedData);
                PopUp.SetSelectButton();
                break;
            case CardHandler.CardStatus.NotFound:
                PopUp.SetCardData(CardFormattedData);
                break;

            default:
                PopUp.SetCardData(CardFormattedData);
                Debug.LogError("This card status is not found. Set default = NotFound");
                break;
        }
    }

}
