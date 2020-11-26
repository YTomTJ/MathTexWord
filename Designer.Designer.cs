
namespace MathTexWord {
    partial class Designer : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Designer()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.tabMathTex = this.Factory.CreateRibbonTab();
            this.grpTool = this.Factory.CreateRibbonGroup();
            this.butInsert = this.Factory.CreateRibbonButton();
            this.butEdit = this.Factory.CreateRibbonButton();
            this.tabMathTex.SuspendLayout();
            this.grpTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMathTex
            // 
            this.tabMathTex.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabMathTex.Groups.Add(this.grpTool);
            this.tabMathTex.Label = "MathTex";
            this.tabMathTex.Name = "tabMathTex";
            // 
            // grpTool
            // 
            this.grpTool.Items.Add(this.butInsert);
            this.grpTool.Items.Add(this.butEdit);
            this.grpTool.Label = "工具";
            this.grpTool.Name = "grpTool";
            // 
            // butInsert
            // 
            this.butInsert.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butInsert.Image = global::MathTexWord.Properties.Resources.sigma;
            this.butInsert.Label = "插入公式";
            this.butInsert.Name = "butInsert";
            this.butInsert.ShowImage = true;
            this.butInsert.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butInsert_Click);
            // 
            // butEdit
            // 
            this.butEdit.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butEdit.Image = global::MathTexWord.Properties.Resources.edit;
            this.butEdit.Label = "编辑";
            this.butEdit.Name = "butEdit";
            this.butEdit.ShowImage = true;
            this.butEdit.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butEdit_Click);
            // 
            // Designer
            // 
            this.Name = "Designer";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabMathTex);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Designer_Load);
            this.tabMathTex.ResumeLayout(false);
            this.tabMathTex.PerformLayout();
            this.grpTool.ResumeLayout(false);
            this.grpTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMathTex;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTool;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butInsert;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butEdit;
    }

    partial class ThisRibbonCollection {
        internal Designer Designer {
            get { return this.GetRibbon<Designer>(); }
        }
    }
}
