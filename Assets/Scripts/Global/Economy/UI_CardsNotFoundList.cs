using UnityEngine;

public class UI_CardsNotFoundList : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;
    private CardInfo[] _uiCard;

    private void Awake()
    {
        LoadData();
        ShowCards();
    }

    private void LoadData()
    {
        Card card = new();
        GlobalCardsList cardsList = new();
        
        _uiCard = new CardInfo[cardsList.Cards.Length];
        
        for (int i = 0; i < cardsList.Cards.Length; i++)
        {
            _uiCard[i] = cardsList.Cards[i];
        }

        for (int i = 0; i < card.CardHave.Count; i++)
        {
            _uiCard[card.CardHave[i].ID - 1] = null;
        }
    }

    private void ShowCards()
    {
        for (int i = 0; i < _uiCard.Length; i++)
        {
            if (_uiCard[i] == null) continue;

            GameObject b = Instantiate(_cardObject, transform);

            b.GetComponent<UI_Card>().CharacterInfo = _uiCard[i];
            b.GetComponent<UI_Card>()._globalCardType = transform.GetComponent<GlobalAttackType>();
            b.GetComponent<UI_Card>()._globalRarity = transform.GetComponent<GlobalRarity>();
            
            b.transform.GetChild(3).gameObject.SetActive(false);
            b.transform.GetChild(6).gameObject.SetActive(true);
            b.GetComponent<UI_Card>().LoadData();
        }
    }
}
