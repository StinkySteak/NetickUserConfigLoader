# NetickUserConfigLoader
Plugin for [Netick](https://github.com/karrarrahim/NetickForUnity) to change the netick config before launching netick, similarly how minecraft `server.properties` works. This plugin is for you if you want to test and change your server config without rebuilding.  
Make sure essential properties is matched between server and client!

| Feature   	        | Status 	|
|-----------	        |--------	|
| Netick Config Loader 	| Beta   	|

## File Location
- The `netickConfig.properties` will be generated and loaded beside the game executeable file

## Keypoints
- When you don't want to override all of the things, you can remove the field in the JSON file

## Example Usage
```cs
// Write Default Config to Disk
NetickUserConfigLoader.WriteTemplateUserConfigToDisk();

// Load Config from Disk
UserNetickConfig userConfig = NetickUserLoader.LoadUserConfigFromDisk();

// Apply custom config to Netick
NetickConfig netickConfig = NetickUserConfigLoader.LoadGlobalNetickConfig();
NetickUserConfigLoader.ApplyUserConfigToNetick(userNetickConfig, netickConfig);
```

### Default Content (Netick 2 Beta 0.13.1)
```
{
  "TickRate": 33.3,
  "MaxAllowedTimestep": 10,
  "MaxPlayers": 16,
  "MaxObjects": 512,
  "MaxSendableDataSize": 15000,
  "StateAllocatorBlockSize": 131072,
  "MetaAllocatorBlockSize": 1048576,
  "AggressivePreAllocation": false,
  "MaxPredictedTicks": 64,
  "ServerDivisor": 1,
  "PhysicsPrediction": false,
  "PhysicsType": 0,
  "InvokeRenderInHeadless": false,
  "InvokeUpdate": true,
  "RenderInvokeOrder": 1,
  "MaxAdditiveScenes": 4,
  "InputReuseAtLowFPS": false,
  "EnableMultithreading": false,
  "EnableLogging": true,
  "EnableProfiling": null,
  "ServerSimulatedLossOut": null,
  "ClientSimulatedLossOut": null,
  "EnableLagCompensation": null,
  "FastSerialization": true,
  "EnableInterestManagement": null,
  "EnableNarrowphaseFilterting": null,
  "CustomGroupCount": 2,
  "AoILayerCount": 1,
  "WorldSize": {
    "x": 8000.0,
    "y": 1.0,
    "z": 8000.0,
    "normalized": {
      "x": 0.707106769,
      "y": 8.838834E-05,
      "z": 0.707106769,
      "magnitude": 1.0,
      "sqrMagnitude": 1.0
    },
    "magnitude": 11313.709,
    "sqrMagnitude": 1.28E+08
  },
  "AoILayer0CellSize": 750,
  "AoILayer1CellSize": 750,
  "AoILayer2CellSize": 750,
  "AoILayer3CellSize": 750,
  "AoILayer4CellSize": 750,
  "RenderWorldGrid": null,
  "RenderedLayer": null,
  "LagCompensationDebug": true
}
```