using System.IO;
using Netick.Unity;
using Newtonsoft.Json;
using UnityEngine;

namespace StinkySteak.Netick.ConfigLoader
{
    public static class NetickUserConfigLoader
    {
        public const string FileName = "netickConfig.properties";
        private readonly static JsonSerializerSettings _jsonSerializerSettings = new()
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        public static NetickConfig LoadGlobalNetickConfig()
        {
            return Resources.Load<NetickConfig>(nameof(NetickConfig));
        }

        public static UserNetickConfig LoadUserConfigFromDisk()
        {
            string directory = new DirectoryInfo(Application.dataPath).Parent.FullName;
            string path = Path.Combine(directory, FileName);

            string json = File.ReadAllText(path);

            UserNetickConfig userConfig = JsonConvert.DeserializeObject<UserNetickConfig>(json, _jsonSerializerSettings);

            return userConfig;
        }

        public static bool IsConfigFileExist()
        {
            string directory = new DirectoryInfo(Application.dataPath).Parent.FullName;
            string path = Path.Combine(directory, FileName);

            bool isExist = File.Exists(path);

            return isExist;
        }

        public static string NetickConfigToJson(NetickConfig netickConfig)
        {
            string json = JsonConvert.SerializeObject(netickConfig, _jsonSerializerSettings);

            return json;
        }

        public static void WriteTemplateUserConfigToDisk()
        {
            UserNetickConfig config = new();
            config.SetDefault();

            WriteUserConfigToDisk(config);
        }

        public static void WriteUserConfigToDisk(UserNetickConfig userNetickConfig)
        {
            string json = JsonConvert.SerializeObject(userNetickConfig, _jsonSerializerSettings);

            string directory = new DirectoryInfo(Application.dataPath).Parent.FullName;
            string path = Path.Combine(directory, FileName);

            File.WriteAllText(path, json);

            Debug.Log($"[{nameof(NetickUserConfigLoader)}]: User config is written to: {path}");
        }

        public static void WriteNetickConfigToDisk(NetickConfig netickConfig)
        {
            UserNetickConfig userConfig = new UserNetickConfig();
            ApplyNetickConfigToUserConfig(netickConfig, userConfig);
            WriteUserConfigToDisk(userConfig);
        }

