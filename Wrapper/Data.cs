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
        #region Create/Write array from host data
#if _
	for (\w+)=(\w+) in
		b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte s16=short u16=ushort
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, $2[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, $2[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, $2[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray($2[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.$1)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, $2[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, bool[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, bool[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, bool[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(bool[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.b8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, bool[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, Complex[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, Complex[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, Complex[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(Complex[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.c64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, Complex[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, float[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, float[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, float[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(float[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, float[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, double[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, double[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, double[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(double[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.f64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, double[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, int[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, int[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, int[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(int[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, int[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, long[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, long[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, long[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(long[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, long[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, uint[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, uint[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, uint[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(uint[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u32)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, uint[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ulong[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ulong[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ulong[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ulong[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u64)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ulong[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, byte[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, byte[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, byte[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(byte[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u8)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, byte[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, short[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, short[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, short[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(short[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.s16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, short[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ushort[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ushort[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ushort[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array CreateArray(ushort[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, af_dtype.u16)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteArray(Array arr, ushort[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, (UIntPtr)(sizeof(bool) * data.Length), af_source.afHost)); }
#endif
        #endregion

        #region Random Arrays
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array RandUniform<T>(params int[] dims)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_randu(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array RandNormal<T>(params int[] dims)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_randn(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
            return new Array(ptr);
        }

        public static ulong RandSeed
        {
            get { ulong value; Internal.VERIFY(AFData.af_get_seed(out value)); return value; }
            set { Internal.VERIFY(AFData.af_set_seed(value)); }
        }
        #endregion

        #region Constant, Iota, Range, Identity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Constant<T>(T value, params int[] dims)
        {
            IntPtr ptr;
            object boxval = value;
            af_dtype dtype = Internal.toDType<T>();
            switch (dtype)
            {
                case af_dtype.u64:
                    Internal.VERIFY(AFData.af_constant_ulong(out ptr, (ulong)boxval, (uint)dims.Length, Internal.toLongArray(dims)));
                    break;
                case af_dtype.s64:
                    Internal.VERIFY(AFData.af_constant_long(out ptr, (long)boxval, (uint)dims.Length, Internal.toLongArray(dims)));
                    break;
                case af_dtype.c64:
                    Complex z = (Complex)boxval;
                    Internal.VERIFY(AFData.af_constant_complex(out ptr, z.Real, z.Imaginary, (uint)dims.Length, Internal.toLongArray(dims), dtype));
                    break;
                default:
                    Internal.VERIFY(AFData.af_constant(out ptr, (double)Convert.ChangeType(boxval, typeof(double)), (uint)dims.Length, Internal.toLongArray(dims), dtype));
                    break;
            }
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Iota<T>(int[] dims, int[] tiles)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_iota(out ptr, (uint)dims.Length, Internal.toLongArray(dims), (uint)tiles.Length, Internal.toLongArray(tiles), Internal.toDType<T>()));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Iota<T>(params int[] dims)
        {
            return Iota<T>(dims, new int[] { 1 });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array RangeAlong<T>(int seq_dim, params int[] dims)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_range(out ptr, (uint)dims.Length, Internal.toLongArray(dims), seq_dim, Internal.toDType<T>()));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Range<T>(params int[] dims)
        {
            return RangeAlong<T>(-1, dims); // -1 is the default according to af_range's documentation
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Identity<T>(params int[] dims)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_identity(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
            return new Array(ptr);
        }
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

		#region Get the array inner data
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
			int[] dims = arr.Dimensions;
			if (dims[2] * dims[3] > 1) throw new NotSupportedException("This array has more than two dimensions");
			T[,] data = new T[dims[0], dims[1]];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,] GetData3D<T>(Array arr) // only works for 3D arrays
		{
            int[] dims = arr.Dimensions;
			if (dims[3] > 1) throw new NotSupportedException("This array has more than three dimensions");
			T[,,] data = new T[dims[0], dims[1], dims[2]];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,,] GetData4D<T>(Array arr)
		{
            int[] dims = arr.Dimensions;
			T[,,,] data = new T[dims[0], dims[1], dims[2], dims[3]];
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
