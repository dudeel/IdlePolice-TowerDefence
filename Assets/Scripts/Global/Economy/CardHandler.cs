public static class CardHandler
{
    public enum CardStatus
    {
        Select = 0, // Выбрано
        Collect = 1, // Найдено
        NotFound = 2 // Не найдено
    }

    public class CardFormattedLevel
    {
        public int Level;
        public int Exp;
        public int EnoughtExp;
    }

    public class CardFormattedData
    {
        public CardInfo cardInfo;
        public CardFormattedLevel levelData;
        public CardStatus cardStatus;
    }

    public class CardContainer
    {
        public CardFormattedData[] all;
        public CardFormattedData[] selected;
        public System.Collections.Generic.List<CardFormattedData> collected;
        public System.Collections.Generic.List<CardFormattedData> notFound;
    }

    private static CardContainer _cardContainer;
    private static readonly Card _card = new();
    private static readonly GlobalCardsList _globalCardsList = new();
    private static CardFormattedLevel cardFormattedLevel;
    private static CardFormattedData cardFormattedData;

    public static void LoadData()
    {
        _cardContainer = new()
        {
            all = new CardFormattedData[_globalCardsList.Cards.Length],
            selected = new CardFormattedData[4],
            collected = new(),
            notFound = new()
        };

        for (int i = 0; i < _globalCardsList.Cards.Length; i++)
        {
            //Если такой карты нет в коллекции игрока            
            cardFormattedData = new()
            {
                cardInfo = _globalCardsList.Cards[i],
                levelData = null,
                cardStatus = CardStatus.NotFound
            };
            _cardContainer.all[i] = cardFormattedData;
            _cardContainer.notFound.Add(cardFormattedData);

            // Если такая карта есть в коллекции игрока
            for (int j = 0; j < _card.Amount.Collecteds.Count; j++)
            {
                if (_globalCardsList.Cards[i].ID == _card.Amount.Collecteds[j].ID)
                {
                    _cardContainer.notFound.Remove(cardFormattedData);

                    cardFormattedLevel = new()
                    {
                        Level = _card.Amount.Collecteds[j].Level,
                        Exp = _card.Amount.Collecteds[j].Exp,
                        EnoughtExp = _card.Amount.Collecteds[j].Level * 2
                    };

                    cardFormattedData = new()
                    {
                        cardInfo = _globalCardsList.Cards[i],
                        levelData = cardFormattedLevel,
                        cardStatus = CardStatus.Collect
                    };

                    _cardContainer.all[i] = cardFormattedData;
                    _cardContainer.collected.Add(cardFormattedData);
                }
            }

            // Если такая карта выбрана игроком
            for (int j = 0; j < _card.Amount.Selecteds.Length; j++)
            {
                if (_globalCardsList.Cards[i].ID == _card.Amount.Selecteds[j].ID)
                {
                    cardFormattedLevel = new()
                    {
                        Level = _card.Amount.Collecteds[j].Level,
                        Exp = _card.Amount.Collecteds[j].Exp,
                        EnoughtExp = _card.Amount.Collecteds[j].Level * 2
                    };

                    cardFormattedData = new()
                    {
                        cardInfo = _globalCardsList.Cards[i],
                        levelData = cardFormattedLevel,
                        cardStatus = CardStatus.Select
                    };

                    _cardContainer.all[i] = cardFormattedData;
                }
            }
        }
    }

    public static void AddExp(int ID, int amount)
    {
        _cardContainer.collected[ID].levelData.Exp += amount;
    }

    public static void AddCard(int ID, int amount)
    {
        cardFormattedLevel = new()
        {
            Level = 1,
            Exp = amount,
            EnoughtExp = _card.Amount.Collecteds[ID].Level * 2
        };

        cardFormattedData = new()
        {
            cardInfo = _globalCardsList.Cards[ID],
            levelData = cardFormattedLevel,
            cardStatus = CardStatus.Collect
        };

        _cardContainer.collected.Add(cardFormattedData);

        for (int i = 0; i < _cardContainer.notFound.Count; i++)
        {
            if (_cardContainer.notFound[i].cardInfo.ID == cardFormattedData.cardInfo.ID)
            {
                _cardContainer.notFound.RemoveAt(i);
            }
        }
    }

    public static CardContainer Get()
    {
        return _cardContainer;
    }

    public static void Save()
    {
        CardData cardData = new();

        for (int i = 0; i < _cardContainer.selected.Length; i++)
        {
            cardData.Selecteds[i] = new Selected() { ID = _cardContainer.selected[i].cardInfo.ID };
        }

        for (int i = 0; i < _cardContainer.collected.Count; i++)
        {
            cardData.Collecteds.Add(_ = new Collect() 
            {
                ID = _cardContainer.collected[i].cardInfo.ID,
                Level = _cardContainer.collected[i].levelData.Level,
                Exp = _cardContainer.collected[i].levelData.Exp
            });
        }

        _card.Amount = cardData;
        _card.Save();
    }
}