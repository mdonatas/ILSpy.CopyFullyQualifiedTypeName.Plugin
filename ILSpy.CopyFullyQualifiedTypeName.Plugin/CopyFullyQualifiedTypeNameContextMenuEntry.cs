using System;
using System.Linq;
using System.Windows;
using ICSharpCode.ILSpy;
using ICSharpCode.ILSpy.TreeNodes;
using Mono.Cecil;

namespace ILSpy.CopyFullyQualifiedTypeName.Plugin
{
    [ExportContextMenuEntryAttribute(Header = "Copy fully qualified type name", Icon = "images/Class.png", Category = "CopyFullyQualifiedTypeName", Order = 5.0001)]
    public class CopyFullyQualifiedTypeNameContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(TextViewContext context)
        {
            return IsTypeNodeSelected(context);
        }

        public bool IsEnabled(TextViewContext context)
        {
            return IsTypeNodeSelected(context);
        }

        public virtual void Execute(TextViewContext context)
        {
            Execute(context, false);
        }

        public void Execute(TextViewContext context, bool includeAssemblyVersion)
        {
            try
            {
                string typeName = GetFullyQualifiedName(context, includeAssemblyVersion);

                if (typeName != null)
                {
                    Clipboard.SetText(typeName);
                }
            }
            catch (Exception)
            {
            }
        }

        private bool IsTypeNodeSelected(TextViewContext context)
        {
            try
            {
                if (context.SelectedTreeNodes == null ||
                    context.SelectedTreeNodes.Length != 1)
                {
                    return false;
                }

                var memberNode = context.SelectedTreeNodes.First() as IMemberTreeNode;
                if (memberNode != null)
                {
                    return memberNode.Member is TypeDefinition ||
                           memberNode.Member is TypeReference;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        protected string GetFullyQualifiedName(TextViewContext context, bool includeAssemblyVersion)
        {
            string assemblyName = string.Empty;
            string namespaceName = string.Empty;
            string typeName = string.Empty;

            var node = context.SelectedTreeNodes.First();

            var derivedTypesNode = node as IMemberTreeNode;
            if (derivedTypesNode != null)
            {
                var typeReference = derivedTypesNode.Member as TypeReference;

                AssemblyNameReference assemblyReference = typeReference.Scope as AssemblyNameReference;
                ModuleDefinition moduleDefinition = typeReference.Scope as ModuleDefinition;

                if (includeAssemblyVersion)
                {
                    if (assemblyReference != null)
                    {
                        assemblyName = assemblyReference.FullName;
                    }
                    else if (moduleDefinition != null)
                    {
                        assemblyName = moduleDefinition.Assembly.FullName;
                    }
                }
                else
                {
                    if (assemblyReference != null)
                    {
                        assemblyName = assemblyReference.Name;
                    }
                    else if (moduleDefinition != null)
                    {
                        assemblyName = moduleDefinition.Assembly.Name.Name;
                    }
                }

                namespaceName = typeReference.Namespace;
                typeName = typeReference.Name;

                return string.Format("{1}.{2}, {0}", assemblyName, namespaceName, typeName);
            }

            return null;
        }
    }
}
