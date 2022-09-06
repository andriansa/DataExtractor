// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataExtractorInstallerExtensions.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the DataExtractorInstallerExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataExtractor.Core.FileReader;
using DataExtractor.Core.FileReader.Csv;
using DataExtractor.Core.FileWriter;
using Microsoft.Extensions.DependencyInjection;

using DataExtractor.Core.FileWriter.Csv;
using DataExtractor.Core.FileReader.Csv.DataTemplates;

namespace DataExtractor.Core;

public static class DataExtractorInstallerExtensions
{
	public static void AddDataExtractorCore(this IServiceCollection services)
	{
		services.AddScoped<DataProcessor>();
		services.AddScoped<IFileManager, FileManager>();
		services.AddScoped<IFileReader, CsvFileReader>();
		services.AddScoped<IFileWriter, CsvFileWriter>();
		services.AddScoped<IDataTemplate, TradeDataTemplate>();
	}
}

