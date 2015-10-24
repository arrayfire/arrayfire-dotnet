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
		b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte s16=short u16=ushort
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }
#endif
		#endregion

		#region Random Arrays
#if _
	for (\w),(\w+) in
		u,Uniform
		n,Normal
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rand$2<T>(long[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_rand$1(out ptr, (uint)dims.Length, dims, Internal.toDType<T>()));
			return new Array(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rand$2<T>(int d0) { return Rand$2<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rand$2<T>(int d0, int d1) { return Rand$2<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rand$2<T>(int d0, int d1, int d2) { return Rand$2<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rand$2<T>(int d0, int d1, int d2, int d3) { return Rand$2<T>(new long[] { d0, d1, d2, d3 }); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandUniform<T>(long[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_randu(out ptr, (uint)dims.Length, dims, Internal.toDType<T>()));
			return new Array(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandUniform<T>(int d0) { return RandUniform<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandUniform<T>(int d0, int d1) { return RandUniform<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandUniform<T>(int d0, int d1, int d2) { return RandUniform<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandUniform<T>(int d0, int d1, int d2, int d3) { return RandUniform<T>(new long[] { d0, d1, d2, d3 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandNormal<T>(long[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_randn(out ptr, (uint)dims.Length, dims, Internal.toDType<T>()));
			return new Array(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandNormal<T>(int d0) { return RandNormal<T>(new long[] { d0 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandNormal<T>(int d0, int d1) { return RandNormal<T>(new long[] { d0, d1 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandNormal<T>(int d0, int d1, int d2) { return RandNormal<T>(new long[] { d0, d1, d2 }); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array RandNormal<T>(int d0, int d1, int d2, int d3) { return RandNormal<T>(new long[] { d0, d1, d2, d3 }); }
#endif
		#endregion

		#region Complex Arrays from real data
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateComplexArray(Array real, Array imag = null)
		{
			IntPtr ptr;
			if (imag != null) Internal.VERIFY(AFArith.af_cplx2(out ptr, real._ptr, imag._ptr, false));
			else Internal.VERIFY(AFArith.af_cplx(out ptr, real._ptr));
			return new Array(ptr);
		}
		#endregion

		#region Get the arrays inner data
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] GetData<T>(Array arr) // not called GetData1D because it works for arrays of any dimensionality
		{
			T[] data = new T[arr.ElemCount];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] GetData2D<T>(Array arr) // only works for 2D arrays
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D2 * dims.D3 > 1) throw new NotSupportedException("This array has more than two dimensions");
			T[,] data = new T[dims.D0, dims.D1];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,] GetData3D<T>(Array arr) // only works for 3D arrays
		{
			Dim4 dims = arr.Dimensions;
			if (dims.D3 > 1) throw new NotSupportedException("This array has more than three dimensions");
			T[,,] data = new T[dims.D0, dims.D1, dims.D2];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,,] GetData4D<T>(Array arr)
		{
			Dim4 dims = arr.Dimensions;
			T[,,,] data = new T[dims.D0, dims.D1, dims.D2, dims.D3];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}
		#endregion

		#region Casting
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Cast<X>(Array arr)
		{
			IntPtr ptr;
			Internal.VERIFY(AFArith.af_cast(out ptr, arr._ptr, Internal.toDType<X>()));
			return new Array(ptr);
		}
		#endregion
	}
}
