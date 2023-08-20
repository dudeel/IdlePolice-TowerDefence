using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardPopUp : MonoBehaviour
{

    private const int MAX_MERGE_LEVEL = 6;
    private const int MAX_UPGRADE_IN_GAME_LEVEL = 10;

    private int _mergeLevel = 1;
    private int _upgradeCardLevel = 1;
    private int _upgradeLevel = 1;

    private CardHandler.CardFormattedData _cardFormattedData;
    private GlobalRarity _globalRarity;

    [SerializeField] private GameObject _menuUI;

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
        if (_cardFormattedData.levelData == null)
            _uiCard.transform.GetChild(3).gameObject.SetActive(false);
        else
        {
            _uiCardLevel.GlobalRarity = _globalRarity;
            _uiCardLevel.Data = _cardFormattedData;

            _upgradeCardLevel = _cardFormattedData.levelData.Level;
            _upgradeCardText.text = $"L. {_cardFormattedData.levelData.Level}";
            _uiCardLevel.SetData();

            _uiCard.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    private void SetStatsText()
    {
        _targetText.text = GlobalTargetType.GetTargetType(_cardFormattedData.cardInfo.Target);
        _healthText.text = _cardFormattedData.cardInfo.Health.ToString();
        _damageText.text = _cardFormattedData.cardInfo.Damage.ToString();
        _attackIntervalText.text = $"{_cardFormattedData.cardInfo.AttackInterval}s";
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
    }

    public void UpgradeCardButtonClick()
    {
        if (_upgradeCardLevel >= _globalRarity.GetMaxLevelUpgrade(_cardFormattedData.cardInfo.Rarity)) _upgradeCardLevel = 1;
        else _upgradeCardLevel++;

        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
    }

    public void UpgradeButtonClick()
    {
        if (_upgradeLevel >= MAX_UPGRADE_IN_GAME_LEVEL) _upgradeLevel = 1;
        else _upgradeLevel++;

        _upgradeText.text = $"L. {_upgradeLevel}";
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

    public void SelectClick()
    {

    }

    public void UpgradeCheck()
    {

    }

    public void UpdateClick()
    {

    }
}
