using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CardLevel : MonoBehaviour
{
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

    public CardHandler.CardFormattedData Data;
    public GlobalRarity GlobalRarity = null;

    void Start()
    {
        if (GlobalRarity) SetData();
    }

    public void SetData()
    {
        if (Data.levelData.Level >= GlobalRarity.GetMaxLevelUpgrade(Data.cardInfo.Rarity))
        {
            _levelIcon.sprite = _maxIcon;

            _barIcon.sprite = _maxBar;
            _progressBar.fillAmount = 1;

            _levelText.text = GlobalRarity.GetMaxLevelUpgrade(Data.cardInfo.Rarity).ToString();
            _expText.text = "MAX";
        }
        else if (Data.levelData.Exp >= Data.levelData.EnoughtExp)
        {
            _levelIcon.sprite = _compliteIcon;
            _barIcon.sprite = _compliteBar;

            Data.levelData.EnoughtExp = Data.levelData.Level * 2;

            UpdateLevelText();
        }
        else
        {
            _levelIcon.sprite = _normalIcon;
            _barIcon.sprite = _normalBar;

            Data.levelData.EnoughtExp = Data.levelData.Level * 2;

            UpdateLevelText();
        }
    }

    private void UpdateLevelText()
    {
        _levelText.SetText(Data.levelData.Level.ToString());
        _expText.SetText($"{Data.levelData.Exp}/{Data.levelData.EnoughtExp}");

        SetProgressFill();
    }

    private void SetProgressFill()
    {
        _progressBar.fillAmount = Mathf.InverseLerp(0f, Data.levelData.EnoughtExp, Data.levelData.Exp);
    }
}
