using HarmonyLib;
using System.Reflection;

namespace KOPMod.Patches
{
    public abstract class BasePatch
    {
        private bool _enabled;

        public abstract void DoPatch();
        public void DoUnpatch() 
        {
            KOPMod.harmony.Unpatch(originalMethod, HarmonyPatchType.All);
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public abstract string GetName();

        protected MethodInfo originalMethod;
    }
}
