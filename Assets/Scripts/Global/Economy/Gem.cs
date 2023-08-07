using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Gem
{
    private const int MAX_AMOUNT = 500000;
    public readonly string KEY = "/Gem";

    private int Amount;

    private readonly GemSerialize _gemSerialize = new();

    public void Add(int value)
    {
        if (Amount + Mathf.Abs(value) <= MAX_AMOUNT)
            Amount += Mathf.Abs(value);
        else Amount = MAX_AMOUNT;

        _gemSerialize.SaveData(KEY, Amount);
    }

    public void Take(int value)
    {
        if (Amount >= Mathf.Abs(value))
            Amount -= Mathf.Abs(value);
        else Amount = 0;

        _gemSerialize.SaveData(KEY, Amount);   
    }

    public void Set(int value)
    {
        Amount = Mathf.Abs(value);

        _gemSerialize.SaveData(KEY, Amount);
    }

    public int Count()
    {
        return _gemSerialize.LoadData(KEY);
    }
}

public class GemSerialize : SaveLoadAbstract
{    
	public override void SaveData(string key, object data)
	{
		string path = GetPath(key);
		
		if (!File.Exists(path))
		{ CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

        //save
        formatter.Serialize(file, data);
		file.Close();
	}

	public int LoadData(string key)
	{
		string path = GetPath(key);
		
		if (!File.Exists(path))
		{  CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

		//load
		int data = (int)formatter.Deserialize(file);
		file.Close();

        return data;
	}
}
