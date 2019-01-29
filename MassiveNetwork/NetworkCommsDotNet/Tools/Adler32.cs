﻿// 
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
// 

using System;

namespace NetworkCommsDotNet.Tools
{
    /// <summary>
    /// Implementation of the <see href="http://en.wikipedia.org/wiki/Adler-32">Adler32</see> checksum algorithm. 
    /// It is not a particularly reliable checksum compared with <see href="http://en.wikipedia.org/wiki/MD5">MD5</see> but it is about 10 times faster.
    /// NetworkComms.Net uses <see href="http://en.wikipedia.org/wiki/MD5">MD5</see> as its default but this class is provided should speed be the more important factor.
    /// </summary>
    public static class Adler32Checksum
    {
        /// <summary>
        /// Generate an Adler32 checksum value based on the provided byte array.
        /// </summary>
        /// <param name="buffer">Buffer for which the checksum should be calculated.</param>
        /// <returns>The checksum value</returns>
        public static long GenerateCheckSum(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer", "Provided byte[] cannot be null.");

            uint BASE = 65521;
            uint checksum = 1;

            int count = buffer.Length;
            int offset = 0;

            uint s1 = checksum & 0xFFFF;
            uint s2 = checksum >> 16;

            while (count > 0)
            {                
                int n = 3800;
                if (n > count)
                {
                    n = count;
                }
                count -= n;
                while (--n >= 0)
                {
                    s1 = s1 + (uint)(buffer[offset++] & 0xff);
                    s2 = s2 + s1;
                }
                s1 %= BASE;
                s2 %= BASE;
            }

            checksum = (s2 << 16) | s1;

            return checksum;
        }

        /// <summary>
        /// Generate a single Adler32 checksum value based on the provided byte arrays. Checksum calculated from splitBuffer[0] onwards.
        /// </summary>
        /// <param name="splitBuffer">Buffers for which the checksum should be calculated.</param>
        /// <returns>The checksum value</returns>
        public static long GenerateCheckSumSplitBuffer(byte[][] splitBuffer)
        {
            if (splitBuffer == null) throw new ArgumentNullException("splitBuffer", "Provided byte[][] cannot be null.");

            uint BASE = 65521;
            uint checksum = 1;

            int count = 0;
            for (int i = 0; i < splitBuffer.Length; ++i)
                count += splitBuffer[i] == null ? 0 : splitBuffer[i].Length;

            int offset = 0;
            int currentIndex = 0;

            uint s1 = checksum & 0xFFFF;
            uint s2 = checksum >> 16;

            while (count > 0)
            {
                int n = 3800;
                if (n > count)
                {
                    n = count;
                }
                count -= n;
                while (--n >= 0)
                {
                    s1 = s1 + (uint)(splitBuffer[currentIndex][offset++] & 0xff);
                    s2 = s2 + s1;

                    if (offset >= splitBuffer[currentIndex].Length)
                    {
                        offset = 0;
                        currentIndex++;
                    }
                }
                s1 %= BASE;
                s2 %= BASE;
            }

            checksum = (s2 << 16) | s1;

            return checksum;
        }
    }
}
