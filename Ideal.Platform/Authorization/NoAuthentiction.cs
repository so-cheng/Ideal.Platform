using Microsoft.AspNetCore.Mvc.Filters;

namespace Ideal.Platform.Authorization
{
    public class NoAuthentiction : Attribute, IFilterMetadata
    {
    }
}
