using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;

namespace FluentReflection.Assembly.EmbeddedResource.SourceGenerator
{
    [Generator]
    public class EmbeddedResourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //Debugger.Launch();

            var inputs = context.AdditionalTextsProvider
            .Combine(context.AnalyzerConfigOptionsProvider)
            .Select((x, _) => new EmbeddedResourceGeneratorHelper(x.Left.Path, x.Right.GlobalOptions.TryGetValue("build_property.RootNamespace", out var rootNamespace) ? rootNamespace : null))
            .Where(x => x.Namespace is not null)
            .Collect()
            .SelectMany((x, _) => Group(x));

            context.RegisterSourceOutput(inputs, (ctx, file) =>
            {
                var content = file.Generate();
                var generatedFileName = file.Namespace.Replace(".", "") + EmbeddedResourceSource.EmbeddedResourceClassName;
                ctx.AddSource(generatedFileName, SourceText.From(content, Encoding.UTF8));
            });
        }

        private static IEnumerable<EmbeddedResourcesGeneratorHelper> Group(IReadOnlyList<EmbeddedResourceGeneratorHelper> allFilesWithHash, CancellationToken cancellationToken = default)
        {
            return allFilesWithHash.GroupBy(x => x.Namespace).Select(x => new EmbeddedResourcesGeneratorHelper
            {
                Namespace = x.Key,
                Paths = x.Select(y => y.Path).ToList()
            });
        }
    }
}