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
using System.Collections.Generic;
using System.Numerics;

using ArrayFire.Interop;

namespace ArrayFire
{
    internal static class Internal // shared functionality
    {
        private static Dictionary<Type, af_dtype> dtypes;

        static Internal()
        {
            dtypes = new Dictionary<Type, af_dtype>();

#if _
    for (\w+)=(\w+) in
            b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte
    do
            dtypes.Add(typeof($2), af_dtype.$1);
#else
            dtypes.Add(typeof(bool), af_dtype.b8);
            dtypes.Add(typeof(Complex), af_dtype.c64);
            dtypes.Add(typeof(float), af_dtype.f32);
            dtypes.Add(typeof(double), af_dtype.f64);
            dtypes.Add(typeof(int), af_dtype.s32);
            dtypes.Add(typeof(long), af_dtype.s64);
            dtypes.Add(typeof(uint), af_dtype.u32);
            dtypes.Add(typeof(ulong), af_dtype.u64);
            dtypes.Add(typeof(byte), af_dtype.u8);
#endif
        }

        internal static af_dtype toDType<T>() { return dtypes[typeof(T)]; }

        internal static void VERIFY(af_err err)
        {
            if (err != af_err.AF_SUCCESS) throw new ArrayFireException(err);
        }
    }
}
