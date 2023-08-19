using UnityEngine;
using TMPro;

public class UI_Currency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldsText;
    [SerializeField] private TextMeshProUGUI _gemsText;


    readonly Curency _curencySerialize = new();
    private readonly CurencyData _data = new();

    private void Awake()
    {
        SetData();
        UpdateText();

        CardHandler.LoadData();
    }

    private void SetData()
    {
        _data.Gold = _curencySerialize.Count().Gold;
        _data.Gem = _curencySerialize.Count().Gem;
    }


    private void UpdateText()
    {
        _goldsText.text = _data.Gold.ToString();
        _gemsText.text = _data.Gem.ToString();
    }
}
