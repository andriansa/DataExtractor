// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvFileReader.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the CsvFileReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Data;

using Microsoft.Extensions.Logging;

using DataExtractor.Core.FileReader.Csv.DataTemplates;

namespace DataExtractor.Core.FileReader.Csv;

public sealed class CsvFileReader : IFileReader
{
	private readonly ILogger<CsvFileReader> logger;
	private readonly IFileManager fileManager;
	private readonly IDataTemplate dataTemplate;

	public CsvFileReader(ILogger<CsvFileReader> logger, IFileManager fileManager, IDataTemplate dataTemplate)
	{
		this.logger = logger;
		this.fileManager = fileManager;
		this.dataTemplate = dataTemplate;
	}

	public DataTable ReadFile(string filePath)
	{
		logger.LogInformation($"ReadFile called for {filePath}");

		using var streamReader = fileManager.StreamReader(filePath);
		using var csvReader = fileManager.CsvReader(streamReader, CultureInfo.InvariantCulture);

		// input file structure requires skipping first 2 lines to get to the real data
		csvReader.Read();
		csvReader.Read();
		csvReader.ReadHeader();

		var dataTable = dataTemplate.BuildDataTable();
		while (csvReader.Read())
		{
			var dataRow = dataTemplate.ParseRow(csvReader, dataTable.NewRow());
			dataTable.Rows.Add(dataRow);
		}

		return dataTable;
	}
}

