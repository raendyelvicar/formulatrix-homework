namespace CodingCompetencyTest;

public static class Rules
{
    public static readonly Dictionary<int, string> KeyValuePair = new()
    {
        { 3, "foo" },  
        { 5, "bar" }, 
    };
    
    public static void AddRule(int input, string output)
    {
        KeyValuePair.Add(input, output);
    }
}