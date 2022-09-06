// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataTemplate.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the IDataTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CsvHelper;

using System.Data;

namespace DataExtractor.Core.FileReader.Csv.DataTemplates;

public interface IDataTemplate
{
	DataTable BuildDataTable();
	DataRow ParseRow(CsvReader csvReader, DataRow dataRow);
}