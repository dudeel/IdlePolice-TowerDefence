using UnityEngine;

public class UI_CardsCollectionList : MonoBehaviour
{
    [SerializeField] private GameObject _cardObject;

    private void Awake()
    {
        Card card = new();
        
        for (int i = 0; i < card.CardHave.Count; i++)
        {
            GameObject b = Instantiate(_cardObject, transform);
            b.GetComponent<UI_Card>().CharacterInfo = card.CardHave[i];
            b.GetComponent<UI_Card>()._globalCardType = transform.GetComponent<GlobalAttackType>();
            b.GetComponent<UI_Card>()._globalRarity = transform.GetComponent<GlobalRarity>();
            b.GetComponent<UI_Card>().LoadData();

            b.GetComponent<UI_CardLevel>().isHave = true;
            b.GetComponent<UI_CardLevel>().Data = card.Amount.Haves[i];
        }
    }
}
