using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Helpers
{
	public static class StringHelper
	{
		/// <summary>
		/// Encodes a string to be represented as a string literal for JavaScript.
		/// If you pass normal string to javascript special chars might cause problems in javascript
		/// The string returned includes outer quotes 
		/// Example Output: "Hello \"Foo\"!\r\nBar"
		/// </summary>
		/// <param name="value">input string</param>
		/// <returns>string</returns>
		public static string EncodeJSString(string value)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\"");
			foreach (char c in value)
			{
				switch (c)
				{
					case '\"':
						sb.Append("\\\"");
						break;
					case '\\':
						sb.Append("\\\\");
						break;
					case '\b':
						sb.Append("\\b");
						break;
					case '\f':
						sb.Append("\\f");
						break;
					case '\n':
						sb.Append("\\n");
						break;
					case '\r':
						sb.Append("\\r");
						break;
					case '\t':
						sb.Append("\\t");
						break;
					default:
						int i = (int)c;
						if (i < 32 || i > 127)
						{
							sb.AppendFormat("\\u{0:X04}", i);
						}
						else
						{
							sb.Append(c);
						}
						break;
				}
			}
			sb.Append("\"");

			return sb.ToString();
		}
	}
}
