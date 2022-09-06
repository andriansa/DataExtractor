// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradeDataTemplate.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the TradeDataTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CsvHelper;

using Microsoft.Extensions.Logging;
using System.Data;

namespace DataExtractor.Core.FileReader.Csv.DataTemplates;

using DataExtractor.Core.FileReader.Csv.Fields.Complex;

public sealed class TradeDataTemplate : IDataTemplate
{
	private readonly ILogger<TradeDataTemplate> logger;

	public TradeDataTemplate(ILogger<TradeDataTemplate> logger)
	{
		this.logger = logger;
	}

	public DataTable BuildDataTable()
	{
		var dataTable = new DataTable("TradeData");

		var column = new DataColumn();
		column.DataType = typeof(string);
		column.ColumnName = "ISIN";
		column.AutoIncrement = false;
		column.Caption = "ISIN";
		column.ReadOnly = false;
		column.Unique = false;

		dataTable.Columns.Add(column);

		column = new DataColumn();
		column.DataType = typeof(string);
		column.ColumnName = "CFICode";
		column.AutoIncrement = false;
		column.Caption = "CFICode";
		column.ReadOnly = false;
		column.Unique = false;

		dataTable.Columns.Add(column);

		column = new DataColumn();
		column.DataType = typeof(string);
		column.ColumnName = "Venue";
		column.AutoIncrement = false;
		column.Caption = "Venue";
		column.ReadOnly = false;
		column.Unique = false;

		dataTable.Columns.Add(column);

		column = new DataColumn();
		column.DataType = typeof(int);
		column.ColumnName = "ContractSize";
		column.AutoIncrement = false;
		column.Caption = "ContractSize";
		column.ReadOnly = true;
		column.Unique = true;

		dataTable.Columns.Add(column);

		return dataTable;
	}

	public DataRow ParseRow(CsvReader csvReader, DataRow dataRow)
	{
		dataRow["ISIN"] = csvReader.GetField<string>("ISIN").Trim();
		dataRow["CFICode"] = csvReader.GetField<string>("CFICode").Trim();
		dataRow["Venue"] = csvReader.GetField<string>("Venue").Trim();

		var complexAlgoParamsField = csvReader.GetField<string>("AlgoParams"); 
		
		var result = new ContractSizeFieldExtractor().ExtractData(complexAlgoParamsField);
		dataRow["ContractSize"] = result;

        return dataRow;
	}
}

