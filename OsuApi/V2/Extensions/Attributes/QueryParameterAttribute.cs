namespace OsuApi.V2.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class QueryParameterAttribute : Attribute
    {
        public string Name;

        public QueryParameterAttribute(string name)
        {
            Name = name;
        }
    }
}
