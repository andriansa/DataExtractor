// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StubDataTemplate.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the StubDataTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CsvHelper;

using System.Data;

using DataExtractor.Core.FileReader.Csv.Fields.Complex;

namespace DataExtractor.Core.FileReader.Csv.DataTemplates;

public sealed class StubDataTemplate : IDataTemplate
{
	public DataTable BuildDataTable()
	{
		var dataTable = new DataTable("StubData");

		var column = new DataColumn();
		column.DataType = typeof(string);
		column.ColumnName = "COLUMN_1";
		column.AutoIncrement = false;
		column.Caption = "COLUMN_1";
		column.ReadOnly = false;
		column.Unique = false;

		dataTable.Columns.Add(column);
		column = new DataColumn();
		column.DataType = typeof(double);
		column.ColumnName = "COLUMN_2";
		column.AutoIncrement = false;
		column.Caption = "COLUMN_2";
		column.ReadOnly = true;
		column.Unique = true;

		dataTable.Columns.Add(column);

		return dataTable;
	}

	public DataRow ParseRow(CsvReader csvReader, DataRow dataRow)
	{
		dataRow["COLUMN_1"] = csvReader.GetField<string>("TEST_STRING_COLUMN_2").Trim();
		var complexField = csvReader.GetField<string>("TEST_COMPLEX_CONTRACT_SIZE_COLUMN_5").Trim();

		dataRow["COLUMN_2"] = new ContractSizeFieldExtractor().ExtractData(complexField);

        return dataRow;
	}
}

