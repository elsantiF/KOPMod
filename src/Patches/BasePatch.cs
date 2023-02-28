using HarmonyLib;
using System.Reflection;

namespace KOPMod.Patches
{
    public abstract class BasePatch
    {
        private bool _enabled;

        protected abstract void DoPatch();
        protected void DoUnpatch() 
        {
            KOPMod.harmony.Unpatch(originalMethod, HarmonyPatchType.All);
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;

                if (_enabled)
                {
                    DoPatch();
                }
                else 
                { 
                    DoUnpatch(); 
                }
            }
        }

        public abstract string GetName();

        protected MethodInfo originalMethod;
    }
}
