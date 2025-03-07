using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.CharacterStats;
using Code.Infrastructure.AssetManagement.Constants;
using Code.Infrastructure.Identifiers;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Gameplay.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
                    .With(x => x[Stats.Speed] = 8)
                    .With(x => x[Stats.MaxHp] = 200)
                ;

            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddViewPath(PrefabsDirectoryConstants.HeroPrefabPath)
                    .With(e => e.isHero = true)
                    
                    
                    .With(e => e.isPhysicsBody = true)
                ;
        }
    }
}