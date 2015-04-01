using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Cocos2DParticleEditor.Application.Messaging
{
    public class ExportFileSelectedMessage : GenericMessage<string>
    {
        public ExportFileSelectedMessage(string param)
            : base(param)
        {
            Identifier = MessageIdentifiers.None;
        }

        public MessageIdentifiers Identifier { get; set; }
    }
}
