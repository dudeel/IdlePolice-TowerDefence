using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Curency
{
    private const int MAX_AMOUNT = 5000000;
    public readonly string KEY = "/Curency.dat";

    public enum CurencyType
    {
        Gold = 0,
        Gem = 1,
    }

    private readonly CurencyData Amount;
    private readonly CurencySerialize _curencySerialize = new();

    public void Add(int value, CurencyType type)
    {
        switch (type)
        {
            case CurencyType.Gold:
                if (Amount.Gold + Mathf.Abs(value) <= MAX_AMOUNT)
                    Amount.Gold += Mathf.Abs(value);
                else Amount.Gold = MAX_AMOUNT;
                break;

            case CurencyType.Gem:
                if (Amount.Gem + Mathf.Abs(value) <= MAX_AMOUNT)
                    Amount.Gem += Mathf.Abs(value);
                else Amount.Gem = MAX_AMOUNT;
                break;

            default:
                break;
        }

        _curencySerialize.SaveData(KEY, Amount);
    }

    public void Take(int value, CurencyType type)
    {
        switch (type)
        {
            case CurencyType.Gold:
                if (Amount.Gold >= Mathf.Abs(value))
                    Amount.Gold -= Mathf.Abs(value);
                else Amount.Gold = 0;
                break;

            case CurencyType.Gem:
                if (Amount.Gem >= Mathf.Abs(value))
                    Amount.Gem -= Mathf.Abs(value);
                else Amount.Gem = 0;
                break;

            default:
                break;
        }

        _curencySerialize.SaveData(KEY, Amount);
    }

    public void Set(int value, CurencyType type)
    {
        switch (type)
        {
            case CurencyType.Gold:
                Amount.Gold = Mathf.Abs(value);
                break;

            case CurencyType.Gem:
                Amount.Gem = Mathf.Abs(value);
                break;

            default:
                break;
        }

        _curencySerialize.SaveData(KEY, Amount);
    }

    public CurencyData Count()
    {
        return _curencySerialize.LoadData(KEY);
    }
}

[System.Serializable]
public class CurencyData
{
    public int Gold;
    public int Gem;
}

public class CurencySerialize : SaveLoadAbstract
{
    private string _path;

    protected override void CreateFile(string key)
    {
        _path = Application.persistentDataPath + key;

        FileStream file = File.Create(_path);

        CurencyData data = new()
        {
            Gold = 4300,
            Gem = 10
        };

        BinaryFormatter formatter = new();
        formatter.Serialize(file, data);

        file.Close();
    }

    public override void SaveData<CurencyData>(string key, CurencyData data)
    {
        _path = Application.persistentDataPath + key;

        if (!File.Exists(_path))
        { CreateFile(key); }

        FileStream _file = File.Open(_path, FileMode.Open);

        BinaryFormatter _formatter = new();
        _formatter.Serialize(_file, data);

        _file.Close();
    }

    public CurencyData LoadData(string key)
    {
        _path = Application.persistentDataPath + key;

        if (!File.Exists(_path))
        { CreateFile(key); }

        FileStream _file = File.Open(_path, FileMode.Open);

        BinaryFormatter _formatter = new();
        CurencyData data = (CurencyData)_formatter.Deserialize(_file);

        _file.Close();

        return data;
    }
}
