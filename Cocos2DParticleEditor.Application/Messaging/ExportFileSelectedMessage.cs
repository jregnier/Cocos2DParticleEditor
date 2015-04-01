namespace Cocos2DParticleEditor.Application.Messaging
{
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// A custom message used to indicated that a file has been selected.
    /// </summary>
    public class ExportFileSelectedMessage : GenericMessage<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportFileSelectedMessage"/> class.
        /// </summary>
        /// <param name="param"></param>
        public ExportFileSelectedMessage(string param)
            : base(param)
        {
            Identifier = MessageIdentifiers.None;
        }

        public MessageIdentifiers Identifier { get; set; }
    }
}