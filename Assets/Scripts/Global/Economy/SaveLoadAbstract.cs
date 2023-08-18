using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class SaveLoadAbstract
{
	public virtual void SaveData<T>(string key, T _data) { }
	public virtual T LoadData<T>(string key) { return default; }

	protected virtual void CreateFile(string key)
	{
		string path = GetPath(key);

		FileStream file = File.Create(path);

		BinaryFormatter formatter = new();
		formatter.Serialize(file, 0);

		file.Close();
	}

	protected string GetPath(string key)
	{
		return Application.persistentDataPath + key;
	}
}
