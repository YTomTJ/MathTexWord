
namespace MathTexWord {

    partial class winEditor {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.butConvert = new System.Windows.Forms.Button();
            this.butPreview = new System.Windows.Forms.Button();
            this.txtOutputInfo = new System.Windows.Forms.RichTextBox();
            this.butInfo = new System.Windows.Forms.Button();
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.picFormula = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFormula)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.AcceptsTab = true;
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BackColor = System.Drawing.Color.Wheat;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 178);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(360, 160);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "字号:";
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Items.AddRange(new object[] {
            "\\tiny",
            "\\scriptsize",
            "\\footnotesize",
            "\\small",
            "\\normalsize",
            "\\large",
            "\\Large",
            "\\LARGE",
            "\\huge",
            "\\Huge"});
            this.cmbFontSize.Location = new System.Drawing.Point(62, 441);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(70, 20);
            this.cmbFontSize.TabIndex = 3;
            // 
            // butConvert
            // 
            this.butConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butConvert.Font = new System.Drawing.Font("等线", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butConvert.Location = new System.Drawing.Point(297, 437);
            this.butConvert.Name = "butConvert";
            this.butConvert.Size = new System.Drawing.Size(75, 26);
            this.butConvert.TabIndex = 4;
            this.butConvert.Text = "完成";
            this.butConvert.UseVisualStyleBackColor = true;
            // 
            // butPreview
            // 
            this.butPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butPreview.Font = new System.Drawing.Font("等线", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butPreview.Location = new System.Drawing.Point(216, 437);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(75, 26);
            this.butPreview.TabIndex = 4;
            this.butPreview.Text = "预览";
            this.butPreview.UseVisualStyleBackColor = true;
            // 
            // txtOutputInfo
            // 
            this.txtOutputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutputInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutputInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputInfo.Location = new System.Drawing.Point(12, 344);
            this.txtOutputInfo.Name = "txtOutputInfo";
            this.txtOutputInfo.ReadOnly = true;
            this.txtOutputInfo.Size = new System.Drawing.Size(360, 55);
            this.txtOutputInfo.TabIndex = 5;
            this.txtOutputInfo.Text = "";
            // 
            // butInfo
            // 
            this.butInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butInfo.Font = new System.Drawing.Font("等线", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butInfo.Location = new System.Drawing.Point(351, 410);
            this.butInfo.Name = "butInfo";
            this.butInfo.Size = new System.Drawing.Size(20, 20);
            this.butInfo.TabIndex = 4;
            this.butInfo.Text = "?";
            this.butInfo.UseVisualStyleBackColor = true;
            // 
            // numScale
            // 
            this.numScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numScale.DecimalPlaces = 2;
            this.numScale.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numScale.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numScale.Location = new System.Drawing.Point(62, 413);
            this.numScale.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(70, 22);
            this.numScale.TabIndex = 9;
            this.numScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "比例:";
            // 
            // picFormula
            // 
            this.picFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFormula.InitialImage = null;
            this.picFormula.Location = new System.Drawing.Point(12, 12);
            this.picFormula.Name = "picFormula";
            this.picFormula.Size = new System.Drawing.Size(360, 160);
            this.picFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFormula.TabIndex = 1;
            this.picFormula.TabStop = false;
            // 
            // winEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 473);
            this.Controls.Add(this.numScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutputInfo);
            this.Controls.Add(this.butInfo);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.butConvert);
            this.Controls.Add(this.cmbFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picFormula);
            this.Controls.Add(this.txtInput);
            this.MinimumSize = new System.Drawing.Size(400, 480);
            this.Name = "winEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFormula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtInput;
        public System.Windows.Forms.PictureBox picFormula;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbFontSize;
        public System.Windows.Forms.Button butConvert;
        public System.Windows.Forms.Button butPreview;
        public System.Windows.Forms.RichTextBox txtOutputInfo;
        public System.Windows.Forms.Button butInfo;
        public System.Windows.Forms.NumericUpDown numScale;
        public System.Windows.Forms.Label label2;
    }
}