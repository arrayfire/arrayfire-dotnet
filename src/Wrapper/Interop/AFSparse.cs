// This file was automatically generated using the AutoGenTool project
// If possible, edit the tool instead of editing this file directly

using System;
using System.Text;
using System.Numerics;
using System.Security;
using System.Runtime.InteropServices;

namespace ArrayFire.Interop
{
	[SuppressUnmanagedCodeSecurity]
	public static class AFSparse
	{
		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_create_sparse_array(out IntPtr array_out, long dim_nRows, long dim_nCols, IntPtr array_values, IntPtr array_rowIdx, IntPtr array_colIdx, af_storage stype);

		/* not yet supported:
		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_create_sparse_array_from_ptr(out IntPtr array_out, long dim_nRows, long dim_nCols, long dim_nNZ, [In] T[_] values, ???const int * const rowIdx???, ???const int * const colIdx???, af_dtype type, af_storage stype, af_source src); */

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_create_sparse_array_from_dense(out IntPtr array_out, IntPtr array_dense, af_storage stype);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_convert_to(out IntPtr array_out, IntPtr array_in, af_storage destStorage);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_to_dense(out IntPtr array_out, IntPtr array_sparse);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_info(out IntPtr array_values, out IntPtr array_rowIdx, out IntPtr array_colIdx, out af_storage stype, IntPtr array_in);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_values(out IntPtr array_out, IntPtr array_in);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_row_idx(out IntPtr array_out, IntPtr array_in);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_col_idx(out IntPtr array_out, IntPtr array_in);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_nnz(out long dim_out, IntPtr array_in);

		[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
		public static extern af_err af_sparse_get_storage(out af_storage output, IntPtr array_in);
	}
}
