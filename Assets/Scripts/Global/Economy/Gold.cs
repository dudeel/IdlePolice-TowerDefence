using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Gold : SaveLoad
{
    private const int MAX_AMOUNT = 5000000;
    private readonly string KEY = "/Economy";

    private int Amount;
    public UnityEngine.Events.UnityAction OnChanged;

	protected override void LoadData(string key)
	{
		string path = BuildPath(key);
		
		if (!File.Exists(path))
		{ CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

		//load
		PlayerData data = (PlayerData)formatter.Deserialize(file);
		file.Close();

        Amount = data.Golds;
	}

    public void Add(int value)
    {
        if (Amount + Mathf.Abs(value) <= MAX_AMOUNT)
            Amount += Mathf.Abs(value);
        else Amount = MAX_AMOUNT;

        OnChanged?.Invoke();
    }

    public void Take(int value)
    {
        if (Amount >= Mathf.Abs(value))
            Amount -= Mathf.Abs(value);
        else Amount = 0;

        OnChanged?.Invoke();        
    }

    public void Set(int value)
    {
        Amount = Mathf.Abs(value);
        OnChanged?.Invoke();        
    }

    public int Count()
    {
        LoadData(KEY);
        return Amount;
    }
}
