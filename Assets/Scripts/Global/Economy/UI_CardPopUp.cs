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

    public void SetHaveData(Have data, bool isSelect)
    {
        _upgradeCardLevel = data.Level;

        LoadCardData(data);
        SelectCheck(isSelect);
    }

    public void LoadCardData(Have data)
    {
        GlobalCardsList cardList = new();
        GlobalRarity globalRarity = transform.GetComponent<GlobalRarity>();

        _descriptionText.text = cardList.Cards[data.ID].Description;
        _targetText.text = GlobalTargetType.GetTargetType(cardList.Cards[data.ID].Target);
        _healthText.text = cardList.Cards[data.ID].Health.ToString();
        _damageText.text = cardList.Cards[data.ID].Damage.ToString();
        _attackIntervalText.text = cardList.Cards[data.ID].AttackInterval.ToString();

        _rarityText.text = globalRarity.GetRarityText(cardList.Cards[data.ID].Rarity);
        _rarityImage.sprite = globalRarity.GetRarityMiniSprite(cardList.Cards[data.ID].Rarity);

        _uiCard.CharacterInfo = cardList.Cards[data.ID];
        _uiCard._globalCardType = transform.GetComponent<GlobalAttackType>();
        _uiCard._globalRarity = globalRarity;
        _uiCard.LoadData();

        _uiCard.GetComponent<UI_CardLevel>().isHave = true;
        _uiCard.GetComponent<UI_CardLevel>().Data = data;
    }

    public void SelectCheck(bool isSelect)
    {
        if (isSelect)
        {
            _selectButtonUI.enabled = false;
            _selectButton.sprite = _disableButtonSprite;
        }
        else 
        {
            _selectButtonUI.enabled = true;
            _selectButton.sprite = _enableButtonSprite;
        }
    }

    public void UpgradeCheck(Have data)
    {
        Curency _curencySerialize = new();

        int levelMultiply = 2;
        int amountEnought = data.Level * levelMultiply;

        int goldCount = _curencySerialize.Count().Gold;
        int goldMultiply = 75;
        int goldEnought = data.Level * goldMultiply;

        if (data.Amount >= amountEnought)
        {
            if (goldCount >= goldEnought)
            {
                _upgradeButton.enabled = true;
                _upgradeButton.sprite = _enableButtonSprite;
            }
            else
            {
                _upgradeButton.enabled = false;
                _upgradeButton.sprite = _disableButtonSprite;
            }
        }
        else
        {
            _upgradeButton.enabled = false;
            _upgradeButton.sprite = _disableButtonSprite;
        }
    }

    public void LoadInfoButton()
    {
        _mergeLevelText.text = _mergeLevel.ToString();
        _upgradeCardText.text = _upgradeCardLevel.ToString();
        _upgradeText.text = _upgradeLevel.ToString();
    }

    public void SelectClick()
    {

    }

    public void UpgradeClick()
    {

    }

    public void OpenMenu()
    {
        _menuUI.SetActive(true);
    }

    public void CloseMenuClick()
    {
        _menuUI.SetActive(false);
    }
}
