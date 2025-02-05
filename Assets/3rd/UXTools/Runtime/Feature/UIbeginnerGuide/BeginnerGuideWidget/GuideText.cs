using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuideText : GuideWidgetBase
{
    public GameObject defaultStyle;
    public GameObject withTitleStyle;
    public GameObject defaultContent;
    public GameObject withTitleTitle;
    public GameObject withTitleContent;

    public override void Init(GuideWidgetData data)
    {
        GuideTextData guideTextData = data as GuideTextData;

        if (guideTextData != null)
        {
            guideTextData.ApplyTransformData(transform);

            defaultStyle.SetActive(guideTextData.textBgStyle == TextBgStyle.Default);
            withTitleStyle.SetActive(guideTextData.textBgStyle == TextBgStyle.WithTitle);

            if (guideTextData.textBgStyle == TextBgStyle.Default)
            {
                var defaultContentText = defaultContent.GetComponent<Text>();

                if (defaultContentText != null)
                {
                    defaultContentText.text = guideTextData.guideTextContent;
                }

                var defaultContentTextMeshPro = defaultContent.GetComponent<TextMeshProUGUI>();

                if (defaultContentTextMeshPro != null)
                {
                    defaultContentTextMeshPro.text = guideTextData.guideTextContent;
                }
            }
            else
            {
                var withTitleTitleText = withTitleTitle.GetComponent<Text>();
                var withTitleContentText = withTitleContent.GetComponent<Text>();

                if (withTitleTitleText != null)
                {
                    withTitleTitleText.text = guideTextData.guideTextTitle;
                }

                if (withTitleContentText != null)
                {
                    withTitleContentText.text = guideTextData.guideTextContent;
                }

                var withTitleTitleTextMeshPro = withTitleTitle.GetComponent<TextMeshProUGUI>();
                var withTitleContentTextMeshPro = withTitleContent.GetComponent<TextMeshProUGUI>();

                if (withTitleTitleTextMeshPro != null)
                {
                    withTitleTitleTextMeshPro.text = guideTextData.guideTextTitle;
                }

                if (withTitleContentTextMeshPro != null)
                {
                    withTitleContentTextMeshPro.text = guideTextData.guideTextContent;
                }
            }
        }
    }

    public override List<int> GetControlledInstanceIds()
    {
        List<int> list = new List<int>();

        return list;
    }

    public override void Show()
    {
    }

    public override void Stop()
    {
    }
}