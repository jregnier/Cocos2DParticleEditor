namespace Cocos2DParticleEditor.Domain
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Cocos2D;
    using System.Linq;

    /// <summary>
    /// Represents a custom particle object.
    /// </summary>
    public class CustomParticle
    {
        /// <summary>
        /// The name of the folder where the custom particles exist.
        /// </summary>
        public const string FolderName = "Particles";

        private string displayName;
        private CCParticleSystemQuad particleSystem;

        /// <summary>
        /// The display name to represent the particle system.
        /// </summary>
        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        /// <summary>
        /// The name of the file in the particles folder.
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// The particle system loaded from the file.
        /// </summary>
        public CCParticleSystemQuad ParticleSystem
        {
            get
            {
                if (particleSystem == null)
                {
                    var filePath = Path.Combine(Environment.CurrentDirectory, CustomParticle.FolderName, this.FileName);

                    particleSystem = new CCParticleSystemQuad(filePath);
                }

                return particleSystem;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomParticle"/> class.
        /// </summary>
        /// <param name="fileName">A <see cref="string"/> representing the name of the file.</param>
        /// <param name="displayName">A <see cref="string"/> representing the display name for the particle system. If no name if specified the file name will be used.</param>
        public CustomParticle(string fileName, string displayName = "")
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            this.FileName = fileName;

            if (string.IsNullOrWhiteSpace(displayName))
            {
                this.displayName = Path.GetFileNameWithoutExtension(fileName);
            }
            else
            {
                this.displayName = displayName;
            }
        }

        /// <summary>
        /// Get the list of custom particles.
        /// </summary>
        /// <returns>A list of <see cref="CustomParticle"/>.</returns>
        public static List<CustomParticle> GetCustomParticles()
        {
            List<CustomParticle> collection;
            DirectoryInfo info;
            string path;

            collection = new List<CustomParticle>();

            path = Path.Combine(Environment.CurrentDirectory, CustomParticle.FolderName);

            if (Directory.Exists(path))
            {
                info = new DirectoryInfo(path);

                var particles = info.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                                    .Select(x => new CustomParticle(x.Name, Path.GetFileNameWithoutExtension(x.Name)));

                collection.AddRange(particles);
            }

            return collection;
        }
    }
}
