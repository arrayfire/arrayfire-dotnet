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
        public static Array Sum(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_sum(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Sum(Array arr, int dim, double nanval)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_sum_nan(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions), nanval));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Product(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_product(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Product(Array arr, int dim, double nanval)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_product_nan(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions), nanval));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Min(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_min(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Max(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_max(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array AllTrue(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_all_true(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array AnyTrue(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_any_true(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Count(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_count(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex SumAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_sum_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex SumAll(Array arr, double nanval)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_sum_nan_all(out r, out i, arr._ptr, nanval));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex ProductAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_product_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex ProductAll(Array arr, double nanval)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_product_nan_all(out r, out i, arr._ptr, nanval));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex MinAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_min_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex MaxAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_max_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex AllTrueAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_all_true_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex AnyTrueAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_any_true_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex CountAll(Array arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_count_all(out r, out i, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Min(Array arr, out Array idx ,int dim = -1)
        {
            IntPtr outPtr;
            IntPtr idxPtr;
            Internal.VERIFY(AFAlgorithm.af_imin(out outPtr, out idxPtr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            idx = new Array(idxPtr);
            return new Array(outPtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Max(Array arr, out Array idx, int dim = -1)
        {
            IntPtr outPtr;
            IntPtr idxPtr;
            Internal.VERIFY(AFAlgorithm.af_imax(out outPtr, out idxPtr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            idx = new Array(idxPtr);
            return new Array(outPtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex MinAll(Array arr, out uint idx)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_imin_all(out r, out i, out idx ,arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex MaxAll(Array arr, out uint idx)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_imax_all(out r, out i, out idx, arr._ptr));
            return new Complex(r, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Accumulate(Array arr, int dim = -1)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_accum(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions)));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Scan(Array arr, int dim, af_binary_op op, bool inclusive_scan = true)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_scan(out ptr, arr._ptr, getFNSD(dim, arr.Dimensions), op, inclusive_scan));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array ScanByKey(Array key, Array arr, int dim, af_binary_op op, bool inclusive_scan = true)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_scan_by_key(out ptr, key._ptr, arr._ptr, getFNSD(dim, arr.Dimensions), op, inclusive_scan));
            return new Array(ptr);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Where(Array arr)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_where(out ptr, arr._ptr));
            return new Array(ptr);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Diff1(Array arr, int dim = 0)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_diff1(out ptr, arr._ptr, dim));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Diff2(Array arr, int dim = 0)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_diff2(out ptr, arr._ptr, dim));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Sort(Array arr, uint dim = 0, bool isAscending = true)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_sort(out ptr, arr._ptr, dim, isAscending));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Sort(Array arr, out Array indices, uint dim = 0, bool isAscending = true)
        {
            IntPtr outPtr, indPtr;
            Internal.VERIFY(AFAlgorithm.af_sort_index(out outPtr, out indPtr , arr._ptr, dim, isAscending));
            indices = new Array(indPtr);
            return new Array(outPtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array Sort(out Array outValues, Array keys, Array values, uint dim = 0, bool isAscending = true)
        {
            IntPtr outKeyPtr;
            IntPtr outValPtr;
            Internal.VERIFY(AFAlgorithm.af_sort_by_key(out outKeyPtr, out outValPtr, keys._ptr, values._ptr, dim, isAscending));
            outValues = new Array(outValPtr);
            return new Array(outKeyPtr);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array SetUnique(Array arr, bool isSorted = false)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_set_unique(out ptr, arr._ptr, isSorted));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array SetUnion(Array arr1, Array arr2, bool isUnique = false)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_set_union(out ptr, arr1._ptr, arr2._ptr, isUnique));
            return new Array(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array SetIntersect(Array arr1, Array arr2, bool isUnique = false)
        {
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_set_intersect(out ptr, arr1._ptr, arr2._ptr, isUnique));
            return new Array(ptr);
        }

        /// Get the first non-zero dimension
        private static int getFNSD(int dim, int[] dims) 
        {
            if (dim >= 0) return dim;

            for (int i = 0; i < 4; ++i)
            {
                if (dims[i] > 1)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
