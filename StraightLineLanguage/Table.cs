namespace StraightLineLanguage;

public record Table(string Key, int Value, Table? Tail = null)
{
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
}