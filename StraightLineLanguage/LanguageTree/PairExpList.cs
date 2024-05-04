namespace StraightLineLanguage.LanguageTree;

public record PairExpList(Exp Head, LastExpList Tail) : ExpList
{
}