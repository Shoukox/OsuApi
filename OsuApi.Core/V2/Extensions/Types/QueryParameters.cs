using System.Reflection;

namespace OsuApi.Core.V2.Extensions.Types
{
    public record QueryParameters(PropertyInfo[] QueryProperties, object ParametersClassInstance);
}