        public static void ApplyUserConfigToNetick(UserNetickConfig userConfig, NetickConfig targetConfig)
        {
            if (userConfig.TickRate.HasValue)
                targetConfig.TickRate = userConfig.TickRate.Value;

            if (userConfig.MaxAllowedTimestep.HasValue)
                targetConfig.MaxAllowedTimestep = userConfig.MaxAllowedTimestep.Value;

            if (userConfig.MaxPlayers.HasValue)
                targetConfig.MaxPlayers = userConfig.MaxPlayers.Value;

            if (userConfig.MaxObjects.HasValue)
                targetConfig.MaxObjects = userConfig.MaxObjects.Value;

            if (userConfig.MaxSendableDataSize.HasValue)
                targetConfig.MaxSendableDataSize = userConfig.MaxSendableDataSize.Value;

            if (userConfig.StateAllocatorBlockSize.HasValue)
                targetConfig.StateAllocatorBlockSize = userConfig.StateAllocatorBlockSize.Value;

            if (userConfig.MetaAllocatorBlockSize.HasValue)
                targetConfig.MetaAllocatorBlockSize = userConfig.MetaAllocatorBlockSize.Value;

            if (userConfig.AggressivePreAllocation.HasValue)
                targetConfig.AggressivePreAllocation = userConfig.AggressivePreAllocation.Value;

            if (userConfig.MaxPredictedTicks.HasValue)
                targetConfig.MaxPredictedTicks = userConfig.MaxPredictedTicks.Value;

            if (userConfig.ServerDivisor.HasValue)
                targetConfig.ServerDivisor = userConfig.ServerDivisor.Value;

            if (userConfig.PhysicsPrediction.HasValue)
                targetConfig.PhysicsPrediction = userConfig.PhysicsPrediction.Value;

            if (userConfig.PhysicsType.HasValue)
                targetConfig.PhysicsType = userConfig.PhysicsType.Value;

            if (userConfig.InvokeRenderInHeadless.HasValue)
                targetConfig.InvokeRenderInHeadless = userConfig.InvokeRenderInHeadless.Value;

            if (userConfig.InvokeUpdate.HasValue)
                targetConfig.InvokeUpdate = userConfig.InvokeUpdate.Value;

            if (userConfig.RenderInvokeOrder.HasValue)
                targetConfig.RenderInvokeOrder = userConfig.RenderInvokeOrder.Value;

            if (userConfig.MaxAdditiveScenes.HasValue)
                targetConfig.MaxAdditiveScenes = userConfig.MaxAdditiveScenes.Value;

            if (userConfig.InputReuseAtLowFPS.HasValue)
                targetConfig.InputReuseAtLowFPS = userConfig.InputReuseAtLowFPS.Value;

            if (userConfig.EnableMultithreading.HasValue)
                targetConfig.EnableMultithreading = userConfig.EnableMultithreading.Value;

            if (userConfig.EnableLogging.HasValue)
                targetConfig.EnableLogging = userConfig.EnableLogging.Value;

            if (userConfig.EnableProfiling.HasValue)
                targetConfig.EnableProfiling = userConfig.EnableProfiling.Value;

            if (userConfig.ServerSimulatedLossOut.HasValue)
                targetConfig.ServerSimulatedLossOut = userConfig.ServerSimulatedLossOut.Value;

            if (userConfig.ClientSimulatedLossOut.HasValue)
                targetConfig.ClientSimulatedLossOut = userConfig.ClientSimulatedLossOut.Value;

            if (userConfig.EnableLagCompensation.HasValue)
                targetConfig.EnableLagCompensation = userConfig.EnableLagCompensation.Value;

            if (userConfig.FastSerialization.HasValue)
                targetConfig.FastSerialization = userConfig.FastSerialization.Value;

            if (userConfig.EnableInterestManagement.HasValue)
                targetConfig.EnableInterestManagement = userConfig.EnableInterestManagement.Value;

            if (userConfig.EnableNarrowphaseFilterting.HasValue)
                targetConfig.EnableNarrowphaseFilterting = userConfig.EnableNarrowphaseFilterting.Value;

            if (userConfig.CustomGroupCount.HasValue)
                targetConfig.CustomGroupCount = userConfig.CustomGroupCount.Value;

            if (userConfig.AoILayerCount.HasValue)
                targetConfig.AoILayerCount = userConfig.AoILayerCount.Value;

            if (userConfig.WorldSize.HasValue)
                targetConfig.WorldSize = userConfig.WorldSize.Value;

            if (userConfig.AoILayer0CellSize.HasValue)
                targetConfig.AoILayer0CellSize = userConfig.AoILayer0CellSize.Value;

            if (userConfig.AoILayer1CellSize.HasValue)
                targetConfig.AoILayer1CellSize = userConfig.AoILayer1CellSize.Value;

            if (userConfig.AoILayer2CellSize.HasValue)
                targetConfig.AoILayer2CellSize = userConfig.AoILayer2CellSize.Value;

            if (userConfig.AoILayer3CellSize.HasValue)
                targetConfig.AoILayer3CellSize = userConfig.AoILayer3CellSize.Value;

            if (userConfig.AoILayer4CellSize.HasValue)
                targetConfig.AoILayer4CellSize = userConfig.AoILayer4CellSize.Value;

            if (userConfig.RenderWorldGrid.HasValue)
                targetConfig.RenderWorldGrid = userConfig.RenderWorldGrid.Value;

            if (userConfig.RenderedLayer.HasValue)
                targetConfig.RenderedLayer = userConfig.RenderedLayer.Value;

            if (userConfig.LagCompensationDebug.HasValue)
                targetConfig.LagCompensationDebug = userConfig.LagCompensationDebug.Value;

        }
        public static void ApplyNetickConfigToUserConfig(NetickConfig netickConfig, UserNetickConfig userConfig)
        {
            userConfig.TickRate = netickConfig.TickRate;
            userConfig.MaxAllowedTimestep = netickConfig.MaxAllowedTimestep;
            userConfig.MaxPlayers = netickConfig.MaxPlayers;
            userConfig.MaxObjects = netickConfig.MaxObjects;
            userConfig.MaxSendableDataSize = netickConfig.MaxSendableDataSize;
            userConfig.StateAllocatorBlockSize = netickConfig.StateAllocatorBlockSize;
            userConfig.MetaAllocatorBlockSize = netickConfig.MetaAllocatorBlockSize;
            userConfig.AggressivePreAllocation = netickConfig.AggressivePreAllocation;
            userConfig.MaxPredictedTicks = netickConfig.MaxPredictedTicks;
            userConfig.ServerDivisor = netickConfig.ServerDivisor;
            userConfig.PhysicsPrediction = netickConfig.PhysicsPrediction;
            userConfig.PhysicsType = netickConfig.PhysicsType;
            userConfig.InvokeRenderInHeadless = netickConfig.InvokeRenderInHeadless;
            userConfig.InvokeUpdate = netickConfig.InvokeUpdate;
            userConfig.RenderInvokeOrder = netickConfig.RenderInvokeOrder;
            userConfig.MaxAdditiveScenes = netickConfig.MaxAdditiveScenes;
            userConfig.InputReuseAtLowFPS = netickConfig.InputReuseAtLowFPS;
            userConfig.EnableMultithreading = netickConfig.EnableMultithreading;
            userConfig.EnableLogging = netickConfig.EnableLogging;
            userConfig.EnableProfiling = netickConfig.EnableProfiling;
            userConfig.ServerSimulatedLossOut = netickConfig.ServerSimulatedLossOut;
            userConfig.ClientSimulatedLossOut = netickConfig.ClientSimulatedLossOut;
            userConfig.EnableLagCompensation = netickConfig.EnableLagCompensation;
            userConfig.FastSerialization = netickConfig.FastSerialization;
            userConfig.EnableInterestManagement = netickConfig.EnableInterestManagement;
            userConfig.EnableNarrowphaseFilterting = netickConfig.EnableNarrowphaseFilterting;
            userConfig.CustomGroupCount = netickConfig.CustomGroupCount;
            userConfig.AoILayerCount = netickConfig.AoILayerCount;
            userConfig.WorldSize = netickConfig.WorldSize;
            userConfig.AoILayer0CellSize = netickConfig.AoILayer0CellSize;
            userConfig.AoILayer1CellSize = netickConfig.AoILayer1CellSize;
            userConfig.AoILayer2CellSize = netickConfig.AoILayer2CellSize;
            userConfig.AoILayer3CellSize = netickConfig.AoILayer3CellSize;
            userConfig.AoILayer4CellSize = netickConfig.AoILayer4CellSize;
            userConfig.RenderWorldGrid = netickConfig.RenderWorldGrid;
            userConfig.RenderedLayer = netickConfig.RenderedLayer;
            userConfig.LagCompensationDebug = netickConfig.LagCompensationDebug;
        }
    }

