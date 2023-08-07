using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Level : MonoBehaviour
{
    private const int MAX_LEVEL = 150;
    private const float EXP_MULTIPLY = 1.02f;
    private const int START_EXP_ENOUGHT = 100;

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
    
    readonly Level _dataSerialize = new();
    private readonly LevelData _data = new();
    private int _enoughtExp;

    private void Awake()
    {
        SetData();
    }

    private void SetData()
    {
        _data.Level = _dataSerialize.Get().Level;
        _data.Exp = _dataSerialize.Get().Exp;
        
        if (_data.Level == 1)
        {
            _enoughtExp = START_EXP_ENOUGHT;

            UpdateLevelText();

            while (_data.Exp >= _enoughtExp)
            {
                _data.Exp -= _enoughtExp;
                _data.Level++;

                _dataSerialize.Set(_data);

                UpdateLevelText();
            }
        }
        else if (_data.Level >= MAX_LEVEL)
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

            _enoughtExp = (int)(_data.Level * EXP_MULTIPLY);
            
            UpdateLevelText();

            while (_data.Exp >= _enoughtExp)
            {
                _data.Exp -= _enoughtExp;
                _data.Level++;

                _dataSerialize.Set(_data);

                UpdateLevelText();
            }
        }
        
    }

    private void UpdateLevelText()
    {
        _levelText.SetText(_data.Level.ToString());
        _expText.SetText($"{_data.Exp}/{_enoughtExp}");

        SetProgressFill();
    }

    private void SetProgressFill ()
    {
        _progressBar.fillAmount = Mathf.InverseLerp(0f, _enoughtExp, _data.Exp);
    }
}
