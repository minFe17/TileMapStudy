using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _levelText;
    [SerializeField] Text _nameText;

    void Start()
    {
        _image.fillAmount = 0.3f;
        _levelText.text = "Lv.105";
        _nameText.text = "min";
    }

    public void OnButtonDown()
    {
        Debug.Log("OnButtonDown");
        _image.fillAmount = 0.7f;
        _levelText.text = "Lv.200";
        _nameText.text = "Fe";
    }

    public void OnPointDown()
    {
        _image.fillAmount = 0.5f;
        _levelText.text = "Lv.150";
        _nameText.text = "ABC";
        Debug.Log("OnPointDown");
    }

    public void OnOptionClick()
    {
        Debug.Log("OnOptionClick");
    }
}
