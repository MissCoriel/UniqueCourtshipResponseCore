using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace ResponseCore
{
    public class ModEntry : Mod
    {
        private Dictionary<string, string> DefaultDialog;
        private Dictionary<string, string> CoreDialogue;
        public override void Entry(IModHelper helper)
        {
            this.DefaultDialog = new Dictionary<string, string>
            {
                ["give_flowersA"] = Helper.Translation.Get("give_flowersA"),
                ["give_flowersB"] = Helper.Translation.Get("give_flowersB"),
                ["give_pendant"] = Helper.Translation.Get("give_pendant"),
                ["stardrop_gift"] = Helper.Translation.Get("stardrop_gift"),
                ["rejectNPCA"] = Helper.Translation.Get("rejectNPCA"),
                ["rejectNPCB"] = Helper.Translation.Get("rejectNPCB"),
                ["reject_two_heartsA"] = Helper.Translation.Get("reject_two_heartsA"),
                ["reject_two_heartsB"] = Helper.Translation.Get("reject_two_heartsB"),
                ["reject_four_heartsA"] = Helper.Translation.Get("reject_four_heartsA"),
                ["reject_four_heartsB"] = Helper.Translation.Get("reject_four_heartsB"),
                ["engageA"] = Helper.Translation.Get("engageA"),
                ["engageB"] = Helper.Translation.Get("engageB"),
                ["marriedA"] = Helper.Translation.Get("marriedA"),
                ["marriedB"] = Helper.Translation.Get("marriedB"),
                ["refusal_knownA"] = Helper.Translation.Get("refusal_knownA"),
                ["refusal_knownB"] = Helper.Translation.Get("refusal_knownB"),
                ["refusal_botherA"] = Helper.Translation.Get("refusal_botherA"),
                ["refusal_botherB"] = Helper.Translation.Get("refusal_botherB"),
                ["refusal_no_heartsA"] = Helper.Translation.Get("refusal_no_heartsA"),
                ["refusal_no_heartsB"] = Helper.Translation.Get("refusal_no_heartsB"),
                ["birthdayLoveA"] = Helper.Translation.Get("birthdayLoveA"),
                ["birthdayLoveB"] = Helper.Translation.Get("birthdayLoveB"),
                ["birthdayLikeA"] = Helper.Translation.Get("birthdayLikeA"),
                ["birthdayLikeB"] = Helper.Translation.Get("birthdayLikeB"),
                ["birthdayDislikeA"] = Helper.Translation.Get("birthdayDislikeA"),
                ["birthdayDislikeB"] = Helper.Translation.Get("birthdayDislikeB"),
                ["birthdayNeutralA"] = Helper.Translation.Get("birthdayNeutralA"),
                ["birthdayNeutralA"] = Helper.Translation.Get("birthdayNeutralB"),
                ["giftquestion_yes"] = Helper.Translation.Get("giftquestion_yes"),
                ["giftquestion_lie"] = Helper.Translation.Get("giftquestion_lie"),
                ["breakUp"] = Helper.Translation.Get("breakUp"),
                ["baby_anxiety"] = Helper.Translation.Get("baby_anxiety"),
                ["adopt_excitedA"] = Helper.Translation.Get("adopt_excitedA"),
                ["adopt_excitedB"] = Helper.Translation.Get("adopt_excitedB"),
                ["morningsick"] = Helper.Translation.Get("morningsick"),
                ["moodyPregnant"] = Helper.Translation.Get("moodyPregnant"),
                ["informPregnancyA"] = Helper.Translation.Get("informPregnancyA"),
                ["informPregnancyB"] = Helper.Translation.Get("informPregnancyB"),
                ["yourePregnantA"] = Helper.Translation.Get("yourePregnantA"),
                ["yourePregnantB"] = Helper.Translation.Get("yourePregnantB"),
                ["annoyedParent"] = Helper.Translation.Get("annoyedParent"),
                ["aloneTime"] = Helper.Translation.Get("aloneTime"),
            };
            this.CoreDialogue = new Dictionary<string, string>
            {
                ["NPC.cs.3962"] = Helper.Translation.Get("NPC.cs.3962"),
                ["NPC.cs.3963"] = Helper.Translation.Get("NPC.cs.3963"),
                ["NPC.cs.3980"] = Helper.Translation.Get("NPC.cs.3980"),
                ["NPC.cs.4001"] = Helper.Translation.Get("NPC.cs.4001"),
                ["NPC.cs.3956"] = Helper.Translation.Get("NPC.cs.3956"),
                ["NPC.cs.3957"] = Helper.Translation.Get("NPC.cs.3957"),
                ["NPC.cs.3958"] = Helper.Translation.Get("NPC.cs.3958"),
                ["NPC.cs.3959"] = Helper.Translation.Get("NPC.cs.3959"),
                ["NPC.cs.3960"] = Helper.Translation.Get("NPC.cs.3960"),
                ["NPC.cs.3961"] = Helper.Translation.Get("NPC.cs.3961"),
                ["NPC.cs.3965"] = Helper.Translation.Get("NPC.cs.3965"),
                ["NPC.cs.3966"] = Helper.Translation.Get("NPC.cs.3966"),
                ["NPC.cs.3967"] = Helper.Translation.Get("NPC.cs.3967"),
                ["NPC.cs.3968"] = Helper.Translation.Get("NPC.cs.3968"),
                ["NPC.cs.3970"] = Helper.Translation.Get("NPC.cs.3970"),
                ["NPC.cs.3971"] = Helper.Translation.Get("NPC.cs.3971"),
                ["NPC.cs.3972"] = Helper.Translation.Get("NPC.cs.3972"),
                ["NPC.cs.3973"] = Helper.Translation.Get("NPC.cs.3973"),
                ["NPC.cs.3974"] = Helper.Translation.Get("NPC.cs.3974"),
                ["NPC.cs.3975"] = Helper.Translation.Get("NPC.cs.3975"),
                ["NPC.cs.4274"] = Helper.Translation.Get("NPC.cs.4274"),
                ["NPC.cs.4275"] = Helper.Translation.Get("NPC.cs.4275"),
                ["NPC.cs.4276"] = Helper.Translation.Get("NPC.cs.4276"),
                ["NPC.cs.4277"] = Helper.Translation.Get("NPC.cs.4277"),
                ["NPC.cs.4278"] = Helper.Translation.Get("NPC.cs.4278"),
                ["NPC.cs.4279"] = Helper.Translation.Get("NPC.cs.4279"),
                ["NPC.cs.4280"] = Helper.Translation.Get("NPC.cs.4280"),
                ["NPC.cs.4281"] = Helper.Translation.Get("NPC.cs.4281"),
                ["NPC.cs.3985"] = Helper.Translation.Get("NPC.cs.3985"),
                ["NPC.cs.4439"] = Helper.Translation.Get("NPC.cs.4439"),
                ["NPC.cs.4440"] = Helper.Translation.Get("NPC.cs.4440"),
                ["NPC.cs.4441"] = Helper.Translation.Get("NPC.cs.4441"),
                ["NPC.cs.4442"] = Helper.Translation.Get("NPC.cs.4442"),
                ["NPC.cs.4443"] = Helper.Translation.Get("NPC.cs.4444"),
                ["NPC.cs.4445"] = Helper.Translation.Get("NPC.cs.4445"),
                ["NPC.cs.4447"] = Helper.Translation.Get("NPC.cs.4447"),
                ["NPC.cs.4448"] = Helper.Translation.Get("NPC.cs.4448"),
                ["NPC.cs.4449"] = Helper.Translation.Get("NPC.cs.4449"),
                ["NPC.cs.4452"] = Helper.Translation.Get("NPC.cs.4452"),
            };
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            helper.Events.Content.AssetReady += this.AssetReady;
        }
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.Name.IsDirectlyUnderPath("Characters/Dialogue"))
            {
                e.Edit(asset =>
                {
                    var dialog = asset.AsDictionary<string, string>().Data;
                    foreach (var pair in this.DefaultDialog)
                    {
                        if (!dialog.ContainsKey(pair.Key))
                            dialog[pair.Key] = pair.Value;
                    }
                });
            }
            else if (e.NameWithoutLocale.IsEquivalentTo("Strings/StringsFromCSFiles"))
            {
                e.Edit(asset =>
                {
                    var dialog = asset.AsDictionary<string, string>().Data;
                    foreach (var pair in this.CoreDialogue)
                    {
                        dialog[pair.Key] = pair.Value;
                    }
                });
            }
        }
        private void AssetReady(object sender, AssetReadyEventArgs e)
        {

            if (e.NameWithoutLocale.IsEquivalentTo("Strings/StringsFromCSFiles"))
            {
                var data = Game1.content.Load<Dictionary<string, string>>("Strings/StringsFromCSFiles");
                foreach((string key, string expectedText) in this.CoreDialogue)
                {
                    if (!data.TryGetValue(key, out string? actualText))
                        Monitor.Log($"Core Dialogue Error! Dialogue Key {key} has been overridden!\n Expected Value: {expectedText}.\n Received Value: (not found).",LogLevel.Error);
                    else if (actualText != expectedText)
                        Monitor.Log($"Core Dialogue Error! Dialogue Key {key} has been overridden!\n Expected Value: {expectedText}.\n Received Value: {actualText}.", LogLevel.Error);
                    else
                        Monitor.Log($"Core Dialogue Check Complete!", LogLevel.Debug);
                }
            }
        }
    }
}
