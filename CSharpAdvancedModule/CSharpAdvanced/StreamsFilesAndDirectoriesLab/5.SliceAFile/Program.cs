using System;
using System.IO;

namespace _5.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int pieceCount = 4;
            using (FileStream stream = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                long size = stream.Length / pieceCount;

                for (int i = 0; i < pieceCount; i++)
                {
                    
                    using (var prieceStream = new FileStream($"../../../part-{i+1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[1];
                        int count = 0;
                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            prieceStream.Write(buffer, 0, buffer.Length);
                            count++;
                        }
                    }
                }
            }
        }
    }
}
