﻿namespace TESUnity.ESM
{
    public struct AppaData
    {
        public int Type;
        public float Quality;
        public float Weight;
        public int Value;
    }

    public class APPARecord : Record, IIdRecord, IModelRecord
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public AppaData Data { get; private set; }
        public string Icon { get; private set; }
        public string Script { get; private set; }

        public override void DeserializeSubRecord(UnityBinaryReader reader, string subRecordName, uint dataSize)
        {
            if (subRecordName == "NAME")
            {
                Id = reader.ReadPossiblyNullTerminatedASCIIString((int)dataSize);
            }
            else if (subRecordName == "MODL")
            {
                Model = reader.ReadPossiblyNullTerminatedASCIIString((int)dataSize);
            }
            else if (subRecordName == "FNAM")
            {
                Name = reader.ReadPossiblyNullTerminatedASCIIString((int)dataSize);
            }
            else if (subRecordName == "AADT")
            {
                Data = new AppaData
                {
                    Type = reader.ReadLEInt32(),
                    Quality = reader.ReadLESingle(),
                    Weight = reader.ReadLESingle(),
                    Value = reader.ReadLEInt32()
                };
            }
            else if (subRecordName == "ITEX")
            {
                Icon = reader.ReadPossiblyNullTerminatedASCIIString((int)dataSize);
            }
            else if (subRecordName == "SCRI")
            {
                Script = reader.ReadPossiblyNullTerminatedASCIIString((int)dataSize);
            }
            else
            {
                ReadMissingSubRecord(reader, subRecordName, dataSize);
            }
        }

        #region Deprecated
        public override bool NewFetchMethod => true;
        public override SubRecord CreateUninitializedSubRecord(string subRecordName, uint dataSize) => null;
        #endregion
    }
}
