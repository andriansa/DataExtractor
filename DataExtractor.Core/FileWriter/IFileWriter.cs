// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileWriter.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the IFileWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;

namespace DataExtractor.Core.FileWriter;

public interface IFileWriter
{
	void WriteToFile(string filePath, DataTable dataTable);
}

