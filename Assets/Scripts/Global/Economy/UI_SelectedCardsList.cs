using UnityEngine;
using System.Collections.Generic;

public class UI_SelectedCardsList : MonoBehaviour
{
    [Header("SelectedCards")]
    [SerializeField] private List<UI_Card> _selectedCards = new();

    private void Awake()
    {
        Card card = new();

        for (int i = 0; i <_selectedCards.Count; i++)
        {
            _selectedCards[i].CharacterInfo = card.CardSelected[i];
            _selectedCards[i].LoadData();
        }
    }
}
