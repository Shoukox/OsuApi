namespace OsuApi.Core.V2.Extensions
{
    public static class ApiUtility
    {
        /// <summary>
        /// Checks if the <paramref name="parameter"/> contains a value in some field of type <paramref name="type"/>
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <param name="type">The type the parameter should be checked for</param>
        public static void ThrowIfParameterValueIsNotOfType(string? parameter, Type type)
        {
            if (parameter != null &&
                !type.GetFields()
                     .Select(m => m.GetRawConstantValue())
                     .Contains(parameter)) throw new Exception();
        }
    }
}
