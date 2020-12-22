using MathTex.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTexWord {
    
    class Editor {

        #region Export API
        private double baseScale = 10.0;
        public double BaseScale {
            get => baseScale;
            set {
                if(value < 1.0) {
                    baseScale = 1.0;
                } else if(value > 20.0) {
                    baseScale = 20.0;
                } else {
                    baseScale = value;
                }
            }
        }

        public double Scale { get; private set; } = 1.0;
        public Image OutputImage { get; private set; } = null;
        public string OutputSvg { get; private set; } = null;
        public string Latex { get; private set; } = "";

        public DialogResult New(string id = null) {
            _editor.Text = id is null ? "MathTex - Temproary" : $"MathTex - {id}";
            Latex = "";
            SetInfo($">>> {id ?? "null"}\n");
            // Call editor
            return _editor.ShowDialog();
        }

        public DialogResult Update(string latex, string id = null) {
            _editor.Text = id is null ? "MathTex - Temproary" : $"MathTex - {id}";
            Latex = latex;
            SetInfo($">>> {id ?? "null"}\n");

            // Call editor
            return _editor.ShowDialog();
        }

        private static Editor _instance;
        public static Editor Instance {
            get {
                if(_instance is null) {
                    _instance = new Editor();
                }
                return _instance;
            }
        }

        #endregion Export API

        private Editor() {

            _editor = new winEditor();
            _editor.KeyPreview = true;

            _editor.FormClosing += this.Editor_FormClosing;
            _editor.Load += this.Editor_Load;
            _editor.butConvert.Click += this.butConvert_Click;
            _editor.numScale.ValueChanged += this.numScale_ValueChanged;
            _editor.butInfo.Click += this.butInfo_Click;
            _editor.butPreview.Click += this.butPreview_Click;
            _editor.KeyDown += Editor_KeyDown;
            _editor.txtInput.KeyDown += TxtInput_KeyDown;
        }

        protected void SetInfo(string info) {
            _editor.txtOutputInfo.Text = info;
        }

        private void Preview() {
            _editor.txtInput.Enabled = false;
            //var ms = Renderer.ConvertFormula(txtInput.Text, out string err);
            var bitmap = Renderer.ConvertFormulaEX(_editor.txtInput.Text, out string err, out string svgtext);
            if(err is null) {
                //picFormula.Image = new Bitmap(ms);
                OutputSvg = svgtext;
                _editor.picFormula.Image = bitmap;
                _editor.txtOutputInfo.Text += "\nSucceed.";
            } else {
                _editor.txtOutputInfo.Text += "\n" + err;
            }
            _editor.txtInput.Enabled = true;
            _editor.txtInput.Focus();
        }

        private void Convert() {
            try {
                Latex = _editor.txtInput.Text;
                OutputImage = Renderer.ConvertFormulaEX(Latex, out string err, out string svgtext, scale: baseScale, color: Color.White);
                OutputSvg = svgtext;
                _editor.DialogResult = DialogResult.OK;
            } catch {
                OutputImage = null;
                OutputSvg = null;
                _editor.DialogResult = DialogResult.None;
            }
            _editor.Hide();
        }


        #region Editor Events

        private static winEditor _editor;

        private void Editor_Load(object sender, EventArgs e) {
            _editor.cmbFontSize.SelectedIndex = 4;
            _editor.txtInput.Text = Latex;

            _editor.picFormula.Image = null;
            OutputImage = null;
            OutputSvg = null;

            // Load previous formula
            Preview();
        }

        private void Editor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == Keys.Escape) {
                Convert();
            }
        }

        private void TxtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                if(e.Control) {
                    e.Handled = true;
                    _editor.txtOutputInfo.Clear();
                    Preview();
                }
            }
        }

        private void butPreview_Click(object sender, EventArgs e) {
            _editor.txtOutputInfo.Clear();
            Preview();
        }

        private void butConvert_Click(object sender, EventArgs e) {
            Convert();
        }

        private void butInfo_Click(object sender, EventArgs e) {
            _editor.txtOutputInfo.Text = OutputSvg;
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                OutputImage = null;
                OutputSvg = null;
                _editor.DialogResult = DialogResult.Cancel;
                _editor.Hide();
            }
        }

        private void numScale_ValueChanged(object sender, EventArgs e) {
            Scale = (double)_editor.numScale.Value;
        }

        #endregion
    }
}
