namespace Cocos2DParticleEditor.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml;
    using Cocos2D;
    using Cocos2DParticleEditor.Domain.CustomPropertyEditors;

    /// <summary>
    /// Object representing the properties used in the particle system.
    /// </summary>
    [DefaultPropertyAttribute("Cococs2d Particle Editor Properties")]
    public class EmitterProperties : INotifyPropertyChanged
    {
        private float gravityX;
        private float gravityY;
        private float speed;
        private float speedVar;
        private float tangencialAccel;
        private float tangencialAccelVar;
        private float radialAccel;
        private float radialAccelVar;
        private float startRadius;
        private float startRadiusVar;
        private float endRadius;
        private float endRadiusVar;
        private float rotatePerSecond;
        private float rotatePerSecondVar;
        private float startSize;
        private float startSizeVar;
        private float endSize;
        private float endSizeVar;
        private Color startColor;
        private Color startColorVar;
        private Color endColor;
        private Color endColorVar;
        private float life;
        private float lifeVar;
        private float angle;
        private float angleVar;
        private Point position;
        private Point positionVar;
        private float emissionRate;
        private float duration;
        private BlendFunctions blendFunc;
        private CCPositionType positionType;
        private string texture;
        private CCEmitterMode emitterMode;
        private int totalParticles;
        private float startSpin;
        private float startSpinVar;
        private float endSpin;
        private float endSpinVar;

        // Indicates if the properties are loaded.
        private bool propertiesLoaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmitterProperties"/> class.
        /// </summary>
        public EmitterProperties()
        {
            propertiesLoaded = false;
        }

        #region Properties

        #region Gravity Mode

        [CategoryAttribute("Gravity Mode")]
        [DescriptionAttribute("Gravity for X Axis")]
        public float GravityX
        {
            get
            {
                return gravityX;
            }

            set
            {
                if (gravityX != value)
                {
                    gravityX = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DescriptionAttribute("Gravity for Y Axis")]
        public float GravityY
        {
            get
            {
                return gravityY;
            }

            set
            {
                if (gravityY != value)
                {
                    gravityY = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DescriptionAttribute("The speed at which the particles are emitted")]
        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                if (speed != value)
                {
                    speed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DisplayName("Speed Variance")]
        [DescriptionAttribute("The speed variance")]
        public float SpeedVar
        {
            get
            {
                return speedVar;
            }

            set
            {
                if (speedVar != value)
                {
                    speedVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DisplayName("Tangential Acceleration")]
        [DescriptionAttribute("The tangential acceleration of the particles")]
        public float TangencialAccel
        {
            get
            {
                return tangencialAccel;
            }

            set
            {
                if (tangencialAccel != value)
                {
                    tangencialAccel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DisplayName("Tangential Acceleration Variance")]
        [DescriptionAttribute("The tangential acceleration variance.")]
        public float TangencialAccelVar
        {
            get
            {
                return tangencialAccelVar;
            }

            set
            {
                if (tangencialAccelVar != value)
                {
                    tangencialAccelVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DisplayName("Radial Acceleration")]
        [DescriptionAttribute("he radial acceleration of the particles.")]
        public float RadialAccel
        {
            get
            {
                return radialAccel;
            }

            set
            {
                if (radialAccel != value)
                {
                    radialAccel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Gravity Mode")]
        [DisplayName("Radial Acceleration Variance")]
        [DescriptionAttribute("he radial acceleration variance.")]
        public float RadialAccelVar
        {
            get
            {
                return radialAccelVar;
            }

            set
            {
                if (radialAccelVar != value)
                {
                    radialAccelVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Gravity Mode

        #region Radius Mode

        [CategoryAttribute("Radius Mode")]
        [DisplayName("Starting Radius")]
        [DescriptionAttribute("The starting radius of the particles")]
        public float StartRadius
        {
            get
            {
                return startRadius;
            }

            set
            {
                if (startRadius != value)
                {
                    startRadius = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Radius Mode")]
        [DisplayName("Starting Radius Variance")]
        [DescriptionAttribute("The starting radius variance")]
        public float StartRadiusVar
        {
            get
            {
                return startRadiusVar;
            }

            set
            {
                if (startRadiusVar != value)
                {
                    startRadiusVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Radius Mode")]
        [DisplayName("End Radius")]
        [DescriptionAttribute("The ending radius of the particles")]
        public float EndRadius
        {
            get
            {
                return endRadius;
            }

            set
            {
                if (endRadius != value)
                {
                    endRadius = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Radius Mode")]
        [DisplayName("End Radius Variation")]
        [DescriptionAttribute("The ending radius variance")]
        public float EndRadiusVar
        {
            get
            {
                return endRadiusVar;
            }

            set
            {
                if (endRadiusVar != value)
                {
                    endRadiusVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Radius Mode")]
        [DisplayName("Rotation Per Second")]
        [DescriptionAttribute("Number of degrees to rotate a particle around the source pos per second")]
        public float RotatePerSecond
        {
            get
            {
                return rotatePerSecond;
            }

            set
            {
                if (rotatePerSecond != value)
                {
                    rotatePerSecond = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Radius Mode")]
        [DisplayName("Rotation Per Second Variance")]
        [DescriptionAttribute("Number of degrees variance")]
        public float RotatePerSecondVar
        {
            get
            {
                return rotatePerSecondVar;
            }

            set
            {
                if (rotatePerSecondVar != value)
                {
                    rotatePerSecondVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Radius Mode

        #region Common

        [CategoryAttribute("Common")]
        [DisplayName("Start Size")]
        [DescriptionAttribute("The start size of the particles in pixels")]
        public float StartSize
        {
            get
            {
                return startSize;
            }

            set
            {
                if (startSize != value)
                {
                    startSize = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Start Size Variance")]
        [DescriptionAttribute("The start size variance")]
        public float StartSizeVar
        {
            get
            {
                return startSizeVar;
            }

            set
            {
                if (startSizeVar != value)
                {
                    startSizeVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("End Size")]
        [DescriptionAttribute("The end size of the particles in pixels")]
        public float EndSize
        {
            get
            {
                return endSize;
            }

            set
            {
                if (endSize != value)
                {
                    endSize = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("End Size Variance")]
        [DescriptionAttribute("The end size variance")]
        public float EndSizeVar
        {
            get
            {
                return endSizeVar;
            }

            set
            {
                if (endSizeVar != value)
                {
                    endSizeVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Start Color")]
        [DescriptionAttribute("The starting color of the particles")]
        public Color StartColor
        {
            get
            {
                return startColor;
            }

            set
            {
                if (startColor != value)
                {
                    startColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Start Color Variance")]
        [DescriptionAttribute("The starting color variance")]
        public Color StartColorVar
        {
            get
            {
                return startColorVar;
            }

            set
            {
                if (startColorVar != value)
                {
                    startColorVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("End Color")]
        [DescriptionAttribute("The ending color of the particles")]
        public Color EndColor
        {
            get
            {
                return endColor;
            }

            set
            {
                if (endColor != value)
                {
                    endColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("End Color Variance")]
        [DescriptionAttribute("The ending color variance")]
        public Color EndColorVar
        {
            get
            {
                return endColorVar;
            }

            set
            {
                if (endColorVar != value)
                {
                    endColorVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Life")]
        [DescriptionAttribute("The Time to live of the particles in seconds")]
        public float Life
        {
            get
            {
                return life;
            }

            set
            {
                if (life != value)
                {
                    life = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Life Variance")]
        [DescriptionAttribute("The Time to live variance")]
        public float LifeVar
        {
            get
            {
                return lifeVar;
            }

            set
            {
                if (lifeVar != value)
                {
                    lifeVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DescriptionAttribute("Starting degrees of the particle")]
        public float Angle
        {
            get
            {
                return angle;
            }

            set
            {
                if (angle != value)
                {
                    angle = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Angle Variance")]
        [DescriptionAttribute("The variance of the starting degrees of the particle")]
        public float AngleVar
        {
            get
            {
                return angleVar;
            }

            set
            {
                if (angleVar != value)
                {
                    angleVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Position")]
        [DescriptionAttribute("The position of the emitter")]
        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                if (position != value)
                {
                    position = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Position Variance")]
        [DescriptionAttribute("The position variance of the emitter")]
        public Point PositionVar
        {
            get
            {
                return positionVar;
            }

            set
            {
                if (positionVar != value)
                {
                    positionVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Emission Rate")]
        [DescriptionAttribute("How many particle are emitted per second")]
        public float EmissionRate
        {
            get
            {
                return emissionRate;
            }

            set
            {
                if (emissionRate != value)
                {
                    emissionRate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Duration")]
        [DescriptionAttribute("How many seconds does the particle system (different than the life property) live")]
        public float Duration
        {
            get
            {
                return duration;
            }

            set
            {
                if (duration != value)
                {
                    duration = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Blend Function")]
        [DescriptionAttribute("The OpenGL blending function used for the system")]
        public BlendFunctions BlendFunc
        {
            get
            {
                return blendFunc;
            }

            set
            {
                if (blendFunc != value)
                {
                    blendFunc = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Position Type")]
        [DescriptionAttribute("The position type")]
        public CCPositionType PositionType
        {
            get
            {
                return positionType;
            }

            set
            {
                if (positionType != value)
                {
                    positionType = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Texture")]
        [DescriptionAttribute("The texture used for the particles")]
        [Editor(typeof(FileLocationEditor), typeof(FileLocationEditor))]
        public string Texture
        {
            get
            {
                return texture;
            }

            set
            {
                if (texture != value)
                {
                    texture = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Mode")]
        [DescriptionAttribute("The type of mode to emit the particles.")]
        public CCEmitterMode EmitterMode
        {
            get
            {
                return emitterMode;
            }

            set
            {
                if (emitterMode != value)
                {
                    emitterMode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common")]
        [DisplayName("Total Particles")]
        [DescriptionAttribute("The limit of total number of particles.")]
        public int TotoalParticles
        {
            get
            {
                return totalParticles;
            }

            set
            {
                if (totalParticles != value)
                {
                    totalParticles = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Common

        #region Common Used only in ParticleSystemQuad

        [CategoryAttribute("Common (ParticleSystemQuad)")]
        [DisplayName("Start Spin")]
        [DescriptionAttribute("The starting spin of the particles")]
        public float StartSpin
        {
            get
            {
                return startSpin;
            }

            set
            {
                if (startSpin != value)
                {
                    startSpin = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common (ParticleSystemQuad)")]
        [DisplayName("Start Spin Variance")]
        [DescriptionAttribute("The starting spin variance")]
        public float StartSpinVar
        {
            get
            {
                return startSpinVar;
            }

            set
            {
                if (startSpinVar != value)
                {
                    startSpinVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common (ParticleSystemQuad)")]
        [DisplayName("End Spin")]
        [DescriptionAttribute("The ending spin of the particles")]
        public float EndSpin
        {
            get
            {
                return endSpin;
            }

            set
            {
                if (endSpin != value)
                {
                    endSpin = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [CategoryAttribute("Common (ParticleSystemQuad)")]
        [DisplayName("End Spin Variance")]
        [DescriptionAttribute("The ending spin variance")]
        public float EndSpinVar
        {
            get
            {
                return endSpinVar;
            }

            set
            {
                if (endSpinVar != value)
                {
                    endSpinVar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Common Used only in ParticleSystemQuad

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Load the emitter properties given the particle system.
        /// </summary>
        /// <param name="system">The particle system used to load the properties.</param>
        public void LoadEmitter(CCParticleSystem system)
        {
            propertiesLoaded = false;

            //gravity mode properties.
            GravityX = system.Gravity.X;
            GravityY = system.Gravity.Y;
            Speed = system.Speed;
            SpeedVar = system.SpeedVar;
            TangencialAccel = system.TangentialAccel;
            TangencialAccelVar = system.TangentialAccelVar;
            RadialAccel = system.RadialAccel;
            RadialAccelVar = system.RadialAccelVar;

            //radius mode properties
            StartRadius = system.StartRadius;
            StartRadiusVar = system.StartRadiusVar;
            EndRadius = system.EndRadius;
            EndRadiusVar = system.EndRadiusVar;
            RotatePerSecond = system.RotatePerSecond;
            RotatePerSecondVar = system.RotatePerSecondVar;

            //common properties
            StartSize = system.StartSize;
            StartSizeVar = system.StartSizeVar;
            EndSize = system.EndSize;
            EndSizeVar = system.EndSizeVar;
            StartColor = Color.FromScRgb(system.StartColor.A, system.StartColor.R, system.StartColor.G, system.StartColor.B);
            StartColorVar = Color.FromScRgb(system.StartColorVar.A, system.StartColorVar.R, system.StartColorVar.G, system.StartColorVar.B);
            EndColor = Color.FromScRgb(system.EndColor.A, system.EndColor.R, system.EndColor.G, system.EndColor.B);
            EndColorVar = Color.FromScRgb(system.EndColorVar.A, system.EndColorVar.R, system.EndColorVar.G, system.EndColorVar.B);
            Life = system.Life;
            LifeVar = system.LifeVar;
            Angle = system.Angle;
            AngleVar = system.AngleVar;
            Position = new Point(system.Position.X, system.Position.Y);
            PositionVar = new Point(system.PosVar.X, system.PosVar.Y);
            StartSpin = system.StartSpin;
            StartSpinVar = system.StartSpinVar;
            EndSpin = system.EndSpin;
            EndSpinVar = system.EndSpinVar;
            EmissionRate = system.EmissionRate;
            Duration = system.Duration;
            BlendFunc = ParticleUtility.GetBlendFunction(system.BlendFunc);
            EmitterMode = system.EmitterMode;
            TotoalParticles = system.TotalParticles;
            //TODO: texture

            propertiesLoaded = true;
        }

        /// <summary>
        /// Save the particle system.
        /// </summary>
        public void Save()
        {
            //TODO: save local to software.
        }

        /// <summary>
        /// Save the particle system to a given location path.
        /// </summary>
        /// <param name="path">The full path of the file to save to or create.</param>
        public void SaveAs(string path)
        {
            var nodes = this.CreateNodes();
            this.SaveFile(path, nodes);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Update the emitter in the game window.
        /// </summary>
        private void UpdateEmitter()
        {
            ParticleLayer.UpdateEmitter(
                gravityX, gravityY, speed, speedVar, tangencialAccel, tangencialAccelVar, radialAccel, radialAccelVar, startRadius, startRadiusVar, endRadius, endRadiusVar,
                rotatePerSecond, rotatePerSecondVar, startSize, startSizeVar, endSize, endSizeVar, new CCColor4F(startColor.ScR, startColor.ScG, startColor.ScB, startColor.ScA),
                new CCColor4F(startColorVar.ScR, startColorVar.ScG, startColorVar.ScB, startColorVar.ScA), new CCColor4F(endColor.ScR, endColor.ScG, endColor.ScB, endColor.ScA),
                new CCColor4F(endColorVar.ScR, endColorVar.ScG, endColorVar.ScB, endColorVar.ScA), life, lifeVar, angle, angleVar, new CCPoint((float)position.X, (float)position.Y),
                new CCPoint((float)positionVar.X, (float)positionVar.Y), startSpin, startSpinVar, endSpin, endSpinVar, emissionRate, duration, ParticleUtility.GetCCBlendFunc(blendFunc),
                emitterMode, totalParticles);
        }

        /// <summary>
        /// Create a dictionary containing a mapping of all the property names and values to write to the file.
        /// </summary>
        /// <returns>A dictionary containing a mapping of all the properties to write to the file.</returns>
        private Dictionary<string, object> CreateNodes()
        {
            Dictionary<string, object> particleSystemNodes;

            particleSystemNodes = new Dictionary<string, object>()
            {
                {"angle", this.angle},
                {"angleVariance", this.angleVar},
                {"blendFuncDestination", ParticleUtility.GetCCBlendFunc(this.blendFunc).Destination},
                {"blendFuncSource", ParticleUtility.GetCCBlendFunc(this.blendFunc).Source},
                {"duration", this.duration},
                {"emitterType", (float)this.emitterMode},
                {"emissionRate", this.emissionRate},
                {"finishColorAlpha", this.endColor.ScA},
                {"finishColorBlue", this.endColor.ScB},
                {"finishColorGreen", this.endColor.ScG},
                {"finishColorRed", this.endColor.ScR},
                {"finishColorVarianceAlpha", this.endColorVar.ScA},
                {"finishColorVarianceBlue", this.endColorVar.ScB},
                {"finishColorVarianceGreen", this.endColorVar.ScG},
                {"finishColorVarianceRed", this.endColorVar.ScR},
                {"rotationStart", this.startSpin},
                {"rotationStartVariance", this.startSpinVar},
                {"rotationEnd", this.endSpin},
                {"rotationEndVariance", this.endSpinVar},
                {"finishParticleSize", this.endSize},
                {"finishParticleSizeVariance", this.endSizeVar},
                {"gravityx", this.gravityX},
                {"gravityy", this.gravityY},
                {"maxParticles", this.totalParticles},
                {"maxRadius", this.startRadius},
                {"maxRadiusVariance", this.startRadiusVar},
                {"minRadius", this.endRadius},
                {"minRadiusVariance", this.endRadiusVar},
                {"particleLifespan", this.life},
                {"particleLifespanVariance", this.lifeVar},
                {"radialAccelVariance", this.radialAccelVar},
                {"radialAcceleration", this.radialAccel},
                {"rotatePerSecond", this.rotatePerSecond},
                {"rotatePerSecondVariance", this.rotatePerSecondVar},
                {"sourcePositionVariancex", this.positionVar.X},
                {"sourcePositionVariancey", this.positionVar.Y},
                {"sourcePositionx", this.position.X},
                {"sourcePositiony", this.position.Y},
                {"speed", this.speed},
                {"speedVariance", this.speedVar},
                {"startColorAlpha", this.startColor.ScA},
                {"startColorBlue", this.startColor.ScB},
                {"startColorGreen", this.startColor.ScG},
                {"startColorRed", this.startColor.ScR},
                {"startColorVarianceAlpha", this.startColorVar.ScA},
                {"startColorVarianceBlue", this.startColorVar.ScB},
                {"startColorVarianceGreen", this.startColorVar.ScG},
                {"startColorVarianceRed", this.startColorVar.ScR},
                {"startParticleSize", this.startSize},
                {"startParticleSizeVariance", this.startSizeVar},
                {"tangentialAccelVariance", this.tangencialAccelVar},
                {"tangentialAcceleration", this.tangencialAccel},
                {"textureFileName", this.texture},
            };

            if (File.Exists(this.texture))
            {
                byte[] bytes = File.ReadAllBytes(this.texture);

                using (MemoryStream stream = new MemoryStream())
                {
                    string imageData = Encoding.UTF8.GetString(bytes);

                    particleSystemNodes.Add("textureImageData", imageData);
                }
            }

            return particleSystemNodes;
        }

        /// <summary>
        /// Save the particle system to a .plist file.
        /// </summary>
        /// <param name="path">The full path to the file.</param>
        /// <param name="nodes">A dictionary containing all the properties and the names to write to the file.</param>
        private void SaveFile(string path, Dictionary<string, object> nodes)
        {
            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;

                writer.WriteDocType("plist", "-//Apple//DTD PLIST 1.0//EN", "http://www.apple.com/DTDs/PropertyList-1.0.dtd", null);
                writer.WriteStartElement("plist");
                writer.WriteAttributeString("version", "1.0");
                writer.WriteStartElement("dict");

                //TODO: Write properties

            }
        }

        /// <summary>
        /// Write a float value to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        /// <param name="node">A <see cref="KeyValuePair"/> representing the property to write.</param>
        private void WriteReal(XmlTextWriter writer, KeyValuePair<string, object> node)
        {
            writer.WriteElementString("key", node.Key);
            writer.WriteElementString("real", node.Value.ToString());
        }

        /// <summary>
        /// Write an int value to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        /// <param name="node">A <see cref="KeyValuePair"/> representing the property to write.</param>
        private void WriteInt(XmlTextWriter writer, KeyValuePair<string, object> node)
        {
            writer.WriteElementString("key", node.Key);
            writer.WriteElementString("integer", node.Value.ToString());
        }

        /// <summary>
        /// Write a string to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        /// <param name="node">A <see cref="KeyValuePair"/> representing the property to write.</param>
        private void WriteString(XmlTextWriter writer, KeyValuePair<string, object> node)
        {
            writer.WriteElementString("key", node.Key);
            writer.WriteElementString("string", node.Value.ToString());
        }

        #endregion Private Methods

        #region INotifiyPropertyChanged Implementation

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Throw property changed event for a given property name.
        /// </summary>
        /// <param name="propertyName">The name of the property to throw the property changed event.</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                if (propertiesLoaded)
                {
                    UpdateEmitter();
                }
            }
        }

        #endregion INotifiyPropertyChanged Implementation
    }
}