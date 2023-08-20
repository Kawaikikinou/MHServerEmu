﻿using System.Text;
using Google.ProtocolBuffers;
using MHServerEmu.Common.Encoding;
using MHServerEmu.Common.Extensions;
using MHServerEmu.GameServer.Common;
using MHServerEmu.GameServer.Powers;

namespace MHServerEmu.GameServer.Entities.Avatars
{
    public class Avatar : Entity
    {
        public PrototypeCollectionEntry[] UnknownPrototypes { get; set; }
        public Condition[] Conditions { get; set; }
        public int UnknownPowerVar { get; set; }
        public ReplicatedString PlayerName { get; set; }
        public ulong OwnerPlayerDbId { get; set; }
        public string GuildName { get; set; }
        public bool IsRuntimeInfo { get; set; }
        public AbilityKeyMapping[] AbilityKeyMappings { get; set; }

        public Avatar(byte[] archiveData)
        {
            CodedInputStream stream = CodedInputStream.CreateInstance(archiveData);
            BoolDecoder boolDecoder = new();

            ReadHeader(stream);
            ReadProperties(stream);

            UnknownPrototypes = new PrototypeCollectionEntry[stream.ReadRawVarint64()];
            for (int i = 0; i < UnknownPrototypes.Length; i++)
                UnknownPrototypes[i] = new(stream);

            Conditions = new Condition[stream.ReadRawVarint64()];
            for (int i = 0; i < Conditions.Length; i++)             
                Conditions[i] = new(stream);

            // Gazillion::PowerCollection::SerializeRecordCount
            UnknownPowerVar = stream.ReadRawInt32();
            // Gazillion::Agent::Serialize End
            PlayerName = new(stream);
            OwnerPlayerDbId = stream.ReadRawVarint64();

            GuildName = stream.ReadRawString();
            //Gazillion::GuildMember::SerializeReplicationRuntimeInfo

            if (boolDecoder.IsEmpty) boolDecoder.SetBits(stream.ReadRawByte());
            IsRuntimeInfo = boolDecoder.ReadBool();

            if (IsRuntimeInfo)
            {
                throw new("RuntimeInfo decoding not implemented!");
                // u64
                // string
                // int zigzag
            }

            AbilityKeyMappings = new AbilityKeyMapping[stream.ReadRawVarint64()];
            for (int i = 0; i < AbilityKeyMappings.Length; i++)
                AbilityKeyMappings[i] = new(stream, boolDecoder);
        }

        public Avatar(Condition[] conditions, int unknownPowerVar, ReplicatedString playerName, ulong ownerPlayerDbId,
            string guildName, bool isRuntimeInfo, AbilityKeyMapping[] abilityKeyMappings)
        {
            Conditions = conditions;
            UnknownPowerVar = unknownPowerVar;
            PlayerName = playerName;
            OwnerPlayerDbId = ownerPlayerDbId;
            GuildName = guildName;
            IsRuntimeInfo = isRuntimeInfo;
            AbilityKeyMappings = abilityKeyMappings;
        }

        public override byte[] Encode()
        {
            using (MemoryStream memoryStream = new())
            {
                CodedOutputStream stream = CodedOutputStream.CreateInstance(memoryStream);

                // Prepare bool encoder
                BoolEncoder boolEncoder = new();
                byte bitBuffer;

                boolEncoder.WriteBool(IsRuntimeInfo);
                foreach (AbilityKeyMapping keyMap in AbilityKeyMappings) boolEncoder.WriteBool(keyMap.ShouldPersist);

                boolEncoder.Cook();

                // Encode
                stream.WriteRawVarint64(ReplicationPolicy);
                stream.WriteRawVarint64(ReplicationId);

                stream.WriteRawBytes(BitConverter.GetBytes(Properties.Length));
                foreach (Property property in Properties)
                    stream.WriteRawBytes(property.Encode());

                stream.WriteRawVarint64((ulong)UnknownPrototypes.Length);
                foreach (PrototypeCollectionEntry entry in UnknownPrototypes) stream.WriteRawBytes(entry.Encode());

                stream.WriteRawVarint64((ulong)Conditions.Length);
                foreach (Condition condition in Conditions) stream.WriteRawBytes(condition.Encode());

                stream.WriteRawInt32(UnknownPowerVar);
                stream.WriteRawBytes(PlayerName.Encode());
                stream.WriteRawVarint64(OwnerPlayerDbId);
                stream.WriteRawString(GuildName);

                bitBuffer = boolEncoder.GetBitBuffer();             // IsRuntimeInfo
                if (bitBuffer != 0) stream.WriteRawByte(bitBuffer);

                stream.WriteRawVarint64((ulong)AbilityKeyMappings.Length);
                foreach (AbilityKeyMapping keyMap in AbilityKeyMappings) stream.WriteRawBytes(keyMap.Encode(boolEncoder));

                stream.Flush();
                return memoryStream.ToArray();
            }
        }

        public override string ToString()
        {
            using (MemoryStream memoryStream = new())
            using (StreamWriter streamWriter = new(memoryStream))
            {
                streamWriter.WriteLine($"ReplicationPolicy: 0x{ReplicationPolicy.ToString("X")}");
                streamWriter.WriteLine($"ReplicationId: 0x{ReplicationId.ToString("X")}");
                for (int i = 0; i < Properties.Length; i++) streamWriter.WriteLine($"Property{i}: {Properties[i]}");
                for (int i = 0; i < Conditions.Length; i++) streamWriter.WriteLine($"Condition{i}: {Conditions[i]}");
                streamWriter.WriteLine($"UnknownPowerVar: 0x{UnknownPowerVar.ToString("X")}");
                streamWriter.WriteLine($"PlayerName: {PlayerName}");
                streamWriter.WriteLine($"OwnerPlayerDbId: 0x{OwnerPlayerDbId.ToString("X")}");
                streamWriter.WriteLine($"GuildName: {GuildName}");
                streamWriter.WriteLine($"IsRuntimeInfo: {IsRuntimeInfo}");
                for (int i = 0; i < AbilityKeyMappings.Length; i++) streamWriter.WriteLine($"AbilityKeyMapping{i}: {AbilityKeyMappings[i]}");

                streamWriter.Flush();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}