namespace StraightLineLanguage.LanguageTree;

public class EseqExp(Stm stm, Exp exp) : Exp
{
    public Stm Stm { get; set; } = stm;
    public Exp Exp { get; set; } = exp;
}