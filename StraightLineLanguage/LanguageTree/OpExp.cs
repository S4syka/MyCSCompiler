using StraightLineLanguage.LanguageTree.Enums;

namespace StraightLineLanguage.LanguageTree;

public record OpExp (Exp Left, Operation Operation, Exp Right) : Exp
{
}
