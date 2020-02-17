﻿using System;
using System.Runtime.InteropServices;

namespace OpenToolkit.Audio.OpenAL.Native
{
    internal class ConstCharPtrMarshaler : ICustomMarshaler
    {
        private static readonly ConstCharPtrMarshaler Instance = new ConstCharPtrMarshaler();

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            switch (ManagedObj)
            {
                case string str:
                    return Marshal.StringToHGlobalAnsi(str);
                default:
                    throw new ArgumentException($"{nameof(ConstCharPtrMarshaler)} only supports marshaling of strings. Got '{ManagedObj.GetType()}'");
            }
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return Marshal.PtrToStringAnsi(pNativeData);
        }

        // See https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.custommarshalers.typetotypeinfomarshaler.getinstance
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return Instance;
        }
    }
}
