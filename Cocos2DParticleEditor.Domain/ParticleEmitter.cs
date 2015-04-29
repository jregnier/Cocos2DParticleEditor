namespace Cocos2DParticleEditor.Domain
{
    using Cocos2D;
    using System.Drawing;
    using System.IO;
    using System;
    using System.Text;

    /// <summary>
    /// Static class containing tools used to interact with the cocos2d particle systems.
    /// </summary>
    public static class ParticleUtility
    {

        /// <summary>
        /// Initializes a new instance of a given particle system.
        /// </summary>
        /// <param name="particle">A <see cref="PredefinedParticles"/> indicating which particle system to create.</param>
        /// <returns>A new instance of a <see cref="CCParticleSystem"/></returns>
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

            system.UserData = "predefined1";

            return system;
        }

        /// <summary>
        /// Convert a given blend function to a blend function from the cocos2d engine.
        /// </summary>
        /// <param name="blendFunc">A <see cref="BlendFunctions"/> representing which cocos2d blend function to return.</param>
        /// <returns>A new instance of a <see cref="CCBlendFunc"/></returns>
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

        /// <summary>
        /// Converts a cocos2d blend function object to a local defined enumeration.
        /// </summary>
        /// <param name="blendFunc">A <see cref="CCBlendFunc"/> which needs to be converted.</param>
        /// <returns>A <see cref="BlendFunctions"/> enumeration.</returns>
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

        /// <summary>
        /// Convert a texture to a byte array string.
        /// </summary>
        /// <param name="filePath">The file path to the texture.</param>
        /// <returns>A array of <see cref="byte"/> representing the texture.</returns>
        public static byte[] TextureToByteArray(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllBytes(filePath);
        }
    }
}