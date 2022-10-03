using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FluentReflection.Assembly.EmbeddedResource.SourceGenerator
{
    [Generator]
    internal class HelpersGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource(EmbeddedResourceSource.EmbeddedResourceHelperClassName, SourceText.From(EmbeddedResourceSource.EmbeddedResourceHelper, Encoding.UTF8));
        }

    }
}
