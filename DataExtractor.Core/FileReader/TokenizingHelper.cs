// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenizingHelper.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the TokenizingHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.FileReader;

using DataExtractor.Core.Exceptions;

using ParsecSharp;

public static class TokenizingHelper
{
	public static string ExtractToken(string source, string tokenKey)
	{
		if (string.IsNullOrEmpty(source))
		{
			throw new ArgumentException(nameof(tokenKey));
		}

		if (string.IsNullOrEmpty(tokenKey))
		{
			throw new ArgumentException(nameof(tokenKey));
		}

		var parsed = CreateParser().Parse($"{source};");

		string? tokenValue = null;
		foreach (var item in parsed.Value)
		{
			if (item[0].Trim() != tokenKey)
			{
				continue;
			}

			if (string.IsNullOrEmpty(tokenValue))
			{
				tokenValue = item[1][..^1];
			}
			else
			{
				throw new ComplexFieldDoubledTokenException($"The token {tokenKey} found more than one time");
			}
		}

		if (!string.IsNullOrEmpty(tokenValue))
		{
			return tokenValue;
		}
		else if (tokenValue == "")
		{
			throw new DataFieldTypeInvalidException($"The complex field {tokenKey} value is empty");
		}

		throw new MissingDataFieldException($"The complex field name {tokenKey} not found");
	}

	private static Parser<char, IEnumerable<string[]>> CreateParser()
	{
		var semicolon = Text.Char(';');
		var colon = Text.Char(':');

		var textChar = Text.Any().Except(colon, semicolon, Text.EndOfLine(), Text.ControlChar());

		var field = Parser.Many(textChar).AsString();

		var record = field.SeparatedBy(colon).ToArray();

		var csv = record.EndBy(semicolon);

		var parser = csv.End();
		return parser;
	}
}