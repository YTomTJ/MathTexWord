using System;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    [Obsolete]
    internal class TableManager {

        private static readonly string IDHeader = "##_MathTexWord";
        private static readonly string IDTail = "droWxeThtaM_##";
        private static ulong IDIndex = 0;

        internal static string GenerateId() {
            return $"{IDHeader};{IDIndex++};{DateTime.Now.ToString("yyyyMMddHHmmss")}:\\sqrt{{A}}:{IDTail}";
        }

        internal static bool CheckDescr(Word.Table table) {
            return table.Descr != null
                && table.Descr.Contains(IDHeader)
                && table.Descr.Contains(IDTail);
        }

        internal static string GetId(Word.Table table) {
            if(CheckDescr(table)) {
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start);
                return table.Descr.Substring(start, split - start);
            }
            return null;
        }

        internal static string GetFormula(Word.Table table) {
            if(CheckDescr(table)) {
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start) + 1;
                int end = table.Descr.IndexOf(IDTail) - 1;
                return table.Descr.Substring(split, end - split);
            }
            return null;
        }

        internal static void SetFormula(Word.Table table, string formula) {
            if(!CheckDescr(table)) {
                table.Descr = GenerateId();
            }
            if(formula != null) {
                // Insert formula
                int start = table.Descr.IndexOf(IDHeader);
                int split = table.Descr.IndexOf(':', start);
                int end = table.Descr.IndexOf(IDTail) + IDTail.Length;
                table.Descr = table.Descr.Substring(0, start)
                    + $"{table.Descr.Substring(start, split - start)}:{formula}:{IDTail}"
                    + table.Descr.Substring(end);
                return;
            }
        }
    }

}
