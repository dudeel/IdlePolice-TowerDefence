using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardPopUp : MonoBehaviour
{
    [SerializeField] private Have _data = new();
    [SerializeField] private GlobalCardsList _cards;

    [SerializeField] private GameObject _menuUI;
    [SerializeField] private Button _background;
    [SerializeField] private Button _closeButton;

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

    private void Awake()
    {
        GlobalCardsList cards = new();
        _cards = cards;
    }

    public void SetHaveData(Have data, bool isSelect)
    {
        _data = data;

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

    public void SetNotFoundData()
    {
        
    }

    public void ShowInfo()
    {

    }

    public void SelectCheck()
    {

    }

    public void SelectClick()
    {

    }

    public void UpgradeCheck()
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
