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
    public void OpenMenu()
    {
        _menuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        _menuUI.SetActive(false);
    }

    public void SetCardData(CardInfo data)
    {
        GlobalRarity globalRarity = transform.GetComponent<GlobalRarity>();

        _uiCard.CharacterInfo = data;
        _uiCard.GlobalCardType = transform.GetComponent<GlobalAttackType>();
        _uiCard.GlobalRarity = globalRarity;
        _uiCard.LoadData();

        _descriptionText.text = data.Description;
        _targetText.text = GlobalTargetType.GetTargetType(data.Target);
        _healthText.text = data.Health.ToString();
        _damageText.text = data.Damage.ToString();
        _attackIntervalText.text = data.AttackInterval.ToString();

        _rarityText.text = globalRarity.GetRarityText(data.Rarity);
        _rarityImage.sprite = globalRarity.GetRarityMiniSprite(data.Rarity);

        _uiCard.transform.GetChild(3).gameObject.SetActive(false);
    }

    public void SetLevelData(CardHandler.CardFormattedLevel data)
    {
        _uiCardLevel.Data = data;

        _upgradeCardLevel = data.Level;
        _upgradeCardText.text = data.Level.ToString();
        _uiCardLevel.SetData();

        _uiCard.transform.GetChild(3).gameObject.SetActive(true);
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
