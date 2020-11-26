using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    public partial class Designer {

        private static Editor editor;
        private readonly string IDHeader = "##_MathTexWord";
        private readonly string IDTail= "droWxeThtaM_##";
        private static ulong IDIndex = 0;

        private void Designer_Load(object sender, RibbonUIEventArgs e) {
            editor = new Editor();
            //formulaTableIds = new List<Word.Table>();
            //formulaTexts = new Dictionary<string, string>();
        }

        private void butInsert_Click(object sender, RibbonControlEventArgs e) {

            Word.Application oApp = Globals.ThisAddIn.Application;
            Word.Document oDoc = oApp.ActiveDocument;

            Word.Table table = oDoc.Tables.Add(oApp.Selection.Range, 1, 2);
            table.Descr = GenerateId();

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

        private void butEdit_Click(object sender, RibbonControlEventArgs e) {

            Word.Application oApp = Globals.ThisAddIn.Application;
            Word.Document oDoc = oApp.ActiveDocument;

            // Check table
            Word.Table table = null;
            if(oApp.Selection.Tables.Count > 0) {
                table = oApp.Selection.Tables[1];
            }
            //for(int i = 1; i <= oApp.Selection.Tables.Count; ++i) {
            //    var tab = oApp.Selection.Tables[i];

            //}
            if(table != null) {
                OpenEdit(table);
            } else {
                OpenEdit(oApp.Selection.Range);
            }
        }


        /// <summary>
        /// Insert formula at normal location.
        /// </summary>
        /// <param name="range"></param>
        private void OpenEdit(Word.Range range) {

            // Load formula latex.
            editor.Text = $"Editor - Temproary";
            editor.inputLatex = "";
            //editor.outputScale = 2.0;

            // Edit it and retrieve output image.
            if(editor.ShowDialog() == DialogResult.OK) {
                if(editor.outputImage != null) {
                    Clipboard.SetDataObject(editor.outputImage);
                    range.Paste();
                    // Modify image scale.
                    foreach(Word.InlineShape ils in range.InlineShapes) {
                        if(ils != null && ils.Type == Word.WdInlineShapeType.wdInlineShapePicture) {
                            ils.ScaleWidth = (float)(100.0 / editor.outputScale);
                            ils.ScaleHeight = (float)(100.0 / editor.outputScale);
                        }
                    }
                }
            }
        }

        private void OpenEdit(Word.Table table) {

            // Load formula latex.
            var id = GetId(table);
            if(id is null) {
                id = "New";
                SetFormula(table, "", true);
            }
            editor.Text = $"Editor - {id}";
            editor.inputLatex = GetFormula(table);
            editor.SetInfo($">>> {id}\n");

            // Edit it and retrieve output image.
            if(editor.ShowDialog() == DialogResult.OK) {
                if(editor.outputImage != null) {
                    SetFormula(table, editor.inputLatex);
                    Clipboard.SetDataObject(editor.outputImage);
                    table.Cell(1, 1).Range.Paste();
                    // Modify image scale.
                    foreach(Word.InlineShape ils in table.Cell(1, 1).Range.InlineShapes) {
                        if(ils != null && ils.Type == Word.WdInlineShapeType.wdInlineShapePicture) {
                            ils.ScaleWidth = (float)(100.0 / editor.outputScale);
                            ils.ScaleHeight = (float)(100.0 / editor.outputScale);
                        }
                    }
                }
            }
        }


        #region MathTexWord Tools

        private string GenerateId() {
            return $"{IDHeader};{IDIndex++};{DateTime.Now.ToString("yyyyMMddHHmmss")}:\\sqrt{{A}}:{IDTail}";
        }

        private bool CheckDescr(Word.Table table) {
            return table.Descr != null 
                && table.Descr.Contains(IDHeader)
                && table.Descr.Contains(IDTail);
        }

        private string GetId(Word.Table table) {
            if(CheckDescr(table)) {
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start);
                return table.Descr.Substring(start, split - start);
            }
            return null;
        }

        private string GetFormula(Word.Table table) {
            if(CheckDescr(table)) {
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start) + 1;
                int end = table.Descr.IndexOf(IDTail) - 1;
                return table.Descr.Substring(split, end - split);
            }
            return null;
        }

        private void SetFormula(Word.Table table, string formula, bool newtab = false) {
            if(CheckDescr(table)) {
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start);
                int end = table.Descr.IndexOf(IDTail) + IDTail.Length;
                table.Descr = table.Descr.Substring(0, start)
                    + $"{table.Descr.Substring(start, split - start)}:{formula}:{IDTail}"
                    + table.Descr.Substring(end);
                return;
            }
            if(newtab) {
                if(table.Descr != null) {
                    if(table.Descr.StartsWith(IDHeader)) {
                        //TODO: I should delete this in later version.
                        table.Descr = "";
                    }
                }
                table.Descr += GenerateId();
                SetFormula(table, formula);
            }
        }

        #endregion MathTexWord Tools
    }
}
