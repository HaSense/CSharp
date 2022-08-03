using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FPU
{
    public class BodyRequest : ISerializable
    {
        public long FILESIZE;
        public byte[] FILENAME;

        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            FILESIZE = BitConverter.ToInt64(bytes, 0);
            FILENAME = new byte[bytes.Length - sizeof(long)];
            Array.Copy(bytes, sizeof(long), FILENAME, 0, FILENAME.Length);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(FILESIZE);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            Array.Copy(FILENAME, 0, bytes, temp.Length, FILENAME.Length);

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(long) + FILENAME.Length;
        }
    }

    public class BodyResponse : ISerializable
    {
        public uint MSGID;
        public byte RESPONSE;
        public BodyResponse() { }
        public BodyResponse(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESPONSE = bytes[4];
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESPONSE;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }

    public class BodyData : ISerializable
    {
        public byte[] DATA;

        public BodyData(byte[] bytes)
        {
            DATA = new byte[bytes.Length];
            bytes.CopyTo(DATA, 0);
        }

        public byte[] GetBytes()
        {
            return DATA;
        }

        public int GetSize()
        {
            return DATA.Length;
        }
    }

    public class BodyResult : ISerializable
    {
        public uint MSGID;
        public byte RESULT;

        public BodyResult() { }
        public BodyResult(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESULT = bytes[4];
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESULT;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }
}
