using System.Collections;
using System.Collections.Generic;

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
        public CardFormattedData[] collected;
        public CardFormattedData[] notFound;
    }

    public static CardContainer cardContainer;

    public static void LoadData()
    {
        GlobalCardsList globalCardsList = new();
        Card card = new();
        
        cardContainer = new()
        {
            all = new CardFormattedData[globalCardsList.Cards.Length],
            selected = new CardFormattedData[4],
            collected = new CardFormattedData[globalCardsList.Cards.Length],
            notFound = new CardFormattedData[globalCardsList.Cards.Length]
        };

        UnityEngine.Debug.Log("globalCardsList: " + globalCardsList.Cards.Length);
        UnityEngine.Debug.Log("Selecteds: " + card.Amount.Selecteds.Length);
        UnityEngine.Debug.Log("Collecteds: " + card.Amount.Collecteds.Count);
        
        UnityEngine.Debug.Log("--------------------------------------------");

        CardFormattedLevel cardFormattedLevel;
        CardFormattedData cardFormattedData;

        for (int i = 0; i < globalCardsList.Cards.Length; i++)
        {
            //Если такой карты нет в коллекции игрока            
            cardFormattedData = new()
            {
                cardInfo = globalCardsList.Cards[i],
                levelData = null,
                cardStatus = CardStatus.NotFound
            };
            cardContainer.all[i] = cardFormattedData;

            // Если такая карта есть в коллекции игрока
            for (int j = 0; j < card.Amount.Collecteds.Count; j++)
            {
                if (globalCardsList.Cards[i].ID == card.Amount.Collecteds[j].ID)
                {
                    cardFormattedLevel = new()
                    {
                        Level = card.Amount.Collecteds[j].Level,
                        Exp = card.Amount.Collecteds[j].Exp,
                        EnoughtExp = card.Amount.Collecteds[j].Level * 2
                    };

                    cardFormattedData = new()
                    {
                        cardInfo = globalCardsList.Cards[i],
                        levelData = cardFormattedLevel,
                        cardStatus = CardStatus.Collect
                    };

                    cardContainer.all[i] = cardFormattedData;
                }
            }

            // Если такая карта выбрана игроком
            for (int j = 0; j < card.Amount.Selecteds.Length; j++)
            {
                if (globalCardsList.Cards[i].ID == card.Amount.Selecteds[j].ID)
                {
                    cardFormattedLevel = new()
                    {
                        Level = card.Amount.Collecteds[j].Level,
                        Exp = card.Amount.Collecteds[j].Exp,
                        EnoughtExp = card.Amount.Collecteds[j].Level * 2
                    };

                    cardFormattedData = new()
                    {
                        cardInfo = globalCardsList.Cards[i],
                        levelData = cardFormattedLevel,
                        cardStatus = CardStatus.Select
                    };

                    cardContainer.all[i] = cardFormattedData;
                }
            }
        }

        UnityEngine.Debug.Log("--------------------------------------------");
        for (int i = 0; i < cardContainer.all.Length; i++)
            if (cardContainer.all[i] != null)
                UnityEngine.Debug.Log(i + ": " + cardContainer.all[i].cardStatus);
    }

    // public static CardContainer Get()
    // {
    //     return null;
    // }
}
