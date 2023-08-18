using UnityEngine;

public class GlobalCardsList
{
    public CardInfo[] Cards { get; private set; }

    public GlobalCardsList()
    {
        Cards = Resources.LoadAll<CardInfo>("Cards");
    }
}
