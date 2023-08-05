using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonToFileStorageService : IStorageService
{
    void IStorageService.Save(string key, object data, Action<bool> callback)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }

        callback?.Invoke(true);
    }

    void IStorageService.Load<T>(string key, Action<T> callback)
    {
        string path = BuildPath(key);

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            
            callback?.Invoke(data);
        }
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
