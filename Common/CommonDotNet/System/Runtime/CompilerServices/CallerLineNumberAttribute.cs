﻿
namespace System.Runtime.CompilerServices
{
#if Net40
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CallerLineNumberAttribute : Attribute
    {
    }
#endif
}