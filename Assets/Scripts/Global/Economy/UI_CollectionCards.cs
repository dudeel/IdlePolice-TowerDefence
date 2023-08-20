using System.Collections.Generic;
using UnityEngine;

public class UI_CollectionCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;
    private List<CardHandler.CardFormattedData> _collected;

    [SerializeField] private UI_CardPopUp _popUpUI;
    private void Start()
    {
        _collected = CardHandler.Get().collected;

        foreach (var item in _collected)
        {
            var card = Instantiate(_cardObject, transform);

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
