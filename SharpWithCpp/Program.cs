using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWithCpp
{
	using System.Runtime.InteropServices;

	class Program
	{
		[DllImport(@"MD5Library.DLL", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		public static extern IntPtr GetMd5([MarshalAs(UnmanagedType.LPStr)]string arg, int count);

		static void Main(string[] args) {
			IntPtr ptr = GetMd5("blabla",100000);
			Console.WriteLine("Result: " + PtrToStringUtf8(ptr));

			Console.ReadKey();
		}

		private static string PtrToStringUtf8(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
				return "";
			int len = 0;
			while (Marshal.ReadByte(ptr, len) != 0)
				len++;
			if (len == 0)
				return "";
			var array = new byte[len];
			Marshal.Copy(ptr, array, 0, len);
			return Encoding.UTF8.GetString(array);
		}

	}
}
