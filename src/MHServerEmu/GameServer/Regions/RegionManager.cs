﻿using MHServerEmu.Common;

namespace MHServerEmu.GameServer.Regions
{
    public static class RegionManager
    {
        private static readonly Logger Logger = LogManager.CreateLogger();
        private static readonly Dictionary<RegionPrototype, Region> RegionDict = new();

        public static bool IsInitialized { get; }

        static RegionManager()
        {
            RegionDict.Add(RegionPrototype.AvengersTowerHUBRegion, LoadRegionData(RegionPrototype.AvengersTowerHUBRegion));
            RegionDict.Add(RegionPrototype.NPEAvengersTowerHUBRegion, LoadRegionData(RegionPrototype.NPEAvengersTowerHUBRegion));
            RegionDict.Add(RegionPrototype.TrainingRoomSHIELDRegion, LoadRegionData(RegionPrototype.TrainingRoomSHIELDRegion));
            RegionDict.Add(RegionPrototype.XaviersMansionRegion, LoadRegionData(RegionPrototype.XaviersMansionRegion));
            RegionDict.Add(RegionPrototype.HelicarrierRegion, LoadRegionData(RegionPrototype.HelicarrierRegion));
            RegionDict.Add(RegionPrototype.AsgardiaRegion, LoadRegionData(RegionPrototype.AsgardiaRegion));
            RegionDict.Add(RegionPrototype.GenoshaHUBRegion, LoadRegionData(RegionPrototype.GenoshaHUBRegion));
            RegionDict.Add(RegionPrototype.DangerRoomHubRegion, LoadRegionData(RegionPrototype.DangerRoomHubRegion));
            RegionDict.Add(RegionPrototype.InvasionSafeAbodeRegion, LoadRegionData(RegionPrototype.InvasionSafeAbodeRegion));
            RegionDict.Add(RegionPrototype.DailyGShockerSubwayRegionL60, LoadRegionData(RegionPrototype.DailyGShockerSubwayRegionL60));
            RegionDict.Add(RegionPrototype.XManhattanRegion60Cosmic, LoadRegionData(RegionPrototype.XManhattanRegion60Cosmic));

            Logger.Info($"Loaded data for {RegionDict.Count} regions");

            IsInitialized = true;
        }

        public static Region GetRegion(RegionPrototype prototype)
        {
            if (RegionDict.ContainsKey(prototype))
            {
                return RegionDict[prototype];
            }
            else
            {
                Logger.Warn($"Data for region {prototype} is not available, falling back to NPEAvengersTowerHUBRegion");
                return RegionDict[RegionPrototype.NPEAvengersTowerHUBRegion];
            }
        }

        public static bool IsRegionAvailable(RegionPrototype prototype) => RegionDict.ContainsKey(prototype);

