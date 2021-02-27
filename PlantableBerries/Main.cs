using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;

namespace PlantableBerries
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations]

        public const string
            MODNAME = "PlantableBerries",
            AUTHOR = "Yozora",
            GUID = AUTHOR + "PlantableBerries" + MODNAME,
            VERSION = "1.0.0.0";

        internal readonly ManualLogSource log;
        internal readonly Harmony harmony;
        internal readonly Assembly assembly;
        public readonly string modFolder;

        #endregion

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }

        public void Start()
        {
            harmony.PatchAll(assembly);
        }

        void Awake()
        {
            string gameVersion = Version.GetVersionString();
            string[] supportedGameVersions = { "0.146.11" };

            if (Array.IndexOf(supportedGameVersions, gameVersion) == -1)
            {
                Logger.LogWarning($"Mod MOD_NAME disabled, incompatible game version {gameVersion}");
                return;
            }

            var harmony = new Harmony("someuniquestring");
            harmony.PatchAll();
        }
    }
}
