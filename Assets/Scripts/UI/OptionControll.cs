using UnityEngine;
using UnityEngine.UI;

public class OptionControll : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    [SerializeField] InputField _inputField;

    void Start()
    {
        _toggle.isOn = false;
    }

    void Update()
    {
        _slider.value += Time.deltaTime;
        if (_slider.value >= 1)
            _slider.value = 0;
    }

    public void OnToggleChange()
    {
        Debug.Log("Toggle Change To : " + _toggle.isOn);
    }

    public void OnSliderValueChange()
    {
        //Debug.Log("Slider Change To : " + _slider.value);
    }

    public void OnInputFieldChange()
    {
        Debug.Log("Field Text is : " + _inputField.text);
    }
}
