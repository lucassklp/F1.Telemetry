﻿using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketMotionExData
{
    [JsonIgnore]
    PacketHeader m_header; // Header
    // Extra player car ONLY data
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionPosition; // Note: All wheel arrays have the following order:
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionVelocity; // RL, RR, FL, FR
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionAcceleration; // RL, RR, FL, FR
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSpeed; // Speed of each wheel
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSlipRatio; // Slip ratio for each wheel
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSlipAngle; // Slip angles for each wheel
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelLatForce; // Lateral forces for each wheel
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelLongForce; // Longitudinal forces for each wheel
    
    public float m_heightOfCOGAboveGround; // Height of centre of gravity above ground
    public float m_localVelocityX; // Velocity in local space – metres/s
    public float m_localVelocityY; // Velocity in local space
    public float m_localVelocityZ; // Velocity in local space
    public float m_angularVelocityX; // Angular velocity x-component – radians/s
    public float m_angularVelocityY; // Angular velocity y-component
    public float m_angularVelocityZ; // Angular velocity z-component
    public float m_angularAccelerationX; // Angular acceleration x-component – radians/s/s
    public float m_angularAccelerationY; // Angular acceleration y-component
    public float m_angularAccelerationZ; // Angular acceleration z-component
    public float m_frontWheelsAngle; // Current front wheels angle in radians
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelVertForce; // Vertical forces for each wheel
    
    public float m_frontAeroHeight; // Front plank edge height above road surface
    public float m_rearAeroHeight; // Rear plank edge height above road surface
    public float m_frontRollAngle; // Roll angle of the front suspension
    public float m_rearRollAngle; // Roll angle of the rear suspension
    public float m_chassisYaw; // Yaw angle of the chassis relative to the direction
    // of motion - radians
};