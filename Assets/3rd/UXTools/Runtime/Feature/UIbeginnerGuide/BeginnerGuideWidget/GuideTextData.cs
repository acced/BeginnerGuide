using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TextBgStyle
{
    Default,
    WithTitle,
}

[System.Serializable]
public class GuideTextData : GuideWidgetData
{
    //引导面板显示文字
    public string guideTextContent;
    public string guideTextTitle;

    public TextBgStyle textBgStyle;

    public override string Serialize()
    {
        UpdateTransformData();

        var guideText = GetComponent<GuideText>();
        if (textBgStyle == TextBgStyle.Default)
        {
            var defaultContentText = guideText.defaultContent.GetComponent<Text>();
            if (defaultContentText != null)
            {
                guideTextContent = defaultContentText.text;
            }

            var defaultContentTextMeshPro = guideText.defaultContent.GetComponent<TextMeshProUGUI>();
            if (defaultContentTextMeshPro != null)
            {
                guideTextContent = defaultContentTextMeshPro.text;
            }
        }
        else
        {
            var withTitleTitleText = guideText.withTitleTitle.GetComponent<Text>();
            var withTitleContentText = guideText.withTitleContent.GetComponent<Text>();
            if (withTitleTitleText != null)
            {
                guideTextTitle = withTitleTitleText.text;
            }

            if (withTitleContentText != null)
            {
                guideTextContent = withTitleContentText.text;
            }

            var withTitleTitleTextMeshPro = guideText.withTitleTitle.GetComponent<TextMeshProUGUI>();
            var withTitleContentTextMeshPro = guideText.withTitleContent.GetComponent<TextMeshProUGUI>();
            if (withTitleTitleTextMeshPro != null)
            {
                guideTextTitle = withTitleTitleTextMeshPro.text;
            }

            if (withTitleContentTextMeshPro != null)
            {
                guideTextContent = withTitleContentTextMeshPro.text;
            }
        }

        string data = JsonUtility.ToJson(this);
        return data;
    }
}