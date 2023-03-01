using HarmonyLib;
using System.Reflection;

namespace KOPMod.Patches
{
    public abstract class BasePatch
    {
        private bool _enabled;

        public abstract void DoPatch();
        public void DoUnpatch() => originalMethods
            .ForEach(method => KOPMod.harmony.Unpatch(method, HarmonyPatchType.All));

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public abstract string GetName();

        protected List<MethodInfo> originalMethods = new List<MethodInfo>();
    }
}
