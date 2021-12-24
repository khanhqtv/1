using System;
using System.Text;

namespace AESimplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string plaintext = "AT140325PhamKhacKhanh";
            string key = "s5v8y/B?E(H+KbPe"; //Converter 73357638792F423F4528482B4B625065


            EncryptAES128(plaintext, key); // To run show result

        }

        static string EncryptAES128(string message, string key)
        {
            // khoi tao
            string input1 = "";
            string output1 = "";
            string output2 = "";
            string input9 = "";
            string output9 = "";
            string output10;
            string key0;
            string key1;
            string key2;
            string key9;
            string key10;
            int[] sBox = {
                  0x63 ,0x7c ,0x77 ,0x7b ,0xf2 ,0x6b ,0x6f ,0xc5 ,0x30 ,0x01 ,0x67 ,0x2b ,0xfe ,0xd7 ,0xab ,0x76
                 ,0xca ,0x82 ,0xc9 ,0x7d ,0xfa ,0x59 ,0x47 ,0xf0 ,0xad ,0xd4 ,0xa2 ,0xaf ,0x9c ,0xa4 ,0x72 ,0xc0
                 ,0xb7 ,0xfd ,0x93 ,0x26 ,0x36 ,0x3f ,0xf7 ,0xcc ,0x34 ,0xa5 ,0xe5 ,0xf1 ,0x71 ,0xd8 ,0x31 ,0x15
                 ,0x04 ,0xc7 ,0x23 ,0xc3 ,0x18 ,0x96 ,0x05 ,0x9a ,0x07 ,0x12 ,0x80 ,0xe2 ,0xeb ,0x27 ,0xb2 ,0x75
                 ,0x09 ,0x83 ,0x2c ,0x1a ,0x1b ,0x6e ,0x5a ,0xa0 ,0x52 ,0x3b ,0xd6 ,0xb3 ,0x29 ,0xe3 ,0x2f ,0x84
                 ,0x53 ,0xd1 ,0x00 ,0xed ,0x20 ,0xfc ,0xb1 ,0x5b ,0x6a ,0xcb ,0xbe ,0x39 ,0x4a ,0x4c ,0x58 ,0xcf
                 ,0xd0 ,0xef ,0xaa ,0xfb ,0x43 ,0x4d ,0x33 ,0x85 ,0x45 ,0xf9 ,0x02 ,0x7f ,0x50 ,0x3c ,0x9f ,0xa8
                 ,0x51 ,0xa3 ,0x40 ,0x8f ,0x92 ,0x9d ,0x38 ,0xf5 ,0xbc ,0xb6 ,0xda ,0x21 ,0x10 ,0xff ,0xf3 ,0xd2
                 ,0xcd ,0x0c ,0x13 ,0xec ,0x5f ,0x97 ,0x44 ,0x17 ,0xc4 ,0xa7 ,0x7e ,0x3d ,0x64 ,0x5d ,0x19 ,0x73
                 ,0x60 ,0x81 ,0x4f ,0xdc ,0x22 ,0x2a ,0x90 ,0x88 ,0x46 ,0xee ,0xb8 ,0x14 ,0xde ,0x5e ,0x0b ,0xdb
                 ,0xe0 ,0x32 ,0x3a ,0x0a ,0x49 ,0x06 ,0x24 ,0x5c ,0xc2 ,0xd3 ,0xac ,0x62 ,0x91 ,0x95 ,0xe4 ,0x79
                 ,0xe7 ,0xc8 ,0x37 ,0x6d ,0x8d ,0xd5 ,0x4e ,0xa9 ,0x6c ,0x56 ,0xf4 ,0xea ,0x65 ,0x7a ,0xae ,0x08
                 ,0xba ,0x78 ,0x25 ,0x2e ,0x1c ,0xa6 ,0xb4 ,0xc6 ,0xe8 ,0xdd ,0x74 ,0x1f ,0x4b ,0xbd ,0x8b ,0x8a
                 ,0x70 ,0x3e ,0xb5 ,0x66 ,0x48 ,0x03 ,0xf6 ,0x0e ,0x61 ,0x35 ,0x57 ,0xb9 ,0x86 ,0xc1 ,0x1d ,0x9e
                 ,0xe1 ,0xf8 ,0x98 ,0x11 ,0x69 ,0xd9 ,0x8e ,0x94 ,0x9b ,0x1e ,0x87 ,0xe9 ,0xce ,0x55 ,0x28 ,0xdf
                 ,0x8c ,0xa1 ,0x89 ,0x0d ,0xbf ,0xe6 ,0x42 ,0x68 ,0x41 ,0x99 ,0x2d ,0x0f ,0xb0 ,0x54 ,0xbb ,0x16 };

            int rounds = 10;

            int[][] keys = KeyExpansion(key, rounds, sBox);
            int[][] blocks = MessageToBlocks(message);

            string encrypted = "";

            for (int i = 0; i < blocks.Length; i++)
            {
                // INITIAL ROUND (0)

                AddRoundKey(blocks[i], keys[0]);
                input1 += Tostring(blocks, 1, i);


                // ROUND 1-9
                for (int j = 1; j < rounds; j++)
                {

                    SubBytes(blocks[i], sBox);
                    ShiftRows(blocks[i]);
                    MixColumns(blocks[i]);
                    AddRoundKey(blocks[i], keys[j]);
                    if (j == 1)
                    {
                        output1 += output1 + Tostring(blocks, 1, i);

                    }


                    if (j == 8)
                    {
                        input9 += input9 + Tostring(blocks, 1, i);

                    }
                    if (j == 9)
                    {
                        output9 += output9 + Tostring(blocks, 1, i);

                    }

                    if (j == 2)
                    {
                        output2 += output2 + Tostring(blocks, 1, i);

                    }
                }
                // LAST ROUND (10)
                SubBytes(blocks[i], sBox);
                ShiftRows(blocks[i]);
                AddRoundKey(blocks[i], keys[rounds]);

                // Adds block to encrypted string.
                foreach (int c in blocks[i])
                {
                    encrypted += (char)c;
                }

            }

            output10 = encrypted;
            show();
            void show()
            {
                Console.WriteLine("ban ro: AT140325PhamKhacKhanh");
                Console.WriteLine("2 vong dau: ");
                key1 = Tostring(keys, 0, 1);
                Console.WriteLine("key 1: " + HexadecimalEncoding.ToHexString(key1));
                Console.WriteLine("input 1: " + HexadecimalEncoding.ToHexString(input1));
                Console.WriteLine("output 1: " + HexadecimalEncoding.ToHexString(output1));
                key2 = Tostring(keys, 0, 2);
                Console.WriteLine("key 2: " + HexadecimalEncoding.ToHexString(key2));
                Console.WriteLine("input 2: " + HexadecimalEncoding.ToHexString(output1));
                Console.WriteLine("output 2: " + HexadecimalEncoding.ToHexString(output2));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("2 vong cuoi: ");
                key9 = Tostring(keys, 0, 9);
                Console.WriteLine("key 9: " + HexadecimalEncoding.ToHexString(key9));
                Console.WriteLine("input 9: " + HexadecimalEncoding.ToHexString(input9));
                Console.WriteLine("output 9: " + HexadecimalEncoding.ToHexString(output9));
                key10 = Tostring(keys, 0, 10);
                Console.WriteLine("key 10: " + HexadecimalEncoding.ToHexString(key10));
                Console.WriteLine("input 10: " + HexadecimalEncoding.ToHexString(output9));
                Console.WriteLine("ban ma : " + HexadecimalEncoding.ToHexString(output10));

            }
            return encrypted;
        }// khối mã hóa


        static int[][] MessageToBlocks(string message)//chia khối dùng PKCS7 Padding
        {
            decimal len = Math.Ceiling((decimal)message.Length / 16);
            int[][] blocks = new int[(int)len][];
            for (int i = 0; i < len; i++)
            {
                int tamp;
                int[] newBlock = new int[16];
                for (int j = 0; j < 16; j++)
                {
                    if ((i * 16 + j) >= message.Length)
                    {
                        tamp = j;
                        while (j < 16)
                        {
                            newBlock[j] += 16 - tamp;
                            j++;
                        }
                        // Adds padding to last block if needed.        
                    }
                    else
                    {
                        newBlock[j] = ((int)message[i * 16 + j]);
                    }

                }

                blocks[i] = newBlock;
            }
            return blocks;
        }



        static int[][] KeyExpansion(string inputKey, int rounds, int[] sBox)
        {
            // 11 keys are needed for 128-bit AES.
            int[][] keys = new int[11][];
            keys[0] = new int[16];
            // The key for round zero is the inputted key.
            for (int i = 0; i < inputKey.Length; i++)
            {
                // Converts character to unicode. 
                keys[0][i] = (int)inputKey[i];
                // Program doesnt crash if user inputs key longer than 128-bit.
                if (i == 15) { break; }
            }


            for (int i = 0; i < rounds; i++)
            {
                int[] newKey = new int[16];
                KeyExpansionFirstCol(newKey, keys[i], i + 1, sBox);

                // Coullumns 2, 3 and 4
                for (int j = 4; j < 16; j++)
                {
                    // "Word" i = ("Word" i - 1) XOR ("Word" i - 4)
                    newKey[j] = keys[i][j] ^ newKey[j - 4];
                }

                keys[i + 1] = newKey;
            }

            return keys;
        } // mở rộng khóa
        static void KeyExpansionFirstCol(int[] newKey, int[] prevKey, int i, int[] sBox)
        {
            // Get last collumn of previous key ("Word" i - 1)
            newKey[0] = prevKey[12];
            newKey[1] = prevKey[13];
            newKey[2] = prevKey[14];
            newKey[3] = prevKey[15];

            // Rotate
            int temp = newKey[0];
            newKey[0] = newKey[1];
            newKey[1] = newKey[2];
            newKey[2] = newKey[3];
            newKey[3] = temp;

            // SubBytes
            newKey[0] = sBox[newKey[0]];
            newKey[1] = sBox[newKey[1]];
            newKey[2] = sBox[newKey[2]];
            newKey[3] = sBox[newKey[3]];

            // Rcon (not the full table)
            int[] rcon = { 0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36 };
            newKey[0] ^= rcon[i];

            // XOR by "Word" i - 4;
            newKey[0] ^= prevKey[0];
            newKey[1] ^= prevKey[1];
            newKey[2] ^= prevKey[2];
            newKey[3] ^= prevKey[3];
        }// trao đổi khóa 


        /*khối mã hóa */
        static void AddRoundKey(int[] state, int[] roundKey)
        {
            // Each byte in the state is XOR-ed by the byte in roundKey with the same index.
            for (int i = 0; i < 16; i++)
            {
                state[i] ^= roundKey[i];

            }
        }
        static void SubBytes(int[] state, int[] lookupTable)
        {
            // The new value for each byte is fetched from a lookup table.
            for (int i = 0; i < 16; i++)
            {
                state[i] = lookupTable[state[i]];
            }
        }
        static void ShiftRows(int[] state)
        {
            int[] temp = new int[16];

            temp[0] = state[0];
            temp[1] = state[5];
            temp[2] = state[10];
            temp[3] = state[15];

            temp[4] = state[4];
            temp[5] = state[9];
            temp[6] = state[14];
            temp[7] = state[3];

            temp[8] = state[8];
            temp[9] = state[13];
            temp[10] = state[2];
            temp[11] = state[7];

            temp[12] = state[12];
            temp[13] = state[1];
            temp[14] = state[6];
            temp[15] = state[11];

            for (int i = 0; i < 16; i++)
            {
                state[i] = temp[i];
            }
        }
        static void MixColumns(int[] st)
        {
           
            int[] m2 = {
                0x00,0x02,0x04,0x06,0x08,0x0a,0x0c,0x0e,0x10,0x12,0x14,0x16,0x18,0x1a,0x1c,0x1e,
                0x20,0x22,0x24,0x26,0x28,0x2a,0x2c,0x2e,0x30,0x32,0x34,0x36,0x38,0x3a,0x3c,0x3e,
                0x40,0x42,0x44,0x46,0x48,0x4a,0x4c,0x4e,0x50,0x52,0x54,0x56,0x58,0x5a,0x5c,0x5e,
                0x60,0x62,0x64,0x66,0x68,0x6a,0x6c,0x6e,0x70,0x72,0x74,0x76,0x78,0x7a,0x7c,0x7e,
                0x80,0x82,0x84,0x86,0x88,0x8a,0x8c,0x8e,0x90,0x92,0x94,0x96,0x98,0x9a,0x9c,0x9e,
                0xa0,0xa2,0xa4,0xa6,0xa8,0xaa,0xac,0xae,0xb0,0xb2,0xb4,0xb6,0xb8,0xba,0xbc,0xbe,
                0xc0,0xc2,0xc4,0xc6,0xc8,0xca,0xcc,0xce,0xd0,0xd2,0xd4,0xd6,0xd8,0xda,0xdc,0xde,
                0xe0,0xe2,0xe4,0xe6,0xe8,0xea,0xec,0xee,0xf0,0xf2,0xf4,0xf6,0xf8,0xfa,0xfc,0xfe,
                0x1b,0x19,0x1f,0x1d,0x13,0x11,0x17,0x15,0x0b,0x09,0x0f,0x0d,0x03,0x01,0x07,0x05,
                0x3b,0x39,0x3f,0x3d,0x33,0x31,0x37,0x35,0x2b,0x29,0x2f,0x2d,0x23,0x21,0x27,0x25,
                0x5b,0x59,0x5f,0x5d,0x53,0x51,0x57,0x55,0x4b,0x49,0x4f,0x4d,0x43,0x41,0x47,0x45,
                0x7b,0x79,0x7f,0x7d,0x73,0x71,0x77,0x75,0x6b,0x69,0x6f,0x6d,0x63,0x61,0x67,0x65,
                0x9b,0x99,0x9f,0x9d,0x93,0x91,0x97,0x95,0x8b,0x89,0x8f,0x8d,0x83,0x81,0x87,0x85,
                0xbb,0xb9,0xbf,0xbd,0xb3,0xb1,0xb7,0xb5,0xab,0xa9,0xaf,0xad,0xa3,0xa1,0xa7,0xa5,
                0xdb,0xd9,0xdf,0xdd,0xd3,0xd1,0xd7,0xd5,0xcb,0xc9,0xcf,0xcd,0xc3,0xc1,0xc7,0xc5,
                0xfb,0xf9,0xff,0xfd,0xf3,0xf1,0xf7,0xf5,0xeb,0xe9,0xef,0xed,0xe3,0xe1,0xe7,0xe5};
            int[] m3 = {
                0x00,0x03,0x06,0x05,0x0c,0x0f,0x0a,0x09,0x18,0x1b,0x1e,0x1d,0x14,0x17,0x12,0x11,
                0x30,0x33,0x36,0x35,0x3c,0x3f,0x3a,0x39,0x28,0x2b,0x2e,0x2d,0x24,0x27,0x22,0x21,
                0x60,0x63,0x66,0x65,0x6c,0x6f,0x6a,0x69,0x78,0x7b,0x7e,0x7d,0x74,0x77,0x72,0x71,
                0x50,0x53,0x56,0x55,0x5c,0x5f,0x5a,0x59,0x48,0x4b,0x4e,0x4d,0x44,0x47,0x42,0x41,
                0xc0,0xc3,0xc6,0xc5,0xcc,0xcf,0xca,0xc9,0xd8,0xdb,0xde,0xdd,0xd4,0xd7,0xd2,0xd1,
                0xf0,0xf3,0xf6,0xf5,0xfc,0xff,0xfa,0xf9,0xe8,0xeb,0xee,0xed,0xe4,0xe7,0xe2,0xe1,
                0xa0,0xa3,0xa6,0xa5,0xac,0xaf,0xaa,0xa9,0xb8,0xbb,0xbe,0xbd,0xb4,0xb7,0xb2,0xb1,
                0x90,0x93,0x96,0x95,0x9c,0x9f,0x9a,0x99,0x88,0x8b,0x8e,0x8d,0x84,0x87,0x82,0x81,
                0x9b,0x98,0x9d,0x9e,0x97,0x94,0x91,0x92,0x83,0x80,0x85,0x86,0x8f,0x8c,0x89,0x8a,
                0xab,0xa8,0xad,0xae,0xa7,0xa4,0xa1,0xa2,0xb3,0xb0,0xb5,0xb6,0xbf,0xbc,0xb9,0xba,
                0xfb,0xf8,0xfd,0xfe,0xf7,0xf4,0xf1,0xf2,0xe3,0xe0,0xe5,0xe6,0xef,0xec,0xe9,0xea,
                0xcb,0xc8,0xcd,0xce,0xc7,0xc4,0xc1,0xc2,0xd3,0xd0,0xd5,0xd6,0xdf,0xdc,0xd9,0xda,
                0x5b,0x58,0x5d,0x5e,0x57,0x54,0x51,0x52,0x43,0x40,0x45,0x46,0x4f,0x4c,0x49,0x4a,
                0x6b,0x68,0x6d,0x6e,0x67,0x64,0x61,0x62,0x73,0x70,0x75,0x76,0x7f,0x7c,0x79,0x7a,
                0x3b,0x38,0x3d,0x3e,0x37,0x34,0x31,0x32,0x23,0x20,0x25,0x26,0x2f,0x2c,0x29,0x2a,
                0x0b,0x08,0x0d,0x0e,0x07,0x04,0x01,0x02,0x13,0x10,0x15,0x16,0x1f,0x1c,0x19,0x1a};

            int[] temp = new int[16];

            temp[0] = m2[st[0]] ^ m3[st[1]] ^ st[2] ^ st[3];
            temp[1] = st[0] ^ m2[st[1]] ^ m3[st[2]] ^ st[3];
            temp[2] = st[0] ^ st[1] ^ m2[st[2]] ^ m3[st[3]];
            temp[3] = m3[st[0]] ^ st[1] ^ st[2] ^ m2[st[3]];

            temp[4] = m2[st[4]] ^ m3[st[5]] ^ st[6] ^ st[7];
            temp[5] = st[4] ^ m2[st[5]] ^ m3[st[6]] ^ st[7];
            temp[6] = st[4] ^ st[5] ^ m2[st[6]] ^ m3[st[7]];
            temp[7] = m3[st[4]] ^ st[5] ^ st[6] ^ m2[st[7]];

            temp[8] = m2[st[8]] ^ m3[st[9]] ^ st[10] ^ st[11];
            temp[9] = st[8] ^ m2[st[9]] ^ m3[st[10]] ^ st[11];
            temp[10] = st[8] ^ st[9] ^ m2[st[10]] ^ m3[st[11]];
            temp[11] = m3[st[8]] ^ st[9] ^ st[10] ^ m2[st[11]];

            temp[12] = m2[st[12]] ^ m3[st[13]] ^ st[14] ^ st[15];
            temp[13] = st[12] ^ m2[st[13]] ^ m3[st[14]] ^ st[15];
            temp[14] = st[12] ^ st[13] ^ m2[st[14]] ^ m3[st[15]];
            temp[15] = m3[st[12]] ^ st[13] ^ st[14] ^ m2[st[15]];

            for (int i = 0; i < 16; i++)
            {
                st[i] = temp[i];
            }
        }

        static string Tostring(int[][] block, int mode, int j)// hiển thị dưới dạng string 
        {
            string result = "";
            if (mode == 1)
            {
                foreach (int c in block[j])
                {
                    result += (char)c;
                }


            }
            else
            {
                foreach (int c in block[j])
                {
                    result += (char)c;
                }

            }
            return result;
        }

    }

    public class HexadecimalEncoding
    {
        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
    } // chuyển đổi từ string thành hex 
}