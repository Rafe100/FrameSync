var customProto = require('./CustomProto/netProto_pb.js');
var net = require('net');
var protobuf = require('protobufjs');

console.log("program start");

var server = net.createServer(function (socket) {

    console.log('a new connection ');
    socket.on('connection', function (data) {
        console.log('a new connection ');
    });

    socket.on('data', function (data) {
        var dataBuffer = Buffer.from(data);
        console.log("a data coming ");
        console.log("total data length:" + data.length);
        var i = 0;
        var length = data.readInt16LE(i);
        i++;
        i++;
        //message type 
        var t = dataBuffer.readUInt16LE(i);
        console.log('a data [Length]' + length + "[type]" + t);

    });

    socket.on('error', function (data) {
        console.log('a error ....');
    });

    socket.on('close', function (data) {
        console.log('a close ....');
    });

});


server.listen(3001);