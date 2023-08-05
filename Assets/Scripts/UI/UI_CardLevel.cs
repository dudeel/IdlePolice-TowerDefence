using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardLevel : MonoBehaviour
{
    [SerializeField] private Image _imageLevelLogo;
    [SerializeField] private Image _imageProgressBar;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private TextMeshProUGUI _textExp;

    [SerializeField] private Sprite _spriteMaxLevelLogo;
    [SerializeField] private Sprite _spriteDefaultLevelLogo;

    private const int MAX_LEVEL = 40;

    void Awake()
    {
        _imageLevelLogo.sprite = _spriteDefaultLevelLogo;
        
        SetLevel();
    }

    public void SetLevel(int m_level = 1)
    {
        if (m_level >= MAX_LEVEL)
        {
            m_level = MAX_LEVEL;
            _imageLevelLogo.sprite = _spriteMaxLevelLogo;
        }

        _textLevel.text = m_level.ToString();
    }
}
