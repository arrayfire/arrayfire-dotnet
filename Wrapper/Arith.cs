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
	public /*static*/ class Arith
	{
		// we can't make Arith static because Array<T> inherits from it (so the F# Core.Operators free functions work correctly)
		protected Arith() { }

        #region Mathematical Functions
#if _
	for (\w+) in
		Sin Sinh Asin Asinh
		Cos Cosh Acos Acosh
		Tan Tanh Atan Atanh
		Exp Expm1 Log Log10 Log1p Log2 Erf Erfc
		Sqrt Pow2 Cbrt
		LGamma TGamma
		Abs Sigmoid Factorial
		Round Trunc Floor Ceil
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> $1<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_$L1(out ptr, arr._ptr)); return new Array<T>(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Sin<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_sin(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Sinh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_sinh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Asin<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_asin(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Asinh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_asinh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Cos<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_cos(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Cosh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_cosh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Acos<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_acos(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Acosh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_acosh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Tan<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_tan(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Tanh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_tanh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Atan<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_atan(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Atanh<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_atanh(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Exp<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_exp(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Expm1<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_expm1(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Log<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_log(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Log10<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_log10(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Log1p<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_log1p(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Log2<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_log2(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Erf<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_erf(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Erfc<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_erfc(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Sqrt<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_sqrt(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Pow2<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_pow2(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Cbrt<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_cbrt(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> LGamma<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_lgamma(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> TGamma<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_tgamma(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Abs<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_abs(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Sigmoid<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_sigmoid(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Factorial<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_factorial(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Round<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_round(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Trunc<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_trunc(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Floor<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_floor(out ptr, arr._ptr)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Ceil<T>(Array<T> arr) { IntPtr ptr; Internal.VERIFY(af_arith.af_ceil(out ptr, arr._ptr)); return new Array<T>(ptr); }
#endif

#if _
	for (\w+) in
		Atan2 Rem Pow
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> $1<T>(Array<T> lhs, Array<T> rhs) { IntPtr ptr; Internal.VERIFY(af_arith.af_$L1(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Atan2<T>(Array<T> lhs, Array<T> rhs) { IntPtr ptr; Internal.VERIFY(af_arith.af_atan2(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Rem<T>(Array<T> lhs, Array<T> rhs) { IntPtr ptr; Internal.VERIFY(af_arith.af_rem(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array<T> Pow<T>(Array<T> lhs, Array<T> rhs) { IntPtr ptr; Internal.VERIFY(af_arith.af_pow(out ptr, lhs._ptr, rhs._ptr, false)); return new Array<T>(ptr); }
#endif
		#endregion
	}
}
