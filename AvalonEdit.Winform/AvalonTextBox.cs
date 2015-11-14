using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using System.IO;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;

namespace AvalonEdit.Winform
{
    /// <summary>
    /// AvalonEditor Winform实现
    /// </summary>
    public partial class AvalonTextBox : UserControl
    {
        [Browsable(true)]
        public new string Text
        {
            get
            {
                return _editor.Text;
            }
            set
            {
                _editor.Text = value;
            }
        }

        public string SyntaxHighlighting
        {
            get
            {
                if (_editor.SyntaxHighlighting==null)
                {
                    return null;
                }
                return _editor.SyntaxHighlighting.Name;
            }
            set
            {
                if (value==null)
                {
                    _editor.SyntaxHighlighting = null;
                }
                if (_editor.SyntaxHighlighting!=null&&_editor.SyntaxHighlighting.Name==value)
                {
                    return;
                }
                _editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(value);
            }
        }

        private TextEditor _editor = new TextEditor();
        [Description("文本框")]
        public ICSharpCode.AvalonEdit.TextEditor TextEditor
        {
            get { return _editor; }
        }
        [Description("显示行号"), DefaultValue(true)]
        public bool ShowLineNumbers
        {
            get { return _editor.ShowLineNumbers; }
            set { _editor.ShowLineNumbers = value; }
        }

        public AvalonTextBox()
        {
            InitializeComponent();
            LoadHighlightingXshd();
            _editor.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            _editor.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            _editor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");
            _editor.ShowLineNumbers = true;
            elementHost.Child = _editor;
        }

        private void LoadHighlightingXshd()
        {
            string[] paths = new string[]{
                "AvalonEdit.Winform.Highlighting.PLSQL.xshd,PLSQL,.sql",
                "AvalonEdit.Winform.Highlighting.SQL.xshd,SQL,.sql"
            };
            foreach (string item in paths)
            {
                string[] temps = item.Split(',',';');
                IHighlightingDefinition customHighlighting;
                using (Stream s = this.GetType().Assembly.GetManifestResourceStream(temps[0]))
                {
                    if (s == null)
                        throw new InvalidOperationException("Could not find embedded resource");
                    using (XmlReader reader = new XmlTextReader(s))
                    {
                        customHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.
                            HighlightingLoader.Load(reader, HighlightingManager.Instance);
                    }
                }
                // and register it in the HighlightingManager
                string[] exts=new string[temps.Length-2];
                Array.Copy(temps, 2, exts, 0, exts.Length);
                HighlightingManager.Instance.RegisterHighlighting(temps[1], exts, customHighlighting);
            }          
        }

    }
}
