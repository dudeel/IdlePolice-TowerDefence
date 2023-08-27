using UnityEngine;
using TMPro;

public class UI_Currency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldsText;
    [SerializeField] private TextMeshProUGUI _gemsText;

    private readonly CurencyData _data = new();

    private void Awake()
    {
        SetData();
        UpdateText();

        CardHandler.LoadData();
    }

    private void SetData()
    {
        _data.Gold = Curency.Count().Gold;
        _data.Gem = Curency.Count().Gem;
    }


    private void UpdateText()
    {
        _goldsText.text = _data.Gold.ToString();
        _gemsText.text = _data.Gem.ToString();
    }
}
