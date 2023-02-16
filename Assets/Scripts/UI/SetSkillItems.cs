using System.Collections.Generic;
using UnityEngine;

public class SetSkillItems : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    [SerializeField] CharacterController _hero;

    List<GameObject> lstItems = new List<GameObject>();

    public void ShowSkillPanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        for (int i = 1; i < (int)ESkillType.max; i++)
        {
            foreach (stSkillData data in _controller.lstSkillData)
            {
                if (data.ETYPE != (ESkillType)i)
                    continue;
                if (_hero.dicSkills.ContainsKey(data.ETYPE) == true)
                {
                    if (data.LV == _hero.dicSkills[data.ETYPE] + 1)
                    {
                        GameObject temp = Instantiate(_item, _content);
                        temp.GetComponent<SkillItem>().Init(data, this);
                        lstItems.Add(temp);
                    }
                }
                else
                {
                    if (data.LV == 1)
                    {
                        GameObject temp = Instantiate(_item, _content);
                        temp.GetComponent<SkillItem>().Init(data, this);
                        lstItems.Add(temp);
                    }
                }
            }
        }
    }

    public void CloseSkillPanel()
    {
        gameObject.SetActive(false);
    }

    public void CharacterLvUp(stSkillData data)
    {
        _hero.GetSkill(data);
        CloseSkillPanel();
        foreach(GameObject temp in lstItems)
        {
            Destroy(temp);
        }
        lstItems.Clear();
        Time.timeScale = 1;
    }
}
