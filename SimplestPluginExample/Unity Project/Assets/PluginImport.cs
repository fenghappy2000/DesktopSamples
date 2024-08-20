using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginImport : MonoBehaviour
{
    //Lets make our calls from the Plugin
    [DllImport("ASimplePlugin", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintANumber();

    [DllImport("ASimplePlugin", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr PrintHello();

    [DllImport("ASimplePlugin", CallingConvention = CallingConvention.Cdecl)]
    private static extern int AddTwoIntegers(int i1, int i2);

    [DllImport("ASimplePlugin", CallingConvention = CallingConvention.Cdecl)]
    private static extern float AddTwoFloats(float f1, float f2);

	const string LUADLL = "xlua";
	
	[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int xlua_get_lib_version();

    void Start()
    {
        Debug.Log(PrintANumber());
        Debug.Log(Marshal.PtrToStringAnsi(PrintHello()));
        Debug.Log(AddTwoIntegers(2, 2));
        Debug.Log(AddTwoFloats(2.5F, 4F));
		
		int luav = xlua_get_lib_version();
		Debug.Log("xlua_get_lib_version: " + luav);
    }
}
