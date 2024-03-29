//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: netProto.proto
namespace CustomProtocol
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PlayerInfo")]
  public partial class PlayerInfo : global::ProtoBuf.IExtensible
  {
    public PlayerInfo() {}
    
    private int _playId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int playId
    {
      get { return _playId; }
      set { _playId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GameStart")]
  public partial class GameStart : global::ProtoBuf.IExtensible
  {
    public GameStart() {}
    
    private int _serverTick;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"serverTick", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int serverTick
    {
      get { return _serverTick; }
      set { _serverTick = value; }
    }
    private int _playId;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"playId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int playId
    {
      get { return _playId; }
      set { _playId = value; }
    }
    private int _udpPort;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"udpPort", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int udpPort
    {
      get { return _udpPort; }
      set { _udpPort = value; }
    }
    private readonly global::System.Collections.Generic.List<CustomProtocol.PlayerInfo> _playerList = new global::System.Collections.Generic.List<CustomProtocol.PlayerInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"playerList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CustomProtocol.PlayerInfo> playerList
    {
      get { return _playerList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Vec3")]
  public partial class Vec3 : global::ProtoBuf.IExtensible
  {
    public Vec3() {}
    
    private long _x;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long x
    {
      get { return _x; }
      set { _x = value; }
    }
    private long _y;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long y
    {
      get { return _y; }
      set { _y = value; }
    }
    private long _z;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"z", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long z
    {
      get { return _z; }
      set { _z = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"C2SPlayerInput")]
  public partial class C2SPlayerInput : global::ProtoBuf.IExtensible
  {
    public C2SPlayerInput() {}
    
    private bool _isUp;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isUp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isUp
    {
      get { return _isUp; }
      set { _isUp = value; }
    }
    private bool _isRight;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"isRight", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isRight
    {
      get { return _isRight; }
      set { _isRight = value; }
    }
    private bool _isLeft;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"isLeft", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isLeft
    {
      get { return _isLeft; }
      set { _isLeft = value; }
    }
    private bool _isDown;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"isDown", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isDown
    {
      get { return _isDown; }
      set { _isDown = value; }
    }
    private long _hashCode;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"hashCode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long hashCode
    {
      get { return _hashCode; }
      set { _hashCode = value; }
    }
    private int _tick;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"tick", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int tick
    {
      get { return _tick; }
      set { _tick = value; }
    }
    private CustomProtocol.Vec3 _pos;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public CustomProtocol.Vec3 pos
    {
      get { return _pos; }
      set { _pos = value; }
    }
    private int _playerId;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"S2CFrame")]
  public partial class S2CFrame : global::ProtoBuf.IExtensible
  {
    public S2CFrame() {}
    
    private readonly global::System.Collections.Generic.List<CustomProtocol.C2SPlayerInput> _frameList = new global::System.Collections.Generic.List<CustomProtocol.C2SPlayerInput>();
    [global::ProtoBuf.ProtoMember(1, Name=@"frameList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CustomProtocol.C2SPlayerInput> frameList
    {
      get { return _frameList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"MSG")]
    public enum MSG
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"Msgid_GameStart", Value=1)]
      Msgid_GameStart = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"Msgid_ServerFrame", Value=2)]
      Msgid_ServerFrame = 2
    }
  
}