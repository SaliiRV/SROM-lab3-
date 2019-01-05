using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public class Program {
        static void Main(string[] args) {
            string a = "01000101111000101111101110011100110101001001001110011001100111101000110011000010010100100001010111010011110001000111001001100110110011100000011001100111100010000001011100101011001001111110011011010100001001000110010010100011000110001101001100110001000101111010001010010110011111100010001010011011011011111100110111111101011000000010001100101111110011000000101001001110110001111111000010000111101111110111001110111100110110010010100111101100100";//1001
            string b = "10111001100001001110011011110100100011110011001110111001110001111001111101111100101011111111011111110101110000111001010000011000100011101111001001011111011100111000000101110010110001000011011000010011001110001010001000000100100111001000100001111011110010001001100100010101010101101111011110001001010110010010101101111011110101010010010100110110001101011011110011100110101010100001010000011111101000100100111100010110111011000110000001010011101";//1010
            string c = "00111111011110010110110111000000111000010011101001000101011110001101000101001111101000001010001110101001110001111100111000100010110110000010100001101011111010000110001101011111001100111000001010111001101010111100110010110000111011001101101010100101101101001110101000101011001010100010101000100110011111101001111010110101111011100111001100100101101110101100000110100111001001011111100001011011001011000011110001011111100111000000010111010000010";//1011010
            int[] p1 = new int[1];
            int[] p2 = new int[1];
            int[] p3 = new int[1];
            p1 = ToByte(a);
            p2 = ToByte(b);
            p3 = ToByte(c);
            Console.WriteLine(ToStr(Addition(p1, p2)));
            Console.ReadKey();
            Console.ReadKey();
        }

        public static string Chek(int[] a, int[] b, int[] c) {
            string result = null;
            var z = Multiply(Addition(a, b), c);
            var x = Addition(Multiply(b, c), Multiply(c, a));
            var zz = ToStr(z);
            var xx = ToStr(x);
            if (zz == xx) { result = "correct"; }
            else { result = "error"; }
            return result;
        }

        public static int[] ToByte(string a) {
            int l = a.Length;
            int[] result = new int[l];
            for (int i = 0; i < l; i++) {
                result[i] = Convert.ToByte(a.Substring(a.Length - (i + 1), 1), 2);
            }
            return result;
        }


        public static string ToStr(int[] a) {
            string result = null;
            for (int i = a.Length - 1; i >= 0; i--) {
                result = result + a[i].ToString();
            }
            return result;
        }


        public static int[] RHZ(int[] a, int length) {
            int k = 0;
            var i = length - 1;
            while (a[i] == 0) {
                k++;
                i--;
                if (i == -1) return a;
            }
            int[] result = new int[a.Length - k];
            for (int j = 0; j < a.Length - k; j++) {
                result[j] = a[j];
            }
            return result;
        }


        public static int[] Lenght(int[] a) {
            if (a.Length < 442) {
                Array.Resize(ref a, 443);
            }
            return a;
        }


        public static int[] Addition(int[] a, int[] b) {
            var maxlenght = Math.Max(a.Length, b.Length);
            Array.Resize(ref a, maxlenght);
            Array.Resize(ref b, maxlenght);

            int[] result = new int[maxlenght];
            for (int i = 0; i < a.Length; i++) {
                result[i] = (a[i] ^ b[i]);
            }
            return RHZ(result, maxlenght);
        }


        public static int[] ShiftBits(int[] a, int k) {
            int[] result = new int[a.Length + k];
            for (int i = 0; i < a.Length; i++) {
                result[i + k] = a[i];
            }
            return result;
        }


        public static int[] Div(int[] a) {
            string g = "100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000000000000000001011";
            int[] gen = new int[1];
            gen = ToByte(g);
            int[] result = new int[1];
            result = a;
            int len_a = a.Length;
            var maxlenght = Math.Max(a.Length, gen.Length);
            if (a.Length >= gen.Length) {
                int[] temp = new int[1];
                while (result.Length >= gen.Length) {
                    temp = ShiftBits(gen, result.Length - gen.Length);
                    result = Addition(result, temp);
                }
            }
            else {
                return a;
            }
            return Lenght(result);
        }

        public static int[] Inv(int[] a) {
            string One = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            int[] result = new int[a.Length];
            int[] temp = new int[a.Length];
            int[] n = new int[a.Length];
            n = ToByte(One);
            result = ToByte(One);
            temp = Power(a, n);

            for (int i = 1; i < a.Length; i++) {
                result = Multiply(result, temp);
                temp = VKvadrat(temp);
            }
            result = VKvadrat(result);
            return result;
        }

        public static int[] Multiply(int[] a, int[] b) {
            var maxlenght = Math.Max(a.Length, b.Length);
            Array.Resize(ref a, maxlenght);
            Array.Resize(ref b, maxlenght);

            int[] temp = new int[1];
            int[] result = new int[1];
            for (int i = 0; i < a.Length; i++) {
                if (b[i] == 1) {
                    temp = ShiftBits(a, i);
                    result = Addition(result, temp);
                }
            }
            result = Div(result);
            return result;
        }


        public static int[] VKvadrat(int[] a) {
            int[] A = new int[2 * a.Length];
            int[] result = new int[1];
            for (int i = 0; i < a.Length; i++) {
                A[2 * i] = a[i];
            }
            result = Div(A);
            return result;
        }


        public static int[] Tr(int[] a) {
            int[] result = new int[1];
            int[] temp = new int[1];
            result = a;
            temp = a;
            for (int i = 1; i < 443; i++) {
                temp = VKvadrat(temp);
                result = Addition(result, temp);
            }
            result = Div(result);
            return result;
        }


        public static int[] Power(int[] a, int[] n) {
            string One = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            int[] result = new int[a.Length];
            result = ToByte(One);
            for (int i = 0; i < a.Length; i++) {
                if (n[i] == 1) {
                    result = Multiply(result, a);
                }
                a = VKvadrat(a);
            }
            return result;
        }


    }
}
