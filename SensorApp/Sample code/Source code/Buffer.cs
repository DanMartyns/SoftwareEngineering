using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBioLib
{
    public class Buffer
    {
        public const int kBytes = 100000;

        public Buffer()
        {
            data = new byte[kBytes];
            nBytes = 0;
            wrPointer = 0;
            rdPointer = 0;
        }


        /// <summary>
        /// Dados recebidos.
        /// </summary>
        public byte[] data { set; get; }

        /// <summary>
        /// N.º de bytes para tratar.
        /// </summary>
        public int nBytes { set; get; }

        /// <summary>
        /// Posição do ponteiro de escrita no buffer.
        /// </summary>
        public int wrPointer { set; get; }

        /// <summary>
        /// Posição do ponteiro de leitura no buffer.
        /// </summary>
        public int rdPointer { set; get; }

    }
}
