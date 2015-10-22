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

	public static class Matrix
	{
		public static Array<T> Multiply<T>(Array<T> lhs, Array<T> rhs, MatMulOp lop = MatMulOp.None, MatMulOp rop = MatMulOp.None)
		{
			IntPtr ptr;
            Internal.VERIFY(af_blas.af_matmul(out ptr, lhs._ptr, rhs._ptr, (af_mat_prop)lop, (af_mat_prop)rop));
			return new Array<T>(ptr);
		}

		public static void TransposeInPlace<T>(Array<T> arr, bool conjugate)
		{
            Internal.VERIFY(af_blas.af_transpose_inplace(arr._ptr, conjugate));
		}

		public static Array<T> Transpose<T>(Array<T> arr, bool conjugate)
		{
			IntPtr ptr;
            Internal.VERIFY(af_blas.af_transpose(out ptr, arr._ptr, conjugate));
			return new Array<T>(ptr);
		}

		public static double Det(Array<double> arr)
		{
			double r, i;
            Internal.VERIFY(af_lapack.af_det(out r, out i, arr._ptr));
			return r;
		}

		public static float Det(Array<float> arr)
		{
			double r, i;
            Internal.VERIFY(af_lapack.af_det(out r, out i, arr._ptr));
			return (float)r;
		}

		public static Complex Det(Array<Complex> arr)
		{
			double r, i;
            Internal.VERIFY(af_lapack.af_det(out r, out i, arr._ptr));
			return new Complex(r, i);
		}

		public static Array<T> Inverse<T>(Array<T> arr)
		{
			IntPtr ptr;
            Internal.VERIFY(af_lapack.af_inverse(out ptr, arr._ptr, af_mat_prop.AF_MAT_NONE));
			return new Array<T>(ptr);
		}
	}
}
