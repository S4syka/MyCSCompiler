namespace StraightLineLanguage.LanguageTree;

public class AssignStm (string id, Exp exp)
{
    public string Id { get; set; } = id;

    public Exp Exp { get; set; } = exp;
}
