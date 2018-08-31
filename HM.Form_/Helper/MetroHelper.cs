using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Form_
{
    public static class MetroHelper
    {
        public static Color ToColor(this MetroFramework.MetroColorStyle colorStyle)
        {
            string htmlColor = "#00AEDB";
            switch (colorStyle)
            {
                case MetroFramework.MetroColorStyle.Default:
                    htmlColor = "#00AEDB";
                    break;
                case MetroFramework.MetroColorStyle.Black:
                    htmlColor = "#000000";
                    break;
                case MetroFramework.MetroColorStyle.White:
                    htmlColor = "#FFFFFF";
                    break;
                case MetroFramework.MetroColorStyle.Silver:
                    htmlColor = "#555555";
                    break;
                case MetroFramework.MetroColorStyle.Blue:
                    htmlColor = "#00AEDB";
                    break;
                case MetroFramework.MetroColorStyle.Green:
                    htmlColor = "#00B159";
                    break;
                case MetroFramework.MetroColorStyle.Lime:
                    htmlColor = "#8EBC00";
                    break;
                case MetroFramework.MetroColorStyle.Teal:
                    htmlColor = "#00AAAD";
                    break;
                case MetroFramework.MetroColorStyle.Orange:
                    htmlColor = "#F37735";
                    break;
                case MetroFramework.MetroColorStyle.Brown:
                    htmlColor = "#A55100";
                    break;
                case MetroFramework.MetroColorStyle.Pink:
                    htmlColor = "#E771BD";
                    break;
                case MetroFramework.MetroColorStyle.Magenta:
                    htmlColor = "#FF0094";
                    break;
                case MetroFramework.MetroColorStyle.Purple:
                    htmlColor = "#7C4199";
                    break;
                case MetroFramework.MetroColorStyle.Red:
                    htmlColor = "#D11141";
                    break;
                case MetroFramework.MetroColorStyle.Yellow:
                    htmlColor = "#FFC425";
                    break;
                default:
                    break;
            }
            return ColorTranslator.FromHtml(htmlColor);
        }

        public static Color ToForeColor(this MetroFramework.MetroThemeStyle themeStyle)
        {
            string htmlColor = "#FFFFFF";
            switch (themeStyle)
            {
                case MetroFramework.MetroThemeStyle.Default:
                case MetroFramework.MetroThemeStyle.Light:
                    break;
                case MetroFramework.MetroThemeStyle.Dark:
                    htmlColor = "#FFC425";
                    break;
                default:
                    break;
            }
            return ColorTranslator.FromHtml(htmlColor);
        }

        public static Color ToBackColor(this MetroFramework.MetroThemeStyle themeStyle)
        {
            string htmlColor = "#FFFFFF";
            switch (themeStyle)
            {
                case MetroFramework.MetroThemeStyle.Default:
                case MetroFramework.MetroThemeStyle.Light:
                    break;
                case MetroFramework.MetroThemeStyle.Dark:
                    htmlColor = "#FFC425";
                    break;
                default:
                    break;
            }
            return ColorTranslator.FromHtml(htmlColor);
        }
    }
}
