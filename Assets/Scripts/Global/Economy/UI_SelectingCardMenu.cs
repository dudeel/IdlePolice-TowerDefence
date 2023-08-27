using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_SelectingCardMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectMenu;

    [SerializeField] private UI_Card _uiCard;
    [SerializeField] private UI_CardLevel _uiCardLevel;
    public CardHandler.CardFormattedData CardFormattedData;
    public GlobalRarity GlobalRarity;
    public GlobalAttackType GlobalAttackType;

    [SerializeField] private List<GameObject> _anotherCardUI;
    [SerializeField] private UI_SelectedCards _selectedCards;

    public void EnableSelectMenu()
    {
        foreach (var item in _anotherCardUI)
        { item.SetActive(false); }

        _selectMenu.SetActive(true);

        foreach (var item in _selectedCards.SelectedCardObjectList)
        {
            item.GetComponent<Animator>().enabled = true;
            item.GetComponent<Button>().enabled = false;
        }

        SetCard();
    }

    public void DisableSelectMenu()
    {
        _selectMenu.SetActive(false);

        foreach (var item in _selectedCards.SelectedCardObjectList)
        {
            item.GetComponent<Animator>().enabled = false;
            item.GetComponent<Button>().enabled = true;
        }

        foreach (var item in _anotherCardUI)
        { item.SetActive(true); }
    }

    private void SetCard()
    {
        _uiCard.CharacterInfo = CardFormattedData.cardInfo;
        _uiCard.GlobalCardType = GlobalAttackType;
        _uiCard.GlobalRarity = GlobalRarity;
        _uiCard.LoadData();

        _uiCardLevel.GlobalRarity = GlobalRarity;
        _uiCardLevel.Data = CardFormattedData;
        _uiCardLevel.SetData();
    }
}
