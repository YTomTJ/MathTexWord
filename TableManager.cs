using System;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    internal class TableManager {

        private static readonly string IDHeader = "##_MathTexWord";
        private static readonly string IDTail = "droWxeThtaM_##";

        internal static string GenerateId(Word.Table table) {
            var id = $"{IDHeader};{DateTime.Now:yyyyMMddHHmmss};{IDTail}";
            table.Title = id;
            return id;
        }

        internal static bool Check(Word.Table table) {
            return table.Title != null
                && table.Title.Contains(IDHeader)
                && table.Title.Contains(IDTail);
        }
    }

}
