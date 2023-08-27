using System.Collections.Generic;
using UnityEngine;

public class UI_SelectedCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;
    private CardHandler.CardFormattedData[] _selected = new CardHandler.CardFormattedData[4];
    public List<GameObject> SelectedCardObjectList;

    [SerializeField] private UI_CardPopUp _popUpUI;
    private void Start()
    {
        _selected = CardHandler.Get().selected;

        foreach (var item in _selected)
        {
            GameObject card = Instantiate(_cardObject, transform);
            SelectedCardObjectList.Add(card);

            UI_Card cardUI = card.GetComponent<UI_Card>();
            UI_CardLevel cardUILevel = card.GetComponent<UI_CardLevel>();

            cardUI.CardFormattedData = item;
            cardUI.PopUp = _popUpUI;

            cardUI.CharacterInfo = item.cardInfo;
            cardUI.GlobalCardType = transform.GetComponent<GlobalAttackType>();
            cardUI.GlobalRarity = transform.GetComponent<GlobalRarity>();
            cardUI.LoadData();

            cardUILevel.GlobalRarity = transform.GetComponent<GlobalRarity>();
            cardUILevel.Data = item;
        }
    }
}
