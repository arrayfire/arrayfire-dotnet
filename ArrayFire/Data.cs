/*
Copyright (c) 2015, ArrayFire
Copyright (c) 2015, Steven Burns (royalstream@hotmail.com)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of arrayfire_dotnet nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

using ArrayFire.Interop;

namespace ArrayFire
{
	public static class Data
	{
        #region Create array from host data
#if _
	for (\w+)=(\w+) in
		b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<$2> CreateArray($2[] data) { IntPtr ptr; Global.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array<$2>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<$2> CreateArray($2[,] data) { IntPtr ptr; Global.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array<$2>(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<bool> CreateArray(bool[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array<bool>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<bool> CreateArray(bool[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array<bool>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<Complex> CreateArray(Complex[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array<Complex>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<Complex> CreateArray(Complex[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array<Complex>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<float> CreateArray(float[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array<float>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<float> CreateArray(float[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array<float>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<double> CreateArray(double[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array<double>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<double> CreateArray(double[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array<double>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<int> CreateArray(int[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array<int>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<int> CreateArray(int[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array<int>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<long> CreateArray(long[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array<long>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<long> CreateArray(long[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array<long>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<uint> CreateArray(uint[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array<uint>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<uint> CreateArray(uint[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array<uint>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<ulong> CreateArray(ulong[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array<ulong>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<ulong> CreateArray(ulong[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array<ulong>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<byte> CreateArray(byte[] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array<byte>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<byte> CreateArray(byte[,] data) { IntPtr ptr; Internal.VERIFY(af_array.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array<byte>(ptr); }
#endif
        #endregion

        #region Random Arrays
#if _
	for (\w),(\w+) in
		u,Uniform
		n,Normal
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rand$2<T>(long[] dims)
		{
			IntPtr ptr;
			Global.VERIFY(af_data.af_rand$1(out ptr, (uint)dims.Length, dims, Global.toDType<T>()));
			return new Array<T>(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rand$2<T>(int d0) { return Rand$2<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rand$2<T>(int d0, int d1) { return Rand$2<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rand$2<T>(int d0, int d1, int d2) { return Rand$2<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rand$2<T>(int d0, int d1, int d2, int d3) { return Rand$2<T>(new long[] { d0, d1, d2, d3 }); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandUniform<T>(long[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(af_data.af_randu(out ptr, (uint)dims.Length, dims, Internal.toDType<T>()));
			return new Array<T>(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandUniform<T>(int d0) { return RandUniform<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandUniform<T>(int d0, int d1) { return RandUniform<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandUniform<T>(int d0, int d1, int d2) { return RandUniform<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandUniform<T>(int d0, int d1, int d2, int d3) { return RandUniform<T>(new long[] { d0, d1, d2, d3 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandNormal<T>(long[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(af_data.af_randn(out ptr, (uint)dims.Length, dims, Internal.toDType<T>()));
			return new Array<T>(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandNormal<T>(int d0) { return RandNormal<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandNormal<T>(int d0, int d1) { return RandNormal<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandNormal<T>(int d0, int d1, int d2) { return RandNormal<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> RandNormal<T>(int d0, int d1, int d2, int d3) { return RandNormal<T>(new long[] { d0, d1, d2, d3 }); }
#endif
		#endregion

		#region Complex Arrays from real data
		public static Array<Complex> CreateComplexArray(Array<double> real, Array<double> imag = null)
		{
			IntPtr ptr;
			if (imag != null) Internal.VERIFY(af_arith.af_cplx2(out ptr, real._ptr, imag._ptr, false));
			else Internal.VERIFY(af_arith.af_cplx(out ptr, real._ptr));
			return new Array<Complex>(ptr);
		}
        #endregion

        #region Get the arrays inner data
#if _
	for (\w+)=(\w+) in
		b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static $2[] GetData(Array<$2> arr)
		{
			$2[] data = new $2[arr.ElemCount];
			Global.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static $2[,] GetData2D(Array<$2> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			$2[,] data = new $2[dims.D0, dims.D1];
			Global.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool[] GetData(Array<bool> arr)
		{
			bool[] data = new bool[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool[,] GetData2D(Array<bool> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			bool[,] data = new bool[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Complex[] GetData(Array<Complex> arr)
		{
			Complex[] data = new Complex[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Complex[,] GetData2D(Array<Complex> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			Complex[,] data = new Complex[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float[] GetData(Array<float> arr)
		{
			float[] data = new float[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float[,] GetData2D(Array<float> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			float[,] data = new float[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double[] GetData(Array<double> arr)
		{
			double[] data = new double[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double[,] GetData2D(Array<double> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			double[,] data = new double[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int[] GetData(Array<int> arr)
		{
			int[] data = new int[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int[,] GetData2D(Array<int> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			int[,] data = new int[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long[] GetData(Array<long> arr)
		{
			long[] data = new long[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long[,] GetData2D(Array<long> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			long[,] data = new long[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint[] GetData(Array<uint> arr)
		{
			uint[] data = new uint[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint[,] GetData2D(Array<uint> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			uint[,] data = new uint[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong[] GetData(Array<ulong> arr)
		{
			ulong[] data = new ulong[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong[,] GetData2D(Array<ulong> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			ulong[,] data = new ulong[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] GetData(Array<byte> arr)
		{
			byte[] data = new byte[arr.ElemCount];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[,] GetData2D(Array<byte> arr)
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			byte[,] data = new byte[dims.D0, dims.D1];
			Internal.VERIFY(af_array.af_get_data_ptr(data, arr._ptr));
			return data;
		}
#endif
		#endregion
	}
}
