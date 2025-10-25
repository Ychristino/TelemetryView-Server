using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarDamageDataStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresWear;      // Desgaste dos pneus (porcentagem)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresDamage;     // Dano dos pneus (porcentagem)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_brakesDamage;    // Dano dos freios (porcentagem)

        public byte m_frontLeftWingDamage;  // Dano da asa dianteira esquerda (porcentagem)
        public byte m_frontRightWingDamage; // Dano da asa dianteira direita (porcentagem)
        public byte m_rearWingDamage;       // Dano da asa traseira (porcentagem)
        public byte m_floorDamage;          // Dano do assoalho (porcentagem)
        public byte m_diffuserDamage;       // Dano do difusor (porcentagem)
        public byte m_sidepodDamage;        // Dano da carenagem lateral (porcentagem)
        public byte m_drsFault;             // Indicador de falha no DRS, 0 = OK, 1 = falha
        public byte m_gearBoxDamage;        // Dano da caixa de câmbio (porcentagem)
        public byte m_engineDamage;         // Dano do motor (porcentagem)
        public byte m_engineMGUHWear;       // Desgaste do motor MGU-H (porcentagem)
        public byte m_engineESWear;         // Desgaste do motor ES (porcentagem)
        public byte m_engineCEWear;         // Desgaste do motor CE (porcentagem)
        public byte m_engineICEWear;        // Desgaste do motor ICE (porcentagem)
        public byte m_engineMGUKWear;       // Desgaste do motor MGU-K (porcentagem)
        public byte m_engineTCWear;         // Desgaste do motor TC (porcentagem)
    }
}
