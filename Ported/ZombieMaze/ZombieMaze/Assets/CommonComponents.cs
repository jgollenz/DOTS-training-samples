﻿using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

using System;

public struct Speed : IComponentData
{
    public float Value;

    public Speed(float speed)
    {
        Value = speed;
    }
}

public struct CapsuleRotation : IComponentData
{
}

public struct Position : IComponentData
{
    public float2 Value;
}

public enum MoveState
{
    IDLE,
    MOVING
}

public struct Direction : IComponentData
{
    public float2 Value;
    public MoveState MoveState;
    public int2 TargetTile;
}

public struct Random : IComponentData
{
    public Unity.Mathematics.Random Value;

    public Random(uint seed)
    {
        Value = new Unity.Mathematics.Random(seed);
    }
}

public struct ZombieTag : IComponentData {}

public struct PlayerTag : IComponentData {}

public struct Spawner : IComponentData
{
    public int2 MazeSize;
    public Entity Prefab;
}

public struct TileSpawner : IComponentData
{
}

public struct ZombieSpawner : IComponentData
{
    public uint NumZombies;
}

public struct MovingWallSpawner : IComponentData
{
    public uint NumWalls;
}

public struct CapsuleSpawner : IComponentData
{
    public uint NumCapsules;
}

public struct MazeSpawner : IComponentData
{
    public uint OpenStripsWidth;
    public uint MazeStripsWidth;
}

public struct MazeSize : IComponentData
{
    public int2 Value;
}

public struct MazeTag : IComponentData
{
};

[Flags]
public enum WallBits : byte
{
    Left   = (1 << 0),
    Right  = (1 << 1),
    Top    = (1 << 2),
    Bottom = (1 << 3),
    Visited = (1 << 4)
}

public struct TagDijkstraGenerateMap : IComponentData {};

public struct MapCell : IBufferElementData
{
    public byte Value;
}

public struct DistCell : IBufferElementData
{
    public int Value;
}

public struct DijkstraMap : IComponentData
{
    public int Width;
    public int Height;
    public int2 Origin;

    public void SetOrigin(int x, int y)
    {
        Origin.x = x;
        Origin.y = y;
    }

    public DijkstraMap(int width, int height)
    {
        Width  = width;
        Height = height;
        Origin = int2.zero;
    }
}

public struct MovingWall : IComponentData
{
    public int Width;
    public int Range;
    public float2 Direction;
    public float2 Index;
    public int Speed;
    public int Tick;
}
