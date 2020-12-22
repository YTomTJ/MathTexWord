using Microsoft.Office.Tools.Ribbon;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    public partial class Designer {

        private void Designer_Load(object sender, RibbonUIEventArgs e) {
        }


        /// <summary>
        /// Insert new formula in table(single line).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butInsert_Click(object sender, RibbonControlEventArgs e) {

            Word.Application oApp = Globals.ThisAddIn.Application;
            Word.Document oDoc = oApp.ActiveDocument;


            Word.Row nrow;
            {
                if(oApp.Selection.Tables.Count > 0) {
                    // Adding new line in the exist MathTex table
                    Word.Table table = oApp.Selection.Tables[oApp.Selection.Tables.Count];
                    if(TableManager.Check(table)) {
                        nrow = table.Rows.Add();
                    } else {
                        MessageBox.Show("This table not a MathTex object.");
                        return;
                    }
                } else {
                    Word.Table table = oDoc.Tables.Add(oApp.Selection.Range, 1, 2);
                    TableManager.GenerateId(table);
                    nrow = table.Rows[1];
                    {
                        Word.Cell cell = nrow.Cells[1];
                        cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    {
                        Word.Cell cell = nrow.Cells[2];
                        cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                        cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        cell.Range.Text = "(0.0)";
                    }
                    {
                        table.Columns[2].AutoFit();
                        table.AllowAutoFit = true;
                        table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
                    }
                }
            }
            nrow.Cells[1].Range.Select();

            OpenEdit();
        }

        /// <summary>
        /// Edit formula or insert a new inline formula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEdit_Click(object sender, RibbonControlEventArgs e) {
            // Check selection
            Word.Application oApp = Globals.ThisAddIn.Application;
            if(oApp.Selection.Type == Word.WdSelectionType.wdSelectionInlineShape
                && oApp.Selection.InlineShapes != null && oApp.Selection.InlineShapes.Count == 1) {
                // Edit formula in picture
                OpenEdit(oApp.Selection.InlineShapes[1]);
            } else {
                // New inline formula.
                OpenEdit();
            }
        }


        #region Inline Formula

        /// <summary>
        /// Add new inline formula.
        /// </summary>
        private void OpenEdit() {
            // Edit it and retrieve output image.
            if(Editor.Instance.New() == DialogResult.OK) {
                if(Editor.Instance.OutputImage != null) {
                    PastePicture(Editor.Instance.OutputImage, Editor.Instance.Latex);
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
            // Edit it and retrieve output image.
            if(Editor.Instance.Update(ShapeManager.GetFormula(shape), $"Editor.Instance - {id}") == DialogResult.OK) {
                if(Editor.Instance.OutputImage != null) {
                    shape.Delete();
                    PastePicture(Editor.Instance.OutputImage, Editor.Instance.Latex);
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
                shape.ScaleWidth = (float)(Editor.Instance.Scale * 100.0 / Editor.Instance.BaseScale);
                shape.ScaleHeight = (float)(Editor.Instance.Scale * 100.0 / Editor.Instance.BaseScale);
                shape.Range.Paragraphs.BaseLineAlignment = Word.WdBaselineAlignment.wdBaselineAlignCenter;
                return shape;
            } else {
                MessageBox.Show("Paste output image failed.");
            }
            return null;
        }

        #endregion Inline Formula

        #region Other Actions
        private void butUpper_Click(object sender, RibbonControlEventArgs e) {

        }

        private void butLower_Click(object sender, RibbonControlEventArgs e) {

        }

        private void butHelp_Click(object sender, RibbonControlEventArgs e) {

        }
        #endregion Other Actions
    }
}
