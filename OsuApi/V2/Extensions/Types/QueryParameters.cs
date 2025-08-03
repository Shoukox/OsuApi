using System.Reflection;

namespace OsuApi.V2.Extensions.Types;

public record QueryParameters(PropertyInfo[] QueryProperties, object ParametersClassInstance);