using StraightLineLanguage.LanguageTree.Enums;

namespace StraightLineLanguage.LanguageTree;

internal class OpExp (Exp left, Operation operation, Exp right)
{
    public Exp Left { get; set; } = left;
    public Exp Right { get; set; } = right;
    public Operation Operation { get; set; } = operation;
}
