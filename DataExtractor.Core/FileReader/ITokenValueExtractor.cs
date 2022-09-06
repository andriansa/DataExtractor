// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITokenValueExtractor.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the ITokenValueExtractor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.FileReader;

public interface ITokenValueExtractor<out T>
{
	string TokenName { get; }

	T ExtractData(string source);
}