using System.Collections.Generic;
using UnityEngine;

public class UI_SelectedCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;
    private CardHandler.CardFormattedData[] _selected = new CardHandler.CardFormattedData[4];
    public List<GameObject> SelectedCardObjectList;

    [SerializeField] private UI_CardPopUp _popUpUI;
    [SerializeField] private UI_SelectingCardMenu _selectingCardMenu;

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        _selected = CardHandler.Get().selected;

        for (int i = 0; i < _selected.Length; i++)
        {
            GameObject card = Instantiate(_cardObject, transform);
            SelectedCardObjectList.Add(card);

            UI_Card cardUI = card.GetComponent<UI_Card>();
            cardUI.CardFormattedData = _selected[i];
            cardUI.PopUp = _popUpUI;
            cardUI.CharacterInfo = _selected[i].cardInfo;
            cardUI.GlobalCardType = transform.GetComponent<GlobalAttackType>();
            cardUI.GlobalRarity = transform.GetComponent<GlobalRarity>();
            cardUI.LoadData();

            UI_CardLevel cardUILevel = card.GetComponent<UI_CardLevel>();
            cardUILevel.GlobalRarity = transform.GetComponent<GlobalRarity>();
            cardUILevel.Data = _selected[i];

            UI_CardSelecting cardSelecting = card.GetComponent<UI_CardSelecting>();
            cardSelecting.Index = i;
            cardSelecting.ID = _selected[i].cardInfo.ID;
            cardSelecting.SelectingCardMenu = _selectingCardMenu;
        }
    }

    public void UpdateData()
    {
        _selected = CardHandler.Get().selected;

        for (int i = 0; i < transform.childCount; i++)
        {
            UI_Card cardUI = transform.GetChild(i).GetComponent<UI_Card>();
            cardUI.CardFormattedData = _selected[i];
            cardUI.CharacterInfo = _selected[i].cardInfo;
            cardUI.LoadData();

            UI_CardLevel cardUILevel = transform.GetChild(i).GetComponent<UI_CardLevel>();
            cardUILevel.Data = _selected[i];
            cardUILevel.LoadData();

            UI_CardSelecting cardSelecting = transform.GetChild(i).GetComponent<UI_CardSelecting>();
            cardSelecting.ID = _selected[i].cardInfo.ID;
        }
    }
}
