using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace ObjectOrientedTest.Helpers;

public static class FormatValidation
{
    //Source: https://stackoverflow.com/questions/1026247/check-well-formed-xml-without-a-try-catchs
    public static bool IsValidXml(string xmlString)
    {
        Regex tagsWithData = new Regex("<\\w+>[^<]+</\\w+>");

        if (string.IsNullOrEmpty(xmlString) || tagsWithData.IsMatch(xmlString) == false)
        {
            return false;
        }

        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            return true;
        }
        catch (Exception e1)
        {
            return false;
        }
    }
    
    public static bool IsValidJson(string jsonString)
    {
        try
        {
            JsonDocument.Parse(jsonString);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}