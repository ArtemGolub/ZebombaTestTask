//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Destructed = 0;
    public const int Persistent = 1;
    public const int SelfDestructTimer = 2;
    public const int View = 3;
    public const int ViewPath = 4;
    public const int ViewPrefab = 5;
    public const int ViewProcessed = 6;
    public const int BorderCamera = 7;
    public const int Camera = 8;
    public const int EdgeCollider2D = 9;
    public const int MainCamera = 10;
    public const int BaseStats = 11;
    public const int StatChange = 12;
    public const int StatModifiers = 13;
    public const int Active = 14;
    public const int Damage = 15;
    public const int EntityLink = 16;
    public const int Id = 17;
    public const int Initialized = 18;
    public const int MeshRenderer = 19;
    public const int SpriteRenderer = 20;
    public const int Transform = 21;
    public const int WorldPosition = 22;
    public const int Chasing = 23;
    public const int DeathTimer = 24;
    public const int DirectionSet = 25;
    public const int Enemy = 26;
    public const int EnemyTypeId = 27;
    public const int SpawnTimer = 28;
    public const int CurrentHP = 29;
    public const int Dead = 30;
    public const int HealthBar = 31;
    public const int MaxHP = 32;
    public const int ProcessingDeath = 33;
    public const int Hero = 34;
    public const int Direction = 35;
    public const int FullRotationAlignedAlongDirection = 36;
    public const int MovableByInput = 37;
    public const int MoveInCameraBounds = 38;
    public const int MovementAvailable = 39;
    public const int MoveWithNoBounds = 40;
    public const int Moving = 41;
    public const int RotationAlignedAlongDirection = 42;
    public const int RotationRandomDirection = 43;
    public const int RotationSpeed = 44;
    public const int Speed = 45;
    public const int TurnedAlongDirection = 46;
    public const int ForceApplier = 47;
    public const int ForceProducerId = 48;
    public const int ForceTargetId = 49;
    public const int PhysicsBody = 50;
    public const int PhysicsForce = 51;
    public const int Processed = 52;
    public const int Rigidbody2D = 53;
    public const int Velocity = 54;

    public const int TotalComponents = 55;

    public static readonly string[] componentNames = {
        "Destructed",
        "Persistent",
        "SelfDestructTimer",
        "View",
        "ViewPath",
        "ViewPrefab",
        "ViewProcessed",
        "BorderCamera",
        "Camera",
        "EdgeCollider2D",
        "MainCamera",
        "BaseStats",
        "StatChange",
        "StatModifiers",
        "Active",
        "Damage",
        "EntityLink",
        "Id",
        "Initialized",
        "MeshRenderer",
        "SpriteRenderer",
        "Transform",
        "WorldPosition",
        "Chasing",
        "DeathTimer",
        "DirectionSet",
        "Enemy",
        "EnemyTypeId",
        "SpawnTimer",
        "CurrentHP",
        "Dead",
        "HealthBar",
        "MaxHP",
        "ProcessingDeath",
        "Hero",
        "Direction",
        "FullRotationAlignedAlongDirection",
        "MovableByInput",
        "MoveInCameraBounds",
        "MovementAvailable",
        "MoveWithNoBounds",
        "Moving",
        "RotationAlignedAlongDirection",
        "RotationRandomDirection",
        "RotationSpeed",
        "Speed",
        "TurnedAlongDirection",
        "ForceApplier",
        "ForceProducerId",
        "ForceTargetId",
        "PhysicsBody",
        "PhysicsForce",
        "Processed",
        "Rigidbody2D",
        "Velocity"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.Destructed),
        typeof(Code.Common.PersistentComponent),
        typeof(Code.Common.SelfDestructTimer),
        typeof(Code.Common.View),
        typeof(Code.Common.ViewPath),
        typeof(Code.Common.ViewPrefab),
        typeof(Code.Common.ViewProcessed),
        typeof(Code.Gameplay.Cameras.BorderCamera),
        typeof(Code.Gameplay.Cameras.CameraComponent),
        typeof(Code.Gameplay.Cameras.EdgeCollider2DComponent),
        typeof(Code.Gameplay.Cameras.MainCamera),
        typeof(Code.Gameplay.CharacterStats.BaseStats),
        typeof(Code.Gameplay.CharacterStats.StatChange),
        typeof(Code.Gameplay.CharacterStats.StatModifiers),
        typeof(Code.Gameplay.Common.Active),
        typeof(Code.Gameplay.Common.Damage),
        typeof(Code.Gameplay.Common.EntityLink),
        typeof(Code.Gameplay.Common.Id),
        typeof(Code.Gameplay.Common.InitializedComponent),
        typeof(Code.Gameplay.Common.MeshRendererComponent),
        typeof(Code.Gameplay.Common.SpriteRendererComponent),
        typeof(Code.Gameplay.Common.TransformComponent),
        typeof(Code.Gameplay.Common.WorldPosition),
        typeof(Code.Gameplay.Enemies.Chasing),
        typeof(Code.Gameplay.Enemies.DeathTimer),
        typeof(Code.Gameplay.Enemies.DirectionSet),
        typeof(Code.Gameplay.Enemies.Enemy),
        typeof(Code.Gameplay.Enemies.EnemyTypeIdComponent),
        typeof(Code.Gameplay.Enemies.SpawnTimer),
        typeof(Code.Gameplay.Features.LifeTime.CurrentHP),
        typeof(Code.Gameplay.Features.LifeTime.Dead),
        typeof(Code.Gameplay.Features.LifeTime.HealthBar),
        typeof(Code.Gameplay.Features.LifeTime.MaxHP),
        typeof(Code.Gameplay.Features.LifeTime.ProcessingDeath),
        typeof(Code.Gameplay.Hero.Hero),
        typeof(Code.Gameplay.Movement.Direction),
        typeof(Code.Gameplay.Movement.FullRotationAlignedAlongDirection),
        typeof(Code.Gameplay.Movement.MovableByInput),
        typeof(Code.Gameplay.Movement.MoveInCameraBounds),
        typeof(Code.Gameplay.Movement.MovementAvailable),
        typeof(Code.Gameplay.Movement.MoveWithNoBounds),
        typeof(Code.Gameplay.Movement.Moving),
        typeof(Code.Gameplay.Movement.RotationAlignedAlongDirection),
        typeof(Code.Gameplay.Movement.RotationRandomDirection),
        typeof(Code.Gameplay.Movement.RotationSpeed),
        typeof(Code.Gameplay.Movement.Speed),
        typeof(Code.Gameplay.Movement.TurnedAlongDirection),
        typeof(Code.Gameplay.Physics.ForceApplier),
        typeof(Code.Gameplay.Physics.ForceProducerId),
        typeof(Code.Gameplay.Physics.ForceTargetId),
        typeof(Code.Gameplay.Physics.PhysicsBody),
        typeof(Code.Gameplay.Physics.PhysicsForce),
        typeof(Code.Gameplay.Physics.Processed),
        typeof(Code.Gameplay.Physics.Rigidbody2DComponent),
        typeof(Code.Gameplay.Physics.Velocity)
    };
}
