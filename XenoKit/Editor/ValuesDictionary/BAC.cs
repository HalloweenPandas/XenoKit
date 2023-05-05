﻿using System.Collections.Generic;
using Xv2CoreLib.BAC;

namespace XenoKit.Editor.ValuesDictionary
{
    public static class BAC
    {
        /// <summary>
        /// Search the file for any unknown values and add them to the dictionaries.
        /// </summary>
        public static void AddMissing(BAC_File bacFile)
        {
            if (bacFile == null) return;

            foreach(var bacEntry in bacFile?.BacEntries)
            {
                if (bacEntry.IBacTypes == null) return;

                foreach(var type in bacEntry.IBacTypes)
                {
                    if(type is BAC_Type0 type0)
                    {
                        if(!AnimationEanType.ContainsKey((ushort)type0.Ean_Type))
                            AnimationEanType.Add((ushort)type0.Ean_Type, $"Unknown ({type0.Ean_Type})");
                    }
                    else if (type is BAC_Type1 type1)
                    {
                        if (!BdmType.ContainsKey((byte)type1.bdmFile))
                            BdmType.Add((byte)type1.bdmFile, $"Unknown ({type1.bdmFile})");
                    }
                    else if (type is BAC_Type3 type3)
                    {
                        if (!InvulnerabilityTypes.ContainsKey(type3.InvulnerabilityType))
                            InvulnerabilityTypes.Add(type3.InvulnerabilityType, $"Unknown ({type3.InvulnerabilityType})");
                    }
                    else if (type is BAC_Type8 type8)
                    {
                        if (!EepkType.ContainsKey((ushort)type8.EepkType))
                            EepkType.Add((ushort)type8.EepkType, $"Unknown ({type8.EepkType})");
                    }
                    else if (type is BAC_Type9 type9)
                    {
                        if (!BsaType.ContainsKey((byte)type9.BsaType))
                            BsaType.Add((byte)type9.BsaType, $"Unknown ({type9.BsaType})");

                        if (!BsaSpawnSource.ContainsKey(type9.SpawnSource))
                            BsaSpawnSource.Add(type9.SpawnSource, $"Unknown ({type9.SpawnSource})");

                        if (!BsaSpawnOrientation.ContainsKey(type9.SpawnOrientation))
                            BsaSpawnOrientation.Add(type9.SpawnOrientation, $"Unknown ({type9.SpawnOrientation})");

                    }
                    else if (type is BAC_Type10 camera)
                    {
                        if (!CameraEanType.ContainsKey((ushort)camera.Ean_Type))
                            CameraEanType.Add((ushort)camera.Ean_Type, $"Unknown ({camera.Ean_Type})");
                    }
                    else if(type is BAC_Type11 sound)
                    {
                        if(!AcbType.ContainsKey((ushort)sound.AcbType))
                            AcbType.Add((ushort)sound.AcbType, $"Unknown ({sound.AcbType})");
                    }
                    else if (type is BAC_Type12 assistance)
                    {
                        if (!TargetingAssistanceAxis.ContainsKey((ushort)assistance.Axis))
                            TargetingAssistanceAxis.Add((ushort)assistance.Axis, $"Unknown ({(ushort)assistance.Axis})");
                    }
                    else if (type is BAC_Type18 physics)
                    {
                        if (!PhysicsObjectControlType.ContainsKey((ushort)physics.Function))
                            PhysicsObjectControlType.Add((ushort)physics.Function, $"Unknown ({(ushort)physics.Function})");
                    }
                    else if (type is BAC_Type20 homing)
                    {
                        if (!HomingType.ContainsKey((ushort)homing.HomingMovementType))
                            HomingType.Add((ushort)homing.HomingMovementType, $"Unknown ({(ushort)homing.HomingMovementType})");
                    }


                }
            }
        }

        //Animation Ean Type
        public static Dictionary<ushort, string> AnimationEanType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Commom" },
            { 5 , "Character" },
            { 65534 , "Skill" },
            { 9 , "Commom (tail)" },
            { 10 , "Face (A)" },
            { 11 , "Face (B)" }
        };