        private static Region LoadRegionData(RegionPrototype prototype)
        {
            // TODO: loading data externally

            Region region = null;
            byte[] archiveData = Array.Empty<byte>();
            Area area;

            switch (prototype)
            {
                case RegionPrototype.AvengersTowerHUBRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.AvengersTowerHUBRegion,
                        1,
                        1488502313,
                        archiveData,
                        new(-5024f, -5024f, -2048f),
                        new(5024f, 5024f, 2048f),
                        new(10, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.AvengersTowerHubArea, new(), true);
                    area.AddCell(new(1, 9602664968964741817, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(500f, 0f, 0f);
                    region.EntranceOrientation = new();
                    region.WaypointPosition = new(1575f, 0f, 0f);
                    region.WaypointOrientation = new();

                    break;


                case RegionPrototype.NPEAvengersTowerHUBRegion:

                    archiveData = new byte[] {
                        0xEF, 0x01, 0xE8, 0xC1, 0x02, 0x02, 0x00, 0x00, 0x00, 0x2C, 0xED, 0xC6,
                        0x05, 0x95, 0x80, 0x02, 0x0C, 0x00, 0x04, 0x9E, 0xCB, 0xD1, 0x93, 0xC7,
                        0xE8, 0xAF, 0xCC, 0xEE, 0x01, 0x06, 0x00, 0x8B, 0xE5, 0x02, 0x9E, 0xE6,
                        0x97, 0xCA, 0x0C, 0x01, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x04, 0x9B, 0xB2, 0x81, 0xF2, 0x83, 0xC6, 0xCD, 0x92, 0x10,
                        0x06, 0x00, 0xA2, 0xE0, 0x03, 0xBC, 0x88, 0xA0, 0x89, 0x0E, 0x01, 0x00,
                        0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xCC, 0xD7, 0xD1,
                        0xBE, 0xA9, 0xB0, 0xBB, 0xFE, 0x44, 0x06, 0x00, 0xCF, 0xF3, 0x04, 0xBC,
                        0xA4, 0xAD, 0xD3, 0x0A, 0x01, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0xC3, 0xBE, 0xB9, 0xC8, 0xD6, 0x8F, 0xAF, 0x8C, 0xE7,
                        0x01, 0x06, 0x00, 0xC7, 0x98, 0x05, 0xD6, 0x91, 0xB8, 0xA9, 0x0E, 0x01,
                        0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00
                    };

                    region = new(RegionPrototype.NPEAvengersTowerHUBRegion,
                        1150669705055451881,
                        1488502313,
                        archiveData,
                        new(-5024f, -5024f, -2048f),
                        new(5024f, 5024f, 2048f),
                        new(10, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.NPEAvengersTowerHubArea, new(), true);
                    area.AddCell(new(1, 14256372356117109756, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(1311f, 515.75f, 369f);
                    region.EntranceOrientation = new(-3.140625f, 0f, 0f);
                    region.WaypointPosition = new(536f, 862f, 341.5f);
                    region.WaypointOrientation = new(1.5625f, 0f, 0f);

                    break;

                case RegionPrototype.TrainingRoomSHIELDRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.TrainingRoomSHIELDRegion,
                        1153032328761311238,
                        740100172,
                        archiveData,
                        new(-3250f, -3250f, -3250f),
                        new(3250f, 3250f, 3250f),
                        new(10, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.TrainingRoomSHIELDArea, new(), true);
                    area.AddCell(new(1, 4566519072692968513, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(-2943.875f, 256f, 308f);
                    region.EntranceOrientation = new(-1.5625f, 0f, 0f);
                    region.WaypointPosition = new(-2943.875f, 256f, 308f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.XaviersMansionRegion:

                    archiveData = new byte[] {    
                    };

                    region = new(RegionPrototype.XaviersMansionRegion,
                        1153032328761311239,
                        1640169729,
                        archiveData,
                        new(-6144f, -5120f, -1043f),
                        new(4096f, 9216f, 1024f),
                        new(28, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.XaviersMansionArea, new(), true);
                    area.AddCell(new(12, 9109153860316370436, new()));
                    area.AddCell(new(27, 13177785476563801619, new()));
                    area.AddCell(new(13, 17941854392027125253, new()));
                    area.AddCell(new(18, 12120264330993014282, new()));
                    area.AddCell(new(19, 6535677982759130635, new()));
                    area.AddCell(new(20, 10515825803755329036, new()));
                    area.AddCell(new(25, 10154077166729893393, new()));
                    area.AddCell(new(26, 5167410838022985234, new()));
                    area.AddCell(new(28, 9060175612352206356, new()));
                    area.AddCell(new(21, 1692163188906202637, new()));
                    area.AddCell(new(14, 3720701338298160646, new()));
                    area.AddCell(new(8, 696078097349416448, new()));
                    area.AddCell(new(1, 10536652095872374268, new()));
                    area.AddCell(new(29, 18097793277182809621, new()));
                    area.AddCell(new(22, 15863673301231801870, new()));
                    area.AddCell(new(15, 3361838850574587399, new()));
                    area.AddCell(new(9, 10321271752406537729, new()));
                    area.AddCell(new(3, 1490066882925893117, new()));
                    area.AddCell(new(2, 16400080554702018141, new()));
                    area.AddCell(new(23, 13916728032834033167, new()));
                    area.AddCell(new(16, 16571968147698030088, new()));
                    area.AddCell(new(10, 4927032947367548418, new()));
                    area.AddCell(new(5, 16136701249791006206, new()));
                    area.AddCell(new(4, 6117192780878648927, new()));
                    area.AddCell(new(24, 756312045859706384, new()));
                    area.AddCell(new(17, 7164953866296301065, new()));
                    area.AddCell(new(11, 13057875448556623363, new()));
                    area.AddCell(new(7, 14047893761362171391, new()));
                    area.AddCell(new(6, 4165682859893855841, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(-2047f, 5136f, -75f);
                    region.EntranceOrientation = new();
                    region.WaypointPosition = new(-2047f, 5136f, -75f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.HelicarrierRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.HelicarrierRegion,
                        1153032354375335949,
                        1347063143,
                        archiveData,
                        new(-4352f, -4352f, -4352f),
                        new(4352f, 4352f, 4352f),
                        new(49, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.HelicarrierArea, new(), true);
                    area.AddCell(new(1, 9132424850153412694, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(-405.75f, 1274.125f, 56f);
                    region.EntranceOrientation = new(0.78125f, 0f, 0f);
                    region.WaypointPosition = new(-405.75f, 1274.125f, 56f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.AsgardiaRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.AsgardiaRegion,
                        1153032354375335950,
                        2119981225,
                        archiveData,
                        new(-1152f, -5760f, -1152f),
                        new(5760f, 8064f, 1152f),
                        new(58, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.AsgardiaArea, new(), true);
                    area.AddCell(new(13, 15073780346019977560, new()));
                    area.AddCell(new(11, 11246649063905891792, new()));
                    area.AddCell(new(10, 1909646168222143951, new()));
                    area.AddCell(new(9, 15122171344131397070, new()));
                    area.AddCell(new(1, 10662757872149665228, new()));
                    area.AddCell(new(2, 6387628673607996877, new()));
                    area.AddCell(new(5, 6869037629237827021, new()));
                    area.AddCell(new(6, 10668863627723347406, new()));
                    area.AddCell(new(3, 16010605369626138062, new()));
                    area.AddCell(new(7, 1340692112513897935, new()));
                    area.AddCell(new(14, 6315350639355304281, new()));
                    area.AddCell(new(4, 1544113879755068879, new()));
                    area.AddCell(new(8, 15692735703338522064, new()));
                    area.AddCell(new(12, 6289501289510147537, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(1919.875f, 767.875f, 63f);
                    region.EntranceOrientation = new(3.140625f, 0f, 0f);
                    region.WaypointPosition = new(1919.875f, 767.875f, 63f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.GenoshaHUBRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.GenoshaHUBRegion,
                        1153032328761311240,
                        1922430980,
                        archiveData,
                        new(-11319f, -12336f, -2304f),
                        new(11319f, 12336f, 2304f),
                        new(60, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.GenoshaHUBArea, new(951f, -336f, 0f), true);
                    area.AddCell(new(3, 5680859166885025055, new()));
                    area.AddCell(new(4, 9622684927434298656, new()));
                    area.AddCell(new(5, 224852719175734561, new()));
                    area.AddCell(new(11, 933212887802189089, new()));
                    area.AddCell(new(7, 13860233243740869920, new()));
                    area.AddCell(new(8, 794220225615762721, new()));
                    area.AddCell(new(12, 14388899140413822242, new()));
                    area.AddCell(new(13, 4700580598661518627, new()));
                    area.AddCell(new(9, 10201165220605859106, new()));
                    //area.AddCell(new(1, 9402521850118673694, new()));
                    //area.AddCell(new(2, 5269392344921281823, new()));
                    //area.AddCell(new(6, 14430102745958978850, new()));
                    //area.AddCell(new(10, 5101736277889127715, new()));
                    //area.AddCell(new(14, 9972942662930928932, new()));
                    //area.AddCell(new(17, 9268983740567000357, new()));
                    //area.AddCell(new(15, 10908336477861319973, new()));
                    //area.AddCell(new(16, 6646998170199004454, new()));
                    region.AddArea(area);

                    //Area entryArea = new(2, AreaPrototype.GenoshaHUBEntryArea, new(-11049f, -12336f, 0f), false);
                    //area.AddCell(new(18, 14666675902348205617, new()));
                    //region.AddArea(entryArea);

                    region.EntrancePosition = new(4434.125f, 2388.875f, -1304f);
                    region.EntranceOrientation = new(2.046875f, 0.0f, 0.0f);
                    region.WaypointPosition = new(4434.125f, 2388.875f, -1304f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.DangerRoomHubRegion:

                    archiveData = new byte[] {
                        0xEF, 0x01, 0xA8, 0x9B, 0x02, 0x07, 0x00, 0x00, 0x00, 0xB6, 0x80, 0x01,
                        0xE6, 0xCC, 0x99, 0xFB, 0x03, 0x2C, 0xFC, 0xA9, 0x02, 0xCA, 0x80, 0x03,
                        0xE6, 0xCC, 0x99, 0xFB, 0x03, 0x95, 0x80, 0x02, 0x12, 0xCA, 0x40, 0xE6,
                        0xCC, 0x99, 0xFB, 0x03, 0xA8, 0x80, 0x02, 0x80, 0x80, 0x80, 0x84, 0x04,
                        0xA8, 0xC0, 0x02, 0x9A, 0xB3, 0xE6, 0xF4, 0x03, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00
                    };

                    region = new(RegionPrototype.DangerRoomHubRegion,
                        1154146333179728693,
                        1830444841,
                        archiveData,
                        new(-1664f, -1664f, -1664f),
                        new(1664f, 1664f, 1664f),
                        new(63, DifficultyTier.Heroic));

                    area = new(1, AreaPrototype.DangerRoomHubArea, new(), true);
                    area.AddCell(new(1, 5938132704447044414, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(-384.125f, -301.375f, 308f);
                    region.EntranceOrientation = new();
                    region.WaypointPosition = new(-284f, -405f, 308f);
                    region.WaypointOrientation = new(2.640625f, 0f, 0f);

                    break;

                case RegionPrototype.InvasionSafeAbodeRegion:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.InvasionSafeAbodeRegion,
                        1153032354375335951,
                        1038711701,
                        archiveData,
                        new(-2304f, -1152f, -1152f),
                        new(2304f, 1152f, 1152f),
                        new(60, DifficultyTier.Normal));

                    area = new(2, AreaPrototype.InvasionSafeAbodeArea2, new(1152f, 0f, 0f), true);
                    area.AddCell(new(1, 17230426162301181800, new()));
                    region.AddArea(area);

                    area = new(1, AreaPrototype.InvasionSafeAbodeArea1, new(-1152f, 0f, 0f), true);
                    area.AddCell(new(2, 8175011988152327381, new()));
                    region.AddArea(area);

                    region.EntrancePosition = new(893f, 0f, 60f);
                    region.EntranceOrientation = new(-0.78125f, 0f, 0f);
                    region.WaypointPosition = new(893f, 0f, 60f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.DailyGShockerSubwayRegionL60:

                    archiveData = new byte[] {
                    };

                    region = new(RegionPrototype.DailyGShockerSubwayRegionL60,
                        1153032329227796483,
                        1901487720,
                        archiveData,
                        new(-5633f, -9600f, -2176f),
                        new(5633f, 9600f, 2176f),
                        new(11, DifficultyTier.Normal));

                    area = new(1, AreaPrototype.DailyGSubwayFactoryGen1Area, new(-3456.5f, -7424f, 0f), true);
                    area.AddCell(new(13, 7185016125568720961, new()));
                    region.AddArea(area);

                    area = new(2, AreaPrototype.DailyGSubwayFactoryGen1Area, new(-3456.5f, -3072.001f, 0f), false);
                    area.AddCell(new(12, 1642556494936285849, new()));
                    region.AddArea(area);

                    area = new(3, AreaPrototype.DailyGSubwayFactoryGen1Area, new(-128.5f, -3072.001f, 0f), false);
                    area.AddCell(new(8, 650610774018169216, new()));
                    area.AddCell(new(9, 3804320553692305684, new(2304f, 0f, 0f)));
                    area.AddCell(new(11, 12283464609304222089, new(2304f, 2304f, 0f)));
                    region.AddArea(area);

                    area = new(4, AreaPrototype.DailyGSubwayFactoryGen1Area, new(2175.5f, 1535.999f, 0f), false);
                    area.AddCell(new(2, 10181902047256058244, new()));
                    area.AddCell(new(3, 337661052037765293, new(2304f, 0f, 0f)));
                    area.AddCell(new(4, 5943981279539894550, new(0f, 2304f, 0f)));
                    area.AddCell(new(7, 8677344119691811512, new(2304f, 2304f, 0f)));
                    area.AddCell(new(5, 3662615361967954209, new(0f, 4608f, 0f)));
                    area.AddCell(new(6, 3804320553692305684, new(2304f, 4608f, 0f)));
                    region.AddArea(area);

                    area = new(5, AreaPrototype.DailyGSubwayFactoryGen1Area, new(4480.5044f, 8448f, 0f), false);
                    area.AddCell(new(1, 1568191647055552056, new()));
                    region.AddArea(area);

                    region.EntrancePosition = new(-3376.5f, -8016f, 56f);
                    region.EntranceOrientation = new(1.5625f, 0f, 0f);
                    region.WaypointPosition = new(-3376.5f, -8016f, 56f);
                    region.WaypointOrientation = new();

                    break;

                case RegionPrototype.XManhattanRegion60Cosmic:

                    archiveData = new byte[] {
                        0xEF, 0x01, 0xCF, 0x8F, 0x01, 0x07, 0x00, 0x00, 0x00, 0xB6, 0x80, 0x01,
                        0x9A, 0xB3, 0xE6, 0x80, 0x04, 0x2C, 0x88, 0x18, 0xCA, 0x80, 0x03, 0x9A,
                        0xB3, 0xE6, 0x80, 0x04, 0x95, 0x80, 0x02, 0x1A, 0xCA, 0x40, 0x9A, 0xB3,
                        0xE6, 0x80, 0x04, 0xA8, 0x80, 0x02, 0x80, 0x80, 0x80, 0x88, 0x04, 0xA8,
                        0xC0, 0x02, 0xB8, 0xBD, 0x94, 0xF0, 0x03, 0x00, 0x16, 0xAE, 0xD6, 0xFD,
                        0xEF, 0xD6, 0x84, 0xE1, 0x9B, 0x83, 0x01, 0x08, 0x00, 0xE5, 0x91, 0x01,
                        0x00, 0x05, 0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01,
                        0x01, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00,
                        0x00, 0x01, 0x01, 0x00, 0x00, 0x03, 0x03, 0x06, 0x00, 0x00, 0x01, 0x01,
                        0x00, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E,
                        0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21,
                        0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22,
                        0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24,
                        0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0x05, 0x8E, 0xDA, 0xC2, 0x88, 0xFD,
                        0xE7, 0x87, 0xD1, 0x2D, 0x0A, 0xA0, 0x9F, 0x93, 0xD5, 0xF4, 0xAF, 0x49,
                        0xFF, 0xE3, 0x01, 0x96, 0xCE, 0x96, 0x91, 0x0F, 0x01, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xCB, 0x98, 0xD1, 0xBC, 0xF7,
                        0xB6, 0xE8, 0x8A, 0x22, 0x0A, 0xE0, 0xB1, 0xE9, 0xD9, 0xF4, 0xAF, 0x49,
                        0xD4, 0xF1, 0x02, 0xB8, 0xC2, 0xD1, 0xA7, 0x0D, 0x01, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF4, 0xA5, 0x8C, 0x85, 0xC3,
                        0xAA, 0xC9, 0xCE, 0xDF, 0x01, 0x06, 0x00, 0xFE, 0x91, 0x01, 0xEE, 0x95,
                        0x80, 0xA3, 0x0C, 0x02, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0xE4,
                        0x82, 0x1E, 0xE1, 0xD9, 0x20, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0x99,
                        0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9, 0xDA, 0x24, 0x8F,
                        0x99, 0x25, 0xC1, 0xFD, 0xA4, 0xD3, 0x8E, 0x9C, 0xE1, 0xCA, 0x55, 0x08,
                        0x00, 0xFA, 0xE6, 0x01, 0x00, 0x02, 0x00, 0x00, 0x06, 0x00, 0x00, 0x05,
                        0x05, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x0E, 0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2,
                        0x21, 0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE,
                        0x22, 0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF,
                        0x24, 0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0x98, 0x8A, 0xBD, 0xC5, 0xE4,
                        0xE9, 0xB8, 0xA0, 0xEF, 0x01, 0x08, 0x00, 0xB0, 0x87, 0x03, 0x00, 0x05,
                        0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x01, 0x06,
                        0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00, 0x00, 0x01,
                        0x01, 0x00, 0x00, 0x03, 0x03, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00,
                        0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0xE4, 0x82,
                        0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21, 0xE1, 0xB2,
                        0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22, 0x9D, 0xB3,
                        0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9, 0xDA,
                        0x24, 0x8F, 0x99, 0x25, 0x05, 0xFB, 0x8B, 0x9C, 0x86, 0xB3, 0x90, 0xFD,
                        0xB7, 0x26, 0x06, 0x00, 0x8F, 0xCF, 0x04, 0xCE, 0x9F, 0xBD, 0x95, 0x0B,
                        0x03, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01,
                        0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x04, 0x00, 0x00,
                        0x00, 0x14, 0x00, 0x00, 0x0E, 0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1,
                        0xD9, 0x20, 0x87, 0xA2, 0x21, 0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E,
                        0xF7, 0x22, 0xCC, 0xFE, 0x22, 0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1,
                        0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0xEB,
                        0xF0, 0xE8, 0x8A, 0xA1, 0x82, 0xBB, 0xFB, 0x5D, 0x0A, 0x00, 0x80, 0xB0,
                        0x01, 0xD6, 0xFA, 0xC8, 0x8F, 0x09, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x01, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00,
                        0x00, 0x02, 0x02, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x03, 0x03,
                        0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00,
                        0x00, 0x01, 0x00, 0x00, 0x05, 0x05, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x0E, 0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87,
                        0xA2, 0x21, 0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC,
                        0xFE, 0x22, 0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF,
                        0xCF, 0x24, 0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0x96, 0x89, 0xD9, 0xD8,
                        0xFA, 0xFC, 0xB7, 0xE9, 0x43, 0x0A, 0xA0, 0x86, 0xAD, 0xDD, 0xF4, 0xAF,
                        0x49, 0xA1, 0xB2, 0x02, 0xFA, 0xEF, 0xE1, 0xE0, 0x08, 0x01, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE9, 0x89, 0xC5, 0xA0,
                        0xF2, 0xC5, 0xE2, 0xFD, 0x4B, 0x0A, 0xA0, 0xD3, 0xD1, 0x80, 0xF5, 0xAF,
                        0x49, 0x9F, 0xC2, 0x02, 0xC4, 0xAE, 0xBE, 0xDA, 0x0E, 0x02, 0x00, 0x00,
                        0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x01, 0x99, 0xA1, 0x24, 0xC9, 0xA3, 0xE9, 0xA6,
                        0xC9, 0x87, 0xCD, 0x9F, 0x4F, 0x08, 0x00, 0xAA, 0xD9, 0x02, 0x00, 0x04,
                        0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x01, 0x06,
                        0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00, 0x00, 0x01,
                        0x01, 0x00, 0x00, 0x03, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x0E, 0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2,
                        0x21, 0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE,
                        0x22, 0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF,
                        0x24, 0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0x05, 0x9A, 0xBB, 0xAF, 0xC8,
                        0x86, 0xEF, 0xD4, 0x92, 0x09, 0x06, 0x00, 0xD5, 0xF3, 0x04, 0xB6, 0x9B,
                        0xA3, 0xC3, 0x0E, 0x03, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02,
                        0x02, 0x00, 0x00, 0x03, 0x03, 0x00, 0x00, 0x00, 0x9D, 0xF0, 0xE0, 0xE4,
                        0xEE, 0xD6, 0x87, 0xF4, 0x11, 0x06, 0x00, 0x81, 0xCF, 0x02, 0xB2, 0xBC,
                        0xF7, 0x87, 0x03, 0x03, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02,
                        0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xA3, 0xB0, 0xE1, 0x97,
                        0x98, 0xB3, 0xB7, 0xB9, 0xA0, 0x01, 0x08, 0x00, 0xF4, 0x90, 0x03, 0x00,
                        0x05, 0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x01,
                        0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00, 0x00,
                        0x01, 0x01, 0x00, 0x00, 0x03, 0x03, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00,
                        0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0xE4,
                        0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21, 0xE1,
                        0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22, 0x9D,
                        0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9,
                        0xDA, 0x24, 0x8F, 0x99, 0x25, 0xBA, 0xAE, 0xA3, 0xC0, 0xB8, 0xF7, 0x95,
                        0x80, 0xA6, 0x01, 0x06, 0x00, 0xF3, 0x97, 0x03, 0x8A, 0xAD, 0xC7, 0xF4,
                        0x01, 0x03, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
                        0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x02, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFE, 0xBC, 0x8D, 0xB4, 0xAF, 0xAD,
                        0xEF, 0xB3, 0x62, 0x06, 0x00, 0xCF, 0x9E, 0x03, 0xC0, 0xFD, 0xBE, 0x9D,
                        0x07, 0x03, 0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01,
                        0x01, 0x04, 0x00, 0x00, 0x02, 0x04, 0x00, 0x00, 0x02, 0x02, 0x04, 0xC0,
                        0xF2, 0xEA, 0xCB, 0xF5, 0xAF, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E,
                        0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21,
                        0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22,
                        0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24,
                        0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0x05, 0xDA, 0xC9, 0xFD, 0xFC, 0x8E,
                        0x9C, 0xEF, 0xBB, 0xD1, 0x01, 0x08, 0x00, 0xD0, 0xA6, 0x03, 0x00, 0x05,
                        0x00, 0x00, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x01, 0x06,
                        0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00, 0x00, 0x01,
                        0x01, 0x00, 0x00, 0x03, 0x03, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00,
                        0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0xE4, 0x82,
                        0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21, 0xE1, 0xB2,
                        0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22, 0x9D, 0xB3,
                        0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9, 0xDA,
                        0x24, 0x8F, 0x99, 0x25, 0x83, 0xE3, 0xB9, 0x8A, 0xD7, 0xDB, 0xE2, 0xED,
                        0xB2, 0x01, 0x08, 0x00, 0x86, 0xDD, 0x04, 0x00, 0x07, 0x00, 0x00, 0x06,
                        0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x01, 0x06, 0x00, 0x00, 0x01,
                        0x01, 0x00, 0x00, 0x02, 0x02, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00,
                        0x03, 0x03, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x04, 0x04, 0x06,
                        0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x05, 0x05, 0x06, 0x00, 0x00, 0x01,
                        0x01, 0x00, 0x00, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x0E, 0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2,
                        0x21, 0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE,
                        0x22, 0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF,
                        0x24, 0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0xF8, 0xFD, 0xA4, 0xBD, 0xD2,
                        0xCA, 0xC2, 0xA2, 0x0D, 0x02, 0x00, 0x8B, 0xB5, 0x03, 0x00, 0x00, 0x0E,
                        0xE4, 0x82, 0x1E, 0xAC, 0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21,
                        0xE1, 0xB2, 0x21, 0x9A, 0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22,
                        0x9D, 0xB3, 0x23, 0x99, 0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24,
                        0xD9, 0xDA, 0x24, 0x8F, 0x99, 0x25, 0xA0, 0xD9, 0xEC, 0x92, 0xDA, 0x8C,
                        0xED, 0xE9, 0xC8, 0x01, 0x06, 0x00, 0xB3, 0xE0, 0x03, 0xEA, 0x8F, 0xB2,
                        0xC0, 0x02, 0x03, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x01, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x02,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xAD, 0xE6, 0x85, 0xFD, 0xEB,
                        0xC3, 0xBC, 0x9A, 0x26, 0x06, 0x00, 0xBA, 0xE9, 0x04, 0xF6, 0x98, 0x99,
                        0xBD, 0x06, 0x03, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x01, 0x01, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x04,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x9E, 0xF7, 0x22, 0xD9, 0xDA,
                        0x24, 0x03, 0xF0, 0x96, 0x8D, 0xE1, 0xD2, 0xE4, 0xA6, 0xF0, 0xA3, 0x01,
                        0x08, 0x00, 0xD2, 0xBB, 0x05, 0x00, 0x04, 0x00, 0x00, 0x06, 0x00, 0x00,
                        0x01, 0x01, 0x00, 0x00, 0x01, 0x01, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00,
                        0x00, 0x02, 0x02, 0x06, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x03, 0x03,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0xE4, 0x82, 0x1E, 0xAC,
                        0xC0, 0x1F, 0xE1, 0xD9, 0x20, 0x87, 0xA2, 0x21, 0xE1, 0xB2, 0x21, 0x9A,
                        0xA0, 0x22, 0x9E, 0xF7, 0x22, 0xCC, 0xFE, 0x22, 0x9D, 0xB3, 0x23, 0x99,
                        0xA1, 0x24, 0xF1, 0xB4, 0x24, 0xDF, 0xCF, 0x24, 0xD9, 0xDA, 0x24, 0x8F,
                        0x99, 0x25, 0x00, 0x02, 0xBF, 0x9B, 0x02, 0xCF, 0x9E, 0x03, 0x00, 0xBB,
                        0x8A, 0x8C, 0xC2, 0x92, 0xC7, 0xA2, 0xD2, 0x71, 0x00, 0xBD, 0xD7, 0x03,
                        0xCF, 0x9E, 0x03, 0x00, 0x02, 0x02, 0x00, 0xC8, 0x88, 0x99, 0x95, 0xB2,
                        0x09, 0x00, 0x00
                    };

                    region = new(RegionPrototype.XManhattanRegion60Cosmic,
                        1154146333179724697,
                        1883928786,
                        archiveData,
                        new(-1152f, -1152f, -1152f),
                        new(12672f, 12672f, 1152f),
                        new(63, DifficultyTier.Cosmic));


                    area = new(1, AreaPrototype.XManhattanArea1, new(), true);
                    area.AddCell(new(30, 16904680670227997475, new()));
                    area.AddCell(new(23, 6471827512511636368, new()));
                    area.AddCell(new(35, 92949505051927936, new()));
                    area.AddCell(new(31, 5807200255061009190, new()));
                    area.AddCell(new(12, 4255131489983407209, new()));
                    area.AddCell(new(13, 16358808346792043741, new()));

                    region.AddArea(area);

                    region.EntrancePosition = new(12131.125f, 7102.125f, 48f);
                    region.EntranceOrientation = new();
                    region.WaypointPosition = new(11952f, 7040f, 48f);
                    region.WaypointOrientation = new(1.5625f, 0f, 0f);

                    break;

            }

            return region;
        }

    }
}
