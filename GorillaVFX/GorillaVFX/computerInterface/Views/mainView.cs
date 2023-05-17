using ComputerInterface;
using ComputerInterface.Interfaces;
using ComputerInterface.ViewLib;
using GorillaVFX.Util;
using System;
using System.Text;

namespace GorillaVFX.computerInterface.Views
{
    internal class mainView : ComputerView
    {
        // --I will do this when I get back on.-- Prefable we will have settings to dick tate particle levels and things like that.
        internal class mainEntry : IComputerModEntry
        {
            public string EntryName => Main.NAME;
            public Type EntryViewType => typeof(Views.mainView);
        }

        /* Page creation methods */

        private static int _SelectedIndex;
        private UISelectionHandler selectionHandler;
        public override void OnShow(object[] args)
        {
            base.OnShow(args);

            selectionHandler = new UISelectionHandler(EKeyboardKey.Up, EKeyboardKey.Down);
            selectionHandler.MaxIdx = 1;
            selectionHandler.CurrentSelectionIndex = _SelectedIndex;
            selectionHandler.OnSelected += SelectionHandler_OnSelected;
            selectionHandler.ConfigureSelectionIndicator("<color=#ed6540>></color>", "", " ", "");

            DrawPage();
        }

        private void DrawPage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AddHeader(Main.NAME, "By JJoe & Crafterbot", 2)
                .BeginAlign("left")
                .AppendLine(selectionHandler.GetIndicatedText(0, "Settings"))
                .AppendLine(selectionHandler.GetIndicatedText(1, "Credits"))
                ;

            SetText(stringBuilder);
        }

        /* Event handling methods */
        private void SelectionHandler_OnSelected(int obj)
        {
            throw new NotImplementedException();
        }

        public override void OnKeyPressed(EKeyboardKey key)
        {
            if (selectionHandler.HandleKeypress(key))
            {
                _SelectedIndex = selectionHandler.CurrentSelectionIndex;
                DrawPage();
                return;
            }
        }
    }
}
