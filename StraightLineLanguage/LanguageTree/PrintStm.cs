namespace StraightLineLanguage.LanguageTree;

internal class PrintStm(ExpList exps) : Stm
{
    public ExpList Exps { get; set; } = exps;
}
