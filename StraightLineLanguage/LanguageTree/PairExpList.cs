namespace StraightLineLanguage.LanguageTree;

public record PairExpList(Exp Head, PairExpList Tail) : ExpList
{
}