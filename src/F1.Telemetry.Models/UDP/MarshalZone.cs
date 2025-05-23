﻿using System.Runtime.InteropServices;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarshalZone
{
    public float m_zoneStart; // Fraction (0..1) of way through the lap the marshal zone starts
    public sbyte m_zoneFlag; // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow
};