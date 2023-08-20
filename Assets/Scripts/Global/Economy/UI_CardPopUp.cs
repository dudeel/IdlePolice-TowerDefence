using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardPopUp : MonoBehaviour
{
    [SerializeField] private GameObject _menuUI;

    [SerializeField] private int _mergeLevel = 1;
    [SerializeField] private int _upgradeCardLevel = 1;
    [SerializeField] private int _upgradeLevel = 1;

    [SerializeField] private Button _selectButtonUI;
    [SerializeField] private Button _upgradeButtonUI;

    [SerializeField] private Image _selectButton;
    [SerializeField] private Image _upgradeButton;

    [SerializeField] private Sprite _disableButtonSprite;
    [SerializeField] private Sprite _enableButtonSprite;


    [SerializeField] private UI_Card _uiCard;
    [SerializeField] private UI_CardLevel _uiCardLevel;

    [SerializeField] private Image _rarityImage;
    [SerializeField] private TextMeshProUGUI _rarityText;

    [SerializeField] private TextMeshProUGUI _descriptionText;

    [SerializeField] private TextMeshProUGUI _upgradePriceText;

    [SerializeField] private TextMeshProUGUI _targetText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _attackIntervalText;

    [SerializeField] private TextMeshProUGUI _mergeLevelText;
    [SerializeField] private TextMeshProUGUI _upgradeCardText;
    [SerializeField] private TextMeshProUGUI _upgradeText;

    [SerializeField] private CardHandler.CardFormattedData _cardFormattedData;
    public void OpenMenu()
    {
        _menuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        _menuUI.SetActive(false);
    }

    public void SetCardData(CardHandler.CardFormattedData data)
    {
        GlobalRarity globalRarity = transform.GetComponent<GlobalRarity>();
        _cardFormattedData = data;

        _uiCard.CharacterInfo = _cardFormattedData.cardInfo;
        _uiCard.GlobalCardType = transform.GetComponent<GlobalAttackType>();
        _uiCard.GlobalRarity = globalRarity;
        _uiCard.LoadData();

        _descriptionText.text = _cardFormattedData.cardInfo.Description;
        _targetText.text = GlobalTargetType.GetTargetType(_cardFormattedData.cardInfo.Target);
        _healthText.text = _cardFormattedData.cardInfo.Health.ToString();
        _damageText.text = _cardFormattedData.cardInfo.Damage.ToString();
        _attackIntervalText.text = _cardFormattedData.cardInfo.AttackInterval.ToString();

        _rarityText.text = globalRarity.GetRarityText(_cardFormattedData.cardInfo.Rarity);
        _rarityImage.sprite = globalRarity.GetRarityMiniSprite(_cardFormattedData.cardInfo.Rarity);

        _uiCard.transform.GetChild(3).gameObject.SetActive(false);

        if (_cardFormattedData.levelData != null) SetLevelData();
    }

    public void SetLevelData()
    {
        _uiCardLevel.GlobalRarity = transform.GetComponent<GlobalRarity>();
        _uiCardLevel.Data = _cardFormattedData;

        _upgradeCardLevel = _cardFormattedData.levelData.Level;
        _upgradeCardText.text = $"L. {_cardFormattedData.levelData.Level}";
        _uiCardLevel.SetData();

        _uiCard.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void MergeButtonClick()
    {
        _mergeLevel++;
        _mergeLevelText.text = $"L. {_mergeLevel}";
    }
    public void UpgradeCardButtonClick()
    {
        _upgradeCardLevel++;
        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
    }
    public void UpgradeButtonClick()
    {
        _upgradeLevel++;
        _upgradeText.text = $"L. {_upgradeLevel}";
    }

    public void SetSelectButton()
    {
        // Включить кнопку для выбора
    }

    public void SelectCheck()
    {

    }

    public void UpgradeCheck()
    {

    }

    public void UpdateClick()
    {

    }

    public void SelectClick()
    {

    }
}
