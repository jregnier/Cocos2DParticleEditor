using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Cocos2D;
using Cocos2DParticleEditor.Domain.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using Cocos2DParticleEditor.Application.Messaging;

namespace Cocos2DParticleEditor.Application.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Game1 game;
        private IntPtr renderPanelHwnd = IntPtr.Zero;
        private List<PredefinedParticles> predefinedParticlesCollection = null;
        private PredefinedParticles selectedPredefinedParticle = PredefinedParticles.Fire;
        private bool isPlaying = false;
        private EmitterProperties particleEmitterProperties = null;
        private bool moveParticleEmitter = false;
        private RelayCommand playCommand = null;
        private RelayCommand stopCommand = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {

            this.RegisterMessages();
        }

        #region Properties

        /// <summary>
        /// The <see cref="PredefinedParticles" /> property's name.
        /// </summary>
        public const string PredefinedParticlesPropertyName = "PredefinedParticles";

        /// <summary>
        /// Sets and gets the PredefinedParticles property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<PredefinedParticles> PredefinedParticlesCollection
        {
            get
            {
                if (predefinedParticlesCollection == null)
                {
                    predefinedParticlesCollection = Enum.GetValues(typeof(PredefinedParticles)).Cast<PredefinedParticles>().ToList();
                }

                return predefinedParticlesCollection;
            }
        }

        /// <summary>
        /// The <see cref="SelectedPredefinedParticle" /> property's name.
        /// </summary>
        public const string SelectedPredefinedParticlePropertyName = "SelectedPredefinedParticle";

        /// <summary>
        /// Sets and gets the SelectedPredefinedParticle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary> 
        public PredefinedParticles SelectedPredefinedParticle
        {
            get
            {   
                return selectedPredefinedParticle;
            }

            set
            {
                if (selectedPredefinedParticle == value)
                {
                    return;
                }

                selectedPredefinedParticle = value;
                RaisePropertyChanged(SelectedPredefinedParticlePropertyName);

                this.SetParticleSystem();
            }
        }

        /// <summary>
        /// The <see cref="IsPlaying" /> property's name.
        /// </summary>
        public const string IsPlayingPropertyName = "IsPlaying";

        /// <summary>
        /// Sets and gets the IsPlaying property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                if (isPlaying == value)
                {
                    return;
                }

                isPlaying = value;
                RaisePropertyChanged(IsPlayingPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ParticleEmitterProperties" /> property's name.
        /// </summary>
        public const string ParticleEmitterPropertiesPropertyName = "ParticleEmitterProperties";

        /// <summary>
        /// Sets and gets the ParticleEmitterProperties property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public EmitterProperties ParticleEmitterProperties
        {
            get
            {
                if (particleEmitterProperties == null)
                {
                    particleEmitterProperties = new EmitterProperties();
                }

                return particleEmitterProperties;
            }

            set
            {
                if (particleEmitterProperties == value)
                {
                    return;
                }

                particleEmitterProperties = value;
                RaisePropertyChanged(ParticleEmitterPropertiesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="MoveParticleEmitter" /> property's name.
        /// </summary>
        public const string MoveParticleEmitterPropertyName = "MoveParticleEmitter";

        /// <summary>
        /// Sets and gets the MoveParticleEmitter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool MoveParticleEmitter
        {
            get
            {
                return moveParticleEmitter;
            }

            set
            {
                if (moveParticleEmitter == value)
                {
                    return;
                }

                moveParticleEmitter = value;
                RaisePropertyChanged(MoveParticleEmitterPropertyName);

                ParticleLayer.SetMove(moveParticleEmitter);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// The <see cref="PlayCommand" /> property's name.
        /// </summary>
        public const string PlayCommandPropertyName = "PlayCommand";

        /// <summary>
        /// Sets and gets the PlayCommand property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RelayCommand PlayCommand
        {
            get
            {
                if (playCommand == null)
                {
                    playCommand = new RelayCommand(Play, CanPlay);
                }

                return playCommand;
            }
        }

        /// <summary>
        /// The <see cref="StopCommand" /> property's name.
        /// </summary>
        public const string StopCommandPropertyName = "StopCommand";

        /// <summary>
        /// Sets and gets the StopCommand property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RelayCommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                {
                    stopCommand = new RelayCommand(Stop, CanStop);
                }

                return stopCommand;
            }
        }

        #endregion

        #region Private Methods

        void RegisterMessages()
        {
            Messenger.Default.Register<GenericMessage<IntPtr>>(
                this,
                arg =>
                {
                    renderPanelHwnd = arg.Content;

                    new Thread(new ThreadStart(() =>
                    {
                        game = new Game1(renderPanelHwnd);
                        game.Run();
                    })).Start();
                });

            Messenger.Default.Register<ExportFileSelectedMessage>(
                this,
                arg =>
                {
                    SaveAsParticleSystem(arg.Content);
                });
        }

        bool CanPlay()
        {
            return !isPlaying;
        }

        void Play()
        {
            isPlaying = true;

            this.SetParticleSystem();
        }

        bool CanStop()
        {
            return isPlaying; 
        }

        void Stop()
        {
            ParticleLayer.StopEmitter();
            isPlaying = false;
        }

        void SetParticleSystem()
        {
            if (isPlaying)
            {
                var system = ParticleUtility.GetPredefinedParticle(selectedPredefinedParticle);

                var emitter = ParticleLayer.SetEmitter(system);
                particleEmitterProperties.LoadEmitter(emitter);
            }
        }

        void SaveParticleSystem()
        {

        }

        void SaveAsParticleSystem(string filePath)
        {
            this.particleEmitterProperties.SaveAs(filePath);
        }

        #endregion
    }
}