using UnityEngine;
using TMPro;

public class UI_CardsCollectionTitle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textAmount;

    private void Awake()
    {
        GlobalCardsList globalCardsList = new();
        Card card = new();

        SetTextAmount(card.CardHave.Count, globalCardsList.Cards.Length);
    }

    private void SetTextAmount(int current, int max)
    {
        _textAmount.text = $"Found {current}/{max}";
    }
}
