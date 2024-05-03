namespace StraightLineLanguage.LanguageTree;

public class LastExpList(Exp head) : ExpList
{
    public Exp Head { get; set; } = head;
}