using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class CsvController : MonoBehaviour
{
    public List<stHeroData> IstHero = new List<stHeroData>();
    public List<stSkillData> lstSkillData = new List<stSkillData>();
    public List<stLevelData> lstLevelData = new List<stLevelData>();

    void Start()
    {
        ReadSkillData();
        ReadLevelData();
        //ReadFile();
        //WriteFile();
    }

    void ReadSkillData()
    {
        string path = Application.dataPath + "/Resources/Datas/Files/SkillData.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                        continue;
                    stSkillData temp = new stSkillData();
                    temp.INDEX = int.Parse(values[0]);
                    temp.LV = int.Parse(values[1]);
                    temp.ETYPE = (ESkillType)Enum.Parse(typeof(ESkillType), values[2]);
                    temp.DMG = int.Parse(values[3]);
                    temp.BULLET = int.Parse(values[4]);
                    temp.RANGE = float.Parse(values[5]);

                    lstSkillData.Add(temp);
                }
            }
        }
    }

    void ReadLevelData()
    {
        string path = Application.dataPath + "/Resources/Datas/Files/LevelData.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                        continue;
                    stLevelData temp = new stLevelData();
                    temp.INDEX = int.Parse(values[0]);
                    temp.LEVEL = int.Parse(values[1]);
                    temp.SUMEXP = int.Parse(values[2]);
                    temp.EXP = int.Parse(values[3]);

                    lstLevelData.Add(temp);
                }
            }
        }
    }

    void WriteFile()
    {
        string fileName = "saveFile" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
        string delimiter = ",";
        List<string[]> lists = new List<string[]>();

        string[] datas = new string[] { "Name", "Time", "Stage", "Exp" };
        lists.Add(datas);
        string[] value1 = new string[] { "p1", DateTime.Now.ToString(), "15", "53122" };
        lists.Add(value1);
        string[] value2 = new string[] { "p2", DateTime.Now.ToString(), "5", "213" };
        lists.Add(value2);

        string[][] outputs = lists.ToArray();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < outputs.Length; i++)
        {
            sb.AppendLine(string.Join(delimiter, outputs[i]));
        }

        string filepath = Application.dataPath + "/Resources/Datas/" + fileName;

        using (StreamWriter outStream = File.CreateText(filepath))
        {
            outStream.Write(sb);
        }
    }

    void ReadFile()
    {
        string path = Application.dataPath + "/Resources/Datas/Source.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                        continue;
                    stHeroData tempData = new stHeroData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.NAME = values[1];
                    tempData.EXP = int.Parse(values[2]);
                    tempData.LEVEL = int.Parse(values[3]);
                    tempData.MOVESPEED = float.Parse(values[4]);
                    tempData.ATTACKPOWER = int.Parse(values[5]);

                    IstHero.Add(tempData);
                    foreach (stHeroData data in IstHero)
                    {
                        Debug.Log(data.NAME + ", " + data.LEVEL);
                    }
                    //int j = 0;
                    //foreach(string data in values) 
                    //{
                    //    Debug.Log(i + "???? " + j + "???? ???????? " + data + "??????");
                    //    j++;
                    //}
                }
            }
        }
    }
}

public struct stHeroData
{
    public int INDEX;
    public string NAME;
    public int EXP;
    public int LEVEL;
    public float MOVESPEED;
    public int ATTACKPOWER;
}

public struct stSkillData
{
    public int INDEX;
    public int LV;
    public ESkillType ETYPE;
    public int DMG;
    public int BULLET;
    public float RANGE;
}

public struct stLevelData
{
    public int INDEX;
    public int LEVEL;
    public int SUMEXP;
    public int EXP;
}

public enum ESkillType
{
    none,
    multiShot,
    homingShot,
    dagger,
    max,
}
