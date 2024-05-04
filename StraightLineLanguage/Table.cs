using StraightLineLanguage.LanguageTree;
using System.Collections;
using StraightLineLanguage.Extensions;

namespace StraightLineLanguage;

public record Table(string Key, int Value, Table? Tail = null) : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new TableEnum(this);
    }

    public int LookUp(string key)
    {
        if (Key == key)
        {
            return Value;
        }

        if (Tail is not null)
        {
            return Tail.LookUp(key);
        }

        return -1;
    }

    public static Table Append(Stm stm, Table? table) => stm switch
    {
        CompoundStm cStm => Append(cStm.Stm2, Append(cStm.Stm1, table)),
        AssignStm aStm => aStm.Exp.Evaluate(table) switch
        {
            (int val, Table newTable) => new Table(aStm.Id, val, newTable)
        },
        _ => table
    };

    public static Table EmptyTable() => new Table("-1", -1);

    public static Table HeaderTable(Table tail) => new Table("-1", -1, tail);
}

public class TableEnum(Table table) : IEnumerator
{
    private readonly Table _table = Table.HeaderTable(table);

    private Table _currentTable = Table.HeaderTable(table);

    object IEnumerator.Current => Current;

    public (string Key, int Value) Current => (_currentTable.Key, _currentTable.Value);

    public bool MoveNext()
    {
        if (_currentTable.Tail != Table.EmptyTable())
        {
            _currentTable = _currentTable.Tail!;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _currentTable = _table;
    }
}