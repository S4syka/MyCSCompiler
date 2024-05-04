using System.Security.AccessControl;
using StraightLineLanguage.LanguageTree;

namespace StraightLineLanguage.Extensions;

public static class LanguageExtension
{
    public static int MaxArgs(this Stm stm) => stm switch
    {
        CompoundStm cStm => Math.Max(cStm.Stm1.MaxArgs(), cStm.Stm2.MaxArgs()),
        AssignStm aStm => aStm.Exp.MaxArgs(),
        PrintStm pStm => pStm.ExpList.Length(),
        _ => 0
    };

    public static int MaxArgs(this Exp exp) => exp switch
    {
        IdExp => 0,
        NumExp => 0,
        OpExp oExp => Math.Max(oExp.Left.MaxArgs(), oExp.Right.MaxArgs()),
        EseqExp eExp => Math.Max(eExp.Stm.MaxArgs(), eExp.Exp.MaxArgs()),
        _ => 0
    };

    public static int Length(this ExpList expList) => expList switch
    {
        PairExpList pair => 1 + pair.Tail.Length(),
        LastExpList => 1,
        _ => 0
    };
}