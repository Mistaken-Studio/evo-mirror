using HarmonyLib;
using InventorySystem.Items.MicroHID;
using NorthwoodLib.Pools;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Xname.EVO.Patches;

[HarmonyPatch(typeof(MicroHIDItem), nameof(MicroHIDItem.ExecuteServerside))]
internal static class MicroHIDExecuteServerside
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

        int index = newInstructions.FindLastIndex(x => x.opcode == OpCodes.Ldc_I4_4) + 2;

        newInstructions.InsertRange(index, new[]
        {
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StatsCollection), "OnMicroHIDFire")),
        });

        foreach (var instruction in newInstructions)
            yield return instruction;

        ListPool<CodeInstruction>.Shared.Return(newInstructions);
    }
}
