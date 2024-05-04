using System.Data;
using StraightLineLanguage.LanguageTree;
using StraightLineLanguage.LanguageTree.Enums;

namespace StraightLineLanguage.Extensions;

public static class LanguageExtension
{
    public static int MaxArgs(this Stm stm) => stm switch
    {
        CompoundStm cStm => Math.Max(cStm.Stm1.MaxArgs(), cStm.Stm2.MaxArgs()),
        AssignStm aStm => aStm.Exp.MaxArgs(),
        PrintStm pStm => pStm.ExpList.MaxArgs(),
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

    public static int MaxArgs(this ExpList expList) => expList switch
    {
        PairExpList pair => Math.Max(1, pair.Head.MaxArgs()) + pair.Tail.MaxArgs(),
        LastExpList last => Math.Max(1, last.Head.MaxArgs()),
        _ => 0
    };

    public static (int Val, Table) Evaluate(this Exp exp, Table table) => exp switch
    {
        IdExp idExp => (table.LookUp(idExp.Id), table),
        NumExp numExp => (numExp.Num, table),
        OpExp oExp => oExp.Operation switch
        {
            Operation.Plus => (oExp.Left.Evaluate(table).Val + oExp.Right.Evaluate(table).Val, table),
            Operation.Minus => (oExp.Left.Evaluate(table).Val - oExp.Right.Evaluate(table).Val, table),
            Operation.Times => (oExp.Left.Evaluate(table).Val * oExp.Right.Evaluate(table).Val, table),
            Operation.Div => (oExp.Left.Evaluate(table).Val / oExp.Right.Evaluate(table).Val, table),
            _ => (0, table)
        },
        EseqExp eExp => eExp.Exp.Evaluate(Append(eExp.Stm, table))
    };

    public static Table Append(Stm stm, Table? table) => stm switch
    {
        CompoundStm cStm => Append(cStm.Stm2, Append(cStm.Stm1, table)),
        AssignStm aStm => aStm.Exp.Evaluate(table) switch
        {
            (int val, Table newTable) => new Table(aStm.Id, val, newTable)
        },
        _ => table
    };
}