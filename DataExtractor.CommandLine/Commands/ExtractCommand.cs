// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtractCommand.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the ExtractCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;

using DataExtractor.Core;

namespace DataExtractor.CommandLine.Commands;

public sealed class ExtractCommand : Command
{
	private readonly DataProcessor dataProcessor;

	public ExtractCommand(DataProcessor dataProcessor) : base("extract", "Extract data from selected file")
	{
		this.dataProcessor = dataProcessor;

		this.AddOption(new Option<string>(new[] { "--input", "-i" }, "Input file"));
		this.AddOption(new Option<string>(new[] { "--output", "-o" }, "Output file"));
		this.Handler = CommandHandler.Create(this.HandleCommand);
	}

	private void HandleCommand(InvocationContext context, string? input, string? output)
	{
		dataProcessor.ExtractData(input, output);
	}
}

