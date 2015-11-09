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
using System.Threading;
using System.Runtime.CompilerServices;

using ArrayFire.Interop;

namespace ArrayFire
{
	public class Array : Arith, IDisposable // we inherit from Arith so the operations in F# Core.Operators module work correctly (e.g. sin, cos, abs)
	{
		private static int _instances = 0;

		internal IntPtr _ptr;

		internal Array(IntPtr pointer)
		{
#if DEBUG
			if (pointer == IntPtr.Zero) throw new ArgumentNullException("Invalid Array Pointer");
#endif
			this._ptr = pointer;
			Interlocked.Increment(ref _instances);
			if (_instances % 50 == 0) // only do it every time we allocated new 50 instances, we can tweak this
			{
				UIntPtr bytes, buffers, lockbytes, lockbuffers;
				Internal.VERIFY(AFDevice.af_device_mem_info(out bytes, out buffers, out lockbytes, out lockbuffers));
				// code borrowed from the R wrapper:
				if ((double)lockbytes > Math.Pow(1000, 3) || (double)lockbuffers > 50) GC.Collect();
			}
		}

		#region Sizes, Dimensions, Type
		public int DimCount
		{
			get
			{
				uint res;
				Internal.VERIFY(AFArray.af_get_numdims(out res, _ptr));
				return (int)res;
			}
		}

		public int ElemCount
		{
			get
			{
				long res;
				Internal.VERIFY(AFArray.af_get_elements(out res, _ptr));
				return (int)res;
			}
		}

		public int[] Dimensions
		{
			get
			{
                int[] result = new int[DimCount];
				long d0, d1, d2, d3;
				Internal.VERIFY(AFArray.af_get_dims(out d0, out d1, out d2, out d3, _ptr));
                result[0] = (int)d0;
                if (result.Length > 1)
                {
                    result[1] = (int)d1;
                    if (result.Length > 2)
                    {
                        result[2] = (int)d2;
                        if (result.Length > 3) result[3] = (int)d3;
                    }
                }
                return result;
			}
		}

		public Type ElemType
		{
			get
			{
				af_dtype dtype;
				Internal.VERIFY(AFArray.af_get_type(out dtype, _ptr));
				return Internal.toClrType(dtype);
			}
		}
		#endregion

		#region Is___ Properties
#if _
	for (\w+) in
		Empty Scalar Row Column Vector
	do
		public bool Is$1 { get { bool res; Internal.VERIFY(AFArray.af_is_$L1(out res, _ptr)); return res; } }
#else
		public bool IsEmpty { get { bool res; Internal.VERIFY(AFArray.af_is_empty(out res, _ptr)); return res; } }
		public bool IsScalar { get { bool res; Internal.VERIFY(AFArray.af_is_scalar(out res, _ptr)); return res; } }
		public bool IsRow { get { bool res; Internal.VERIFY(AFArray.af_is_row(out res, _ptr)); return res; } }
		public bool IsColumn { get { bool res; Internal.VERIFY(AFArray.af_is_column(out res, _ptr)); return res; } }
		public bool IsVector { get { bool res; Internal.VERIFY(AFArray.af_is_vector(out res, _ptr)); return res; } }
#endif
		#endregion

		#region Operators
#if _
	for (\W)(\w+) in
		+add -sub *mul /div %mod &bitand |bitor ^bitxor
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator $1(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_$2(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator +(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_add(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator -(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_sub(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator *(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_mul(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator /(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_div(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator %(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_mod(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator &(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_bitand(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator |(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_bitor(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array operator ^(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_bitxor(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }
#endif
		#endregion

		#region IDisposable Support
		protected virtual void Dispose(bool disposing)
		{
			if (_ptr != IntPtr.Zero)
			{
				AFArray.af_release_array(_ptr);
				_ptr = IntPtr.Zero;
				Interlocked.Decrement(ref _instances);
			}
			if (disposing) GC.SuppressFinalize(this);
		}

		~Array() { Dispose(false); }

		public void Dispose() { Dispose(true); }
		#endregion
	}
}
