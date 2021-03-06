using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        internal string SerializeObject(object obj)
        {
            this.CurrentStackLevel++;
            string json /*= string.Empty*/;

#warning building new version.
            //if (obj == null)
            //{
            //    #region null
            //    json = "null";
            //    #endregion

            //    this.CurrentStackLevel--;
            //    return json;
            //}
            //else
            //{
            //    Type type = obj.GetType();
            //    TypeCode typeCode = Type.GetTypeCode(type);
            //    switch (typeCode)
            //    {
            //        case TypeCode.Object:
            //            {
            //                if (1 == 1)
            //                {
            //                }
            //                else
            //                {
            //                    json = SerializeClass(obj);
            //                }
            //                break;
            //            }
            //        case TypeCode.DBNull:
            //            {
            //                json = "";
            //                break;
            //            }
            //        case TypeCode.Boolean:
            //            {
            //                json = SerializeBoolean((bool)obj);
            //                break;
            //            }
            //        case TypeCode.Char:
            //            {
            //                json = SerializeChar((char)obj);
            //                break;
            //            }
            //        default:
            //            {
            //                throw new InvalidEnumArgumentException("obj", (int)typeCode, typeof(TypeCode));
            //            }
            //    }
            //}

            //this.CurrentStackLevel--;
            //return json;

            #region null
            if (obj == null)
            {
                json = "null";
            }
            #endregion
            #region Boolean
            else if (obj is bool)
            {
                json = SerializeBoolean((bool)obj);
            }
            #endregion
            #region Byte
            else if (obj is byte)
            {
                json = SerializeByte((byte)obj);
            }
            #endregion
            #region Char
            else if (obj is char)
            {
                json = SerializeChar((char)obj);
            }
            #endregion
            #region Decimal
            else if (obj is decimal)
            {
                json = SerializeDecimal((decimal)obj);
            }
            #endregion
            #region Double
            else if (obj is double)
            {
                json = SerializeDouble((double)obj);
            }
            #endregion
            #region Int16
            else if (obj is short)
            {
                json = SerializeInt16((short)obj);
            }
            #endregion
            #region Int32
            else if (obj is int)
            {
                json = SerializeInt32((int)obj);
            }
            #endregion
            #region Int64
            else if (obj is long)
            {
                json = SerializeInt64((long)obj);
            }
            #endregion
            #region SByte
            else if (obj is sbyte)
            {
                json = SerializeSByte((sbyte)obj);
            }
            #endregion
            #region Single
            else if (obj is float)
            {
                json = SerializeSingle((float)obj);
            }
            #endregion
            #region String
            else if (obj is string)
            {
                json = SerializeString(obj as string);
            }
            #endregion
            #region UInt16
            else if (obj is ushort)
            {
                json = SerializeUInt16((ushort)obj);
            }
            #endregion
            #region UInt32
            else if (obj is uint)
            {
                json = SerializeUInt32((uint)obj);
            }
            #endregion
            #region UInt64
            else if (obj is ulong)
            {
                json = SerializeUInt64((ulong)obj);
            }
            #endregion
            #region Array
            else if (obj is Array)
            {
                json = SerializeArray(obj as Array);
            }
            #endregion
            #region BigInteger
            else if (obj is BigInteger)
            {
                json = SerializeBigInteger((BigInteger)obj);
            }
            #endregion
            #region DataTable
            else if (obj is DataTable)
            {
                json = SerializeDataTable((DataTable)obj);
            }
            #endregion
            #region DateTime
            else if (obj is DateTime)
            {
                json = SerializeDateTime((DateTime)obj);
            }
            #endregion
            #region Dictionary
            else if (obj is IDictionary)
            {
                json = SerializeDictionary(obj as IDictionary);
            }
            #endregion
            #region Enum
            else if (obj is Enum)
            {
                json = SerializeEnum(obj as Enum);
            }
            #endregion
            #region ExpandoObject
            else if (obj is ExpandoObject)
            {
                json = SerializeExpandoObject(obj as ExpandoObject);
            }
            #endregion
            #region Guid
            else if (obj is Guid)
            {
                json = SerializeGuid((Guid)obj);
            }
            #endregion
            #region Lazy
            else if (obj.GetType().IsGenericType == true && obj.GetType().GetGenericTypeDefinition() == typeof(Lazy<>))
            {
                json = SerializeLazy((dynamic)obj);
            }
            #endregion
            #region List
            else if (obj is IList)
            {
                json = SerializeList(obj as IList);
            }
            #endregion
            #region Nullable
            else if (obj.GetType().IsGenericType == true && obj.GetType().GetGenericTypeDefinition() == typeof(Nullable<>) && obj.GetType().GetElementType().IsValueType == true)
            {
                json = SerializeNullable(obj);
            }
            #endregion
            #region Regex
            else if (obj is Regex)
            {
                json = SerializeRegex(obj as Regex);
            }
            #endregion
            #region Uri
            else if (obj is Uri)
            {
                json = SerializeUri(obj as Uri);
            }
            #endregion
            #region Class
            else
            {
                json = SerializeClass(obj);
            }
            #endregion

            this.CurrentStackLevel--;
            return json;
        }
    }
}