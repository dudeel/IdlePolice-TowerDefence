using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardsNotFoundList : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;

    private void Awake()
    {
        Card card = new();
        GlobalCardsList cardsList = new();
        CardInfo[] _uiCard = new CardInfo[cardsList.Cards.Length];
        
        for (int i = 0; i < cardsList.Cards.Length; i++)
        {
            _uiCard[i] = cardsList.Cards[i];
        }

        for (int i = 0; i < card.CardHave.Count; i++)
        {
            _uiCard[card.CardHave[i].ID - 1] = null;
        }

        for (int i = 0; i < _uiCard.Length; i++)
        {
            if (_uiCard[i] == null) continue;

            GameObject b = Instantiate(_cardObject, transform);

            b.GetComponent<UI_Card>().CharacterInfo = _uiCard[i];
            b.GetComponent<UI_Card>()._globalCardType = transform.GetComponent<GlobalAttackType>();
            b.GetComponent<UI_Card>()._globalRarity = transform.GetComponent<GlobalRarity>();
            b.GetComponent<UI_Card>().LoadData();
        }
    }
}
