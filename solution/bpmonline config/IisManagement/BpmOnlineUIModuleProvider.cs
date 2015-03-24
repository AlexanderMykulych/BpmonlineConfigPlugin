using System;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineUIModuleProvider : ModuleProvider
    {
        public override Type ServiceType
        {
            get { return null; }
        }

        public override bool SupportsScope(ManagementScope scope)
        {
            return true;
        }

        public override ModuleDefinition GetModuleDefinition(IManagementContext context)
        {
            return new ModuleDefinition(Name, typeof(BpmOnlineConfigUI).AssemblyQualifiedName);
        }
    }
}
