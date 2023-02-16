using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image _expGauge;
    [SerializeField] Text _expText;
    [SerializeField] Text _levelText;
    [SerializeField] Text _nameText;
    [SerializeField] GameObject _optionPanel;

    void Start()
    {
        _expGauge.fillAmount = 0f;
    }

    void Update()
    {
        //_expGauge.transform.localScale += new Vector3(Time.deltaTime,0,0);
        //if (_expGauge.transform.localScale.x >= 1f)
        //    _expGauge.transform.localScale = new Vector3(0, 1, 1);

        //if (_expGauge.fillAmount >= 1f)
        //    _expGauge.fillAmount = 0f;
    }

    public void ExpChange(int heroExp, int needExp)
    {
        float value = (float)heroExp / needExp;
        float min = 0f;
        float max = 1f;
        if (value < min)
            value = min;
        if (value > max)
            value = max;

        _expGauge.fillAmount = value;
        _expText.text = $"{heroExp} / {needExp}";
    }

    public void ShowLevel(int level)
    {
        _levelText.text = "LV. " + level;
    }

    public void ShowOptionPanel()
    {
        Time.timeScale = 0;
        _optionPanel.SetActive(true);
    }

    public void SetChangeName(string name)
    {
        _nameText.text = name;
    }
}
