namespace StraightLineLanguage.LanguageTree;

public class CompoundStm(Stm stm1, Stm stm2) : Stm
{
    public Stm Stm1 { get; set; } = stm1;
    public Stm Stm2 { get; set; } = stm2;
}
