using ComputerInterface;
using ComputerInterface.ViewLib;
using GorillaVFX.Util;
using System.Text;

namespace GorillaVFX.computerInterface.Views
{
    internal class settingsView : ComputerView
    {
        internal class TextItem
        {
            public string Text;
            public TextItem(string Text) { this.Text = Text; }
        }

        public override void OnShow(object[] args)
        {
            base.OnShow(args);
            DrawPage();
        }

        private void DrawPage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AddHeader(Main.NAME)
                .BeginAlign("left")
                .AppendLine($"ParticleAmountMultiplier:[<color=green>{Main.ParticleMultiplier.Value}</color>]")
            ;
            SetText(stringBuilder);
        }

        /* event handler methods */

        public override void OnKeyPressed(EKeyboardKey key)
        {
            if (key == EKeyboardKey.Left)
                Main.ParticleMultiplier.Value--;
            else if (key == EKeyboardKey.Right)
                Main.ParticleMultiplier.Value++;

            if (key == EKeyboardKey.Back)
                ReturnView();
            else
                DrawPage();
        }
    }
}
