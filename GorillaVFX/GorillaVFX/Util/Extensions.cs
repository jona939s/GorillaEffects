using BepInEx.Logging;
using ComputerInterface;
using System.Text;

namespace GorillaVFX.Util
{
    internal static class Extensions
    {
        internal static void Log(this object obj, LogLevel logLevel = LogLevel.Info)
        {
#if DEBUG
            Main.manualLogSource.Log(logLevel, obj);
#endif 
        }
        internal static StringBuilder AddHeader(this StringBuilder stringBuilder, string Title, string Author = "", int Offset = 2)
        {
            stringBuilder
                .BeginCenter()
                .MakeBar('=', ComputerInterface.ViewLib.ComputerView.SCREEN_WIDTH, 0)
                .AppendLine(Title);
            if (Author != "") stringBuilder.AppendLine("<color=ffffff50>" + Author + "</color>");
            stringBuilder
                .AppendLine()
                .MakeBar('=', ComputerInterface.ViewLib.ComputerView.SCREEN_WIDTH, 0)
                .AppendLines(Offset)
                .EndAlign();
            return stringBuilder;
        }
    }
}
