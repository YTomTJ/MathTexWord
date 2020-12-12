using System;
using Word = Microsoft.Office.Interop.Word;

namespace MathTexWord {

    internal class ShapeManager {

        internal static readonly string IDHeader = "##_MathTexWord";
        internal static readonly string IDTail = "droWxeThtaM_##";
        internal static ulong IDIndex = 0;

        internal static string GenerateId() {
            return $"{IDHeader};{IDIndex++};{DateTime.Now.ToString("yyyyMMddHHmmss")}:\\sqrt{{A}}:{IDTail}";
        }

        internal static bool CheckDescr(Word.InlineShape shape) {
            return shape.Title != null
                && shape.Title.Contains(IDHeader)
                && shape.Title.Contains(IDTail);
        }

        internal static string GetId(Word.InlineShape shape) {
            if(CheckDescr(shape)) {
                int start = shape.Title.IndexOf(IDHeader);
                int split = shape.Title.IndexOf(':', start);
                return shape.Title.Substring(start, split - start);
            }
            return null;
        }

        internal static string GetFormula(Word.InlineShape shape) {
            if(CheckDescr(shape)) {
                int start = shape.Title.IndexOf(IDHeader);
                int split = shape.Title.IndexOf(':', start) + 1;
                int end = shape.Title.IndexOf(IDTail) - 1;
                return shape.Title.Substring(split, end - split);
            }
            return null;
        }

        internal static string SetFormula(Word.InlineShape shape, string formula = null) {
            if(!CheckDescr(shape)) {
                shape.Title = GenerateId();
            }
            if(formula != null) {
                int start = shape.Title.IndexOf(IDHeader);
                int split = shape.Title.IndexOf(':', start);
                int end = shape.Title.IndexOf(IDTail) + IDTail.Length;
                shape.Title = shape.Title.Substring(0, start)
                    + $"{shape.Title.Substring(start, split - start)}:{formula}:{IDTail}"
                    + shape.Title.Substring(end);
            }
            return shape.Title;
        }
    }

}
