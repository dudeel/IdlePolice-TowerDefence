using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Level
{
    private const int MAX_LEVEL = 150;
    public readonly string KEY = "/Level";

    private int _level;
    private int _exp;

    private readonly LevelSerialize _levelSerialize = new();

    public void SetLevel(int value)
    {
        _level = Mathf.Abs(value);
        _exp = 0;

        _levelSerialize.SaveData(KEY, _level);
    }

    public int GetLevel()
    {
        return _levelSerialize.LoadData(KEY).Level;
    }

    public int GetExp()
    {
        return _levelSerialize.LoadData(KEY).Exp;
    }
}

public class LevelData
{
    public int Level;
    public int Exp;
}

public class LevelSerialize : SaveLoadAbstract
{    
	public override void SaveData(string key, int data)
	{
		string path = GetPath(key);
		
		if (!File.Exists(path))
		{ CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

        LevelData _levelData = new()
        {
            Level = data,
            Exp = data
        };

        //save
        formatter.Serialize(file, _levelData);
		file.Close();
	}

	public LevelData LoadData(string key)
	{
		string path = GetPath(key);
		
		if (!File.Exists(path))
		{  CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

		//load
		LevelData data = (LevelData)formatter.Deserialize(file);
		file.Close();

        return data;
	}
}
