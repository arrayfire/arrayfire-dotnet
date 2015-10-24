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
	// we can't make Arith static because Array inherits from it (so the F# Core.Operators free functions work correctly)
	public /*static*/ class Arith
	{
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
		public static Array $1(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_$L1(out ptr, arr._ptr)); return new Array(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Sin(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sin(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Sinh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sinh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Asin(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asin(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Asinh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asinh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Cos(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cos(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Cosh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cosh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Acos(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acos(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Acosh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acosh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Tan(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tan(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Tanh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tanh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Atan(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atan(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Atanh(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atanh(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Exp(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_exp(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Expm1(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_expm1(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Log(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Log10(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log10(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Log1p(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log1p(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Log2(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log2(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Erf(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erf(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Erfc(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erfc(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Sqrt(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sqrt(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Pow2(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow2(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Cbrt(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cbrt(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array LGamma(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_lgamma(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array TGamma(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tgamma(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Abs(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_abs(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Sigmoid(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sigmoid(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Factorial(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_factorial(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Round(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_round(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Trunc(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_trunc(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Floor(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_floor(out ptr, arr._ptr)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Ceil(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_ceil(out ptr, arr._ptr)); return new Array(ptr); }
#endif

#if _
	for (\w+) in
		Atan2 Rem Pow
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array $1(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_$L1(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Atan2(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_atan2(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Rem(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_rem(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array Pow(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }
#endif
		#endregion
	}
}
