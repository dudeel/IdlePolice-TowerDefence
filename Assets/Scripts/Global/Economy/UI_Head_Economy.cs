using UnityEngine;
using TMPro;

public class UI_Head_Economy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldsText;
    [SerializeField] private TextMeshProUGUI _gemsText;

    private void Awake() 
    {
        UpdateText();
    }

    private void UpdateText()
    {
        PlayerData test = new()
        {
            Golds = 5,
            Gems = 12
        };

        //SaveLoad saveLoad = new();
        //saveLoad.SaveData("/PlayerDataEconomy", test);
        //var data = saveLoad.LoadData("/PlayerDataEconomy");

        //_goldsText.text = data.Golds.ToString();
        //_gemsText.text = data.Gems.ToString();
    }
}
