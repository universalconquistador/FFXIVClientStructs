namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::ModelResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct ModelResourceHandle {

    [FieldOffset(0xC8)] public byte* ModelData; // StringTable, ModelHeader ...

    [FieldOffset(0x228)] public MaterialResourceHandle** MaterialResourceHandles;

    [FieldOffset(0x248)] public StdMap<CStringPointer, short> Attributes;
    [FieldOffset(0x268)] public StdMap<CStringPointer, short> Shapes;

    [MemberFunction("E8 ?? ?? ?? ?? 45 8B CE 48 89 44 24 ?? 41 B8 ?? ?? ?? ?? 48 8D 54 24")]
    public unsafe partial CStringPointer GetMaterialFileNameBySlot(uint slot);

    /// <summary>
    /// Synchronosly loads each of the materials and stores them in <see cref="MaterialResourceHandles"/>.
    /// </summary>
    /// <remarks>
    /// Not called when <see cref="Type"/> is <see cref="ResourceHandleType.HandleCategory.Chara"/>
    /// as character materials are loaded by the character itself.
    /// </remarks>
    /// <returns>Success or failure, with zero materials counting as a success.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 12 B0 F6")]
    public partial bool LoadMaterials();
}

[StructLayout(LayoutKind.Explicit, Size = 0x44)]
public unsafe partial struct ModelFileHeader {
    [FieldOffset(0x00)] public uint Version;
    [FieldOffset(0x04)] public uint StackSize; // Size of all the vertex declarations
    [FieldOffset(0x08)] public uint RuntimeSize;
    [FieldOffset(0x0C)] public ushort VertexDeclarationCount;
    [FieldOffset(0x0E)] public ushort MaterialCount;
    [FieldOffset(0x10)] internal FixedSizeArray3<uint> _vertexOffset;
    [FieldOffset(0x1C)] internal FixedSizeArray3<uint> _indexOffset;
    [FieldOffset(0x28)] internal FixedSizeArray3<uint> _vertexBufferSize;
    [FieldOffset(0x34)] public uint IndexBufferSize;
    [FieldOffset(0x40)] public byte LodCount;
    [FieldOffset(0x41)] public bool EnableIndexBufferStreaming;
    [FieldOffset(0x42)] public bool EnableEdgeGeometry;
}

[StructLayout(LayoutKind.Explicit, Size = 0x9)]
public unsafe struct ModelStringData {
    [FieldOffset(0x00)] public uint StringCount;
    [FieldOffset(0x04)] public uint DataLength;
    [FieldOffset(0x08)] public fixed byte Data[1];
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ModelVertexElement {
    [FieldOffset(0x00)] public byte Stream;
    [FieldOffset(0x01)] public byte Offset;
    [FieldOffset(0x02)] public byte Type;
    [FieldOffset(0x03)] public byte Usage;
    [FieldOffset(0x04)] public byte UsageIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x08 * 17)]
public unsafe partial struct ModelVertexDeclaration {
    [FieldOffset(0x00)] private FixedSizeArray17<ModelVertexElement> _vertexElements;
}

[Flags]
public enum ModelFlags1 : byte {
    DustOcclusionEnabled = 0x80,
    SnowOcclusionEnabled = 0x40,
    RainOcclusionEnabled = 0x20,
    Unknown1 = 0x10,
    LightingReflectionEnabled = 0x08,
    WavingAnimationDisabled = 0x04,
    LightShadowDisabled = 0x02,
    ShadowDisabled = 0x01,
}

[Flags]
public enum ModelFlags2 : byte {
    Unknown2 = 0x80,
    BgUvScrollEnabled = 0x40,
    EnableForceNonResident = 0x20,
    ExtraLodEnabled = 0x10,
    ShadowMaskEnabled = 0x08,
    ForceLodRangeEnabled = 0x04,
    EdgeGeometryEnabled = 0x02,
    Unknown3 = 0x01,
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct ModelMeshHeader {
    [FieldOffset(0x00)] public float Radius;
    [FieldOffset(0x04)] public ushort MeshCount;
    [FieldOffset(0x06)] public ushort AttributeCount;
    [FieldOffset(0x08)] public ushort SubmeshCount;
    [FieldOffset(0x0A)] public ushort MaterialCount;
    [FieldOffset(0x0C)] public ushort BoneCount;
    [FieldOffset(0x0E)] public ushort BoneTableCount;
    [FieldOffset(0x10)] public ushort ShapeCount;
    [FieldOffset(0x12)] public ushort ShapeMeshCount;
    [FieldOffset(0x14)] public ushort ShapeValueCount;
    [FieldOffset(0x16)] public byte LodCount;
    [FieldOffset(0x17)] public ModelFlags1 Flags1;
    [FieldOffset(0x18)] public ushort ElementIdCount;
    [FieldOffset(0x1A)] public byte TerrainShadowMeshCount;
    [FieldOffset(0x1B)] public ModelFlags2 Flags2;
    [FieldOffset(0x1C)] public float ModelClipOutDistance;
    [FieldOffset(0x20)] public float ShadowClipOutDistance;
    [FieldOffset(0x24)] public ushort CullingGridCount;
    [FieldOffset(0x26)] public ushort TerrainShadowSubmeshCount;
    [FieldOffset(0x28)] public byte Flags3;
    [FieldOffset(0x29)] public byte BGChangeMaterialIndex;
    [FieldOffset(0x2A)] public byte BGCrestChangeMaterialIndex;
    [FieldOffset(0x2B)] public byte NeckMorphCount;
    [FieldOffset(0x2C)] public ushort BoneTableArrayCountTotal;
    [FieldOffset(0x2E)] public ushort Unknown8;
    [FieldOffset(0x30)] public ushort Unknown9;
}
