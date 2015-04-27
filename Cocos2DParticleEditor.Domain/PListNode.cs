namespace Cocos2DParticleEditor.Domain
{
    using System.Xml;

    /// <summary>
    /// Represents a node item in a list file.
    /// </summary>
    public class PListNode
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="PListNode"/> class.
        /// </summary>
        /// <param name="key">The key to write in the file.</param>
        /// <param name="value">The value to write in the file.</param>
        public PListNode(string key, object value, PListValueType type)
        {
            this.Key = key;
            this.Value = value;
            this.Type = type;
        }

        /// <summary>
        /// Gets and sets the key.
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets the type of value.
        /// </summary>
        public PListValueType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value
        {
            get;
            set;
        }

        /// <summary>
        /// Write the node to a file.
        /// </summary>
        /// <param name="writer">The XML writer stream to write to.</param>
        public void WriteToFile(XmlTextWriter writer)
        {
            switch (this.Type)
            {
                case PListValueType.INT:
                    this.WriteInt(writer);
                    break;
                case PListValueType.REAL:
                    this.WriteReal(writer);
                    break;
                case PListValueType.STRING:
                    this.WriteReal(writer);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Write a float value to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        private void WriteReal(XmlTextWriter writer)
        {
            writer.WriteElementString("key", this.Key);
            writer.WriteElementString("real", this.Value.ToString());
        }

        /// <summary>
        /// Write an int value to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        private void WriteInt(XmlTextWriter writer)
        {
            writer.WriteElementString("key", this.Key);
            writer.WriteElementString("integer", this.Value.ToString());
        }

        /// <summary>
        /// Write a string to the file.
        /// </summary>
        /// <param name="writer">A <see cref="XmlTextWriter"/> to write the value.</param>
        private void WriteString(XmlTextWriter writer)
        {
            writer.WriteElementString("key", this.Key);
            writer.WriteElementString("string", this.Value.ToString());
        }
    }
}