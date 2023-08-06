using System.Collections.Generic;
using UnityEngine;

public class PlayerDataCards : MonoBehaviour
{
    [SerializeField] private List<GameObject> _selectCards = new();
    [SerializeField] private List<GameObject> _collectionCards = new();

    private void Start()
    {
        Debug.Log(_selectCards.Count);
        Debug.Log(_collectionCards.Count);
    }
}

class SelectCard
{
    public int ID = 0;
}

class CollectionCards
{
    public int ID = 0;
    public int Level = 0;
    public int Amount = 0;
}
