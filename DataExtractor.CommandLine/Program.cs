// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataExtractor.CommandLine.Commands;
using DataExtractor.Core;

using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

var services = new ServiceCollection();

services.AddLogging();

// --------------------------------------------------------------------
// --------------------------------------------------------------------
services.AddDataExtractorCore();
// --------------------------------------------------------------------
// --------------------------------------------------------------------

var provider = services.BuildServiceProvider();

try
{
    var dataProcessor = provider.GetRequiredService<DataProcessor>();
    var rootCommand = new RootCommand("DataExtractor CLI");
    rootCommand.AddCommand(new ExtractCommand(dataProcessor));

    await rootCommand.InvokeAsync(args);
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}

