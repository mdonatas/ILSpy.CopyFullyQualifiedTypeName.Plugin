using ICSharpCode.ILSpy;

namespace ILSpy.CopyFullyQualifiedTypeName.Plugin
{
    [ExportContextMenuEntryAttribute(Header = "Copy fully qualified type name with version", Icon = "images/Class.png", Category = "CopyFullyQualifiedTypeName", Order = 5.0002)]
    internal class CopyFullyQualifiedTypeNameWithVersionContextMenuEntry : CopyFullyQualifiedTypeNameContextMenuEntry
    {
        public override void Execute(TextViewContext context)
        {
            base.Execute(context, true);
        }
    }
}
