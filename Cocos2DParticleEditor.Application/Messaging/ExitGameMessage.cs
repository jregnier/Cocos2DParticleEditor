namespace Cocos2DParticleEditor.Application.Messaging
{
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// A custom message indicating to exit the game.
    /// </summary>
    public class ExitGameMessage : NotificationMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitGameMessage"/> class.
        /// </summary>
        public ExitGameMessage()
            : base("Exit Game")
        {
        }
    }
}
