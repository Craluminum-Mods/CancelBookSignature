using Vintagestory.API.Common;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

[assembly: ModInfo(name: "Cancel Book Signature", modID: "cancelbooksignature")]

namespace CancelBookSignature;

public class Core : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        base.Start(api);
        api.RegisterCollectibleBehaviorClass("CancelBookSignature.CollectibleBehaviorCancelSignature", typeof(CollectibleBehaviorCancelSignature));
        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }

    public override void AssetsFinalize(ICoreAPI api)
    {
        foreach (Item item in api.World.Items)
        {
            if (item is not ItemBook)
            {
                continue;
            }

            item.CollectibleBehaviors = item.CollectibleBehaviors.Append(new CollectibleBehaviorCancelSignature(item));
        }
    }
}
