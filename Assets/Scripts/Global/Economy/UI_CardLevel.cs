using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardLevel : MonoBehaviour
{
    private const int MAX_LEVEL = 40;
    private const int AMOUNT_MULTIPLY = 2;
    private const int START_EXP_ENOUGHT = 40;

    [Header("Level Data (Object)")]
    [SerializeField] private Image _levelIcon;
    [SerializeField] private TextMeshProUGUI _levelText;

    [Header("Exp Data (Object)")]
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _barIcon;
    [SerializeField] private TextMeshProUGUI _expText;

    [Header("Level Sprite")]
    [SerializeField] private Sprite _normalIcon;
    [SerializeField] private Sprite _maxIcon;

    [Header("Exp Sprite")]
    [SerializeField] private Sprite _normalBar;
    [SerializeField] private Sprite _maxBar;

    public bool isHave = false;
    public Collect Data = new();
    private int _enoughtAmount;

    void Start()
    {
        SetData();
    }

    private void SetData()
    {
        if (Data.Level <= 1) _enoughtAmount = START_EXP_ENOUGHT;

        if (Data.Level >= MAX_LEVEL)
        {
            _levelIcon.sprite = _maxIcon;

            _barIcon.sprite = _maxBar;
            _progressBar.fillAmount = 1;

            _levelText.text = MAX_LEVEL.ToString();
            _expText.text = "MAX";
        }
        else
        {
            _levelIcon.sprite = _normalIcon;
            _barIcon.sprite = _normalBar;

            _enoughtAmount = Data.Level * AMOUNT_MULTIPLY;

            UpdateLevelText();
        }

    }

    private void UpdateLevelText()
    {
        _levelText.SetText(Data.Level.ToString());
        _expText.SetText($"{Data.Exp}/{_enoughtAmount}");

        SetProgressFill();
    }

    private void SetProgressFill()
    {
        _progressBar.fillAmount = Mathf.InverseLerp(0f, _enoughtAmount, Data.Exp);
    }
}
