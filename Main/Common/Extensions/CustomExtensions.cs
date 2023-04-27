using System.Linq.Dynamic.Core;
using UpdateDataWithDynamicLinq.DB;

namespace UpdateDataWithDynamicLinq.Common.Extensions;
// Add extension method:
public static class DBContextExtensions
{

    public static IQueryable<object> Get(this MyContext _context, Type t)
    {
        return (IQueryable<object>)_context.GetType().GetMethod($"get_{t.Name}").Invoke(_context, null);
    }

    // Or the modified set which handles ambigous ref issues:
    public static IQueryable<object> Set(this MyContext _context, Type t)
    {
        return (IQueryable<object>)_context.GetType().GetMethods()
                .First(x => x.Name == "Set" && x.ContainsGenericParameters)
                .MakeGenericMethod(t).Invoke(_context, null);
    }
}


