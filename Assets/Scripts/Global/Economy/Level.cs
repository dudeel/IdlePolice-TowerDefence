using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Level
{
    public readonly static string KEY = "/Level.dat";
    private readonly LevelSerialize _levelSerialize = new();

    public void Set(LevelData data)
    {
        _levelSerialize.SaveData(KEY, data);
    }

    public LevelData Get()
    {
        return _levelSerialize.LoadData(KEY);
    }
}


[System.Serializable]
public class LevelData
{
    public int Level;
    public int Exp;
}

public class LevelSerialize : SaveLoadAbstract
{
    private string _path;

	protected override void CreateFile(string key)
	{
		_path = UnityEngine.Application.persistentDataPath + key;

		FileStream file = File.Create(_path);
		
		LevelData data = new()
		{
			Level = 1,
			Exp = 0
		};

		BinaryFormatter formatter = new(); 
        formatter.Serialize(file, data);

		file.Close();
	}
	
	public override void SaveData(string key, object data)
	{
		_path = UnityEngine.Application.persistentDataPath + key;

		if (!File.Exists(_path))
		{ CreateFile(key); }
		
    	FileStream _file = File.Open(_path, FileMode.Open);

		BinaryFormatter _formatter = new(); 
        _formatter.Serialize(_file, data);
		
		_file.Close();
	}

	public LevelData LoadData(string key)
	{
		_path = UnityEngine.Application.persistentDataPath + key;

		if (!File.Exists(_path))
		{ CreateFile(key); }
		
    	FileStream _file = File.Open(_path, FileMode.Open);

		BinaryFormatter _formatter = new(); 
		LevelData data = (LevelData)_formatter.Deserialize(_file);

		_file.Close();

        return data;
	}
}
