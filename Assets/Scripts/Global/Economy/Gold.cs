using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Gold
{
    private const int MAX_AMOUNT = 5000000;
    public readonly string KEY = "/Gold";

    private int Amount;

    private readonly GoldSerialize _goldSerialize = new();

    public void Add(int value)
    {
        if (Amount + Mathf.Abs(value) <= MAX_AMOUNT)
            Amount += Mathf.Abs(value);
        else Amount = MAX_AMOUNT;

        _goldSerialize.SaveData(KEY, Amount);
    }

    public void Take(int value)
    {
        if (Amount >= Mathf.Abs(value))
            Amount -= Mathf.Abs(value);
        else Amount = 0;

        _goldSerialize.SaveData(KEY, Amount);   
    }

    public void Set(int value)
    {
        Amount = Mathf.Abs(value);

        _goldSerialize.SaveData(KEY, Amount);
    }

    public int Count()
    {
        return _goldSerialize.LoadData(KEY);
    }
}

public class GoldSerialize : SaveLoadAbstract
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
