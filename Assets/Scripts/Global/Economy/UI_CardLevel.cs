using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardLevel : MonoBehaviour
{
    private const int MAX_LEVEL = 40;

    [Header("Level Data (Object)")]
    [SerializeField] private Image _levelIcon;
    [SerializeField] private TextMeshProUGUI _levelText;

    [Header("Exp Data (Object)")]
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _barIcon;
    [SerializeField] private TextMeshProUGUI _expText;

    [Header("Level Sprite")]
    [SerializeField] private Sprite _normalIcon;
    [SerializeField] private Sprite _compliteIcon;
    [SerializeField] private Sprite _maxIcon;

    [Header("Exp Sprite")]
    [SerializeField] private Sprite _normalBar;
    [SerializeField] private Sprite _compliteBar;
    [SerializeField] private Sprite _maxBar;

    public bool isHave = false;
    public CardHandler.CardFormattedLevel Data = new();

    void Start()
    {
        SetData();
    }

    private void SetData()
    {
        if (Data.Level >= MAX_LEVEL)
        {
            _levelIcon.sprite = _maxIcon;

            _barIcon.sprite = _maxBar;
            _progressBar.fillAmount = 1;

            _levelText.text = MAX_LEVEL.ToString();
            _expText.text = "MAX";
        }
        else if (Data.Exp >= Data.EnoughtExp)
        {
            _levelIcon.sprite = _compliteIcon;
            _barIcon.sprite = _compliteBar;

            Data.EnoughtExp = Data.Level * 2;

            UpdateLevelText();
        }
        else
        {
            _levelIcon.sprite = _normalIcon;
            _barIcon.sprite = _normalBar;

            Data.EnoughtExp = Data.Level * 2;

            UpdateLevelText();
        }
    }

    private void UpdateLevelText()
    {
        _levelText.SetText(Data.Level.ToString());
        _expText.SetText($"{Data.Exp}/{Data.EnoughtExp}");

        SetProgressFill();
    }

    private void SetProgressFill()
    {
        _progressBar.fillAmount = Mathf.InverseLerp(0f, Data.EnoughtExp, Data.Exp);
    }
}
