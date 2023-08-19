using System.Collections.Generic;
using UnityEngine;

public class UI_NotFoundCards : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;
    private List<CardHandler.CardFormattedData> _notFount;

    [SerializeField] private UI_CardPopUp _popUpUI;
    private void Start()
    {
        _notFount = CardHandler.Get().notFound;

        foreach (var item in _notFount)
        {
            var card = Instantiate(_cardObject, transform);

            UI_Card cardUI = card.GetComponent<UI_Card>();

            cardUI.CardFormattedData = item;
            cardUI.PopUp = _popUpUI;

            cardUI.CharacterInfo = item.cardInfo;
            cardUI.GlobalCardType = transform.GetComponent<GlobalAttackType>();
            cardUI.GlobalRarity = transform.GetComponent<GlobalRarity>();
            cardUI.LoadData();

            card.transform.GetChild(3).gameObject.SetActive(false);
            card.transform.GetChild(6).gameObject.SetActive(true);
        }
    }
}
