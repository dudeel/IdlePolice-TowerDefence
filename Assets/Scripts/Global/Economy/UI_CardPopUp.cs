using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_CardPopUp : MonoBehaviour
{

    private const int MAX_MERGE_LEVEL = 6;
    private const int MAX_UPGRADE_IN_GAME_LEVEL = 10;
    private const int UPGRADE_PRICE_MULTIPLY = 350;

    private int _mergeLevel = 1;
    private int _startUpgradeCardLevel = 1;
    private int _upgradeCardLevel = 1;
    private int _upgradeLevel = 1;

    private int upgradePrice = 0;

    private CardHandler.CardFormattedData _cardFormattedData;
    private GlobalRarity _globalRarity;

    [SerializeField] private GameObject _menuUI;

    [SerializeField] private Button _upgradeCardLevelButtonUI;
    [SerializeField] private Image _upgradeCardLevelButton;

    [SerializeField] private Button _selectButtonUI;
    [SerializeField] private Button _upgradeButtonUI;

    [SerializeField] private Image _selectButton;
    [SerializeField] private Image _upgradeButton;

    [SerializeField] private Sprite _disableButtonSprite;
    [SerializeField] private Sprite _enableButtonSprite;
    [SerializeField] private Sprite _blueButtonSprite;


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

    readonly Curency _curencySerialize = new();

    [SerializeField] private UI_SelectingCardMenu _selectingCardMenu;

    public void OpenMenu()
    {
        _menuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        _menuUI.SetActive(false);
    }

    public void SetMenuData(CardHandler.CardFormattedData data)
    {
        _globalRarity = transform.GetComponent<GlobalRarity>();
        _cardFormattedData = data;

        SetButtonsText();
        SetCard();
        SetLevelData();
        SetRarity();
        SetDescription();
        SetStatsText();
        SetSelectButton();
        SetUpgradeButton();
    }

    private void SetCard()
    {
        _uiCard.CharacterInfo = _cardFormattedData.cardInfo;
        _uiCard.GlobalCardType = transform.GetComponent<GlobalAttackType>();
        _uiCard.GlobalRarity = _globalRarity;
        _uiCard.LoadData();
    }

    private void SetDescription()
    {
        _descriptionText.text = _cardFormattedData.cardInfo.Description;
    }

    private void SetRarity()
    {
        _rarityText.text = _globalRarity.GetRarityText(_cardFormattedData.cardInfo.Rarity);
        _rarityImage.sprite = _globalRarity.GetRarityMiniSprite(_cardFormattedData.cardInfo.Rarity);

        if (_cardFormattedData.levelData != null)
            _rarityImage.transform.localPosition = new Vector3(transform.localPosition.x, 127, transform.localPosition.z);
        else
            _rarityImage.transform.localPosition = new Vector3(transform.localPosition.x, 110, transform.localPosition.z);
    }

    private void SetLevelData()
    {
        _upgradeCardLevelButtonUI.enabled = true;
        _upgradeCardLevelButton.sprite = _blueButtonSprite;

        if (_cardFormattedData.levelData == null)
        {
            _startUpgradeCardLevel = 1;
            _upgradeCardLevel = _startUpgradeCardLevel;
            _upgradeCardText.text = $"L. {_upgradeCardLevel}";

            _uiCard.transform.GetChild(3).gameObject.SetActive(false);
        }
        else
        {
            _uiCardLevel.GlobalRarity = _globalRarity;
            _uiCardLevel.Data = _cardFormattedData;

            _startUpgradeCardLevel = _cardFormattedData.levelData.Level;
            _upgradeCardLevel = _startUpgradeCardLevel;
            _uiCardLevel.SetData();

            if (_startUpgradeCardLevel >= _globalRarity.GetMaxLevelUpgrade(_cardFormattedData.cardInfo.Rarity))
            {
                _upgradeCardLevelButtonUI.enabled = false;
                _upgradeCardLevelButton.sprite = _disableButtonSprite;
                _upgradeCardText.text = $"MAX";
            }
            else
            {
                _upgradeCardText.text = $"L. {_upgradeCardLevel}";
            }

            _uiCard.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    private void SetStatsText()
    {
        _targetText.text = GlobalTargetType.GetTargetType(_cardFormattedData.cardInfo.Target);

        float health = _cardFormattedData.cardInfo.Health + (_cardFormattedData.cardInfo.Health * 0.5f * (_mergeLevel - 1)) + (_cardFormattedData.cardInfo.Health * 0.2f * (_upgradeCardLevel - 1)) + (_cardFormattedData.cardInfo.Health * 0.4f * (_upgradeLevel - 1));

        float damage = _cardFormattedData.cardInfo.Damage + (_cardFormattedData.cardInfo.Damage * 0.45f * (_mergeLevel - 1)) + (_cardFormattedData.cardInfo.Damage * 0.15f * (_upgradeCardLevel - 1)) + (_cardFormattedData.cardInfo.Damage * 0.35f * (_upgradeLevel - 1));

        float attackInterval = _cardFormattedData.cardInfo.AttackInterval - (_cardFormattedData.cardInfo.AttackInterval * 0.06f * (_mergeLevel - 1)) - (_cardFormattedData.cardInfo.AttackInterval * 0.01f * (_upgradeCardLevel - 1)) - (_cardFormattedData.cardInfo.AttackInterval * 0.04f * (_upgradeLevel - 1));

        if (0 < Math.Round(health - (_cardFormattedData.cardInfo.Health * 0.2f * (_startUpgradeCardLevel - 1)) - _cardFormattedData.cardInfo.Health, 1))
            _healthText.text = $"{Math.Round(health, 1)} <size=35><color=green>+{Math.Round(health - (_cardFormattedData.cardInfo.Health * 0.2f * (_startUpgradeCardLevel - 1)) - _cardFormattedData.cardInfo.Health, 1)}s</color></size>";
        else _healthText.text = $"{Math.Round(health, 1)}";

        if (0 < Math.Round(damage - (_cardFormattedData.cardInfo.Damage * 0.15f * (_startUpgradeCardLevel - 1)) - _cardFormattedData.cardInfo.Damage, 1))
            _damageText.text = $"{Math.Round(damage, 1)} <size=35><color=green>+{Math.Round(damage - (_cardFormattedData.cardInfo.Damage * 0.15f * (_startUpgradeCardLevel - 1)) - _cardFormattedData.cardInfo.Damage, 1)}s</color></size>";
        else _damageText.text = $"{Math.Round(damage, 1)}";

        if (0 < Math.Round(_cardFormattedData.cardInfo.AttackInterval - (_cardFormattedData.cardInfo.AttackInterval * 0.01f * (_startUpgradeCardLevel - 1)) - attackInterval, 2))
            _attackIntervalText.text = $"{Math.Round(attackInterval, 2)}s <size=35><color=green>-{Math.Round(_cardFormattedData.cardInfo.AttackInterval - (_cardFormattedData.cardInfo.AttackInterval * 0.01f * (_startUpgradeCardLevel - 1)) - attackInterval, 2)}s</color></size>";
        else _attackIntervalText.text = $"{Math.Round(attackInterval, 2)}s";
    }

    private void SetButtonsText()
    {
        _mergeLevel = 1;
        _upgradeLevel = 1;

        _mergeLevelText.text = $"L. {_mergeLevel}";
        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
        _upgradeText.text = $"L. {_upgradeLevel}";
    }

    public void MergeButtonClick()
    {
        if (_mergeLevel >= MAX_MERGE_LEVEL) _mergeLevel = 1;
        else _mergeLevel++;

        _mergeLevelText.text = $"L. {_mergeLevel}";
        SetStatsText();
    }

    public void UpgradeCardButtonClick()
    {
        if (_upgradeCardLevel >= _globalRarity.GetMaxLevelUpgrade(_cardFormattedData.cardInfo.Rarity)) _upgradeCardLevel = _startUpgradeCardLevel;
        else _upgradeCardLevel++;

        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
        SetStatsText();
    }

    public void UpgradeButtonClick()
    {
        if (_upgradeLevel >= MAX_UPGRADE_IN_GAME_LEVEL) _upgradeLevel = 1;
        else _upgradeLevel++;

        _upgradeText.text = $"L. {_upgradeLevel}";
        SetStatsText();
    }

    public void SetSelectButton()
    {
        if (_cardFormattedData.cardStatus == CardHandler.CardStatus.Collect)
        {
            _selectButtonUI.enabled = true;
            _selectButton.sprite = _enableButtonSprite;
        }
        else
        {
            _selectButtonUI.enabled = false;
            _selectButton.sprite = _disableButtonSprite;
        }
    }

    public void SetUpgradeButton()
    {
        if (_cardFormattedData.levelData == null)
        {
            _upgradeButtonUI.enabled = false;
            _upgradeButton.sprite = _disableButtonSprite;

            upgradePrice = _globalRarity.GetUpgradePriceMultiply(_cardFormattedData.cardInfo.Rarity) * UPGRADE_PRICE_MULTIPLY;
            _upgradePriceText.text = upgradePrice.ToString();
        }
        else if (_cardFormattedData.levelData.Level >= _globalRarity.GetMaxLevelUpgrade(_cardFormattedData.cardInfo.Rarity))
        {
            _upgradeButtonUI.enabled = false;
            _upgradeButton.sprite = _disableButtonSprite;
            _upgradePriceText.text = "MAX";
        }
        else
        {
            upgradePrice = _cardFormattedData.levelData.Level * _globalRarity.GetUpgradePriceMultiply(_cardFormattedData.cardInfo.Rarity) * UPGRADE_PRICE_MULTIPLY;
            _upgradePriceText.text = upgradePrice.ToString();

            if (_cardFormattedData.levelData.Exp < _cardFormattedData.levelData.EnoughtExp)
            {
                _upgradeButtonUI.enabled = false;
                _upgradeButton.sprite = _disableButtonSprite;
                return;
            }

            if (_curencySerialize.Count().Gold >= upgradePrice)
            {
                _upgradeButtonUI.enabled = true;
                _upgradeButton.sprite = _enableButtonSprite;
            }
            else
            {
                _upgradeButtonUI.enabled = false;
                _upgradeButton.sprite = _disableButtonSprite;
            }
        }
    }

    public void SelectClick()
    {
        CloseMenu();
        _selectingCardMenu.CardFormattedData = _cardFormattedData;
        _selectingCardMenu.GlobalRarity = _globalRarity;
        _selectingCardMenu.GlobalAttackType = transform.GetComponent<GlobalAttackType>();
        _selectingCardMenu.EnableSelectMenu();
    }

    public void UpdateClick()
    {

    }
}
