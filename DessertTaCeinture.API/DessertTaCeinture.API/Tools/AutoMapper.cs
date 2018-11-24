using System;
using System.Reflection;

namespace DessertTaCeinture.API.Tools
{
    public static class AutoMapper<TInput, TOutput>
    {
        public static TOutput AutoMap(TInput input)
        {
            TOutput output = Activator.CreateInstance<TOutput>();
            foreach (PropertyInfo pi in output.GetType().GetProperties())
            {
                var value = input.GetType().GetProperty(pi.Name)?.GetValue(input);
                if (value != null) pi.SetValue(output, value);
            }
            return output;
        }
    }
}