using System;
using System.Linq;
using System.Text;
using Share;


class Message
{
    private byte[] data = new byte[1024];
    private int curDataSize = 0; //我们存取了多少字节的数据在数组里面

    private const int flagSize = 4;

    public byte[] Data
    {
        get { return data; }
    }


    /// <summary>
    /// 获取现在存在的数据的长度
    /// </summary>
    public int CurDataSize
    {
        get { return curDataSize; }
    }

    public int RemianSize
    {
        get { return data.Length - curDataSize; }
    }


    public string ReadMessage(int newDataAmount, Action<RequestCode, string> processDataCallback)
    {
        curDataSize += newDataAmount;
        string message = null;
        while (true)
        {
            if (curDataSize <= flagSize)
            {
                return message;
            }
            else
            {
                //当前的数据的长度
                int count = BitConverter.ToInt32(data, 0);
                if (curDataSize - flagSize >= count)
                {
                    RequestCode requestCode = (RequestCode) BitConverter.ToInt32(data, 4);
                    message = Encoding.UTF8.GetString(data, flagSize + 4, count - 4);
                    processDataCallback(requestCode, message);
                    Array.Copy(data, count + flagSize, data, 0, curDataSize - flagSize - count);
                    curDataSize -= (count + flagSize);
                }
                else
                {
                    break;
                }
            }
        }

        return message;
    }


    /// <summary>
    ///  打包数据流
    /// </summary>
    /// <param name="requestCode">requestCode</param>
    /// <param name="actionCode">actionCode</param>
    /// <param name="data">传输的数据</param>
    /// <returns>打包的数据数组</returns>
    public static byte[] PackData(RequestCode requestCode, ActionCode actionCode, string data)
    {
        byte[] requestCodeBytes = BitConverter.GetBytes((int) requestCode);
        byte[] actionCodeBytes = BitConverter.GetBytes((int) actionCode);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int dataAmount = requestCodeBytes.Length + actionCodeBytes.Length + dataBytes.Length;
        byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
        return dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>().Concat(actionCodeBytes).ToArray<byte>()
            .Concat(dataBytes).ToArray<byte>();
    }
}