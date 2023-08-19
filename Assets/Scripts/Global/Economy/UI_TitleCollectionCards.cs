using UnityEngine;
using TMPro;

public class UI_TitleCollectionCards : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    void Start()
    {
        _text.text = $"Found {CardHandler.Get().collected.Count} / {CardHandler.Get().all.Length}";
    }
}
