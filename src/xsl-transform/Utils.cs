using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace XslTransform
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public static string ReadFile(string filePath)
		{
			using(StreamReader sr=new StreamReader(filePath))
			{
				return sr.ReadToEnd();
			}
		}

		public static void WriteFile(string filePath, string text)
		{
			using(StreamWriter sw=new StreamWriter(filePath))
			{
				sw.Write(text);
			}
		}
	}

	public class WaitCursor: IDisposable
	{
		Cursor initialCursor;

		public WaitCursor()
		{
			initialCursor=Cursor.Current;
			Cursor.Current=Cursors.WaitCursor;
		}

		public void Close()
		{
			Cursor.Current=initialCursor;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Close();
		}

		#endregion
	}

	public struct XmlFont
	{
		public string FontFamily;
		public GraphicsUnit GraphicsUnit;
		public float Size;
		public FontStyle Style;

		public XmlFont(Font f)
		{
			FontFamily = f.FontFamily.Name;
			GraphicsUnit = f.Unit;
			Size = f.Size;
			Style = f.Style;
		}

		public Font ToFont()
		{
			return new Font(FontFamily, Size, Style, 
				GraphicsUnit);
		}
	}
}