        //BdmType
        public static Dictionary<byte, string> BdmType { get; private set; } = new Dictionary<byte, string>()
        {
            { 0 , "Commom" },
            { 1 , "Character" },
            { 2 , "Skill" }
        };

        //BDM HitboxFlags (DamageProperties): These are flags but are better represented as a dropdown menu. In all BAC files none of these are ever used in combination so it is safe to do. (exception is the first 4 bits, which will be seperated into bools)
        public static Dictionary<ushort, string> BdmImpactType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0x0000 , "Continuous" },
            { 0x2000 , "Single Impact" },
            { 0x1000 , "Unk1" },
            { 0x4000 , "Unk2" },
            { 0x8000 , "Unk3" }
        };

        public static Dictionary<ushort, string> BdmDamageType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0x0000 , "Health" },
            { 0x0200 , "No Damage" },
            { 0x0400 , "Ki" },
            { 0x0100 , "No Impact (1)" },
            { 0x0800 , "No Impact (2)" }
        };

        public static Dictionary<ushort, string> BdmSpawnSource { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0x0000 , "User" },
            { 0x0080 , "Target" },
            { 0x0010 , "Unk1" },
            { 0x0020 , "Unk2" },
            { 0x0040 , "Unk3" }
        };

        //Invulnerability
        public static Dictionary<ushort, string> InvulnerabilityTypes { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0xffff , "None" },
            { 0x0 , "All Attacks Miss (0)" },
            { 0x1 , "Unknown (1)" },
            { 0x2 , "Stun Proof (2)" },
            { 0x3 , "No Damage, Stun Proof (3)" },
            { 0x4 , "No Damage, Stun Proof (4)" },
            { 0x5 , "No Damage, Consume Stamina (5)" },
            { 0x6 , "Attacks Absorbed (6)" },
            { 0x7 , "Attacks Absorbed (7)" },
            { 0x8 , "No Damage, Stun Proof (8)" },
            { 0x9 , "First Hit Damages, Stun Proof (9)" },
            { 0xa , "First Hit Damages, Stun Proof (10)" },
            { 0xb , "First Hit Damages, Stun Proof (11)" },
            { 0xc , "First Hit Damages, Stun Proof (12)" },
            { 0xd , "Automatic Guard (13)" },
            { 0xe , "Ki Blasts Fly Through (14)" }
        };


        //Camera Ean Type
        public static Dictionary<ushort, string> CameraEanType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Target" },
            { 3 , "Common" },
            { 4 , "Character" },
            { 5 , "Skill" }
        };

        //"Flags"
        public static Dictionary<short, string> Flags { get; private set; } = new Dictionary<short, string>()
        {
            { 0x0 , "Both" },
            { 0x1 , "CaC" },
            { 0x2 , "Roster" },
            { 0x5 , "Unknown (5)" },
        };

        //AcbType
        public static Dictionary<ushort, string> AcbType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Common SE" },
            { 2 , "Character SE" },
            { 3 , "Character VOX" },
            { 10 , "Skill SE" },
            { 11 , "Skill VOX" }
        };

        //EepkType
        public static Dictionary<ushort, string> EepkType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Common" },
            { 2 , "Character" },
            { 5 , "Super Skill" },
            { 6 , "Ultimate Skill" },
            { 3 , "Awoken Skill" },
            { 7 , "Evasive Skill" },
            { 9 , "Ki Blast Skill" },
            { 1 , "Stage BG" },
            { 11 , "Stage" }
        };

        //EepkGlobalSkillIds
        public static Dictionary<ushort, string> EepkGlobalSkillId { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "BTL_CMN" },
            { 1 , "BTL_AURA" },
            { 2 , "BTL_KDN" },
            { 6 , "BTL_CMN2" },
            { 3 , "lby_cmn/LBY_CMN" },
            { 4 , "TTL/TTL" },
            { 5 , "ttl_lby/TTL_LBY" }
        };

        //BsaType
        public static Dictionary<byte, string> BsaType { get; private set; } = new Dictionary<byte, string>()
        {
            { 0 , "Common" },
            { 5 , "Super Skill" },
            { 6 , "Ultimate Skill" },
            { 3 , "Awoken Skill" },
            { 7 , "Evasive Skill" },
            { 8,  "Unknown (8)" }, 
            { 9 , "Ki Blast Skill" },
        };

        //BsaSpawnSource
        public static Dictionary<byte, string> BsaSpawnSource { get; private set; } = new Dictionary<byte, string>()
        {
            { 0 , "User (0)" },
            { 1 , "Target (1)" },
            { 2 , "Unknown (2)" },
            { 3 , "Unknown (3)" },
            { 4 , "Unknown (4)" },
            { 5,  "Target (5)" },
            { 6 , "Unknown (6)" },
            { 7 , "Map (7)" },
        };

        //BsaSpawnOrientation
        public static Dictionary<byte, string> BsaSpawnOrientation { get; private set; } = new Dictionary<byte, string>()
        {
            { 0 , "Default" },
            { 3 , "User Direction" }
        };

        //Targeting Assistance
        public static Dictionary<ushort, string> TargetingAssistanceAxis { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "X" },
            { 1 , "Y" },
            { 2 , "Z" },
            { 3 , "Unknown (3)" },
            { 4 , "Unknown (4)" },
            { 8 , "Unknown (8)" },
            { 12 , "Unknown (12)" }
        };

        //BCS Part ID
        public static Dictionary<ushort, string> BcsPartId { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "FaceBase" },
            { 1 , "FaceForehead" },
            { 2 , "FaceEye" },
            { 3 , "FaceNose" },
            { 4 , "FaceEar" },
            { 5 , "Hair" },
            { 6 , "Bust" },
            { 7 , "Pants" },
            { 8 , "Rists" },
            { 9 , "Boots" },
        };

        //Used on Cameras, Effects, Projectiles, ScreenEffects, ThrowHandlers...
        public static Dictionary<BoneLinks, string> BoneNames = new Dictionary<BoneLinks, string>()
        {
            //All values tested manually ingame.
            { BoneLinks.b_C_Base , "b_C_Base" },
            { BoneLinks.b_C_Chest , "b_C_Chest" },
            { BoneLinks.b_C_Head , "b_C_Head" },
            { BoneLinks.b_C_Neck1 , "b_C_Neck1" },
            { BoneLinks.b_C_Pelvis , "b_C_Pelvis" },
            { BoneLinks.b_C_Spine1 , "b_C_Spine1" },
            { BoneLinks.b_C_Spine2 , "b_C_Spine2" },
            { BoneLinks.b_R_Hand , "b_R_Hand" },
            { BoneLinks.b_L_Hand , "b_L_Hand" },
            { BoneLinks.b_R_Arm , "b_R_Arm" },
            { BoneLinks.b_L_Arm , "b_L_Arm" },
            { BoneLinks.b_R_Shoulder , "b_R_Shoulder" },
            { BoneLinks.b_L_Shoulder , "b_L_Shoulder" },
            { BoneLinks.b_R_Foot , "b_R_Foot" },
            { BoneLinks.b_L_Foot , "b_L_Foot" },
            { BoneLinks.b_R_Leg1 , "b_R_Leg1" },
            { BoneLinks.b_L_Leg1 , "b_L_Leg1" },
            { BoneLinks.g_C_Head , "g_C_Head" },
            { BoneLinks.g_C_Pelvis , "g_C_Pelvis" },
            { BoneLinks.g_L_Foot , "g_L_Foot" },
            { BoneLinks.g_L_Hand , "g_L_Hand" },
            { BoneLinks.g_R_Foot , "g_R_Foot" },
            { BoneLinks.g_R_Hand , "g_R_Hand" },
            { BoneLinks.g_x_CAM, "g_x_CAM" },
            { BoneLinks.g_x_LND , "g_x_LND" },
        };

        #region Functions
        //Functions
        public static Dictionary<int, string> BacFunctionNames { get; private set; } = new Dictionary<int, string>()
        {
            { 0x0 , "BAC Loop" },
            { 0x2 , "Damage" },
            { 0x4 , "Take/Give Ki" },
            { 0x6 , "Invisibility" },
            { 0x7 , "Bone Rotate (Y)" },
            { 0xb , "Override ThrowHandler Duration" },
            { 0xc , "Freeze Game, Dark Screen" },
            { 0xd , "Activate Transformation" },
            { 0xe , "Deactivate Transformation" },
            { 0xf , "Damage User" },
            { 0x10 , "Pass BSA Entry (0x10)" },
            { 0x11 , "Swap Bodies (Target, Throw)" },
            { 0x12 , "Toggle Target" },
            { 0x13 , "Sets BCS PartSet (temp)" },
            { 0x14 , "Sets BCS PartSet (permanent)" },
            { 0x15 , "Remove From Battle" },
            { 0x16 , "Take/Give Stamina" },
            { 0x17 , "Recover Health (instant)" },
            { 0x1b , "Activate Power Up" },
            { 0x1d , "GoTo BAC Entry NOW" },
            { 0x1e , "Disable Movement (0x1e)" },
            { 0x1f , "Reset Camera" },
            { 0x20 , "Disable Movement (0x20)" },
            { 0x22 , "BAC Loop (instant end)" },
            { 0x23 , "Spawn Floating Pebbles" },
            { 0x24 , "Knock Away Pebbles" },
            { 0x25 , "GoTo BAC Entry AFTER" },
            { 0x26 , "Pass BSA Entry (0x26)" },
            { 0x28 , "Invisible Opponents" },
            { 0x29 , "Untargetable" },
            { 0x2a , "Set BCS BoneScale (gradual)" },
            { 0x2d , "Disable Hitbox" },
            { 0x2e , "Activate Giant Hitbox (Become Giant)" },
            { 0x30 , "Render Black Void" },
            { 0x31 , "Recover Health (gradual)" },
            { 0x3c , "Stun User" },
            { 0x3d , "Force End BAC Loop" },
            { 0x3f , "Activate Limit Burst" },
            { 0x40 , "Auto Lock-On" },
            { 0x43 , "UI Function" },
            { 0x44 , "Damages User (x10)" },
            { 0x4a , "Skill Cooldown" },
            { 0x4c , "Activate Talisman" },
            { 0x4e , "Skill Upgrade" },
        };

        //Param1 Names
        public static Dictionary<int, string> BacFunctionParam1Names { get; private set; } = new Dictionary<int, string>()
        {
            { 0x2 , "Damage" },
            { 0x4 , "Ki Amount" },
            { 0x7 , "Rotation (degrees)" },
            { 0xb , "New Duration" },
            { 0xf , "Damage Amount" },
            { 0x10 , "BSA Condition" },
            { 0x13 , "PartSet ID" },
            { 0x14 , "PartSet ID" },
            { 0x16 , "Stamina Amount" },
            { 0x17 , "Health Amount" },
            { 0x1d , "BAC Entry ID" },
            { 0x25 , "BAC Entry ID" },
            { 0x26 , "BSA Condition" },
            { 0x2a , "BoneScale ID" },
            { 0x31 , "Health Amount" },
            { 0x3c , "Stun Duration" },
            { 0x40 , "Range" },
            { 0x43 , "Stamina Cost" },
            { 0x44 , "Damage Amount" },
            { 0x4a , "Cooldown Duration" },
            { 0x4c , "Talisman ID" },
            { 0x4e , "Skill ID" },
        };

        //Param2 Names
        public static Dictionary<int, string> BacFunctionParam2Names { get; private set; } = new Dictionary<int, string>()
        {
            { 0x25 , "Skill Type" },
            { 0x26 , "Skill Type" },
            { 0x4e , "Skill Type" },
        };

        //Param3 Names
        public static Dictionary<int, string> BacFunctionParam3Names { get; private set; } = new Dictionary<int, string>()
        {
            { 0x25 , "Skill ID" },
            { 0x26 , "Skill ID" },
            { 0x4e , "Upgrade Command" },
        };

        //Param1 ToolTips
        public static Dictionary<int, string> BacFunctionParam1ToolTips { get; private set; } = new Dictionary<int, string>()
        {
            { 0x4 , "Positive amounts drain Ki, negative amounts give." },
            { 0xf , "Positive values deal damage. Can't KO user." },
            { 0x10 , "Should match the BAC condition on the projectile BSA entry (BsaEntryPassing type)." },
            { 0x13 , "Can only use PartSets that are loaded with the character (starting costume + any PartSets on an awoken skill) or 100 and 200." },
            { 0x14 , "Can only use PartSets that are loaded with the character (starting costume + any PartSets on an awoken skill) or 100 and 200." },
            { 0x16 , "Positive amounts drain stamina, negative amounts give." },
            { 0x17 , "Positive amounts give health. Negative values do nothing." },
            { 0x1d , "ID of the BAC entry to pass to. Must be in the same BAC file." },
            { 0x25 , "ID of the BAC entry to pass to. Can be in another skills BAC file." },
            { 0x26 , "Should match the BAC condition on the projectile BSA entry (BsaEntryPassing type)." },
            { 0x2a , "This is either the BoneScale entry ID, or -1 to deactivate (return to default bone scale)." },
            { 0x31 , "Positive values for health gain. An amount of 100 is equal to 3 bars." },
            { 0x43 , "Positive values for stamina drain, negative for gain." }
        };

        //Param1 ToolTips
        public static Dictionary<int, string> BacFunctionParam2ToolTips { get; private set; } = new Dictionary<int, string>()
        {
            { 0x25 , "Skill Types:\nSuper = 5\nUltimate = 6\nAwoken = 3\nEvasive = 7\nKi Blast = 9" },
            { 0x26 , "Skill Types:\nSuper = 5\nUltimate = 6\nAwoken = 3\nEvasive = 7\nKi Blast = 9" },
            { 0x4e , "Skill Types:\nSuper = 5\nUltimate = 6\nAwoken = 3\nEvasive = 7\nKi Blast = 9" }
        };

        //Function Parameter count
        public static Dictionary<int, int> BacFunctionParamCount { get; private set; } = new Dictionary<int, int>()
        {
            { 0 , 0 },
            { 1 , 0 },
            { 2 , 3 },
            { 4 , 1 },
            { 5 , 1 },
            { 6 , 1 },
            { 7 , 1 },
            { 11 , 1 },
            { 12 , 0 },
            { 13 , 1 },
            { 14 , 0 },
            { 15 , 1 },
            { 16 , 1 },
            { 17 , 0 },
            { 18 , 0 },
            { 19 , 1 },
            { 20 , 1 },
            { 22 , 1 },
            { 23 , 1 },
            { 24 , 1 },
            { 25 , 1 },
            { 26 , 1 },
            { 27 , 0 },
            { 28 , 0 },
            { 29 , 1 },
            { 30 , 0 },
            { 31 , 0 },
            { 33 , 0 },
            { 34 , 0 },
            { 35 , 1 },
            { 36 , 0 },
            { 37 , 3 },
            { 38 , 5 },
            { 39 , 0 },
            { 40 , 0 },
            { 41 , 0 },
            { 42 , 1 },
            { 43 , 1 },
            { 44 , 1 },
            { 45 , 1 },
            { 46 , 1 },
            { 47 , 0 },
            { 48 , 0 },
            { 49 , 1 },
            { 50 , 0 },
            { 51 , 0 },
            { 52 , 0 },
            { 53 , 1 },
            { 54 , 1 },
            { 55 , 1 },
            { 56 , 0 },
            { 57 , 5 },
            { 58 , 0 },
            { 59 , 0 },
            { 60 , 1 },
            { 61 , 0 },
            { 62 , 3 },
            { 63 , 0 },
            { 64 , 1 },
            { 65 , 0 },
            { 66 , 0 },
            { 67 , 1 },
            { 68 , 1 },
            { 69 , 0 },
            { 71 , 0 },
            { 72 , 0 },
            { 73 , 0 },
            { 74 , 1 },
            { 75 , 4 },
            { 76 , 1 },
            { 77 , 4 },
            { 78 , 4 },
            { 79 , 0 },
            { 80 , 3 },
            { 81 , 0 },
            { 82 , 0 },
            { 83 , 0 },
            { 84 , 4 },
            { 85 , 0 },
            { 86 , 0 },
            { 87 , 2 },
            { 88 , 1 },
            { 89 , 0 },
            { 90 , 0 },
            { 91 , 0 },
            { 92 , 0 },
            { 94 , 0 },
        };

        //BacFunctionSkillType
        public static Dictionary<float, string> BacFunctionSkillType { get; private set; } = new Dictionary<float, string>()
        {
            { 0f , "Common" },
            { 1f , "Stage BG" },
            { 2f , "Character" },
            { 5f , "Super Skill" },
            { 6f , "Ultimate Skill" },
            { 3f , "Awoken Skill" },
            { 7f , "Evasive Skill" },
            { 9f , "Ki Blast Skill" }
        };
        #endregion

        //ScreenEffect IDs (BPE)
        public static Dictionary<ushort, string> ScreenEffectIds { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "White Flash [30]" },
            { 1 , "Strong White Flash [30]" },
            { 2 , "Weak White Flash [60]" },
            { 3 , "Weaker White Flash [6]" },
            { 4 , "Weak Chara Illumination [180]" },
            { 5 , "Mild Desaturated Reddish Flash [39]" },
            { 6 , "2 Consecutive Mild Flashes [90]" },
            { 10 , "Small Motion Blur/Shake [10]" },
            { 11 , "Strong Motion Blur/Shake [30]" },
            { 12, "Rapid Motion Blur/Shake [100]" },
            { 13, "Tiny Motion Blur/Shake [13]" },
            { 14, "Side Screen Shake, Blue Filter [40]" },
            { 15, "Very Quick Sideway Motion Blur/Shake 1 [10]" },
            { 16, "Very Quick Sideway Motion Blur/Shake 2 [10]" },
            { 17, "Dark, Purple Flash [40]" },
            { 18, "Motion Blur/Shake Sequence [80]" },
            { 20, "Underwater Blur Effect 1 [120]" },
            { 21, "Underwater Blur Effect 2 [200]" },
            { 22, "Underwater Blur Effect 3 [200]" },
            { 23, "Underwater Blur Effect 4 [150]" },
            { 24, "Underwater Blur Effect 5 [140]" },
            { 26, "Wave-like Blur [139]" },
            { 27, "Upward-flow Liquid Blur [85]" },
            { 30, "Solar Flare Effects [90]" },
            { 31, "Shaking and Dark Flash [20]" },
            { 32, "Shadowy Flash [19]" },
            { 33, "Consecutive Shadowy Flashes [50]" },
            { 34, "Consecutive Shadowy Flashes, Darken Screen [100]" },
            { 35, "Shadowy Flash, Longer  [80]" },
            { 36, "Desaturated Flash [40]" },
            { 37, "Black Screen [12]" },
            { 40, "Expanding Transparent Ring 1 [10]" },
            { 41, "Expanding Transparent Ring 2 [12]" },
            { 42, "Expanding Transparent Ring 3 [20]" },
            { 43, "Expanding Distorted Ring [60]" },
            { 44, "Expanding Distorted Ring, Bigger [50]" },
            { 45, "Expanding Transparent Ring 2, Quick [24]" },
            { 46, "Expanding Transparent Ring 3, Quick [40]" },
            { 50, "Brighten Screen 1 [100]" },
            { 51, "Brighten Screen 2 [800]" },
            { 52, "Expanding Transparent Sphere [20]" },
            { 53, "Flashing Blue Hue [16]" },
            { 54, "Darken Screen 1 [10]" },
            { 57, "Darken Screen 2 [28]" },
            { 55, "Darken and Desaturate Screen 1 [120]" },
            { 56, "Darken and Desaturate Screen 2 [90]" },
            { 59, "Darken and Desaturate Screen 3 [120]" },
            { 60, "Bright motion blur/shake [70]" },
            { 61, "Darken Screen Slightly (Fade) 1 [200]" },
            { 63, "Darken Screen Slightly (Fade) 2 [200]" },
            { 64, "Bright Pink Flash [14]" },
            { 65, "Light Blue Filter, Fade to Normal [60]" },
            { 66, "Shadowy Flash, Desaturated [55]" },
            { 70, "Darken Filter For Skill Activation [100]" },
            { 71, "Quick Blur/Shake [16]" },
            { 72, "Render a Black Void [160]" },
            { 73, "Darken Screen 3 [60]" },
            { 74, "Render a Black Void [200]" },
            { 75, "Flashing Dark-Purple Hue [160]" },
            { 76, "Gradual White Screen Blur 1 [50]" },
            { 77, "Gradual White Screen Blur 2 [80]" },
            { 78, "Invert World Colors [59]" },
            { 79, "Consecutive transparent flashes/shakes [95]" },
            { 80, "Flashing Green Body Outline 1 [30]" },
            { 81, "Red Body Outline [160]" },
            { 82, "Flashing Putple Body Outline [130]" },
            { 83, "Flashing White Body Outline 1 [100]" },
            { 84, "Flashing White Body Outline 2 [100]" },
            { 85, "Flashing White Body Outline 3 [60]" },
            { 86, "Flashing Green Body Outline 2 [30]" },
            { 88, "Flashing Green Body Outline 3 [30]" },
            { 90, "Gradually Darken Background [300]" },
            { 91, "Slightly Fade Out Background [120]" },
            { 92, "Background Flashes Purple [120]" },
            { 93, "Background Flashes Purple, Quick [120]" },
            { 94, "Several Intense Blurs/Shakes [190]" },
            { 95, "Gradualy Fade To White [260]" },
            { 96, "Background Flashes Light-Purple [160]" },
            { 97, "Background Flashes Light-Purple, Slow [190]" },
            { 98, "Quick White Flash [30]" },
            { 100, "Distortion Bulge [199]" },
            { 101, "Intense Zoom Blur [350]" },
            { 110, "Light Blue Haze [190]" },
            { 111, "Light Blue Haze, Intense [140]" },
            { 112, "Light Purple Haze [138]" },
            { 113, "Light Purple Haze, Blur [51]" },
            { 114, "Light Blue Haze, Blur, Intense [130]" },
            { 115, "Warm Light-Blue Hue [186]" },
            { 116, "Light Green Hue [130]" },
            { 117, "Flashing Green Hue [350]" },
            { 118, "Saturated Light Purple Hue [250]" },
            { 119, "Saturated Green Hue [130]" },
            { 120, "Darken Background 1 [100]" },
            { 121, "Darken Background 2 [560]" },
            { 122, "Darken Background 3 [560]" },
            { 123, "Black Background [20]" },
            { 124, "Darken Background 4 [30]" },
            { 125, "Light Blue Tint [0]" },
            { 126, "Darken Background 5 [130]" },
            { 127, "Deep Blue Tint [150]" },
            { 128, "Bleached Light Blue Tint [40]" },
            { 129, "Blue Background [30]" },
            { 130, "Fade Background to Blue [352]" },
            { 131, "Fade to Pink Tint [350]" },
            { 132, "Darken Background 6 [60]" },
            { 133, "Background Flashes Light Green [30]" },
            { 140, "Thin Green Body Outline 1 [110]" },
            { 141, "Thin White Body Outline [140]" },
            { 142, "Thin Green Body Outline 2 [400]" },
            { 150, "Very Dark Background [60]" },
            { 151, "Warm Organge Hue 1 [0]" },
            { 152, "Warm Bluish Hue [0]" },
            { 153, "Intense Reddish Hue [0]" },
            { 154, "Slightly Darker Background [60]" },
            { 155, "Gradually Darkens Screen [180]" },
            { 156, "Warm Organge Hue 2 [0]" },
            { 157, "Light Blue Tint [130]" },
            { 158, "Blue Tint [0]" },
            { 159, "Blue Tint, Weaker [0]" },
            { 160, "Blur [500]" },
            { 165, "Various Distortion Effects (Large) [200]" },
            { 170, "Motion Blur/Shakes [90]" },
            { 175, "Gradually Fade Background to Dark Brown 1 [260]" },
            { 176, "Gradually Fade Background to Dark Brown 2 [350]" },
            { 177, "Quick Light Blue Tint Flash [60]" },
            { 178, "Light Blue Tint Flash [150]" },
            { 200, "Distortion Bulge Effects [80]" },
            { 211, "Consecutive Shadowy Flashes, Intense [180]" },
            { 212, "Dark Flash, Blur [19]" },
            { 220, "Single Green Hue Flash 1 [90]" },
            { 221, "Single Dark Green Hue Flash [55]" },
            { 222, "Single Green Hue Flash 2 [65]" },
            { 225, "Vertical Blur [140]" },
            { 226, "Blue Tint Flashes, Shakes [100]" },
            { 227, "Red Tint Flashes, Shakes [160]" },
            { 230, "Gradually Darken Background Slightly [160]" },
            { 231, "Single Pink/Purplish Hue Flash [160]" },
            { 232, "Lighten Background [20]" },
            { 233, "Blurry Shakes [80]" },
            { 234, "Light Blue Hue On Background [160]" },
            { 235, "Purple Hue On Background [140]" },
            { 236, "Intense White Flashes, Shakes [70]" },
            { 237, "Intense White Flash -> Purple Flashes/Shakes [140]" },
            { 240, "Lighten Screen [200]" },
            { 241, "Flash Black Background [50]" },
            { 245, "Red Body Outline [5]" },
            { 246, "Dark Tint, Flashing, Quaking [60]" },
            { 250, "Red Body Outline, Red Background [120]" },
            { 251, "Blue Body Outline, Blue Background [120]" },
            { 252, "Green Body Outline, Green Background [120]" },
            { 253, "Pink Body Outline, Pink Background [120]" },
            { 255, "White Flash [33]" },
            { 256, "White Flash [29]" },
            { 257, "White Body Outline 1 [60]" },
            { 260, "White Body Outline 2 [30]" },
        };

        //Bac PhysicsObjectControl
        public static Dictionary<ushort, string> PhysicsObjectControlType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Simulate Physics" },
            { 1 , "Play SCD Animation" },
            { 2 , "Unknown (2)" }
        };

        //BacAuraType
        public static Dictionary<ushort, string> AuraType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "BoostStart" },
            { 1 , "BoostLoop" },
            { 2 , "BoostEnd" },
            { 3 , "KiaiCharge (Ki Charge)" },
            { 4 , "KiryokuMax (Charge End)" },
            { 5 , "HenshinStart (Transformation Aura)" },
            { 6 , "HenshinEnd (Transformation Ends)" }
        };

        //BacHomingType
        public static Dictionary<ushort, string> HomingType { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Horizontal Arc" },
            { 1 , "Straight Line" },
            { 2 , "Right/Left/Up/Down" },
            { 3 , "Unknown (3)" }
        };

        //BacHomingArcDirection
        public static Dictionary<ushort, string> HomingArcDirection { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Right" },
            { 1 , "Left" }
        };

        //BacEyeMovementDirection
        public static Dictionary<ushort, string> EyeMovementDirection { get; private set; } = new Dictionary<ushort, string>()
        {
            { 0 , "Left Up" },
            { 1 , "Up" },
            { 2 , "Right Up" },
            { 3 , "Left" },
            { 4 , "None" },
            { 5 , "Right" },
            { 6 , "Left Down" },
            { 7 , "Down" },
            { 8 , "Right Down" }
        };

    }
}
