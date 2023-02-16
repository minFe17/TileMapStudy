using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image _hpBar;

    public void ShowHp(int curHp, int maxHp)
    {
        float value = 0f;
        if (curHp < 0f)
            value = 0f;
        value = (float)curHp / maxHp;
        _hpBar.fillAmount = value;

    }

}
