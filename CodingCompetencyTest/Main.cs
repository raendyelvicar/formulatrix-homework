namespace CodingCompetencyTest;

public class Main
{
    public string CheckNum(int range)
    {
        List<string> listOfResult = new List<string>();
        for (int numToCheck = 1; numToCheck <= range; numToCheck++)
        {
            string result = string.Empty;
            foreach (var keyValue in Rules.KeyValuePair)
            {
                if (IsDivisible(numToCheck, keyValue.Key))
                {
                    result += keyValue.Value;
                }
            }

            listOfResult.Add(!string.IsNullOrEmpty(result) ? result : numToCheck.ToString());
        }
        
        string joinedRes = string.Join(", ", listOfResult);

        return joinedRes;
    }

    private bool IsDivisible(int num, int divisor)
    {
        return num % divisor == 0;
    }
}