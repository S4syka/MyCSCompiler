using StraightLineLanguage;
using StraightLineLanguage.Extensions;
using StraightLineLanguage.LanguageTree;
using StraightLineLanguage.LanguageTree.Enums;

Stm prog = new CompoundStm(
       new AssignStm("a", new OpExp(new NumExp(5), Operation.Plus, new NumExp(3))),
          new CompoundStm(
                     new AssignStm("b", new EseqExp(
                                    new PrintStm(new PairExpList(new IdExp("a"), new LastExpList(new OpExp(new IdExp("a"), Operation.Minus, new NumExp(1))))),
                                               new OpExp(new NumExp(10), Operation.Times, new IdExp("a"))
                                                      )),
                            new PrintStm(new LastExpList(new IdExp("b")))
                               )
          );


var table = Table.Append(prog, Table.EmptyTable());

foreach (var item in table)
{
    Console.WriteLine(item);
}

Console.WriteLine(table);