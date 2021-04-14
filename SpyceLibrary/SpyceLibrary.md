<a name='assembly'></a>
# SpyceLibrary

## Contents

- [AnimatedSprite](#T-SpyceLibrary-Sprites-AnimatedSprite 'SpyceLibrary.Sprites.AnimatedSprite')
  - [#ctor()](#M-SpyceLibrary-Sprites-AnimatedSprite-#ctor 'SpyceLibrary.Sprites.AnimatedSprite.#ctor')
- [BoxCollider](#T-SpyceLibrary-Physics-BoxCollider 'SpyceLibrary.Physics.BoxCollider')
  - [#ctor()](#M-SpyceLibrary-Physics-BoxCollider-#ctor 'SpyceLibrary.Physics.BoxCollider.#ctor')
  - [Offset](#P-SpyceLibrary-Physics-BoxCollider-Offset 'SpyceLibrary.Physics.BoxCollider.Offset')
  - [Size](#P-SpyceLibrary-Physics-BoxCollider-Size 'SpyceLibrary.Physics.BoxCollider.Size')
  - [ConstructRectangleAt(position)](#M-SpyceLibrary-Physics-BoxCollider-ConstructRectangleAt-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Physics.BoxCollider.ConstructRectangleAt(Microsoft.Xna.Framework.Vector2)')
  - [SetBounds(size)](#M-SpyceLibrary-Physics-BoxCollider-SetBounds-Microsoft-Xna-Framework-Point- 'SpyceLibrary.Physics.BoxCollider.SetBounds(Microsoft.Xna.Framework.Point)')
  - [SetOffset(offset)](#M-SpyceLibrary-Physics-BoxCollider-SetOffset-Microsoft-Xna-Framework-Point- 'SpyceLibrary.Physics.BoxCollider.SetOffset(Microsoft.Xna.Framework.Point)')
- [Camera](#T-SpyceLibrary-Camera 'SpyceLibrary.Camera')
  - [#ctor()](#M-SpyceLibrary-Camera-#ctor 'SpyceLibrary.Camera.#ctor')
  - [Position](#P-SpyceLibrary-Camera-Position 'SpyceLibrary.Camera.Position')
  - [FixViewOn(obj)](#M-SpyceLibrary-Camera-FixViewOn-SpyceLibrary-GameObject- 'SpyceLibrary.Camera.FixViewOn(SpyceLibrary.GameObject)')
  - [GetTransformedMatrix()](#M-SpyceLibrary-Camera-GetTransformedMatrix 'SpyceLibrary.Camera.GetTransformedMatrix')
  - [SetOffset(offset)](#M-SpyceLibrary-Camera-SetOffset-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Camera.SetOffset(Microsoft.Xna.Framework.Vector2)')
  - [SetViewOffsetPercent(pOffset)](#M-SpyceLibrary-Camera-SetViewOffsetPercent-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Camera.SetViewOffsetPercent(Microsoft.Xna.Framework.Vector2)')
- [CommandHandler](#T-SpyceLibrary-Debugging-Commands-CommandHandler 'SpyceLibrary.Debugging.Commands.CommandHandler')
  - [Instance](#P-SpyceLibrary-Debugging-Commands-CommandHandler-Instance 'SpyceLibrary.Debugging.Commands.CommandHandler.Instance')
  - [Initialize(initializer)](#M-SpyceLibrary-Debugging-Commands-CommandHandler-Initialize-SpyceLibrary-Initializer- 'SpyceLibrary.Debugging.Commands.CommandHandler.Initialize(SpyceLibrary.Initializer)')
  - [ParseCommand(sender,command)](#M-SpyceLibrary-Debugging-Commands-CommandHandler-ParseCommand-System-String,System-String- 'SpyceLibrary.Debugging.Commands.CommandHandler.ParseCommand(System.String,System.String)')
- [ComponentEvent](#T-SpyceLibrary-GameComponent-ComponentEvent 'SpyceLibrary.GameComponent.ComponentEvent')
- [Debug](#T-SpyceLibrary-Debugging-Debug 'SpyceLibrary.Debugging.Debug')
  - [LOGS_FILE_EXTENSION](#F-SpyceLibrary-Debugging-Debug-LOGS_FILE_EXTENSION 'SpyceLibrary.Debugging.Debug.LOGS_FILE_EXTENSION')
  - [LOGS_FOLDER](#F-SpyceLibrary-Debugging-Debug-LOGS_FOLDER 'SpyceLibrary.Debugging.Debug.LOGS_FOLDER')
  - [OnCommandSend](#F-SpyceLibrary-Debugging-Debug-OnCommandSend 'SpyceLibrary.Debugging.Debug.OnCommandSend')
  - [OnLogsCleared](#F-SpyceLibrary-Debugging-Debug-OnLogsCleared 'SpyceLibrary.Debugging.Debug.OnLogsCleared')
  - [OnLogsSaved](#F-SpyceLibrary-Debugging-Debug-OnLogsSaved 'SpyceLibrary.Debugging.Debug.OnLogsSaved')
  - [OnNewDebugMessage](#F-SpyceLibrary-Debugging-Debug-OnNewDebugMessage 'SpyceLibrary.Debugging.Debug.OnNewDebugMessage')
  - [DrawTime](#P-SpyceLibrary-Debugging-Debug-DrawTime 'SpyceLibrary.Debugging.Debug.DrawTime')
  - [Instance](#P-SpyceLibrary-Debugging-Debug-Instance 'SpyceLibrary.Debugging.Debug.Instance')
  - [TickSpeed](#P-SpyceLibrary-Debugging-Debug-TickSpeed 'SpyceLibrary.Debugging.Debug.TickSpeed')
  - [UpdateTime](#P-SpyceLibrary-Debugging-Debug-UpdateTime 'SpyceLibrary.Debugging.Debug.UpdateTime')
  - [ClearLogs(sender)](#M-SpyceLibrary-Debugging-Debug-ClearLogs-System-String- 'SpyceLibrary.Debugging.Debug.ClearLogs(System.String)')
  - [Draw(spriteBatch)](#M-SpyceLibrary-Debugging-Debug-Draw-Microsoft-Xna-Framework-Graphics-SpriteBatch- 'SpyceLibrary.Debugging.Debug.Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch)')
  - [EndDrawTick()](#M-SpyceLibrary-Debugging-Debug-EndDrawTick 'SpyceLibrary.Debugging.Debug.EndDrawTick')
  - [EndUpdateTick()](#M-SpyceLibrary-Debugging-Debug-EndUpdateTick 'SpyceLibrary.Debugging.Debug.EndUpdateTick')
  - [GetCurrentSceneObjectCount()](#M-SpyceLibrary-Debugging-Debug-GetCurrentSceneObjectCount 'SpyceLibrary.Debugging.Debug.GetCurrentSceneObjectCount')
  - [Initialize(engine)](#M-SpyceLibrary-Debugging-Debug-Initialize-SpyceLibrary-Engine- 'SpyceLibrary.Debugging.Debug.Initialize(SpyceLibrary.Engine)')
  - [ParseCommand(sender,toParse)](#M-SpyceLibrary-Debugging-Debug-ParseCommand-System-String,System-String- 'SpyceLibrary.Debugging.Debug.ParseCommand(System.String,System.String)')
  - [SaveLog(sender)](#M-SpyceLibrary-Debugging-Debug-SaveLog-System-String- 'SpyceLibrary.Debugging.Debug.SaveLog(System.String)')
  - [SaveLog(sender,path)](#M-SpyceLibrary-Debugging-Debug-SaveLog-System-String,System-String- 'SpyceLibrary.Debugging.Debug.SaveLog(System.String,System.String)')
  - [StartDrawTick()](#M-SpyceLibrary-Debugging-Debug-StartDrawTick 'SpyceLibrary.Debugging.Debug.StartDrawTick')
  - [StartUpdateTick()](#M-SpyceLibrary-Debugging-Debug-StartUpdateTick 'SpyceLibrary.Debugging.Debug.StartUpdateTick')
  - [WriteLine(sender,message,senderColor,messageColor)](#M-SpyceLibrary-Debugging-Debug-WriteLine-System-String,System-String,System-ConsoleColor,System-ConsoleColor- 'SpyceLibrary.Debugging.Debug.WriteLine(System.String,System.String,System.ConsoleColor,System.ConsoleColor)')
  - [listObjects(sender)](#M-SpyceLibrary-Debugging-Debug-listObjects-System-String- 'SpyceLibrary.Debugging.Debug.listObjects(System.String)')
- [DebugEvent](#T-SpyceLibrary-Debugging-Debug-DebugEvent 'SpyceLibrary.Debugging.Debug.DebugEvent')
- [EchoCommand](#T-SpyceLibrary-Debugging-Commands-EchoCommand 'SpyceLibrary.Debugging.Commands.EchoCommand')
  - [Help()](#M-SpyceLibrary-Debugging-Commands-EchoCommand-Help 'SpyceLibrary.Debugging.Commands.EchoCommand.Help')
  - [Run(sender,args,initializer)](#M-SpyceLibrary-Debugging-Commands-EchoCommand-Run-System-String,System-String[],SpyceLibrary-Initializer- 'SpyceLibrary.Debugging.Commands.EchoCommand.Run(System.String,System.String[],SpyceLibrary.Initializer)')
- [Engine](#T-SpyceLibrary-Engine 'SpyceLibrary.Engine')
  - [#ctor()](#M-SpyceLibrary-Engine-#ctor 'SpyceLibrary.Engine.#ctor')
  - [Draw(gameTime)](#M-SpyceLibrary-Engine-Draw-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Engine.Draw(Microsoft.Xna.Framework.GameTime)')
  - [Initialize()](#M-SpyceLibrary-Engine-Initialize 'SpyceLibrary.Engine.Initialize')
  - [LoadContent()](#M-SpyceLibrary-Engine-LoadContent 'SpyceLibrary.Engine.LoadContent')
  - [Update(gameTime)](#M-SpyceLibrary-Engine-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Engine.Update(Microsoft.Xna.Framework.GameTime)')
- [FastNoiseLite](#T--FastNoiseLite '.FastNoiseLite')
  - [#ctor()](#M-FastNoiseLite-#ctor-System-Int32- 'FastNoiseLite.#ctor(System.Int32)')
  - [DomainWarp()](#M-FastNoiseLite-DomainWarp-System-Single@,System-Single@- 'FastNoiseLite.DomainWarp(System.Single@,System.Single@)')
  - [DomainWarp()](#M-FastNoiseLite-DomainWarp-System-Single@,System-Single@,System-Single@- 'FastNoiseLite.DomainWarp(System.Single@,System.Single@,System.Single@)')
  - [GetNoise()](#M-FastNoiseLite-GetNoise-System-Single,System-Single- 'FastNoiseLite.GetNoise(System.Single,System.Single)')
  - [GetNoise()](#M-FastNoiseLite-GetNoise-System-Single,System-Single,System-Single- 'FastNoiseLite.GetNoise(System.Single,System.Single,System.Single)')
  - [SetCellularDistanceFunction()](#M-FastNoiseLite-SetCellularDistanceFunction-FastNoiseLite-CellularDistanceFunction- 'FastNoiseLite.SetCellularDistanceFunction(FastNoiseLite.CellularDistanceFunction)')
  - [SetCellularJitter()](#M-FastNoiseLite-SetCellularJitter-System-Single- 'FastNoiseLite.SetCellularJitter(System.Single)')
  - [SetCellularReturnType()](#M-FastNoiseLite-SetCellularReturnType-FastNoiseLite-CellularReturnType- 'FastNoiseLite.SetCellularReturnType(FastNoiseLite.CellularReturnType)')
  - [SetDomainWarpAmp()](#M-FastNoiseLite-SetDomainWarpAmp-System-Single- 'FastNoiseLite.SetDomainWarpAmp(System.Single)')
  - [SetDomainWarpType()](#M-FastNoiseLite-SetDomainWarpType-FastNoiseLite-DomainWarpType- 'FastNoiseLite.SetDomainWarpType(FastNoiseLite.DomainWarpType)')
  - [SetFractalGain()](#M-FastNoiseLite-SetFractalGain-System-Single- 'FastNoiseLite.SetFractalGain(System.Single)')
  - [SetFractalLacunarity()](#M-FastNoiseLite-SetFractalLacunarity-System-Single- 'FastNoiseLite.SetFractalLacunarity(System.Single)')
  - [SetFractalOctaves()](#M-FastNoiseLite-SetFractalOctaves-System-Int32- 'FastNoiseLite.SetFractalOctaves(System.Int32)')
  - [SetFractalPingPongStrength()](#M-FastNoiseLite-SetFractalPingPongStrength-System-Single- 'FastNoiseLite.SetFractalPingPongStrength(System.Single)')
  - [SetFractalType()](#M-FastNoiseLite-SetFractalType-FastNoiseLite-FractalType- 'FastNoiseLite.SetFractalType(FastNoiseLite.FractalType)')
  - [SetFractalWeightedStrength()](#M-FastNoiseLite-SetFractalWeightedStrength-System-Single- 'FastNoiseLite.SetFractalWeightedStrength(System.Single)')
  - [SetFrequency()](#M-FastNoiseLite-SetFrequency-System-Single- 'FastNoiseLite.SetFrequency(System.Single)')
  - [SetNoiseType()](#M-FastNoiseLite-SetNoiseType-FastNoiseLite-NoiseType- 'FastNoiseLite.SetNoiseType(FastNoiseLite.NoiseType)')
  - [SetRotationType3D()](#M-FastNoiseLite-SetRotationType3D-FastNoiseLite-RotationType3D- 'FastNoiseLite.SetRotationType3D(FastNoiseLite.RotationType3D)')
  - [SetSeed()](#M-FastNoiseLite-SetSeed-System-Int32- 'FastNoiseLite.SetSeed(System.Int32)')
- [FrameData](#T-SpyceLibrary-Sprites-FrameData 'SpyceLibrary.Sprites.FrameData')
  - [Position](#P-SpyceLibrary-Sprites-FrameData-Position 'SpyceLibrary.Sprites.FrameData.Position')
  - [Texture](#P-SpyceLibrary-Sprites-FrameData-Texture 'SpyceLibrary.Sprites.FrameData.Texture')
  - [Time](#P-SpyceLibrary-Sprites-FrameData-Time 'SpyceLibrary.Sprites.FrameData.Time')
- [GameComponent](#T-SpyceLibrary-GameComponent 'SpyceLibrary.GameComponent')
  - [#ctor()](#M-SpyceLibrary-GameComponent-#ctor 'SpyceLibrary.GameComponent.#ctor')
  - [OnDestroy](#F-SpyceLibrary-GameComponent-OnDestroy 'SpyceLibrary.GameComponent.OnDestroy')
  - [OnDisable](#F-SpyceLibrary-GameComponent-OnDisable 'SpyceLibrary.GameComponent.OnDisable')
  - [OnEnable](#F-SpyceLibrary-GameComponent-OnEnable 'SpyceLibrary.GameComponent.OnEnable')
  - [Holder](#P-SpyceLibrary-GameComponent-Holder 'SpyceLibrary.GameComponent.Holder')
  - [IsEnabled](#P-SpyceLibrary-GameComponent-IsEnabled 'SpyceLibrary.GameComponent.IsEnabled')
  - [Load(init,holder)](#M-SpyceLibrary-GameComponent-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.GameComponent.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
  - [RequireComponent\`\`1()](#M-SpyceLibrary-GameComponent-RequireComponent``1 'SpyceLibrary.GameComponent.RequireComponent``1')
  - [SetActive()](#M-SpyceLibrary-GameComponent-SetActive-System-Boolean- 'SpyceLibrary.GameComponent.SetActive(System.Boolean)')
  - [Unload()](#M-SpyceLibrary-GameComponent-Unload 'SpyceLibrary.GameComponent.Unload')
- [GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject')
  - [#ctor()](#M-SpyceLibrary-GameObject-#ctor 'SpyceLibrary.GameObject.#ctor')
  - [Children](#P-SpyceLibrary-GameObject-Children 'SpyceLibrary.GameObject.Children')
  - [Components](#P-SpyceLibrary-GameObject-Components 'SpyceLibrary.GameObject.Components')
  - [ID](#P-SpyceLibrary-GameObject-ID 'SpyceLibrary.GameObject.ID')
  - [IsActive](#P-SpyceLibrary-GameObject-IsActive 'SpyceLibrary.GameObject.IsActive')
  - [RelativeTransform](#P-SpyceLibrary-GameObject-RelativeTransform 'SpyceLibrary.GameObject.RelativeTransform')
  - [AddComponent(component)](#M-SpyceLibrary-GameObject-AddComponent-SpyceLibrary-GameComponent- 'SpyceLibrary.GameObject.AddComponent(SpyceLibrary.GameComponent)')
  - [AddTags(addTags)](#M-SpyceLibrary-GameObject-AddTags-System-String[]- 'SpyceLibrary.GameObject.AddTags(System.String[])')
  - [Destroy()](#M-SpyceLibrary-GameObject-Destroy 'SpyceLibrary.GameObject.Destroy')
  - [Draw()](#M-SpyceLibrary-GameObject-Draw 'SpyceLibrary.GameObject.Draw')
  - [GenerateNewID()](#M-SpyceLibrary-GameObject-GenerateNewID 'SpyceLibrary.GameObject.GenerateNewID')
  - [GetComponent\`\`1()](#M-SpyceLibrary-GameObject-GetComponent``1 'SpyceLibrary.GameObject.GetComponent``1')
  - [GetTransform()](#M-SpyceLibrary-GameObject-GetTransform 'SpyceLibrary.GameObject.GetTransform')
  - [HasTag(tag)](#M-SpyceLibrary-GameObject-HasTag-System-String- 'SpyceLibrary.GameObject.HasTag(System.String)')
  - [IsDirectChild(parent,child)](#M-SpyceLibrary-GameObject-IsDirectChild-SpyceLibrary-GameObject,SpyceLibrary-GameObject- 'SpyceLibrary.GameObject.IsDirectChild(SpyceLibrary.GameObject,SpyceLibrary.GameObject)')
  - [Load(init)](#M-SpyceLibrary-GameObject-Load-SpyceLibrary-Initializer- 'SpyceLibrary.GameObject.Load(SpyceLibrary.Initializer)')
  - [SetActive(active)](#M-SpyceLibrary-GameObject-SetActive-System-Boolean- 'SpyceLibrary.GameObject.SetActive(System.Boolean)')
  - [SetParent(parent)](#M-SpyceLibrary-GameObject-SetParent-SpyceLibrary-GameObject- 'SpyceLibrary.GameObject.SetParent(SpyceLibrary.GameObject)')
  - [SetRelativeTransform(transform)](#M-SpyceLibrary-GameObject-SetRelativeTransform-SpyceLibrary-Transform- 'SpyceLibrary.GameObject.SetRelativeTransform(SpyceLibrary.Transform)')
  - [ToString()](#M-SpyceLibrary-GameObject-ToString 'SpyceLibrary.GameObject.ToString')
  - [Update(gameTime)](#M-SpyceLibrary-GameObject-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.GameObject.Update(Microsoft.Xna.Framework.GameTime)')
- [GameObjectEvent](#T-SpyceLibrary-GameObject-GameObjectEvent 'SpyceLibrary.GameObject.GameObjectEvent')
- [ICommand](#T-SpyceLibrary-Debugging-Commands-ICommand 'SpyceLibrary.Debugging.Commands.ICommand')
  - [Help()](#M-SpyceLibrary-Debugging-Commands-ICommand-Help 'SpyceLibrary.Debugging.Commands.ICommand.Help')
  - [Run(sender,args,initializer)](#M-SpyceLibrary-Debugging-Commands-ICommand-Run-System-String,System-String[],SpyceLibrary-Initializer- 'SpyceLibrary.Debugging.Commands.ICommand.Run(System.String,System.String[],SpyceLibrary.Initializer)')
- [IDrawn](#T-SpyceLibrary-IDrawn 'SpyceLibrary.IDrawn')
  - [MAX_DRAW_ORDER](#F-SpyceLibrary-IDrawn-MAX_DRAW_ORDER 'SpyceLibrary.IDrawn.MAX_DRAW_ORDER')
  - [Draw()](#M-SpyceLibrary-IDrawn-Draw 'SpyceLibrary.IDrawn.Draw')
  - [DrawOrder()](#M-SpyceLibrary-IDrawn-DrawOrder 'SpyceLibrary.IDrawn.DrawOrder')
  - [GetDrawRectangle()](#M-SpyceLibrary-IDrawn-GetDrawRectangle 'SpyceLibrary.IDrawn.GetDrawRectangle')
- [IUpdated](#T-SpyceLibrary-IUpdated 'SpyceLibrary.IUpdated')
  - [Update(gameTime)](#M-SpyceLibrary-IUpdated-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.IUpdated.Update(Microsoft.Xna.Framework.GameTime)')
- [Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer')
  - [Content](#F-SpyceLibrary-Initializer-Content 'SpyceLibrary.Initializer.Content')
  - [Device](#F-SpyceLibrary-Initializer-Device 'SpyceLibrary.Initializer.Device')
  - [Graphics](#F-SpyceLibrary-Initializer-Graphics 'SpyceLibrary.Initializer.Graphics')
  - [SpriteBatch](#F-SpyceLibrary-Initializer-SpriteBatch 'SpyceLibrary.Initializer.SpriteBatch')
  - [Window](#F-SpyceLibrary-Initializer-Window 'SpyceLibrary.Initializer.Window')
- [InputManager](#T-SpyceLibrary-InputManager 'SpyceLibrary.InputManager')
  - [Instance](#P-SpyceLibrary-InputManager-Instance 'SpyceLibrary.InputManager.Instance')
  - [IsKeyDown(keys)](#M-SpyceLibrary-InputManager-IsKeyDown-Microsoft-Xna-Framework-Input-Keys[]- 'SpyceLibrary.InputManager.IsKeyDown(Microsoft.Xna.Framework.Input.Keys[])')
  - [IsKeyPressed(keys)](#M-SpyceLibrary-InputManager-IsKeyPressed-Microsoft-Xna-Framework-Input-Keys[]- 'SpyceLibrary.InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys[])')
  - [IsKeyReleased(keys)](#M-SpyceLibrary-InputManager-IsKeyReleased-Microsoft-Xna-Framework-Input-Keys[]- 'SpyceLibrary.InputManager.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys[])')
  - [IsMouseClicked(button)](#M-SpyceLibrary-InputManager-IsMouseClicked-SpyceLibrary-MouseButton- 'SpyceLibrary.InputManager.IsMouseClicked(SpyceLibrary.MouseButton)')
  - [IsMouseDown(button)](#M-SpyceLibrary-InputManager-IsMouseDown-SpyceLibrary-MouseButton- 'SpyceLibrary.InputManager.IsMouseDown(SpyceLibrary.MouseButton)')
  - [IsMouseUp(button)](#M-SpyceLibrary-InputManager-IsMouseUp-SpyceLibrary-MouseButton- 'SpyceLibrary.InputManager.IsMouseUp(SpyceLibrary.MouseButton)')
  - [IsScrolledDown()](#M-SpyceLibrary-InputManager-IsScrolledDown 'SpyceLibrary.InputManager.IsScrolledDown')
  - [IsScrolledUp()](#M-SpyceLibrary-InputManager-IsScrolledUp 'SpyceLibrary.InputManager.IsScrolledUp')
  - [MouseScrollAmount()](#M-SpyceLibrary-InputManager-MouseScrollAmount 'SpyceLibrary.InputManager.MouseScrollAmount')
  - [Update()](#M-SpyceLibrary-InputManager-Update 'SpyceLibrary.InputManager.Update')
  - [findNewKeys\`\`1(a,b)](#M-SpyceLibrary-InputManager-findNewKeys``1-``0[],``0[]- 'SpyceLibrary.InputManager.findNewKeys``1(``0[],``0[])')
- [KeyboardEventHandler](#T-SpyceLibrary-InputManager-KeyboardEventHandler 'SpyceLibrary.InputManager.KeyboardEventHandler')
- [ListCommand](#T-SpyceLibrary-Debugging-Commands-ListCommand 'SpyceLibrary.Debugging.Commands.ListCommand')
  - [Help()](#M-SpyceLibrary-Debugging-Commands-ListCommand-Help 'SpyceLibrary.Debugging.Commands.ListCommand.Help')
  - [Run(sender,args,initializer)](#M-SpyceLibrary-Debugging-Commands-ListCommand-Run-System-String,System-String[],SpyceLibrary-Initializer- 'SpyceLibrary.Debugging.Commands.ListCommand.Run(System.String,System.String[],SpyceLibrary.Initializer)')
- [LogEntry](#T-SpyceLibrary-Debugging-LogEntry 'SpyceLibrary.Debugging.LogEntry')
  - [Message](#F-SpyceLibrary-Debugging-LogEntry-Message 'SpyceLibrary.Debugging.LogEntry.Message')
  - [Sender](#F-SpyceLibrary-Debugging-LogEntry-Sender 'SpyceLibrary.Debugging.LogEntry.Sender')
  - [Time](#F-SpyceLibrary-Debugging-LogEntry-Time 'SpyceLibrary.Debugging.LogEntry.Time')
- [MouseButton](#T-SpyceLibrary-MouseButton 'SpyceLibrary.MouseButton')
  - [LEFT](#F-SpyceLibrary-MouseButton-LEFT 'SpyceLibrary.MouseButton.LEFT')
  - [MIDDLE](#F-SpyceLibrary-MouseButton-MIDDLE 'SpyceLibrary.MouseButton.MIDDLE')
  - [RIGHT](#F-SpyceLibrary-MouseButton-RIGHT 'SpyceLibrary.MouseButton.RIGHT')
- [MouseEventHandler](#T-SpyceLibrary-InputManager-MouseEventHandler 'SpyceLibrary.InputManager.MouseEventHandler')
- [PhysicsBody](#T-SpyceLibrary-Physics-PhysicsBody 'SpyceLibrary.Physics.PhysicsBody')
  - [#ctor()](#M-SpyceLibrary-Physics-PhysicsBody-#ctor 'SpyceLibrary.Physics.PhysicsBody.#ctor')
  - [Collider](#P-SpyceLibrary-Physics-PhysicsBody-Collider 'SpyceLibrary.Physics.PhysicsBody.Collider')
  - [IsCollidable](#P-SpyceLibrary-Physics-PhysicsBody-IsCollidable 'SpyceLibrary.Physics.PhysicsBody.IsCollidable')
  - [Position](#P-SpyceLibrary-Physics-PhysicsBody-Position 'SpyceLibrary.Physics.PhysicsBody.Position')
  - [Velocity](#P-SpyceLibrary-Physics-PhysicsBody-Velocity 'SpyceLibrary.Physics.PhysicsBody.Velocity')
  - [Load(init,holder)](#M-SpyceLibrary-Physics-PhysicsBody-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Physics.PhysicsBody.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
- [PhysicsEngine](#T-SpyceLibrary-Physics-PhysicsEngine 'SpyceLibrary.Physics.PhysicsEngine')
  - [#ctor()](#M-SpyceLibrary-Physics-PhysicsEngine-#ctor 'SpyceLibrary.Physics.PhysicsEngine.#ctor')
  - [QUAD_SIZE](#F-SpyceLibrary-Physics-PhysicsEngine-QUAD_SIZE 'SpyceLibrary.Physics.PhysicsEngine.QUAD_SIZE')
  - [Clear()](#M-SpyceLibrary-Physics-PhysicsEngine-Clear 'SpyceLibrary.Physics.PhysicsEngine.Clear')
  - [Draw()](#M-SpyceLibrary-Physics-PhysicsEngine-Draw-SpyceLibrary-Camera- 'SpyceLibrary.Physics.PhysicsEngine.Draw(SpyceLibrary.Camera)')
  - [Initialize(initializer)](#M-SpyceLibrary-Physics-PhysicsEngine-Initialize-SpyceLibrary-Initializer- 'SpyceLibrary.Physics.PhysicsEngine.Initialize(SpyceLibrary.Initializer)')
  - [ReaddQuadBody(body)](#M-SpyceLibrary-Physics-PhysicsEngine-ReaddQuadBody-SpyceLibrary-Physics-PhysicsBody- 'SpyceLibrary.Physics.PhysicsEngine.ReaddQuadBody(SpyceLibrary.Physics.PhysicsBody)')
  - [RegisterBody(body)](#M-SpyceLibrary-Physics-PhysicsEngine-RegisterBody-SpyceLibrary-Physics-PhysicsBody- 'SpyceLibrary.Physics.PhysicsEngine.RegisterBody(SpyceLibrary.Physics.PhysicsBody)')
  - [UnregisterQuadBody(body)](#M-SpyceLibrary-Physics-PhysicsEngine-UnregisterQuadBody-SpyceLibrary-Physics-PhysicsBody- 'SpyceLibrary.Physics.PhysicsEngine.UnregisterQuadBody(SpyceLibrary.Physics.PhysicsBody)')
  - [Update(gameTime)](#M-SpyceLibrary-Physics-PhysicsEngine-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Physics.PhysicsEngine.Update(Microsoft.Xna.Framework.GameTime)')
- [Program](#T-SpyceLibrary-Program 'SpyceLibrary.Program')
  - [NAME](#F-SpyceLibrary-Program-NAME 'SpyceLibrary.Program.NAME')
  - [Main()](#M-SpyceLibrary-Program-Main 'SpyceLibrary.Program.Main')
  - [Run()](#M-SpyceLibrary-Program-Run 'SpyceLibrary.Program.Run')
- [Scene](#T-SpyceLibrary-Scene 'SpyceLibrary.Scene')
  - [#ctor()](#M-SpyceLibrary-Scene-#ctor 'SpyceLibrary.Scene.#ctor')
  - [GameObjects](#P-SpyceLibrary-Scene-GameObjects 'SpyceLibrary.Scene.GameObjects')
  - [ScreenRectangle](#P-SpyceLibrary-Scene-ScreenRectangle 'SpyceLibrary.Scene.ScreenRectangle')
  - [AddObject(obj)](#M-SpyceLibrary-Scene-AddObject-SpyceLibrary-GameObject- 'SpyceLibrary.Scene.AddObject(SpyceLibrary.GameObject)')
  - [Draw()](#M-SpyceLibrary-Scene-Draw 'SpyceLibrary.Scene.Draw')
  - [GetDebugName()](#M-SpyceLibrary-Scene-GetDebugName 'SpyceLibrary.Scene.GetDebugName')
  - [Initialize(initializer)](#M-SpyceLibrary-Scene-Initialize-SpyceLibrary-Initializer- 'SpyceLibrary.Scene.Initialize(SpyceLibrary.Initializer)')
  - [Load(initializer)](#M-SpyceLibrary-Scene-Load-SpyceLibrary-Initializer- 'SpyceLibrary.Scene.Load(SpyceLibrary.Initializer)')
  - [LoadObject(path)](#M-SpyceLibrary-Scene-LoadObject-System-String- 'SpyceLibrary.Scene.LoadObject(System.String)')
  - [OnObjectDestruction(obj)](#M-SpyceLibrary-Scene-OnObjectDestruction-SpyceLibrary-GameObject- 'SpyceLibrary.Scene.OnObjectDestruction(SpyceLibrary.GameObject)')
  - [PrintTickSpeed()](#M-SpyceLibrary-Scene-PrintTickSpeed 'SpyceLibrary.Scene.PrintTickSpeed')
  - [RemoveInterval(action)](#M-SpyceLibrary-Scene-RemoveInterval-System-Action- 'SpyceLibrary.Scene.RemoveInterval(System.Action)')
  - [RemoveObject(id)](#M-SpyceLibrary-Scene-RemoveObject-System-Guid- 'SpyceLibrary.Scene.RemoveObject(System.Guid)')
  - [SaveObject(obj,path)](#M-SpyceLibrary-Scene-SaveObject-SpyceLibrary-GameObject,System-String- 'SpyceLibrary.Scene.SaveObject(SpyceLibrary.GameObject,System.String)')
  - [SetInterval(action,interval,time)](#M-SpyceLibrary-Scene-SetInterval-System-Action,System-Single,System-Single- 'SpyceLibrary.Scene.SetInterval(System.Action,System.Single,System.Single)')
  - [SetScreenRectangleBounds(width,height)](#M-SpyceLibrary-Scene-SetScreenRectangleBounds-System-Int32,System-Int32- 'SpyceLibrary.Scene.SetScreenRectangleBounds(System.Int32,System.Int32)')
  - [SetScreenRectangleLocation(x,y)](#M-SpyceLibrary-Scene-SetScreenRectangleLocation-System-Int32,System-Int32- 'SpyceLibrary.Scene.SetScreenRectangleLocation(System.Int32,System.Int32)')
  - [Unload()](#M-SpyceLibrary-Scene-Unload 'SpyceLibrary.Scene.Unload')
  - [Update(gameTime)](#M-SpyceLibrary-Scene-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Scene.Update(Microsoft.Xna.Framework.GameTime)')
- [SceneManager](#T-SpyceLibrary-SceneManager 'SpyceLibrary.SceneManager')
  - [CurrentScene](#P-SpyceLibrary-SceneManager-CurrentScene 'SpyceLibrary.SceneManager.CurrentScene')
  - [CurrentSceneType](#P-SpyceLibrary-SceneManager-CurrentSceneType 'SpyceLibrary.SceneManager.CurrentSceneType')
  - [Instance](#P-SpyceLibrary-SceneManager-Instance 'SpyceLibrary.SceneManager.Instance')
  - [ChangeScene(scene)](#M-SpyceLibrary-SceneManager-ChangeScene-System-String- 'SpyceLibrary.SceneManager.ChangeScene(System.String)')
  - [Draw()](#M-SpyceLibrary-SceneManager-Draw 'SpyceLibrary.SceneManager.Draw')
  - [GetWindowSize()](#M-SpyceLibrary-SceneManager-GetWindowSize 'SpyceLibrary.SceneManager.GetWindowSize')
  - [Initialize(content,spriteBatch,device,graphics,window)](#M-SpyceLibrary-SceneManager-Initialize-Microsoft-Xna-Framework-Content-ContentManager,Microsoft-Xna-Framework-Graphics-SpriteBatch,Microsoft-Xna-Framework-Graphics-GraphicsDevice,Microsoft-Xna-Framework-GraphicsDeviceManager,Microsoft-Xna-Framework-GameWindow- 'SpyceLibrary.SceneManager.Initialize(Microsoft.Xna.Framework.Content.ContentManager,Microsoft.Xna.Framework.Graphics.SpriteBatch,Microsoft.Xna.Framework.Graphics.GraphicsDevice,Microsoft.Xna.Framework.GraphicsDeviceManager,Microsoft.Xna.Framework.GameWindow)')
  - [LoadScene(scene)](#M-SpyceLibrary-SceneManager-LoadScene-System-String- 'SpyceLibrary.SceneManager.LoadScene(System.String)')
  - [OnExiting()](#M-SpyceLibrary-SceneManager-OnExiting 'SpyceLibrary.SceneManager.OnExiting')
  - [RegisterScene(sceneType,sceneName)](#M-SpyceLibrary-SceneManager-RegisterScene-System-Type,System-String- 'SpyceLibrary.SceneManager.RegisterScene(System.Type,System.String)')
  - [SetFrameDimension(width,height)](#M-SpyceLibrary-SceneManager-SetFrameDimension-System-Int32,System-Int32- 'SpyceLibrary.SceneManager.SetFrameDimension(System.Int32,System.Int32)')
  - [Update(gameTime)](#M-SpyceLibrary-SceneManager-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.SceneManager.Update(Microsoft.Xna.Framework.GameTime)')
- [Sprite](#T-SpyceLibrary-Sprites-Sprite 'SpyceLibrary.Sprites.Sprite')
  - [#ctor()](#M-SpyceLibrary-Sprites-Sprite-#ctor 'SpyceLibrary.Sprites.Sprite.#ctor')
  - [TexturePath](#P-SpyceLibrary-Sprites-Sprite-TexturePath 'SpyceLibrary.Sprites.Sprite.TexturePath')
  - [Draw()](#M-SpyceLibrary-Sprites-Sprite-Draw 'SpyceLibrary.Sprites.Sprite.Draw')
  - [DrawOrder()](#M-SpyceLibrary-Sprites-Sprite-DrawOrder 'SpyceLibrary.Sprites.Sprite.DrawOrder')
  - [GetDrawRectangle()](#M-SpyceLibrary-Sprites-Sprite-GetDrawRectangle 'SpyceLibrary.Sprites.Sprite.GetDrawRectangle')
  - [Load(init,holder)](#M-SpyceLibrary-Sprites-Sprite-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Sprites.Sprite.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
  - [SetDrawOrder(order)](#M-SpyceLibrary-Sprites-Sprite-SetDrawOrder-System-UInt32- 'SpyceLibrary.Sprites.Sprite.SetDrawOrder(System.UInt32)')
  - [SetOffset(offset)](#M-SpyceLibrary-Sprites-Sprite-SetOffset-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Sprites.Sprite.SetOffset(Microsoft.Xna.Framework.Vector2)')
  - [SetSize(size)](#M-SpyceLibrary-Sprites-Sprite-SetSize-Microsoft-Xna-Framework-Point- 'SpyceLibrary.Sprites.Sprite.SetSize(Microsoft.Xna.Framework.Point)')
  - [SetSize(width,height)](#M-SpyceLibrary-Sprites-Sprite-SetSize-System-Int32,System-Int32- 'SpyceLibrary.Sprites.Sprite.SetSize(System.Int32,System.Int32)')
  - [SetTexturePath(path)](#M-SpyceLibrary-Sprites-Sprite-SetTexturePath-System-String- 'SpyceLibrary.Sprites.Sprite.SetTexturePath(System.String)')
- [SpriteAnimation](#T-SpyceLibrary-Sprites-SpriteAnimation 'SpyceLibrary.Sprites.SpriteAnimation')
  - [CurrentFrame](#P-SpyceLibrary-Sprites-SpriteAnimation-CurrentFrame 'SpyceLibrary.Sprites.SpriteAnimation.CurrentFrame')
  - [FrameData](#P-SpyceLibrary-Sprites-SpriteAnimation-FrameData 'SpyceLibrary.Sprites.SpriteAnimation.FrameData')
  - [SetCurrentFrame(frame)](#M-SpyceLibrary-Sprites-SpriteAnimation-SetCurrentFrame-System-Int32- 'SpyceLibrary.Sprites.SpriteAnimation.SetCurrentFrame(System.Int32)')
  - [Update(gameTime)](#M-SpyceLibrary-Sprites-SpriteAnimation-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Sprites.SpriteAnimation.Update(Microsoft.Xna.Framework.GameTime)')
- [TestComponent](#T-SpyceLibrary-Physics-TestComponent 'SpyceLibrary.Physics.TestComponent')
  - [#ctor()](#M-SpyceLibrary-Physics-TestComponent-#ctor 'SpyceLibrary.Physics.TestComponent.#ctor')
  - [Load(init,holder)](#M-SpyceLibrary-Physics-TestComponent-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Physics.TestComponent.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
  - [Update(gameTime)](#M-SpyceLibrary-Physics-TestComponent-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Physics.TestComponent.Update(Microsoft.Xna.Framework.GameTime)')
- [TestScene](#T-SpyceLibrary-Scenes-TestScene 'SpyceLibrary.Scenes.TestScene')
  - [#ctor()](#M-SpyceLibrary-Scenes-TestScene-#ctor 'SpyceLibrary.Scenes.TestScene.#ctor')
  - [NAME](#F-SpyceLibrary-Scenes-TestScene-NAME 'SpyceLibrary.Scenes.TestScene.NAME')
  - [WINDOW_HEIGHT](#F-SpyceLibrary-Scenes-TestScene-WINDOW_HEIGHT 'SpyceLibrary.Scenes.TestScene.WINDOW_HEIGHT')
  - [WINDOW_WIDTH](#F-SpyceLibrary-Scenes-TestScene-WINDOW_WIDTH 'SpyceLibrary.Scenes.TestScene.WINDOW_WIDTH')
  - [AddObject(obj)](#M-SpyceLibrary-Scenes-TestScene-AddObject-SpyceLibrary-GameObject- 'SpyceLibrary.Scenes.TestScene.AddObject(SpyceLibrary.GameObject)')
  - [Draw()](#M-SpyceLibrary-Scenes-TestScene-Draw 'SpyceLibrary.Scenes.TestScene.Draw')
  - [Load(initializer)](#M-SpyceLibrary-Scenes-TestScene-Load-SpyceLibrary-Initializer- 'SpyceLibrary.Scenes.TestScene.Load(SpyceLibrary.Initializer)')
  - [Unload()](#M-SpyceLibrary-Scenes-TestScene-Unload 'SpyceLibrary.Scenes.TestScene.Unload')
  - [Update(gameTime)](#M-SpyceLibrary-Scenes-TestScene-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Scenes.TestScene.Update(Microsoft.Xna.Framework.GameTime)')
- [Time](#T-SpyceLibrary-Time 'SpyceLibrary.Time')
  - [DeltaTime](#P-SpyceLibrary-Time-DeltaTime 'SpyceLibrary.Time.DeltaTime')
  - [GameTime](#P-SpyceLibrary-Time-GameTime 'SpyceLibrary.Time.GameTime')
  - [Instance](#P-SpyceLibrary-Time-Instance 'SpyceLibrary.Time.Instance')
  - [RawDeltaTime](#P-SpyceLibrary-Time-RawDeltaTime 'SpyceLibrary.Time.RawDeltaTime')
  - [Update(gameTime)](#M-SpyceLibrary-Time-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Time.Update(Microsoft.Xna.Framework.GameTime)')
- [Transform](#T-SpyceLibrary-Transform 'SpyceLibrary.Transform')
  - [Position](#F-SpyceLibrary-Transform-Position 'SpyceLibrary.Transform.Position')
  - [Rotation](#F-SpyceLibrary-Transform-Rotation 'SpyceLibrary.Transform.Rotation')
  - [Scale](#F-SpyceLibrary-Transform-Scale 'SpyceLibrary.Transform.Scale')
  - [Identity](#P-SpyceLibrary-Transform-Identity 'SpyceLibrary.Transform.Identity')
  - [SetPosition(position)](#M-SpyceLibrary-Transform-SetPosition-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Transform.SetPosition(Microsoft.Xna.Framework.Vector2)')
  - [SetPosition(x,y)](#M-SpyceLibrary-Transform-SetPosition-System-Single,System-Single- 'SpyceLibrary.Transform.SetPosition(System.Single,System.Single)')
  - [SetScale(scale)](#M-SpyceLibrary-Transform-SetScale-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Transform.SetScale(Microsoft.Xna.Framework.Vector2)')

<a name='T-SpyceLibrary-Sprites-AnimatedSprite'></a>
## AnimatedSprite `type`

##### Namespace

SpyceLibrary.Sprites

##### Summary

A spritesheet based sprite.

<a name='M-SpyceLibrary-Sprites-AnimatedSprite-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the Animated Sprite.

##### Parameters

This constructor has no parameters.

<a name='T-SpyceLibrary-Physics-BoxCollider'></a>
## BoxCollider `type`

##### Namespace

SpyceLibrary.Physics

<a name='M-SpyceLibrary-Physics-BoxCollider-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the collider.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-Physics-BoxCollider-Offset'></a>
### Offset `property`

##### Summary

The offset of the collider.

<a name='P-SpyceLibrary-Physics-BoxCollider-Size'></a>
### Size `property`

##### Summary

The size of the collider.

<a name='M-SpyceLibrary-Physics-BoxCollider-ConstructRectangleAt-Microsoft-Xna-Framework-Vector2-'></a>
### ConstructRectangleAt(position) `method`

##### Summary

Constructs a rectangle at the given position.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='M-SpyceLibrary-Physics-BoxCollider-SetBounds-Microsoft-Xna-Framework-Point-'></a>
### SetBounds(size) `method`

##### Summary

Sets the size of the collision rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [Microsoft.Xna.Framework.Point](#T-Microsoft-Xna-Framework-Point 'Microsoft.Xna.Framework.Point') |  |

<a name='M-SpyceLibrary-Physics-BoxCollider-SetOffset-Microsoft-Xna-Framework-Point-'></a>
### SetOffset(offset) `method`

##### Summary

Sets the offset of the collision rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| offset | [Microsoft.Xna.Framework.Point](#T-Microsoft-Xna-Framework-Point 'Microsoft.Xna.Framework.Point') |  |

<a name='T-SpyceLibrary-Camera'></a>
## Camera `type`

##### Namespace

SpyceLibrary

##### Summary

Handles matrix camera transformations.

<a name='M-SpyceLibrary-Camera-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the camera.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-Camera-Position'></a>
### Position `property`

##### Summary

The position of the camera.

<a name='M-SpyceLibrary-Camera-FixViewOn-SpyceLibrary-GameObject-'></a>
### FixViewOn(obj) `method`

##### Summary

Fixes the view on the object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Camera-GetTransformedMatrix'></a>
### GetTransformedMatrix() `method`

##### Summary

Gets the transformed viewport matrix.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Camera-SetOffset-Microsoft-Xna-Framework-Vector2-'></a>
### SetOffset(offset) `method`

##### Summary

Sets the offset of the camera.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| offset | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='M-SpyceLibrary-Camera-SetViewOffsetPercent-Microsoft-Xna-Framework-Vector2-'></a>
### SetViewOffsetPercent(pOffset) `method`

##### Summary

Sets the percentage for how offset the camera is relative to the screen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pOffset | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='T-SpyceLibrary-Debugging-Commands-CommandHandler'></a>
## CommandHandler `type`

##### Namespace

SpyceLibrary.Debugging.Commands

##### Summary

Takes in full command lines and parses it into a command form.

<a name='P-SpyceLibrary-Debugging-Commands-CommandHandler-Instance'></a>
### Instance `property`

##### Summary

Singleton access to the command handler.

<a name='M-SpyceLibrary-Debugging-Commands-CommandHandler-Initialize-SpyceLibrary-Initializer-'></a>
### Initialize(initializer) `method`

##### Summary

Initializes the command handler.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-Debugging-Commands-CommandHandler-ParseCommand-System-String,System-String-'></a>
### ParseCommand(sender,command) `method`

##### Summary

Parses the arguments and executes the command.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| command | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-SpyceLibrary-GameComponent-ComponentEvent'></a>
## ComponentEvent `type`

##### Namespace

SpyceLibrary.GameComponent

##### Summary

Delegate for handling events related to UI components.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| component | [T:SpyceLibrary.GameComponent.ComponentEvent](#T-T-SpyceLibrary-GameComponent-ComponentEvent 'T:SpyceLibrary.GameComponent.ComponentEvent') |  |

<a name='T-SpyceLibrary-Debugging-Debug'></a>
## Debug `type`

##### Namespace

SpyceLibrary.Debugging

##### Summary

Debugging and performance analysis tools. Singleton to be universally access throughout
the game project.

<a name='F-SpyceLibrary-Debugging-Debug-LOGS_FILE_EXTENSION'></a>
### LOGS_FILE_EXTENSION `constants`

##### Summary

The file extension for the logs.

<a name='F-SpyceLibrary-Debugging-Debug-LOGS_FOLDER'></a>
### LOGS_FOLDER `constants`

##### Summary

The main folder where all the logs are saved to.

<a name='F-SpyceLibrary-Debugging-Debug-OnCommandSend'></a>
### OnCommandSend `constants`

##### Summary

When a line is sent through the command prompt.

<a name='F-SpyceLibrary-Debugging-Debug-OnLogsCleared'></a>
### OnLogsCleared `constants`

##### Summary

When the logs are cleared.

<a name='F-SpyceLibrary-Debugging-Debug-OnLogsSaved'></a>
### OnLogsSaved `constants`

##### Summary

When the logs are saved

<a name='F-SpyceLibrary-Debugging-Debug-OnNewDebugMessage'></a>
### OnNewDebugMessage `constants`

##### Summary

When a new message is added to the debug log.

<a name='P-SpyceLibrary-Debugging-Debug-DrawTime'></a>
### DrawTime `property`

##### Summary

The time it takes to run the draw loop.

<a name='P-SpyceLibrary-Debugging-Debug-Instance'></a>
### Instance `property`

##### Summary

Accessor for the singleton.

<a name='P-SpyceLibrary-Debugging-Debug-TickSpeed'></a>
### TickSpeed `property`

##### Summary

The measured time (milliseconds) between a draw and update function.

<a name='P-SpyceLibrary-Debugging-Debug-UpdateTime'></a>
### UpdateTime `property`

##### Summary

The time it takes to run the update loop.

<a name='M-SpyceLibrary-Debugging-Debug-ClearLogs-System-String-'></a>
### ClearLogs(sender) `method`

##### Summary

Clears all the logs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Debugging-Debug-Draw-Microsoft-Xna-Framework-Graphics-SpriteBatch-'></a>
### Draw(spriteBatch) `method`

##### Summary

Draws debug items to the screen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| spriteBatch | [Microsoft.Xna.Framework.Graphics.SpriteBatch](#T-Microsoft-Xna-Framework-Graphics-SpriteBatch 'Microsoft.Xna.Framework.Graphics.SpriteBatch') |  |

<a name='M-SpyceLibrary-Debugging-Debug-EndDrawTick'></a>
### EndDrawTick() `method`

##### Summary

Ends the counting of the current cycle of the update.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Debug-EndUpdateTick'></a>
### EndUpdateTick() `method`

##### Summary

Ends the counting of the current cycle of the update.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Debug-GetCurrentSceneObjectCount'></a>
### GetCurrentSceneObjectCount() `method`

##### Summary

Gets the number of objects in the current scene.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Debug-Initialize-SpyceLibrary-Engine-'></a>
### Initialize(engine) `method`

##### Summary

Initializes the in-game debugger.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| engine | [SpyceLibrary.Engine](#T-SpyceLibrary-Engine 'SpyceLibrary.Engine') |  |

<a name='M-SpyceLibrary-Debugging-Debug-ParseCommand-System-String,System-String-'></a>
### ParseCommand(sender,toParse) `method`

##### Summary

Parses the given line to the command prompt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| toParse | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Debugging-Debug-SaveLog-System-String-'></a>
### SaveLog(sender) `method`

##### Summary

Saves the log to the logs folder as a timestamped file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Debugging-Debug-SaveLog-System-String,System-String-'></a>
### SaveLog(sender,path) `method`

##### Summary

Saves the log to the specified path.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Debugging-Debug-StartDrawTick'></a>
### StartDrawTick() `method`

##### Summary

Starts counting the current cycle of the game loop.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Debug-StartUpdateTick'></a>
### StartUpdateTick() `method`

##### Summary

Starts counting the current cycle of the game loop.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Debug-WriteLine-System-String,System-String,System-ConsoleColor,System-ConsoleColor-'></a>
### WriteLine(sender,message,senderColor,messageColor) `method`

##### Summary

Writes a new line to the debug log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| senderColor | [System.ConsoleColor](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ConsoleColor 'System.ConsoleColor') |  |
| messageColor | [System.ConsoleColor](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ConsoleColor 'System.ConsoleColor') |  |

<a name='M-SpyceLibrary-Debugging-Debug-listObjects-System-String-'></a>
### listObjects(sender) `method`

##### Summary

Lists all the objects within the current scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-SpyceLibrary-Debugging-Debug-DebugEvent'></a>
## DebugEvent `type`

##### Namespace

SpyceLibrary.Debugging.Debug

##### Summary

Delegate handler for each event that is relevant to the debug object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:SpyceLibrary.Debugging.Debug.DebugEvent](#T-T-SpyceLibrary-Debugging-Debug-DebugEvent 'T:SpyceLibrary.Debugging.Debug.DebugEvent') |  |

<a name='T-SpyceLibrary-Debugging-Commands-EchoCommand'></a>
## EchoCommand `type`

##### Namespace

SpyceLibrary.Debugging.Commands

##### Summary

A simple echo command that prints the text after the command.

<a name='M-SpyceLibrary-Debugging-Commands-EchoCommand-Help'></a>
### Help() `method`

##### Summary

Prints out the syntax for the command.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Commands-EchoCommand-Run-System-String,System-String[],SpyceLibrary-Initializer-'></a>
### Run(sender,args,initializer) `method`

##### Summary

Runs the echo command.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='T-SpyceLibrary-Engine'></a>
## Engine `type`

##### Namespace

SpyceLibrary

##### Summary

The game engine holds various components from the game and runs them respectively.

<a name='M-SpyceLibrary-Engine-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the engine.

##### Parameters

This constructor has no parameters.

<a name='M-SpyceLibrary-Engine-Draw-Microsoft-Xna-Framework-GameTime-'></a>
### Draw(gameTime) `method`

##### Summary

Draws the instance of the engine.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='M-SpyceLibrary-Engine-Initialize'></a>
### Initialize() `method`

##### Summary

Initializes the graphics window.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Engine-LoadContent'></a>
### LoadContent() `method`

##### Summary

Loads and initializes necessary game assets.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Engine-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the game and it's members.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T--FastNoiseLite'></a>
## FastNoiseLite `type`

##### Namespace



<a name='M-FastNoiseLite-#ctor-System-Int32-'></a>
### #ctor() `constructor`

##### Summary

Create new FastNoise object with optional seed

##### Parameters

This constructor has no parameters.

<a name='M-FastNoiseLite-DomainWarp-System-Single@,System-Single@-'></a>
### DomainWarp() `method`

##### Summary

2D warps the input position using current domain warp settings

##### Parameters

This method has no parameters.

##### Example

Example usage with GetNoise

```
DomainWarp(ref x, ref y)
            noise = GetNoise(x, y)
```

<a name='M-FastNoiseLite-DomainWarp-System-Single@,System-Single@,System-Single@-'></a>
### DomainWarp() `method`

##### Summary

3D warps the input position using current domain warp settings

##### Parameters

This method has no parameters.

##### Example

Example usage with GetNoise

```
DomainWarp(ref x, ref y, ref z)
            noise = GetNoise(x, y, z)
```

<a name='M-FastNoiseLite-GetNoise-System-Single,System-Single-'></a>
### GetNoise() `method`

##### Summary

2D noise at given position using current settings

##### Returns

Noise output bounded between -1...1

##### Parameters

This method has no parameters.

<a name='M-FastNoiseLite-GetNoise-System-Single,System-Single,System-Single-'></a>
### GetNoise() `method`

##### Summary

3D noise at given position using current settings

##### Returns

Noise output bounded between -1...1

##### Parameters

This method has no parameters.

<a name='M-FastNoiseLite-SetCellularDistanceFunction-FastNoiseLite-CellularDistanceFunction-'></a>
### SetCellularDistanceFunction() `method`

##### Summary

Sets distance function used in cellular noise calculations

##### Parameters

This method has no parameters.

##### Remarks

Default: Distance

<a name='M-FastNoiseLite-SetCellularJitter-System-Single-'></a>
### SetCellularJitter() `method`

##### Summary

Sets the maximum distance a cellular point can move from it's grid position

##### Parameters

This method has no parameters.

##### Remarks

Default: 1.0
Note: Setting this higher than 1 will cause artifacts

<a name='M-FastNoiseLite-SetCellularReturnType-FastNoiseLite-CellularReturnType-'></a>
### SetCellularReturnType() `method`

##### Summary

Sets return type from cellular noise calculations

##### Parameters

This method has no parameters.

##### Remarks

Default: EuclideanSq

<a name='M-FastNoiseLite-SetDomainWarpAmp-System-Single-'></a>
### SetDomainWarpAmp() `method`

##### Summary

Sets the maximum warp distance from original position when using DomainWarp(...)

##### Parameters

This method has no parameters.

##### Remarks

Default: 1.0

<a name='M-FastNoiseLite-SetDomainWarpType-FastNoiseLite-DomainWarpType-'></a>
### SetDomainWarpType() `method`

##### Summary

Sets the warp algorithm when using DomainWarp(...)

##### Parameters

This method has no parameters.

##### Remarks

Default: OpenSimplex2

<a name='M-FastNoiseLite-SetFractalGain-System-Single-'></a>
### SetFractalGain() `method`

##### Summary

Sets octave gain for all fractal noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: 0.5

<a name='M-FastNoiseLite-SetFractalLacunarity-System-Single-'></a>
### SetFractalLacunarity() `method`

##### Summary

Sets octave lacunarity for all fractal noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: 2.0

<a name='M-FastNoiseLite-SetFractalOctaves-System-Int32-'></a>
### SetFractalOctaves() `method`

##### Summary

Sets octave count for all fractal noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: 3

<a name='M-FastNoiseLite-SetFractalPingPongStrength-System-Single-'></a>
### SetFractalPingPongStrength() `method`

##### Summary

Sets strength of the fractal ping pong effect

##### Parameters

This method has no parameters.

##### Remarks

Default: 2.0

<a name='M-FastNoiseLite-SetFractalType-FastNoiseLite-FractalType-'></a>
### SetFractalType() `method`

##### Summary

Sets method for combining octaves in all fractal noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: None
Note: FractalType.DomainWarp... only affects DomainWarp(...)

<a name='M-FastNoiseLite-SetFractalWeightedStrength-System-Single-'></a>
### SetFractalWeightedStrength() `method`

##### Summary

Sets octave weighting for all none DomainWarp fratal types

##### Parameters

This method has no parameters.

##### Remarks

Default: 0.0
Note: Keep between 0...1 to maintain -1...1 output bounding

<a name='M-FastNoiseLite-SetFrequency-System-Single-'></a>
### SetFrequency() `method`

##### Summary

Sets frequency for all noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: 0.01

<a name='M-FastNoiseLite-SetNoiseType-FastNoiseLite-NoiseType-'></a>
### SetNoiseType() `method`

##### Summary

Sets noise algorithm used for GetNoise(...)

##### Parameters

This method has no parameters.

##### Remarks

Default: OpenSimplex2

<a name='M-FastNoiseLite-SetRotationType3D-FastNoiseLite-RotationType3D-'></a>
### SetRotationType3D() `method`

##### Summary

Sets domain rotation type for 3D Noise and 3D DomainWarp.
Can aid in reducing directional artifacts when sampling a 2D plane in 3D

##### Parameters

This method has no parameters.

##### Remarks

Default: None

<a name='M-FastNoiseLite-SetSeed-System-Int32-'></a>
### SetSeed() `method`

##### Summary

Sets seed used for all noise types

##### Parameters

This method has no parameters.

##### Remarks

Default: 1337

<a name='T-SpyceLibrary-Sprites-FrameData'></a>
## FrameData `type`

##### Namespace

SpyceLibrary.Sprites

##### Summary

Represents a single frame for an animation.

<a name='P-SpyceLibrary-Sprites-FrameData-Position'></a>
### Position `property`

##### Summary

The position of the frame data on the texture file.

<a name='P-SpyceLibrary-Sprites-FrameData-Texture'></a>
### Texture `property`

##### Summary

The texture that the frame is located on. Each frame data holds a refernce to its
texture to allow for animations to potentially consist of different files.

<a name='P-SpyceLibrary-Sprites-FrameData-Time'></a>
### Time `property`

##### Summary

The amount of time is spent on this individual frame.

<a name='T-SpyceLibrary-GameComponent'></a>
## GameComponent `type`

##### Namespace

SpyceLibrary

##### Summary

An abstract component that is attached to a game object

<a name='M-SpyceLibrary-GameComponent-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the game component.

##### Parameters

This constructor has no parameters.

<a name='F-SpyceLibrary-GameComponent-OnDestroy'></a>
### OnDestroy `constants`

##### Summary

When the component is being destroyed.

<a name='F-SpyceLibrary-GameComponent-OnDisable'></a>
### OnDisable `constants`

##### Summary

When the component is disabled.

<a name='F-SpyceLibrary-GameComponent-OnEnable'></a>
### OnEnable `constants`

##### Summary

When the component is enabled.

<a name='P-SpyceLibrary-GameComponent-Holder'></a>
### Holder `property`

##### Summary

The game object that this component is attached to.

<a name='P-SpyceLibrary-GameComponent-IsEnabled'></a>
### IsEnabled `property`

##### Summary

Whether this component should be updated or drawn.

<a name='M-SpyceLibrary-GameComponent-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Called before the first Update has been called and after the object is created

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-GameComponent-RequireComponent``1'></a>
### RequireComponent\`\`1() `method`

##### Summary

Checks if the component is in the game object and throws an exception if it is not.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-SpyceLibrary-GameComponent-SetActive-System-Boolean-'></a>
### SetActive() `method`

##### Summary

Sets the activeness of the component.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameComponent-Unload'></a>
### Unload() `method`

##### Summary

Performs any final cleanup operations that aren't handled through regular garbage collection.

##### Parameters

This method has no parameters.

<a name='T-SpyceLibrary-GameObject'></a>
## GameObject `type`

##### Namespace

SpyceLibrary

##### Summary

Represents an abstract game object within the game.

<a name='M-SpyceLibrary-GameObject-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of a game object.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-GameObject-Children'></a>
### Children `property`

##### Summary

All game objects are childed to this game object.

<a name='P-SpyceLibrary-GameObject-Components'></a>
### Components `property`

##### Summary

The components attached to this game object.

<a name='P-SpyceLibrary-GameObject-ID'></a>
### ID `property`

##### Summary

The unique ID of this game object.

<a name='P-SpyceLibrary-GameObject-IsActive'></a>
### IsActive `property`

##### Summary

Whether this object currently has behavior.

<a name='P-SpyceLibrary-GameObject-RelativeTransform'></a>
### RelativeTransform `property`

##### Summary

The relative transformation (before applying parent transformations).

<a name='M-SpyceLibrary-GameObject-AddComponent-SpyceLibrary-GameComponent-'></a>
### AddComponent(component) `method`

##### Summary

Adds a component to the list of components

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| component | [SpyceLibrary.GameComponent](#T-SpyceLibrary-GameComponent 'SpyceLibrary.GameComponent') |  |

<a name='M-SpyceLibrary-GameObject-AddTags-System-String[]-'></a>
### AddTags(addTags) `method`

##### Summary

Adds a list of tags to the set of tags.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| addTags | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

<a name='M-SpyceLibrary-GameObject-Destroy'></a>
### Destroy() `method`

##### Summary

Frees up the memory in the game object and its components.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameObject-Draw'></a>
### Draw() `method`

##### Summary

Draws all the drawable components.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameObject-GenerateNewID'></a>
### GenerateNewID() `method`

##### Summary

Generates a new unique id for this object.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameObject-GetComponent``1'></a>
### GetComponent\`\`1() `method`

##### Summary

Gets the component if it is attached to this game object.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-SpyceLibrary-GameObject-GetTransform'></a>
### GetTransform() `method`

##### Summary

Gets the relative to world transform of the game object.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameObject-HasTag-System-String-'></a>
### HasTag(tag) `method`

##### Summary

Searches the list of tags for the specified tag.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tag | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-GameObject-IsDirectChild-SpyceLibrary-GameObject,SpyceLibrary-GameObject-'></a>
### IsDirectChild(parent,child) `method`

##### Summary

Checks if the first element is the direct parent of the second element.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |
| child | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-GameObject-Load-SpyceLibrary-Initializer-'></a>
### Load(init) `method`

##### Summary

Initializes the game object and loads all necessary assets.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-GameObject-SetActive-System-Boolean-'></a>
### SetActive(active) `method`

##### Summary

Sets the current object's activeness.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| active | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-SpyceLibrary-GameObject-SetParent-SpyceLibrary-GameObject-'></a>
### SetParent(parent) `method`

##### Summary

Sets the parent of the game object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-GameObject-SetRelativeTransform-SpyceLibrary-Transform-'></a>
### SetRelativeTransform(transform) `method`

##### Summary

Sets the relative transform of the game object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| transform | [SpyceLibrary.Transform](#T-SpyceLibrary-Transform 'SpyceLibrary.Transform') |  |

<a name='M-SpyceLibrary-GameObject-ToString'></a>
### ToString() `method`

##### Summary

Gets a string representation of the game object.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-GameObject-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the game object, components, and children.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-GameObject-GameObjectEvent'></a>
## GameObjectEvent `type`

##### Namespace

SpyceLibrary.GameObject

##### Summary

Delegate handler for game object events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [T:SpyceLibrary.GameObject.GameObjectEvent](#T-T-SpyceLibrary-GameObject-GameObjectEvent 'T:SpyceLibrary.GameObject.GameObjectEvent') |  |

<a name='T-SpyceLibrary-Debugging-Commands-ICommand'></a>
## ICommand `type`

##### Namespace

SpyceLibrary.Debugging.Commands

##### Summary

Base class for all console commands.

<a name='M-SpyceLibrary-Debugging-Commands-ICommand-Help'></a>
### Help() `method`

##### Summary

The summary and syntax for what this command.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Commands-ICommand-Run-System-String,System-String[],SpyceLibrary-Initializer-'></a>
### Run(sender,args,initializer) `method`

##### Summary

Executes the command with the given arguments

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='T-SpyceLibrary-IDrawn'></a>
## IDrawn `type`

##### Namespace

SpyceLibrary

##### Summary

An object that has draw behavior.

<a name='F-SpyceLibrary-IDrawn-MAX_DRAW_ORDER'></a>
### MAX_DRAW_ORDER `constants`

##### Summary

The maximum number of layers to be drawn on.

<a name='M-SpyceLibrary-IDrawn-Draw'></a>
### Draw() `method`

##### Summary

Draws the object to the screen.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-IDrawn-DrawOrder'></a>
### DrawOrder() `method`

##### Summary

The draw order of the game component.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-IDrawn-GetDrawRectangle'></a>
### GetDrawRectangle() `method`

##### Summary

The visible rectangle on the game world.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-SpyceLibrary-IUpdated'></a>
## IUpdated `type`

##### Namespace

SpyceLibrary

##### Summary

An object that has realtime update behavior.

<a name='M-SpyceLibrary-IUpdated-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Initializer'></a>
## Initializer `type`

##### Namespace

SpyceLibrary

##### Summary

Holds necessary data members for initializing game objects.

<a name='F-SpyceLibrary-Initializer-Content'></a>
### Content `constants`

##### Summary

Loads content for the game object.

<a name='F-SpyceLibrary-Initializer-Device'></a>
### Device `constants`

##### Summary

The graphics device manager of the game.

<a name='F-SpyceLibrary-Initializer-Graphics'></a>
### Graphics `constants`

##### Summary

The graphics device for the game engine.

<a name='F-SpyceLibrary-Initializer-SpriteBatch'></a>
### SpriteBatch `constants`

##### Summary

Allows for creation of sprite batches and drawn to the screen.

<a name='F-SpyceLibrary-Initializer-Window'></a>
### Window `constants`

##### Summary

The window of the game engine.

<a name='T-SpyceLibrary-InputManager'></a>
## InputManager `type`

##### Namespace

SpyceLibrary

##### Summary

A singleton class that handles user input.

<a name='P-SpyceLibrary-InputManager-Instance'></a>
### Instance `property`

##### Summary

Singleton access to the input manager.

<a name='M-SpyceLibrary-InputManager-IsKeyDown-Microsoft-Xna-Framework-Input-Keys[]-'></a>
### IsKeyDown(keys) `method`

##### Summary

Determines whether the key(s) are down.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keys | [Microsoft.Xna.Framework.Input.Keys[]](#T-Microsoft-Xna-Framework-Input-Keys[] 'Microsoft.Xna.Framework.Input.Keys[]') |  |

<a name='M-SpyceLibrary-InputManager-IsKeyPressed-Microsoft-Xna-Framework-Input-Keys[]-'></a>
### IsKeyPressed(keys) `method`

##### Summary

Determines whether the key(s) have been pressed.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keys | [Microsoft.Xna.Framework.Input.Keys[]](#T-Microsoft-Xna-Framework-Input-Keys[] 'Microsoft.Xna.Framework.Input.Keys[]') |  |

<a name='M-SpyceLibrary-InputManager-IsKeyReleased-Microsoft-Xna-Framework-Input-Keys[]-'></a>
### IsKeyReleased(keys) `method`

##### Summary

Determines whether the key(s) are released.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keys | [Microsoft.Xna.Framework.Input.Keys[]](#T-Microsoft-Xna-Framework-Input-Keys[] 'Microsoft.Xna.Framework.Input.Keys[]') |  |

<a name='M-SpyceLibrary-InputManager-IsMouseClicked-SpyceLibrary-MouseButton-'></a>
### IsMouseClicked(button) `method`

##### Summary

Determines whether the mouse has been clicked.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| button | [SpyceLibrary.MouseButton](#T-SpyceLibrary-MouseButton 'SpyceLibrary.MouseButton') |  |

<a name='M-SpyceLibrary-InputManager-IsMouseDown-SpyceLibrary-MouseButton-'></a>
### IsMouseDown(button) `method`

##### Summary

Determines if the button is currently being held down.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| button | [SpyceLibrary.MouseButton](#T-SpyceLibrary-MouseButton 'SpyceLibrary.MouseButton') |  |

<a name='M-SpyceLibrary-InputManager-IsMouseUp-SpyceLibrary-MouseButton-'></a>
### IsMouseUp(button) `method`

##### Summary

Determines if the button is currently being held down.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| button | [SpyceLibrary.MouseButton](#T-SpyceLibrary-MouseButton 'SpyceLibrary.MouseButton') |  |

<a name='M-SpyceLibrary-InputManager-IsScrolledDown'></a>
### IsScrolledDown() `method`

##### Summary

Determines if the mouse is scrolled down.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-InputManager-IsScrolledUp'></a>
### IsScrolledUp() `method`

##### Summary

Determines if the mouse is scrolled up.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-InputManager-MouseScrollAmount'></a>
### MouseScrollAmount() `method`

##### Summary

Returns the amount the mouse is scrolled in this update cycle.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-InputManager-Update'></a>
### Update() `method`

##### Summary

Updates the state of the input manager.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-InputManager-findNewKeys``1-``0[],``0[]-'></a>
### findNewKeys\`\`1(a,b) `method`

##### Summary

Creates a list of keys that are currently in a, but not in b.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [\`\`0[]](#T-``0[] '``0[]') |  |
| b | [\`\`0[]](#T-``0[] '``0[]') |  |

<a name='T-SpyceLibrary-InputManager-KeyboardEventHandler'></a>
## KeyboardEventHandler `type`

##### Namespace

SpyceLibrary.InputManager

##### Summary

Delegate handler for events from keyboards.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [T:SpyceLibrary.InputManager.KeyboardEventHandler](#T-T-SpyceLibrary-InputManager-KeyboardEventHandler 'T:SpyceLibrary.InputManager.KeyboardEventHandler') |  |

<a name='T-SpyceLibrary-Debugging-Commands-ListCommand'></a>
## ListCommand `type`

##### Namespace

SpyceLibrary.Debugging.Commands

##### Summary

Lists specific things in the game.

<a name='M-SpyceLibrary-Debugging-Commands-ListCommand-Help'></a>
### Help() `method`

##### Summary

Gets the syntax for the command.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debugging-Commands-ListCommand-Run-System-String,System-String[],SpyceLibrary-Initializer-'></a>
### Run(sender,args,initializer) `method`

##### Summary

Runs the list command.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='T-SpyceLibrary-Debugging-LogEntry'></a>
## LogEntry `type`

##### Namespace

SpyceLibrary.Debugging

<a name='F-SpyceLibrary-Debugging-LogEntry-Message'></a>
### Message `constants`

##### Summary

The content of the message.

<a name='F-SpyceLibrary-Debugging-LogEntry-Sender'></a>
### Sender `constants`

##### Summary

The name of the sender.

<a name='F-SpyceLibrary-Debugging-LogEntry-Time'></a>
### Time `constants`

##### Summary

The time the message was created.

<a name='T-SpyceLibrary-MouseButton'></a>
## MouseButton `type`

##### Namespace

SpyceLibrary

##### Summary

The mouse buttons on a mouse.

<a name='F-SpyceLibrary-MouseButton-LEFT'></a>
### LEFT `constants`

##### Summary

The left mouse button

<a name='F-SpyceLibrary-MouseButton-MIDDLE'></a>
### MIDDLE `constants`

##### Summary

The middle mouse button

<a name='F-SpyceLibrary-MouseButton-RIGHT'></a>
### RIGHT `constants`

##### Summary

The right mouse button

<a name='T-SpyceLibrary-InputManager-MouseEventHandler'></a>
## MouseEventHandler `type`

##### Namespace

SpyceLibrary.InputManager

##### Summary

Delegate handlder for events from them mouse.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| button | [T:SpyceLibrary.InputManager.MouseEventHandler](#T-T-SpyceLibrary-InputManager-MouseEventHandler 'T:SpyceLibrary.InputManager.MouseEventHandler') |  |

<a name='T-SpyceLibrary-Physics-PhysicsBody'></a>
## PhysicsBody `type`

##### Namespace

SpyceLibrary.Physics

##### Summary

A member of the physics engine. This represents a physical object within the game world
that has physics-based behaviors and interactions with other physical objects.

<a name='M-SpyceLibrary-Physics-PhysicsBody-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the physics body.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-Physics-PhysicsBody-Collider'></a>
### Collider `property`

##### Summary

The rectangular collision rectangle of the physics body. TODO: Change to a more
generic collider type.

<a name='P-SpyceLibrary-Physics-PhysicsBody-IsCollidable'></a>
### IsCollidable `property`

##### Summary

Whether this object should be collided with in the collision detection.

<a name='P-SpyceLibrary-Physics-PhysicsBody-Position'></a>
### Position `property`

##### Summary

Position of the physics body.

<a name='P-SpyceLibrary-Physics-PhysicsBody-Velocity'></a>
### Velocity `property`

##### Summary

The velocity of the body for this tick.

<a name='M-SpyceLibrary-Physics-PhysicsBody-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Initializes the physics body.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='T-SpyceLibrary-Physics-PhysicsEngine'></a>
## PhysicsEngine `type`

##### Namespace

SpyceLibrary.Physics

##### Summary

Updates physical objects within the game world.

<a name='M-SpyceLibrary-Physics-PhysicsEngine-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the physics engine.

##### Parameters

This constructor has no parameters.

<a name='F-SpyceLibrary-Physics-PhysicsEngine-QUAD_SIZE'></a>
### QUAD_SIZE `constants`

##### Summary

The size of each theoretical quad.

<a name='M-SpyceLibrary-Physics-PhysicsEngine-Clear'></a>
### Clear() `method`

##### Summary

Clears all the bodies from the physics engine.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Physics-PhysicsEngine-Draw-SpyceLibrary-Camera-'></a>
### Draw() `method`

##### Summary

Debug Purposes. Draws a half opacity rectangle for all the physics bodies in the world.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Physics-PhysicsEngine-Initialize-SpyceLibrary-Initializer-'></a>
### Initialize(initializer) `method`

##### Summary

Initializes the physics engine.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-Physics-PhysicsEngine-ReaddQuadBody-SpyceLibrary-Physics-PhysicsBody-'></a>
### ReaddQuadBody(body) `method`

##### Summary

Registers the quad bodies of this body into the quad map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [SpyceLibrary.Physics.PhysicsBody](#T-SpyceLibrary-Physics-PhysicsBody 'SpyceLibrary.Physics.PhysicsBody') |  |

<a name='M-SpyceLibrary-Physics-PhysicsEngine-RegisterBody-SpyceLibrary-Physics-PhysicsBody-'></a>
### RegisterBody(body) `method`

##### Summary

Registers the body to the engine.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [SpyceLibrary.Physics.PhysicsBody](#T-SpyceLibrary-Physics-PhysicsBody 'SpyceLibrary.Physics.PhysicsBody') |  |

<a name='M-SpyceLibrary-Physics-PhysicsEngine-UnregisterQuadBody-SpyceLibrary-Physics-PhysicsBody-'></a>
### UnregisterQuadBody(body) `method`

##### Summary

Unregisters the bod with the quad map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [SpyceLibrary.Physics.PhysicsBody](#T-SpyceLibrary-Physics-PhysicsBody 'SpyceLibrary.Physics.PhysicsBody') |  |

<a name='M-SpyceLibrary-Physics-PhysicsEngine-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of each physics engine.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Program'></a>
## Program `type`

##### Namespace

SpyceLibrary

##### Summary

Game runner class.

<a name='F-SpyceLibrary-Program-NAME'></a>
### NAME `constants`

##### Summary

The debug name of the game runner.

<a name='M-SpyceLibrary-Program-Main'></a>
### Main() `method`

##### Summary

Main method.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Program-Run'></a>
### Run() `method`

##### Summary

Runs the game.

##### Parameters

This method has no parameters.

<a name='T-SpyceLibrary-Scene'></a>
## Scene `type`

##### Namespace

SpyceLibrary

##### Summary

A scene represents a set of various game objects interacting. Scenes are indepedent of each other and
can be interchangebly loaded using the scene manager.

<a name='M-SpyceLibrary-Scene-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the game scene.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-Scene-GameObjects'></a>
### GameObjects `property`

##### Summary

Refernce to the data structure holding all the game objects in the game.

<a name='P-SpyceLibrary-Scene-ScreenRectangle'></a>
### ScreenRectangle `property`

##### Summary

The rectangle of the screen.

<a name='M-SpyceLibrary-Scene-AddObject-SpyceLibrary-GameObject-'></a>
### AddObject(obj) `method`

##### Summary

Adds an object to the game scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Scene-Draw'></a>
### Draw() `method`

##### Summary

Calls draw on each of the objects in the scene.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scene-GetDebugName'></a>
### GetDebugName() `method`

##### Summary

The debug name of the current scene.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scene-Initialize-SpyceLibrary-Initializer-'></a>
### Initialize(initializer) `method`

##### Summary

Initializes the game scene with the necessary resources.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-Scene-Load-SpyceLibrary-Initializer-'></a>
### Load(initializer) `method`

##### Summary

Called before the first update is called.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-Scene-LoadObject-System-String-'></a>
### LoadObject(path) `method`

##### Summary

Loads an object from a specified path.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Scene-OnObjectDestruction-SpyceLibrary-GameObject-'></a>
### OnObjectDestruction(obj) `method`

##### Summary

When an object is destroyed, it is removed from the scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Scene-PrintTickSpeed'></a>
### PrintTickSpeed() `method`

##### Summary

Prints the current tick speed and FPS to the debug console.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scene-RemoveInterval-System-Action-'></a>
### RemoveInterval(action) `method`

##### Summary

Removes an existing intervaled function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

<a name='M-SpyceLibrary-Scene-RemoveObject-System-Guid-'></a>
### RemoveObject(id) `method`

##### Summary

Removes an object from the game scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') |  |

<a name='M-SpyceLibrary-Scene-SaveObject-SpyceLibrary-GameObject,System-String-'></a>
### SaveObject(obj,path) `method`

##### Summary

Saves the object to a specified path.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Scene-SetInterval-System-Action,System-Single,System-Single-'></a>
### SetInterval(action,interval,time) `method`

##### Summary

Runs a function on a fixed interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |
| interval | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| time | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-SpyceLibrary-Scene-SetScreenRectangleBounds-System-Int32,System-Int32-'></a>
### SetScreenRectangleBounds(width,height) `method`

##### Summary

Sets the size of the screen rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SpyceLibrary-Scene-SetScreenRectangleLocation-System-Int32,System-Int32-'></a>
### SetScreenRectangleLocation(x,y) `method`

##### Summary

Sets the position of the screen rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| y | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SpyceLibrary-Scene-Unload'></a>
### Unload() `method`

##### Summary

Performs any cleanup operations not done in regular garbage collection.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scene-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates all the game objects in this scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-SceneManager'></a>
## SceneManager `type`

##### Namespace

SpyceLibrary

##### Summary

A singleton object that handles various screen states. This has functionality that allows for
smooth transitions between different screen states.

<a name='P-SpyceLibrary-SceneManager-CurrentScene'></a>
### CurrentScene `property`

##### Summary

The scene that is currently being drawn and updated.

<a name='P-SpyceLibrary-SceneManager-CurrentSceneType'></a>
### CurrentSceneType `property`

##### Summary

The type of the current scene.

<a name='P-SpyceLibrary-SceneManager-Instance'></a>
### Instance `property`

##### Summary

Static access to the singleton scene manager object.

<a name='M-SpyceLibrary-SceneManager-ChangeScene-System-String-'></a>
### ChangeScene(scene) `method`

##### Summary

Changes the scene to the given scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scene | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-SceneManager-Draw'></a>
### Draw() `method`

##### Summary

Renders the contents of the scene manager and it's current scene.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-SceneManager-GetWindowSize'></a>
### GetWindowSize() `method`

##### Summary

Returns the size of the window in pixels.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-SceneManager-Initialize-Microsoft-Xna-Framework-Content-ContentManager,Microsoft-Xna-Framework-Graphics-SpriteBatch,Microsoft-Xna-Framework-Graphics-GraphicsDevice,Microsoft-Xna-Framework-GraphicsDeviceManager,Microsoft-Xna-Framework-GameWindow-'></a>
### Initialize(content,spriteBatch,device,graphics,window) `method`

##### Summary

Initializes the scene manager.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [Microsoft.Xna.Framework.Content.ContentManager](#T-Microsoft-Xna-Framework-Content-ContentManager 'Microsoft.Xna.Framework.Content.ContentManager') |  |
| spriteBatch | [Microsoft.Xna.Framework.Graphics.SpriteBatch](#T-Microsoft-Xna-Framework-Graphics-SpriteBatch 'Microsoft.Xna.Framework.Graphics.SpriteBatch') |  |
| device | [Microsoft.Xna.Framework.Graphics.GraphicsDevice](#T-Microsoft-Xna-Framework-Graphics-GraphicsDevice 'Microsoft.Xna.Framework.Graphics.GraphicsDevice') |  |
| graphics | [Microsoft.Xna.Framework.GraphicsDeviceManager](#T-Microsoft-Xna-Framework-GraphicsDeviceManager 'Microsoft.Xna.Framework.GraphicsDeviceManager') |  |
| window | [Microsoft.Xna.Framework.GameWindow](#T-Microsoft-Xna-Framework-GameWindow 'Microsoft.Xna.Framework.GameWindow') |  |

<a name='M-SpyceLibrary-SceneManager-LoadScene-System-String-'></a>
### LoadScene(scene) `method`

##### Summary

Creates a new instance of the given scene and returns it.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scene | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-SceneManager-OnExiting'></a>
### OnExiting() `method`

##### Summary

Called when the game is closing.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-SceneManager-RegisterScene-System-Type,System-String-'></a>
### RegisterScene(sceneType,sceneName) `method`

##### Summary

Registers a scene with the scene manager.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sceneType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| sceneName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-SceneManager-SetFrameDimension-System-Int32,System-Int32-'></a>
### SetFrameDimension(width,height) `method`

##### Summary

Sets the dimension of the window

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SpyceLibrary-SceneManager-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the scene manager and it's current scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Sprites-Sprite'></a>
## Sprite `type`

##### Namespace

SpyceLibrary.Sprites

##### Summary

Represents a drawable texture to the game object.

<a name='M-SpyceLibrary-Sprites-Sprite-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the game component.

##### Parameters

This constructor has no parameters.

<a name='P-SpyceLibrary-Sprites-Sprite-TexturePath'></a>
### TexturePath `property`

##### Summary

The path of the texture.

<a name='M-SpyceLibrary-Sprites-Sprite-Draw'></a>
### Draw() `method`

##### Summary

Draws the sprite to the screen.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Sprites-Sprite-DrawOrder'></a>
### DrawOrder() `method`

##### Summary

Gets the draw order for the sprite.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Sprites-Sprite-GetDrawRectangle'></a>
### GetDrawRectangle() `method`

##### Summary

Gets the visible rectangle for the sprite.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Sprites-Sprite-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Loads the textures of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetDrawOrder-System-UInt32-'></a>
### SetDrawOrder(order) `method`

##### Summary

Sets the draw order for the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| order | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetOffset-Microsoft-Xna-Framework-Vector2-'></a>
### SetOffset(offset) `method`

##### Summary

Sets the offset of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| offset | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetSize-Microsoft-Xna-Framework-Point-'></a>
### SetSize(size) `method`

##### Summary

Sets the drawn dimension of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| size | [Microsoft.Xna.Framework.Point](#T-Microsoft-Xna-Framework-Point 'Microsoft.Xna.Framework.Point') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetSize-System-Int32,System-Int32-'></a>
### SetSize(width,height) `method`

##### Summary

Sets the drawn dimension of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetTexturePath-System-String-'></a>
### SetTexturePath(path) `method`

##### Summary

Sets the texture path of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-SpyceLibrary-Sprites-SpriteAnimation'></a>
## SpriteAnimation `type`

##### Namespace

SpyceLibrary.Sprites

##### Summary

Represents an individual animation for a spritesheet.

<a name='P-SpyceLibrary-Sprites-SpriteAnimation-CurrentFrame'></a>
### CurrentFrame `property`

##### Summary

The current frame being displayed.

<a name='P-SpyceLibrary-Sprites-SpriteAnimation-FrameData'></a>
### FrameData `property`

##### Summary

The list of frame data in the animated sprite.

<a name='M-SpyceLibrary-Sprites-SpriteAnimation-SetCurrentFrame-System-Int32-'></a>
### SetCurrentFrame(frame) `method`

##### Summary

Sets the current frame of the animated sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frame | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SpyceLibrary-Sprites-SpriteAnimation-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the animated sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Physics-TestComponent'></a>
## TestComponent `type`

##### Namespace

SpyceLibrary.Physics

##### Summary

A component for testing means.

<a name='M-SpyceLibrary-Physics-TestComponent-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the test component.

##### Parameters

This constructor has no parameters.

<a name='M-SpyceLibrary-Physics-TestComponent-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Loads the test component.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Physics-TestComponent-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the player controller.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Scenes-TestScene'></a>
## TestScene `type`

##### Namespace

SpyceLibrary.Scenes

##### Summary

This is the scene that will test the various functionality.

<a name='M-SpyceLibrary-Scenes-TestScene-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the game scene.

##### Parameters

This constructor has no parameters.

<a name='F-SpyceLibrary-Scenes-TestScene-NAME'></a>
### NAME `constants`

##### Summary

The name of this scene.

<a name='F-SpyceLibrary-Scenes-TestScene-WINDOW_HEIGHT'></a>
### WINDOW_HEIGHT `constants`

##### Summary

Height of the window size.

<a name='F-SpyceLibrary-Scenes-TestScene-WINDOW_WIDTH'></a>
### WINDOW_WIDTH `constants`

##### Summary

Width of the window size.

<a name='M-SpyceLibrary-Scenes-TestScene-AddObject-SpyceLibrary-GameObject-'></a>
### AddObject(obj) `method`

##### Summary

Adds an object to the scene

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Scenes-TestScene-Draw'></a>
### Draw() `method`

##### Summary

Draws the contents of the game scene to the screen.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scenes-TestScene-Load-SpyceLibrary-Initializer-'></a>
### Load(initializer) `method`

##### Summary

Loads the scene and initializes it's data members.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initializer | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |

<a name='M-SpyceLibrary-Scenes-TestScene-Unload'></a>
### Unload() `method`

##### Summary

Unloads the test scene

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Scenes-TestScene-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the instance of the game scene.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Time'></a>
## Time `type`

##### Namespace

SpyceLibrary

##### Summary

Singleton class for handling time related applications.

<a name='P-SpyceLibrary-Time-DeltaTime'></a>
### DeltaTime `property`

##### Summary

The amount of elapsed time from the last update call.

<a name='P-SpyceLibrary-Time-GameTime'></a>
### GameTime `property`

##### Summary

The gametime field from the update cycle.

<a name='P-SpyceLibrary-Time-Instance'></a>
### Instance `property`

##### Summary

Singleton instance of the time.

<a name='P-SpyceLibrary-Time-RawDeltaTime'></a>
### RawDeltaTime `property`

##### Summary

The actual amount of elapsed time from the last update call.

<a name='M-SpyceLibrary-Time-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the time manager.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-Transform'></a>
## Transform `type`

##### Namespace

SpyceLibrary

##### Summary

Represents a size transformation of the game object.

<a name='F-SpyceLibrary-Transform-Position'></a>
### Position `constants`

##### Summary

The position of the transform.

<a name='F-SpyceLibrary-Transform-Rotation'></a>
### Rotation `constants`

##### Summary

The rotation of the sprite.

<a name='F-SpyceLibrary-Transform-Scale'></a>
### Scale `constants`

##### Summary

The size scale of the transform.

<a name='P-SpyceLibrary-Transform-Identity'></a>
### Identity `property`

##### Summary

Gets the identity transform. When this transform is applied, you get the exact same
transform.

<a name='M-SpyceLibrary-Transform-SetPosition-Microsoft-Xna-Framework-Vector2-'></a>
### SetPosition(position) `method`

##### Summary

Sets the position of the transform.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='M-SpyceLibrary-Transform-SetPosition-System-Single,System-Single-'></a>
### SetPosition(x,y) `method`

##### Summary

Sets the position of the transform.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| y | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-SpyceLibrary-Transform-SetScale-Microsoft-Xna-Framework-Vector2-'></a>
### SetScale(scale) `method`

##### Summary

Sets the scale of the transform.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scale | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |
