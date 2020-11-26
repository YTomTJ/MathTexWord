using MathTex.Parser;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathTexWord {

    public partial class Editor : Form {

        internal string inputLatex = null;
        internal double outputScale = 2.0;
        internal Image outputImage = null;

        public Editor() {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Editor_KeyDown;
            this.txtInput.KeyDown += TxtInput_KeyDown;
        }

        private void Editor_Load(object sender, EventArgs e) {
            cmbFontSize.SelectedIndex = 4;
            txtInput.Text = inputLatex;
            
            //txtOutputInfo.Clear();

            picFormula.Image = null;
            outputImage = null;

            // TODO: Load previous formula
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
                    txtOutputInfo.Clear();
                    Preview();
                }
            }
        }

        private void butPreview_Click(object sender, EventArgs e) {
            txtOutputInfo.Clear();
            Preview();
        }

        private void butConvert_Click(object sender, EventArgs e) {
            Convert();
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                outputImage = null;
                this.DialogResult = DialogResult.Cancel;
                this.Hide();
            }
        }

        private void Preview() {
            txtInput.Enabled = false;
            var ms = Renderer.ConvertFormula(txtInput.Text, out string err);
            if(err is null) {
                picFormula.Image = new Bitmap(ms);
                txtOutputInfo.Text += "\nSucceed.";
            } else {
                txtOutputInfo.Text += "\n" + err;
            }
            txtInput.Enabled = true;
            txtInput.Focus();
        }

        private void Convert() {
            try {
                inputLatex = txtInput.Text;
                var ms = Renderer.ConvertFormula(inputLatex, out string err, scale: outputScale, color: Color.White);
                outputImage = new Bitmap(ms);
                this.DialogResult = DialogResult.OK;
            } catch {
                outputImage = null;
                this.DialogResult = DialogResult.None;
            }
            this.Hide();
        }

        internal void SetInfo(string info) {
            txtOutputInfo.Text = info;
        }
    }
}