    public class UserNetickConfig
    {
        public float? TickRate;
        public float? MaxAllowedTimestep;
        public int? MaxPlayers;
        public int? MaxObjects;
        public int? MaxSendableDataSize;
        public int? StateAllocatorBlockSize;
        public int? MetaAllocatorBlockSize;
        public bool? AggressivePreAllocation;
        public int? MaxPredictedTicks;
        public int? ServerDivisor;
        public bool? PhysicsPrediction;
        public PhysicsType? PhysicsType;
        public bool? InvokeRenderInHeadless;
        public bool? InvokeUpdate;
        public NetworkRenderInvokeOrder? RenderInvokeOrder;
        public int? MaxAdditiveScenes;
        public bool? InputReuseAtLowFPS;
        public bool? EnableMultithreading;
        public bool? EnableLogging;
        public bool? EnableProfiling;
        public float? ServerSimulatedLossOut;
        public float? ClientSimulatedLossOut;
        public bool? EnableLagCompensation;
        public bool? FastSerialization;
        public bool? EnableInterestManagement;
        public bool? EnableNarrowphaseFilterting;
        public int? CustomGroupCount;
        public int? AoILayerCount;
        public Vector3? WorldSize;
        public int? AoILayer0CellSize;
        public int? AoILayer1CellSize;
        public int? AoILayer2CellSize;
        public int? AoILayer3CellSize;
        public int? AoILayer4CellSize;
        public bool? RenderWorldGrid;
        public int? RenderedLayer;
        public bool? LagCompensationDebug;

        public void SetDefault()
        {
            TickRate = 33.3f;
            MaxAllowedTimestep = 0.1f;
            MaxPlayers = 16;
            MaxObjects = 512;
            MaxSendableDataSize = 15000;
            StateAllocatorBlockSize = 131072;
            MetaAllocatorBlockSize = 1048576;
            AggressivePreAllocation = false;
            MaxPredictedTicks = 64;
            ServerDivisor = 1;
            PhysicsPrediction = false;
            PhysicsType = global::Netick.Unity.PhysicsType.None;
            InvokeRenderInHeadless = false;
            InvokeUpdate = true;
            RenderInvokeOrder = NetworkRenderInvokeOrder.LateUpdate;
            MaxAdditiveScenes = 4;
            InputReuseAtLowFPS = false;
            EnableMultithreading = false;
            EnableLogging = true;
            EnableProfiling = null;
            ServerSimulatedLossOut = null;
            ClientSimulatedLossOut = null;
            EnableLagCompensation = null;
            FastSerialization = true;
            EnableInterestManagement = null;
            EnableNarrowphaseFilterting = null;
            CustomGroupCount = 2;
            AoILayerCount = 1;
            WorldSize = new Vector3(8000f, 1f, 8000f);
            AoILayer0CellSize = 750;
            AoILayer1CellSize = 750;
            AoILayer2CellSize = 750;
            AoILayer3CellSize = 750;
            AoILayer4CellSize = 750;
            RenderWorldGrid = null;
            RenderedLayer = null;
            LagCompensationDebug = true;
        }
    }
}