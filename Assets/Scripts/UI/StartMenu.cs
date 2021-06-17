using System;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MenuBase
{
    [SerializeField] Text widthText;
    [SerializeField] Text heightText;
    [SerializeField] Text depthText;
    [SerializeField] Text mineCountText;

    private void Update()
    {
        SetSettingsValues();
    }

    private void SetSettingsValues()
    {
        try
        {
            Settings.Width = int.Parse(widthText.text);
            Settings.Height = int.Parse(heightText.text);
            Settings.Depth = int.Parse(depthText.text);
            Settings.MineCount = int.Parse(mineCountText.text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
