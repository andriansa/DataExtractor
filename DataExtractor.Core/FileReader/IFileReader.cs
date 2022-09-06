// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileReader.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the IFileReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;

namespace DataExtractor.Core.FileReader;

public interface IFileReader
{
	DataTable ReadFile(string filePath);
}

