using ComputerInterface;
using ComputerInterface.ViewLib;
using GorillaVFX.Util;
using System.Text;

namespace GorillaVFX.computerInterface.Views
{
    internal class creditsView : ComputerView
    {
        public override void OnShow(object[] args)
        {
            base.OnShow(args);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AddHeader("Credits", "Press any key to exit")
                .Append("GorillaVFX was created by Crafterbot & JJoe (jona939s).")
                ;
            SetText(stringBuilder);
        }
        public override void OnKeyPressed(EKeyboardKey key)
        {
            ReturnView();
        }
    }
}
