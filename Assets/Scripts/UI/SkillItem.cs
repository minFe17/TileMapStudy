using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _name;
    [SerializeField] Text _descript;

    SetSkillItems _parent;
    stSkillData _data;

    public void Init(stSkillData data, SetSkillItems parent)
    {
        _data = data;
        _parent = parent;
        _name.text = data.ETYPE + ", LV." + data.LV;
        _descript.text = "DMG : " + data.DMG + ", RANGE : " + data.RANGE + ", BULLET : " + data.BULLET; 
    }

    public void OnSelected()
    {
        _parent.CharacterLvUp(_data);
    }
}
