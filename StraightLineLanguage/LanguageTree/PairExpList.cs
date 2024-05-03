namespace StraightLineLanguage.LanguageTree;

public class PairExpList(Exp head, PairExpList tail) : ExpList
{
    public Exp Head { get; set; } = head;
    public PairExpList Tail { get; set; } = tail;
}