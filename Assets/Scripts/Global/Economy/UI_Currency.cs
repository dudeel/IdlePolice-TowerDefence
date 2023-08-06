using UnityEngine;
using TMPro;

public class UI_Currency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldsText;
    [SerializeField] private TextMeshProUGUI _gemsText;

    readonly Gold _gold = new();
    readonly Gem _gem = new();

    private void Awake() 
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _goldsText.text = _gold.Count().ToString();
        _gemsText.text = _gem.Count().ToString();
    }
}
