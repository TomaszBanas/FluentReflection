using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentReflection.Assembly.EmbeddedResource.SourceGenerator
{
    public record struct EmbeddedResourceGeneratorHelper(string Path, string Namespace);
    internal class EmbeddedResourcesInternalHelper
    {
        public List<EmbeddedResourcesInternalHelper> Childs { get; set; }
        public List<string> FileNames { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }

        public string Generate(string currentPath = ".")
        {
            // FilesNames

            var result = "";
            foreach (var fileName in FileNames)
            {
                if (string.IsNullOrWhiteSpace(fileName)) continue;

                var propName = Regex.Replace(fileName, @"[^0-9a-zA-Z]+", "");

                var prop = EmbeddedResourceSource.EmbeddedResourceTextProp;
                prop = prop.Replace(EmbeddedResourceSource.PropertyNameKey, propName);
                prop = prop.Replace(EmbeddedResourceSource.TabKey, string.Concat(Enumerable.Repeat(EmbeddedResourceSource.Tab, currentPath.Count(x => x == '.'))));
                prop = prop.Replace(EmbeddedResourceSource.ResourcePathKey, $"{Namespace}{currentPath}{fileName}");
                result += prop;
            }

            // Childs

            foreach (var child in Childs)
            {
                var classTemplate = EmbeddedResourceSource.EmbeddedResourceSubClassTemplate;
                classTemplate = classTemplate.Replace(EmbeddedResourceSource.SubClassNameKey, child.Name);
                classTemplate = classTemplate.Replace(EmbeddedResourceSource.TabKey, string.Concat(Enumerable.Repeat(EmbeddedResourceSource.Tab, currentPath.Count(x => x == '.'))));
                classTemplate = classTemplate.Replace(EmbeddedResourceSource.CustomPropertiesKey, child.Generate(currentPath + child.Name + "."));
                result += classTemplate;
            }

            return result;
        }

        public static EmbeddedResourcesInternalHelper Create(List<List<string>> paths, string _namespace, string? name = null)
        {
            return new EmbeddedResourcesInternalHelper
            {
                FileNames = paths
                            .Where(x => x.Count() == 1)
                            .Select(x => x.First())
                            .OrderBy(x => x)
                            .ToList(),
                Childs = paths
                            .Where(x => x.Count() > 1)
                            .GroupBy(x => x.First())
                            .OrderBy(x => x.Key)
                            .Select(x =>
                            {
                                var paths = x.Select(x => x.Skip(1).ToList()).ToList();
                                return EmbeddedResourcesInternalHelper.Create(paths, _namespace, x.Key);
                            })
                            .ToList(),
                Name = name,
                Namespace = _namespace
            };
        }
    }

    public class EmbeddedResourcesGeneratorHelper
    {
        public List<string> Paths { get; set; }
        public string Namespace { get; set; }

        public string Generate()
        {
            var template = EmbeddedResourceSource.EmbeddedResourceClassTemplate;
            template = template.Replace(EmbeddedResourceSource.CustomNamespaceKey, Namespace);
            var paths = Paths.Select(x => {
                var index = x.IndexOf("@(");
                if (index < 1) return null;

                return x.Substring(index+2, x.Length - index - 3);
            })
            .Where(x => x != null)
            .Select(x => x.Split('\\').ToList())
            .ToList();

            var tree = EmbeddedResourcesInternalHelper.Create(paths, Namespace);
            template = template.Replace(EmbeddedResourceSource.CustomPropertiesKey, tree.Generate());
            return template;
        }
    }
}
