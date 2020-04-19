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
    public static class Algorithm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex SumAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_sum_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object MinAll<T>(Array arr)
        {
            af_dtype dtype = Internal.toDType<T>();
            double r, i;
            switch(dtype)
            {
                case af_dtype.f32:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (float)r;
                case af_dtype.f64:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (double)r;
                case af_dtype.s32:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (int)r;
                case af_dtype.s64:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (long)r;
                case af_dtype.u32:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (uint)r;
                case af_dtype.u64:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (ulong)r;
                case af_dtype.u8:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (byte)r;
                case af_dtype.s16:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (short)r;
                case af_dtype.u16:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out _, arr._ptr));
                    return (ushort)r;
                case af_dtype.c32:
                case af_dtype.c64:
                    Internal.VERIFY(AFAlgorithm.af_min_all(out r, out i, arr._ptr));
                    return new Complex(r, i);
                default:
                    throw new NotSupportedException("Data type not supported");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object MaxAll<T>(Array arr)
        {
            af_dtype dtype = Internal.toDType<T>();
            double r, i;
            switch(dtype)
            {
                case af_dtype.f32:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (float)r;
                case af_dtype.f64:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (double)r;
                case af_dtype.s32:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (int)r;
                case af_dtype.s64:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (long)r;
                case af_dtype.u32:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (uint)r;
                case af_dtype.u64:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (ulong)r;
                case af_dtype.u8:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (byte)r;
                case af_dtype.s16:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (short)r;
                case af_dtype.u16:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out _, arr._ptr));
                    return (ushort)r;
                case af_dtype.c32:
                case af_dtype.c64:
                    Internal.VERIFY(AFAlgorithm.af_max_all(out r, out i, arr._ptr));
                    return new Complex(r, i);
                default:
                    throw new NotSupportedException("Data type not supported");
            }
        }
        // TODO: Add the other algorithms
    }
}
