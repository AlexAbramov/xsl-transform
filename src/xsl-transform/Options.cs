using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace XslTransform
{
	public class Options
	{
		Font font;

		[XmlIgnore]
		public Font Font{get{return font;}set{font=value;}}

		[Browsable(false)]
		public XmlFont XmlFont{get{return new XmlFont(font);}set{font=value.ToFont();}}


		public static string FilePath{get{return Application.StartupPath+"\\Options.xml";}}
		
		public Options()
		{
			font=new Font("Courier",12);
		}
		public static Options Load()
		{
			XmlSerializer xs = new XmlSerializer(typeof(Options));
			using(TextReader reader = new StreamReader(FilePath))
			{
				return (Options)xs.Deserialize(reader);
			}
		}
		public void Save()
		{
			XmlSerializer xs = new XmlSerializer(typeof(Options));
			using(TextWriter writer = new StreamWriter(FilePath))
			{
				xs.Serialize(writer, this);
			}
		}
	}
}
