using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class SaveLoad
{	
	protected void CreateFile(string key)
	{
		string path = BuildPath(key);

		FileStream file = File.Create(path);
		
		BinaryFormatter formatter = new(); 
        formatter.Serialize(file, 0);

		file.Close();
	}
	
    protected string BuildPath(string key)
    {
        return Application.persistentDataPath + key;
    }

	protected virtual void SaveData(string key, object data)
	{
		string path = BuildPath(key);
		
		if (!File.Exists(path))
		{ CreateFile(key); }

		BinaryFormatter formatter = new(); 
        FileStream file = File.Open(path, FileMode.Open);

		//save
        formatter.Serialize(file, data);
		file.Close();
	}

	protected virtual void LoadData(string key) {}
}
