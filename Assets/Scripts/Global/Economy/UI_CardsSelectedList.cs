using UnityEngine;
using System.Collections.Generic;

public class UI_CardsSelectedList : MonoBehaviour
{
    [Header("SelectedCards")]
    [SerializeField] private List<UI_Card> _selectedCards = new();

    private void Awake()
    {
        Card card = new();

        for (int i = 0; i <_selectedCards.Count; i++)
        {
            _selectedCards[i].CharacterInfo = card.CardSelected[i];
            _selectedCards[i]._globalCardType = transform.GetComponent<GlobalAttackType>();
            _selectedCards[i]._globalRarity = transform.GetComponent<GlobalRarity>();
            _selectedCards[i].LoadData();

            _selectedCards[i].GetComponent<UI_CardLevel>().isHave = true;
            _selectedCards[i].GetComponent<UI_CardLevel>().Data = card.Amount.Haves[i];
        }
    }
}
