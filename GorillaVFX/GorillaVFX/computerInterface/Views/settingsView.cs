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

        private UIElementPageHandler<TextItem> pageHandler;
        private UISelectionHandler selectionHandler;

        public override void OnShow(object[] args)
        {
            base.OnShow(args);
            pageHandler = new UIElementPageHandler<TextItem>();
            pageHandler.EntriesPerPage = 5;
            pageHandler.SetElements(new TextItem[]
            {
                new TextItem("Partical Multiplier")
            });

            selectionHandler = new UISelectionHandler(EKeyboardKey.Up, EKeyboardKey.Down, EKeyboardKey.Enter);
            selectionHandler.OnSelected += SelectionHandler_OnSelected;
            selectionHandler.MaxIdx = pageHandler.EntriesPerPage;
        }

        private void DrawPage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AddHeader(Main.NAME)
                .BeginAlign("left")
                .AppendLine(selectionHandler.GetIndicatedText(0, "Settings"))
                .AppendLine(selectionHandler.GetIndicatedText(1, "Credits"));
            SetText(stringBuilder);
        }

        /* event handler methods */

        public override void OnKeyPressed(EKeyboardKey key)
        {
            if (selectionHandler.HandleKeypress(key))
            {
                int index = selectionHandler.CurrentSelectionIndex;
                if (index == 0 && key == EKeyboardKey.Up && pageHandler.CurrentPage != 0)
                    pageHandler.CurrentPage--;
                if (index == selectionHandler.MaxIdx && key == EKeyboardKey.Down && pageHandler.CurrentPage != pageHandler.CurrentPage)
                    pageHandler.CurrentPage++;
                DrawPage();
                return;
            }

            if (key == EKeyboardKey.Back)
                ReturnView();
        }
        private void SelectionHandler_OnSelected(int obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
