namespace OsuApi.V2.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class QueryParameterAttribute : Attribute
{
    public string Name;

    public QueryParameterAttribute(string name)
    {
        Name = name;
    }
}