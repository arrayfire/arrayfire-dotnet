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
using static ArrayFire.Global;

namespace ArrayFire
{
	public class Array<T> : Arith, IDisposable // we inherit from Arith so the operations in F# Core.Operators module work correctly (e.g. sin, cos, abs)
	{
		internal IntPtr _ptr;

		internal Array(IntPtr pointer)
		{
#if DEBUG
			if (pointer == IntPtr.Zero) throw new ArgumentNullException("Invalid Array Pointer");
			af_dtype type;
			VERIFY(af_array.af_get_type(out type, pointer));
			if(type != toDType<T>()) throw new ArrayTypeMismatchException("Type mismatch: trying to wrap a " + type.ToString() + " into an Array<" + typeof(T).ToString() + ">");
#endif
			this._ptr = pointer;
			GCMan.OnAlloc();
		}

		#region Sizes and Dimensions
		public int DimCount
		{
			get
			{
				uint res;
				VERIFY(af_array.af_get_numdims(out res, _ptr));
				return (int)res;
			}
		}

		public int ElemCount
		{
			get
			{
				long res;
				VERIFY(af_array.af_get_elements(out res, _ptr));
				return (int)res;
			}
		}

		public Dim4 Dimensions
		{
			get
			{
				long d0, d1, d2, d3;
				VERIFY(af_array.af_get_dims(out d0, out d1, out d2, out d3, _ptr));
				return new Dim4((int)d0, (int)d1, (int)d2, (int)d3);
			}
		}
		#endregion

		#region Is___ Properties
#if _
	for (\w+) in
		Empty Scalar Row Column Vector
	do
		public bool Is$1 { get { bool res; VERIFY(af_array.af_is_$L1(out res, _ptr)); return res; } }
#else
		public bool IsEmpty { get { bool res; VERIFY(af_array.af_is_empty(out res, _ptr)); return res; } }
		public bool IsScalar { get { bool res; VERIFY(af_array.af_is_scalar(out res, _ptr)); return res; } }
		public bool IsRow { get { bool res; VERIFY(af_array.af_is_row(out res, _ptr)); return res; } }
		public bool IsColumn { get { bool res; VERIFY(af_array.af_is_column(out res, _ptr)); return res; } }
		public bool IsVector { get { bool res; VERIFY(af_array.af_is_vector(out res, _ptr)); return res; } }
#endif
		#endregion

		#region Operators
#if _
	for (\W)(\w+) in
		+add -sub *mul /div %mod &bitand |bitor ^bitxor
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator $1(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_$2(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator +(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_add(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator -(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_sub(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator *(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_mul(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator /(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_div(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator %(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_mod(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator &(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_bitand(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator |(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_bitor(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> operator ^(Array<T> lhs, Array<T> rhs) { IntPtr ptr; VERIFY(af_arith.af_bitxor(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }
#endif
		#endregion

		#region Casting
		public Array<X> Cast<X>()
		{
			IntPtr ptr;
			VERIFY(af_arith.af_cast(out ptr, _ptr, toDType<X>()));
			return new Array<X>(ptr);
		}
		#endregion

		#region IDisposable Support
		protected virtual void Dispose(bool disposing)
		{
			if (_ptr != IntPtr.Zero)
			{
				af_array.af_release_array(_ptr);
				_ptr = IntPtr.Zero;
				GCMan.OnRelease();
			}
			if (disposing) GC.SuppressFinalize(this);
		}

		~Array() { Dispose(false); }

		public void Dispose() { Dispose(true); }
		#endregion
	}
}
