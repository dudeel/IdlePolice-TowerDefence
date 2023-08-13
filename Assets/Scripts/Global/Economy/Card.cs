using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class Card
{
    public readonly string KEY = "/Card.dat";
    private readonly GlobalCardsList _globalCardsList = new();

    private readonly CardSerialize _cardSerialize = new();

    public CardData Amount = new();

    public Card()
    {
        LoadData();
    }

    private void LoadData()
    {
        Amount = _cardSerialize.LoadData(KEY);
    }

    // public void Set(int value)
    // {
    //     _cardSerialize.SaveData(KEY, Amount);
    // }
}

[System.Serializable]
public class Selected
{ public int ID; };

[System.Serializable]
public class Collect
{
    public int ID;
    public int Level;
    public int Exp;
};

[System.Serializable]
public class CardData
{
    public Selected[] Selecteds = new Selected[4];
    public List<Collect> Collecteds = new();
}
public class CardSerialize : SaveLoadAbstract
{    
    private string _path;

	protected override void CreateFile(string key)
	{
		_path = Application.persistentDataPath + key;

		FileStream file = File.Create(_path);

		CardData data = new();
        
        data.Selecteds[0] = new Selected() { ID = 0 };
        data.Selecteds[1] = new Selected() { ID = 1 };
        data.Selecteds[2] = new Selected() { ID = 7 };
        data.Selecteds[3] = new Selected() { ID = 8 };

        data.Collecteds.Add(_ = new Collect() { ID = 0, Level = 1, Exp = 0 });
        data.Collecteds.Add(_ = new Collect() { ID = 1, Level = 40, Exp = 1 });
        data.Collecteds.Add(_ = new Collect() { ID = 7, Level = 32, Exp = 42 });
        data.Collecteds.Add(_ = new Collect() { ID = 8, Level = 3, Exp = 2 });
        data.Collecteds.Add(_ = new Collect() { ID = 13, Level = 1, Exp = 4 });
        data.Collecteds.Add(_ = new Collect() { ID = 16, Level = 3, Exp = 21 });
        data.Collecteds.Add(_ = new Collect() { ID = 23, Level = 2, Exp = 5 });

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
