using HM.Enum_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common_
{
    public class MessageColor
    {
        public static Color GetColorByMessgaeType(MessageType type)
        {
            Color color = Color.Black;
            switch (type)
            {
                case MessageType.Default: color = Color.Black; break;
                case MessageType.Success: color = Color.LimeGreen; break;
                case MessageType.Information: color = Color.DeepSkyBlue; break;
                case MessageType.Warning: color = Color.DarkOrange; break;
                case MessageType.Error: color = Color.Red; break;
            }

            return color;
        }
    }
}
