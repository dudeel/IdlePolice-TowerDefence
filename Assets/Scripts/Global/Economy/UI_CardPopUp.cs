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
    private GlobalRarity _globalRarity;
    public void OpenMenu()
    {
        _menuUI.SetActive(true);

        _mergeLevelText.text = $"L. {_mergeLevel}";
        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
        _upgradeText.text = $"L. {_upgradeLevel}";
    }

    public void CloseMenu()
    {
        _menuUI.SetActive(false);
    }

    public void SetCardData(CardHandler.CardFormattedData data)
    {
        _globalRarity = transform.GetComponent<GlobalRarity>();
        _cardFormattedData = data;

        _uiCard.CharacterInfo = _cardFormattedData.cardInfo;
        _uiCard.GlobalCardType = transform.GetComponent<GlobalAttackType>();
        _uiCard.GlobalRarity = _globalRarity;
        _uiCard.LoadData();

        _descriptionText.text = _cardFormattedData.cardInfo.Description;
        _targetText.text = GlobalTargetType.GetTargetType(_cardFormattedData.cardInfo.Target);
        _healthText.text = _cardFormattedData.cardInfo.Health.ToString();
        _damageText.text = _cardFormattedData.cardInfo.Damage.ToString();
        _attackIntervalText.text = _cardFormattedData.cardInfo.AttackInterval.ToString();

        _rarityText.text = _globalRarity.GetRarityText(_cardFormattedData.cardInfo.Rarity);
        _rarityImage.sprite = _globalRarity.GetRarityMiniSprite(_cardFormattedData.cardInfo.Rarity);

        _uiCard.transform.GetChild(3).gameObject.SetActive(false);

        if (_cardFormattedData.levelData != null)
        {
            SetLevelData();
            _rarityImage.transform.localPosition = new Vector3(transform.localPosition.x, 127, transform.localPosition.z);
        }
        else
        {
            _rarityImage.transform.localPosition = new Vector3(transform.localPosition.x, 110, transform.localPosition.z);
        }
        SetSelectButton();
    }

    public void SetLevelData()
    {
        _uiCardLevel.GlobalRarity = _globalRarity;
        _uiCardLevel.Data = _cardFormattedData;

        _upgradeCardLevel = _cardFormattedData.levelData.Level;
        _upgradeCardText.text = $"L. {_cardFormattedData.levelData.Level}";
        _uiCardLevel.SetData();

        _uiCard.transform.GetChild(3).gameObject.SetActive(true);
    }

    private int MaxMerge = 6;
    public void MergeButtonClick()
    {
        if (_mergeLevel >= MaxMerge) _mergeLevel = 1;
        else _mergeLevel++;

        _mergeLevelText.text = $"L. {_mergeLevel}";
    }

    public void UpgradeCardButtonClick()
    {
        if (_upgradeCardLevel >= _globalRarity.GetMaxLevelUpgrade(_cardFormattedData.cardInfo.Rarity)) _upgradeCardLevel = 1;
        else _upgradeCardLevel++;

        _upgradeCardText.text = $"L. {_upgradeCardLevel}";
    }

    private int MaxUpgrade = 10;
    public void UpgradeButtonClick()
    {
        if (_upgradeLevel >= MaxUpgrade) _upgradeLevel = 1;
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
