using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class Card
{
    public readonly string KEY = "/Card.dat";
    private readonly GlobalCardsList _globalCardsList = new();

    public readonly List<CardInfo> CardSelected = new();
    public readonly List<CardInfo> CardHave = new();

    private readonly CardSerialize _cardSerialize = new();

    private CardData _amount = new();

    public Card()
    {
        LoadData();
    }

    private void LoadData()
    {
        _amount = _cardSerialize.LoadData(KEY);

        LoadSelections();
        LoadHaves();
    }

    private void LoadSelections()
    {
        for (int i = 0; i < _amount.Selecteds.Count; i++)
        {
            CardSelected.Add(_globalCardsList.Cards[_amount.Selecteds[i].ID - 1]);
        }
    }

    private void LoadHaves()
    {
        for (int i = 0; i < _amount.Haves.Count; i++)
        {
            CardHave.Add(_globalCardsList.Cards[_amount.Haves[i].ID - 1]);
        }
    }
    
    public void Set(int value)
    {
        _cardSerialize.SaveData(KEY, _amount);
    }
}

[System.Serializable]
public class Selected
{ public int ID; };

[System.Serializable]
public class Have
{
    public int ID;
    public int Level;
    public int Amount;
};

[System.Serializable]
public class CardData
{
    public List<Selected> Selecteds = new();
    public List<Have> Haves = new();
}

public class CardSerialize : SaveLoadAbstract
{    
    private string _path;

	protected override void CreateFile(string key)
	{
		_path = Application.persistentDataPath + key;

		FileStream file = File.Create(_path);

		CardData data = new();
        
        data.Selecteds.Add(_ = new Selected() { ID = 1 });
        data.Selecteds.Add(_ = new Selected() { ID = 8 });
        data.Selecteds.Add(_ = new Selected() { ID = 2 });
        data.Selecteds.Add(_ = new Selected() { ID = 9 });

        data.Haves.Add(_ = new Have() { ID = 1, Level = 1, Amount = 0 });
        data.Haves.Add(_ = new Have() { ID = 2, Level = 1, Amount = 1 });
        data.Haves.Add(_ = new Have() { ID = 8, Level = 1, Amount = 42 });
        data.Haves.Add(_ = new Have() { ID = 9, Level = 1, Amount = 2 });

		BinaryFormatter formatter = new(); 
        formatter.Serialize(file, data);

		file.Close();
	}
	
	public override void SaveData<CardData>(string key, CardData data)
	{
		_path = Application.persistentDataPath + key;

		if (!File.Exists(_path))
		{ CreateFile(key); }
		
    	FileStream _file = File.Open(_path, FileMode.Open);

		BinaryFormatter _formatter = new(); 
        _formatter.Serialize(_file, data);
		
		_file.Close();
	}

	public CardData LoadData(string key)
	{
		_path = Application.persistentDataPath + key;

		if (!File.Exists(_path))
		{ CreateFile(key); }
		
    	FileStream file = File.Open(_path, FileMode.Open);

		BinaryFormatter _formatter = new(); 
		CardData data = (CardData)_formatter.Deserialize(file);

		file.Close();

        return data;
	}
}
