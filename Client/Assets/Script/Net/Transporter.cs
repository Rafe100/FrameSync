using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class Transporter
{

    public const Int32 MAX_PACKAGE_LENGTH = 1024 * 64 * 4;

    NetClient nClient;
    MemoryStream memoryStream;
    BinaryWriter binaryWriter;
    byte[] buffer;
    Socket socket;
    Thread revThread;
    BufferCache revCache;

    public Transporter() {

    }

    public Transporter(NetClient nc,Socket netSocket) {
        buffer = new byte[MAX_PACKAGE_LENGTH];
        memoryStream = new MemoryStream(buffer);
        binaryWriter = new BinaryWriter(memoryStream);
        revCache = new BufferCache(MAX_PACKAGE_LENGTH);
        if (nc == null || netSocket == null) {
            Debug.Log("netclient or socket is null");
            return;
        }
        this.nClient = nc;
        this.socket = netSocket;
    }

    public void TCPStartRev() {
        revThread = new Thread(new ThreadStart(RevTCP));
        revThread.Start();
    }

    public void UDPStartRev() {
        revThread = new Thread(new ThreadStart(RevUDP));
        revThread.Start();
    }

    void RevTCP() {
        while (true) {
            
            int len = this.socket.Receive(buffer,0,buffer.Length, SocketFlags.None);
            if(len > 0) {
                revCache.Write(buffer, len);
                ReceiveData rd;
                do {
                    rd = Decode(revCache, len);
                    if(rd != null) {
                        this.nClient.NetWorkMessageEnqueue(rd);
                    }
                } while (rd != null);

            } else {
                string v = "the len is zero";
            }
        }
    }

    void RevUDP() {
        while (true) {
            EndPoint remoteEp = null;
            int len = this.socket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,ref remoteEp);
            if (len > 0) {
                revCache.Write(buffer, len);
                ReceiveData rd;
                do {
                    rd = Decode(revCache, len);
                    if (rd != null) {
                        this.nClient.NetWorkMessageEnqueue(rd);
                    }
                } while (rd != null);

            } else {
                string v = "the len is zero";
            }
        }
    }

    public ReceiveData Decode(BufferCache cache, Int32 revLength) {

        if (revLength < sizeof(Int16) * 2)
            return null;
        int packageLength = cache.ReadUInt16();
        Debug.Log("decode pck length:" + packageLength);
        if (packageLength > Transporter.MAX_PACKAGE_LENGTH) {
            Debug.Log("Transporter receive package length over max length :" + packageLength);
            return null;
        }
        UInt16 typeId = cache.ReadUInt16();
        Debug.Log("decode typeId:" + typeId);
        Type packageType = ClientProtocol.GetTypeById(typeId);
        if (packageType == null) {
            Debug.Log("Transporter receive package can not find id" + typeId);
            return null;
        }
        int packageBodyLength = packageLength - 2 - 4;
        ReceiveData data = new ReceiveData();
        data.MsgId = typeId;

        data.MsgObject = Activator.CreateInstance(packageType);
        MemoryStream mStream = cache.GetMemoryStream(packageBodyLength);
        //#if UNITY_IPHONE && !UNITY_EDITOR
        //ProtobufSerializer serializer = new ProtobufSerializer();
        //serializer.Deserialize(rCache.GetStream(pakBodyLength), ccMsg, pakType);

        //#else
        //RuntimeTypeModel.Default.Deserialize(rCache.GetStream(pakBodyLength), ccMsg, pakType);
        //#endif

        RuntimeTypeModel.Default.Deserialize(mStream, data.MsgObject, packageType);
        return data;
    }


    public bool Send(object msg) {
        try {
            UInt16 id;
            ArraySegment<byte> sendArraySegment = Encode(msg, out id);
            SendStateObject sendState = new SendStateObject();
            sendState.StateSocket = this.socket;
            sendState.Size = sendArraySegment.Count;
            sendState.Id = id;
            //int t = this.socket.Send(sendArraySegment.Array, sendArraySegment.Offset, sendArraySegment.Count, SocketFlags.None);
            int t = this.nClient.SendTo(sendArraySegment);
            return true;
        } catch (Exception e) {
            Debug.Log("transporter send exception :" + e.ToString());
            return false;
        }
    }


    /// <summary>
    /// 2byte - message length
    /// 2byte - message type
    /// 4byte - not use
    /// protobuf
    /// extern
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public ArraySegment<byte> Encode(object msg, out UInt16 id) {

        memoryStream.Seek(0, SeekOrigin.Begin);
        binaryWriter.Seek(0, SeekOrigin.Begin);
        binaryWriter.Write(UInt16.MinValue);
        UInt16 msgId = ClientProtocol.GetIdByType(msg.GetType());
        id = msgId;
        binaryWriter.Write(msgId);
        Debug.Log("encode msgId:" + memoryStream.Position);
        binaryWriter.Write(UInt32.MinValue);
        Debug.Log("encode + 4:" + memoryStream.Position);
        RuntimeTypeModel.Default.Serialize(memoryStream, msg);
        Debug.Log("encode :" + memoryStream.Position);
        int totalLength = (int)memoryStream.Position;
        UInt16 length = (UInt16)(memoryStream.Position - 2);
        binaryWriter.Seek(0, SeekOrigin.Begin);
        binaryWriter.Write(length);
        byte[] fullBuffer = new byte[totalLength];
        Array.Copy(this.buffer, fullBuffer, totalLength);
        ArraySegment<byte> encodeResult = new ArraySegment<byte>(fullBuffer, 0, totalLength);
        return encodeResult;
    }


  


}

public class ReceiveData {
    public UInt16 MsgId;
    public object MsgObject;
    public ReceiveData() {

    }

    public ReceiveData(UInt16 id , object obj) {
        MsgId = id;
        MsgObject = obj;
    }
}

class SendStateObject {
    public Socket StateSocket;
    public int Size;
    public UInt16 Id;
}
