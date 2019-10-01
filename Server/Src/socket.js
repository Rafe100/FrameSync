var customProto = require('./CustomProto/netProto_pb.js');
var net = require('net');
var protobuf = require('protobufjs');
var dgram = require('dgram');
var udpSocket = dgram.createSocket('udp4');
console.log("program start");

var playerId = 1000;
var updPort = 3003;
var allPlayer = new Array();

var server = net.createServer(function (socket) {

    console.log('tcpSocket server accept a new connection ');
    var rsp = new customProto.PlayerConnectRsp();
    rsp.setPlayid(playerId);
    rsp.setUdpport(updPort);
    allPlayer[playerId] = socket;
    playerId++;
    var sendBuffer = encode(rsp,2);
    socket.write(sendBuffer);
    socket.on('connection', function (data) {
        console.log('tcpSocket connection event');
       
    });

    socket.on('data', function (data) { 
        console.log("tcpSocket a data coming ");
    });

    socket.on('error', function (data) {
        console.log('tcpSocket a error');
    });

    socket.on('close', function (data) {
        console.log('tcpSocket a close');
    });

});

function encode(req,id) {
    var b = req.serializeBinary();
    var headBuffer = Buffer.alloc(8);
    headBuffer.writeInt16LE(b.length + 6);
    id = 2;
    headBuffer.writeUInt16LE(id, 2);
    headBuffer.writeInt32LE(0, 4);
    var sendBuffer = Buffer.concat([headBuffer, b], headBuffer.length + b.length);
    console.log('encode msg :' + typeof (req));
    return sendBuffer;
}

function decode(data) {
    var dataBuffer = Buffer.from(data);
    var i = 0;
    var length = data.readInt16LE(i);
    i++;
    i++;
    //message type 
    var t = dataBuffer.readUInt16LE(i);
    console.log('decode the data [Length]' + length + "[type]" + t);
    var encodeBuffer = data.slice(8, length - 6 + 8);
    console.log("deserialize length :" + encodeBuffer.length + typeof (encodeBuffer));
    var u8array = new Uint8Array(encodeBuffer);
    var ack = customProto.PlayerConnectRsp.deserializeBinary(u8array);
    return { id: t, obj: ack };
}


server.listen(3001);
/* udp */
udpSocket.on('connect', function (data) {
    console.log('udpSocket a new connect ');
});

udpSocket.on('close', () => {
    console.log('udpSocketÒÑ¹Ø±Õ');
});

udpSocket.on('error', (err) => {
    console.log('udpSocket' + err);
});

udpSocket.on('listening', () => {
    console.log('udpSocket  listening...');
});

udpSocket.on('message', (data, rinfo) => {
    console.log(`udpSocket receive message from ${rinfo.address}:${rinfo.port}`);
    var ack = decode(data);
    if (ack.id == 2) {
        console.log("the Playid :" + ack.obj.getPlayid());
        console.log("udp port :" + ack.obj.getUdpport());
    }



});

udpSocket.bind('3003');