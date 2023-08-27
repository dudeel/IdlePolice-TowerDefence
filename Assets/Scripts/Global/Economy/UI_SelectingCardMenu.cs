using UnityEngine;
using System.Collections.Generic;

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

    private List<CardHandler.CardFormattedData> _collected;
    private CardHandler.CardFormattedData[] _selected = new CardHandler.CardFormattedData[4];

    private void Start()
    {
        _selected = CardHandler.Get().selected;
        _collected = CardHandler.Get().collected;
    }

    public void EnableSelectMenu()
    {
        foreach (var item in _anotherCardUI)
        { item.SetActive(false); }

        _selectMenu.SetActive(true);

        foreach (var item in _selectedCards.SelectedCardObjectList)
        {
            item.GetComponent<Animator>().enabled = true;
            item.GetComponent<UI_CardSelecting>().enabled = true;
        }

        SetCard();
    }

    public void DisableSelectMenu()
    {
        _selectMenu.SetActive(false);

        foreach (var item in _selectedCards.SelectedCardObjectList)
        {
            item.GetComponent<Animator>().enabled = false;
            item.GetComponent<UI_CardSelecting>().enabled = false;
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

    public void ChangeCard(int index)
    {
        UI_Card cardUI = _selectedCards.SelectedCardObjectList[index].GetComponent<UI_Card>();
        UI_CardLevel cardUILevel = _selectedCards.SelectedCardObjectList[index].GetComponent<UI_CardLevel>();

        cardUI.CardFormattedData = CardFormattedData;
        cardUI.CharacterInfo = CardFormattedData.cardInfo;
        cardUI.LoadData();

        cardUILevel.Data = CardFormattedData;
        cardUILevel.SetData();

        DisableSelectMenu();
    }
}
