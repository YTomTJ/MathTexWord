using Microsoft.Office.Tools.Ribbon;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    public partial class Designer {

        private static Editor editor;

        private void Designer_Load(object sender, RibbonUIEventArgs e) {
            editor = new Editor();
        }


        /// <summary>
        /// Insert new formula in table(single line).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butInsert_Click(object sender, RibbonControlEventArgs e) {

            Word.Application oApp = Globals.ThisAddIn.Application;
            Word.Document oDoc = oApp.ActiveDocument;

            Word.Table table = oDoc.Tables.Add(oApp.Selection.Range, 1, 2);
            table.Descr = TableManager.GenerateId();

            {
                Word.Cell cell = table.Cell(1, 1);
                cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            {
                Word.Cell cell = table.Cell(1, 2);
                cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                cell.Range.Text = "(0.0)";
            }

            OpenEdit(table);

            table.Columns[2].AutoFit();
            table.AllowAutoFit = true;
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow); // Fill page width
        }

        /// <summary>
        /// Edit formula or insert a new inline formula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEdit_Click(object sender, RibbonControlEventArgs e) {
            // Check selection
            Word.Application oApp = Globals.ThisAddIn.Application;
            if(oApp.Selection.Tables.Count > 0) {
                // Edit formula in table(single line)
                OpenEdit(oApp.Selection.Tables[1]);
            } else if(oApp.Selection.Type == Word.WdSelectionType.wdSelectionInlineShape
                && oApp.Selection.InlineShapes != null && oApp.Selection.InlineShapes.Count == 1) {
                // Edit inline formula
                OpenEdit(oApp.Selection.InlineShapes[1]);
            } else {
                // New inline formula.
                OpenEdit();
            }
        }


        #region Table Formula

        /// <summary>
        /// Edit or update formula in table(single line).
        /// </summary>
        /// <param name="table"></param>
        private void OpenEdit(Word.Table table) {

            // Load formula latex.
            var id = TableManager.GetId(table);
            if(id is null) {
                id = "New";
                TableManager.SetFormula(table, null);
            }
            editor.Text = $"Editor - {id}";
            editor.inputLatex = TableManager.GetFormula(table);
            editor.SetInfo($">>> {id}\n");

            // Edit it and retrieve output image.
            if(editor.ShowDialog() == DialogResult.OK) {
                if(editor.outputImage != null) {
                    TableManager.SetFormula(table, editor.inputLatex);
                    Clipboard.SetDataObject(editor.outputImage);
                    table.Cell(1, 1).Range.Paste();
                    // Modify image scale.
                    foreach(Word.InlineShape ils in table.Cell(1, 1).Range.InlineShapes) {
                        if(ils != null && ils.Type == Word.WdInlineShapeType.wdInlineShapePicture) {
                            ils.ScaleWidth = (float)(editor.outputScale * 100.0 / editor.baseScale);
                            ils.ScaleHeight = (float)(editor.outputScale * 100.0 / editor.baseScale);
                        }
                    }
                }
            }
        }

        #endregion Table Formula


        #region Inline Formula

        /// <summary>
        /// Add new inline formula.
        /// </summary>
        private void OpenEdit() {
            // Load formula latex.
            editor.Text = $"Editor - Temproary";
            editor.inputLatex = "";
            // Edit it and retrieve output image.
            if(editor.ShowDialog() == DialogResult.OK) {
                if(editor.outputImage != null) {
                    PastePicture(editor.outputImage, editor.inputLatex);
                }
            }
        }

        /// <summary>
        /// Edit exist inline formula.
        /// </summary>
        /// <param name="shape"></param>
        private void OpenEdit(Word.InlineShape shape) {
            // Load formula latex.
            var id = ShapeManager.GetId(shape);
            if(id is null) {
                return;
            }
            editor.Text = $"Editor - {id}";
            editor.inputLatex = ShapeManager.GetFormula(shape);
            editor.SetInfo($">>> {id}\n");
            // Edit it and retrieve output image.
            if(editor.ShowDialog() == DialogResult.OK) {
                if(editor.outputImage != null) {
                    shape.Delete();
                    PastePicture(editor.outputImage, editor.inputLatex);
                }
            }
        }

        private Word.InlineShape PastePicture(Image image, string formula = null) {
            var range = Globals.ThisAddIn.Application.Selection.Range;
            var c0 = range.InlineShapes.Count;
            Clipboard.SetDataObject(image);
            range.Paste();
            if(range.InlineShapes.Count == c0 + 1) {
                var shape = range.InlineShapes[range.InlineShapes.Count];
                ShapeManager.SetFormula(shape, formula);
                shape.ScaleWidth = (float)(editor.outputScale * 100.0 / editor.baseScale);
                shape.ScaleHeight = (float)(editor.outputScale * 100.0 / editor.baseScale);
                shape.Range.Paragraphs.BaseLineAlignment = Word.WdBaselineAlignment.wdBaselineAlignFarEast50;
                return shape;
            } else {
                MessageBox.Show("Paste output image failed.");
            }
            return null;
        }

        #endregion Inline Formula
    }
}
