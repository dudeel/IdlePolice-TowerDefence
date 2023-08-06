using UnityEngine;
using System.Collections.Generic;

public class PlayerDataEconomy : MonoBehaviour
{
    private const string key = "test_save_key";
    private IStorageService storageService;
    private StorageItem e;

    private void Start()
    {
        storageService = new JsonToFileStorageService();
        e = new StorageItem();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            e.StringParameter = "example";

            e.DictionaryParameter = new Dictionary<int, int>();
            e.DictionaryParameter.Add(1, 421);
            e.DictionaryParameter.Add(2, 6456546);
            e.DictionaryParameter.Add(3, Random.Range(0,14242));

            storageService.Save(key, e);

            Debug.Log("data save");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            storageService.Load<StorageItem>(key, e=>
            {
                Debug.Log($"Loaded. string: {e.StringParameter}, dictionart[0]: {e.DictionaryParameter[3]}");
            });
        }
    }
}

public class StorageItem
{
    public string StringParameter {get; set;}
    public Dictionary<int, int> DictionaryParameter {get; set;}
}
