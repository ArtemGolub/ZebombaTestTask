using System;
using System.Linq;
using System.Text;
using Code.Audios.Audio;
using Code.Common.Entity.ToStrings;
using Code.Common.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.Enemies;
using Entitas;
using UnityEngine;
using Code.Gameplay.Hero;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
    private EntityPrinter _printer;

    public override string ToString()
    {
        if (_printer == null)
            _printer = new EntityPrinter(this);

        _printer.InvalidateCache();

        return _printer.BuildToString();
    }

    public string EntityName(IComponent[] components)
    {
        try
        {
            if (components.Length == 1)
                return components[0].GetType().Name;

            foreach (IComponent component in components)
            {
                switch (component.GetType().Name)
                {
                    case nameof(Hero):
                        return PrintHero();

                    case nameof(Enemy):
                        return PrintEnemy();

                    case nameof(CameraComponent):
                        return PrintCamera();

                    case nameof(MusicSource):
                        return PrintMusicSource();

                    case nameof(SoundSource):
                        return PrintSoundSource();
                }
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        return components.First().GetType().Name;
    }

    private string PrintHero()
    {
        return new StringBuilder($"Hero ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintEnemy() =>
        new StringBuilder($"Enemy ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();

    private string PrintCamera() =>
        new StringBuilder($"Camera ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();

    private string PrintMusicSource() =>
        new StringBuilder($"Music Source ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();

    private string PrintSoundSource() =>
        new StringBuilder($"Sound Source ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();

    public string BaseToString() => base.ToString();
}