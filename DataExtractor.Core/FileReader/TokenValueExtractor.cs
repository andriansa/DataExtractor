// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenValueExtractor.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the TokenValueExtractor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.FileReader;

public abstract class TokenValueExtractor<T> : ITokenValueExtractor<T>
{
	public string TokenName { get; }

	protected TokenValueExtractor(string tokenName)
	{
		TokenName = tokenName;
	}

	public T ExtractData(string source)
	{
		var token = TokenizingHelper.ExtractToken(source, TokenName);

		var tokenValue = ParseValue(token);

		return tokenValue;
	}

	protected abstract T ParseValue(string tokenValue);
}