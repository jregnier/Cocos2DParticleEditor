using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cocos2D;

namespace Cocos2DParticleEditor.Domain.Models
{
    public enum PredefinedParticles
    {
        Explosion,
        Fire,
        Fireworks,
        Flower,
        Galaxy,
        Meteor,
        Rain,
        Smoke,
        Snow,
        Spriral,
        Sun
    };

    public static class ParticleUtility
    {
        public static CCParticleSystem GetPredefinedParticle(PredefinedParticles particle)
        {
            CCParticleSystem system = null;

            switch (particle)
            {
                case PredefinedParticles.Explosion:
                    system = new CCParticleExplosion();
                    break;
                case PredefinedParticles.Fire:
                    system = new CCParticleFire();
                    break;
                case PredefinedParticles.Fireworks:
                    system = new CCParticleFireworks();
                    break;
                case PredefinedParticles.Flower:
                    system = new CCParticleFlower();
                    break;
                case PredefinedParticles.Galaxy:
                    system = new CCParticleGalaxy();
                    break;
                case PredefinedParticles.Meteor:
                    system = new CCParticleMeteor();
                    break;
                case PredefinedParticles.Rain:
                    system = new CCParticleRain();
                    break;
                case PredefinedParticles.Smoke:
                    system = new CCParticleSmoke();
                    break;
                case PredefinedParticles.Snow:
                    system = new CCParticleSnow();
                    break;
                case PredefinedParticles.Spriral:
                    system = new CCParticleSpiral();
                    break;
                case PredefinedParticles.Sun:
                    system = new CCParticleSun();
                    break;
                default:
                    break;
            }

            return system;
        }

        public static CCBlendFunc GetCCBlendFunc(BlendFunctions blendFunc)
        {
            CCBlendFunc func = new CCBlendFunc();

            switch (blendFunc)
            {
                case BlendFunctions.Additive:
                    func = CCBlendFunc.Additive;
                    break;
                case BlendFunctions.AlphaBlend:
                    func = CCBlendFunc.AlphaBlend;
                    break;
                case BlendFunctions.NonPremultiplied:
                    func = CCBlendFunc.NonPremultiplied;
                    break;
                case BlendFunctions.Opaque:
                    func = CCBlendFunc.Opaque;
                    break;
            }

            return func;
        }

        public static BlendFunctions GetBlendFunction(CCBlendFunc blendFunc)
        {
            BlendFunctions func = BlendFunctions.NONE;

            if (blendFunc == CCBlendFunc.Additive)
            {
                func = BlendFunctions.Additive;
            }
            else if (blendFunc == CCBlendFunc.AlphaBlend)
            {
                func = BlendFunctions.AlphaBlend;
            }
            else if (blendFunc == CCBlendFunc.NonPremultiplied)
            {
                func = BlendFunctions.NonPremultiplied;
            }
            else if (blendFunc == CCBlendFunc.Opaque)
            {
                func = BlendFunctions.Opaque;
            }

            return func;
        }
    }
}
