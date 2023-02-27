using HarmonyLib;
using System.Reflection.Emit;

namespace KOPMod
{
    public static class CodeGen
    {
        /// <summary>
        /// A simple utility to patch a function with "Ret". Not the best but simple and working
        /// </summary>
        public static IEnumerable<CodeInstruction> GetRet(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            for (int i = 0; i < codes.Count; i++)
            {
                codes[i].opcode = OpCodes.Ret;
            }

            return codes.AsEnumerable();
        }
    }
}
