using System.Collections.Generic;

[System.Serializable]
public class Emotion
{
    public string name; // Название эмоции
    public Dictionary<string, float> blendShapeValues; // Параметры BlendShape и их значения
}

public static class EmotionDatabase
{
    public static List<Emotion> Emotions = new List<Emotion>
    {
        new Emotion
        {
            name = "Neutral",
            blendShapeValues = new Dictionary<string, float>
            {
                { "Fcl_ALL_Neutral", 100f }
            }
        },
        new Emotion
        {
            name = "Angry",
            blendShapeValues = new Dictionary<string, float>
            {
                { "Fcl_ALL_Angry", 100f },
                { "Fcl_BRW_Angry", 50f },
                { "Fcl_EYE_Angry", 30f }
            }
        },
        new Emotion
        {
            name = "Joy",
            blendShapeValues = new Dictionary<string, float>
            {
                { "Fcl_ALL_Joy", 100f },
                { "Fcl_BRW_Joy", 50f },
                { "Fcl_EYE_Joy", 30f }
            }
        },
    };
}

/*
Fcl_ALL_Neutral
Fcl_ALL_Angry
Fcl_ALL_Fun
Fcl_ALL_Joy
Fcl_ALL_Sorrow
Fcl_ALL_Surprised
Fcl_BRW_Angry
Fcl_BRW_Fun
Fcl_BRW_Joy
Fcl_BRW_Sorrow
Fcl_BRW_Surprised
Fcl_EYE_Angry
Fcl_EYE_Close
Fcl_EYE_Close_R
Fcl_EYE_Close_L
Fcl_EYE_Fun
Fcl_EYE_Joy
Fcl_EYE_Joy_R
Fcl_EYE_Joy_L
Fcl_EYE_Sorrow
Fcl_EYE_Surprised
Fcl_EYE_Spread
Fcl_EYE_Iris_Hide
Fcl_EYE_Highlight_Hide
Fcl_MTH_Close
Fcl_MTH_Up
Fcl_MTH_Down
Fcl_MTH_Angry
Fcl_MTH_Small
Fcl_MTH_Large
Fcl_MTH_Neutral
Fcl_MTH_Fun
Fcl_MTH_Joy
Fcl_MTH_Sorrow
Fcl_MTH_Surprised
Fcl_MTH_SkinFung
Fcl_MTH_SkinFung_R
Fcl_MTH_SkinFung_L
Fcl_MTH_A
Fcl_MTH_I
Fcl_MTH_U
Fcl_MTH_E
Fcl_MTH_O
Fcl_HA_Hide
Fcl_HA_Fung1
Fcl_HA_Fung1_Low
Fcl_HA_Fung1_Up
Fcl_HA_Fung2
Fcl_HA_Fung2_Low
Fcl_HA_Fung2_Up
Fcl_HA_Fung3
Fcl_HA_Fung3_Up
Fcl_HA_Fung3_Low
Fcl_HA_Short
Fcl_HA_Short_Up
Fcl_HA_Short_Low
*/