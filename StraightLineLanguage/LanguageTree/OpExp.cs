using StraightLineLanguage.LanguageTree.Enums;

namespace StraightLineLanguage.LanguageTree;

internal record OpExp (Exp Left, Operation Operation, Exp Right) : Exp
{
}
