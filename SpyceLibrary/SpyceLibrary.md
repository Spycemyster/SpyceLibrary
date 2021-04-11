<a name='assembly'></a>
# SpyceLibrary

## Contents

- [BoxCollider](#T-SpyceLibrary-Physics-BoxCollider 'SpyceLibrary.Physics.BoxCollider')
  - [#ctor()](#M-SpyceLibrary-Physics-BoxCollider-#ctor 'SpyceLibrary.Physics.BoxCollider.#ctor')
  - [Colliders](#P-SpyceLibrary-Physics-BoxCollider-Colliders 'SpyceLibrary.Physics.BoxCollider.Colliders')
  - [AddCollisionRectangle(rect)](#M-SpyceLibrary-Physics-BoxCollider-AddCollisionRectangle-Microsoft-Xna-Framework-Rectangle- 'SpyceLibrary.Physics.BoxCollider.AddCollisionRectangle(Microsoft.Xna.Framework.Rectangle)')
- [Camera](#T-SpyceLibrary-Camera 'SpyceLibrary.Camera')
  - [#ctor()](#M-SpyceLibrary-Camera-#ctor 'SpyceLibrary.Camera.#ctor')
  - [Position](#P-SpyceLibrary-Camera-Position 'SpyceLibrary.Camera.Position')
  - [GetTransformedMatrix()](#M-SpyceLibrary-Camera-GetTransformedMatrix 'SpyceLibrary.Camera.GetTransformedMatrix')
  - [Load(init,holder)](#M-SpyceLibrary-Camera-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Camera.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
- [Debug](#T-SpyceLibrary-Debug 'SpyceLibrary.Debug')
  - [LOGS_FILE_EXTENSION](#F-SpyceLibrary-Debug-LOGS_FILE_EXTENSION 'SpyceLibrary.Debug.LOGS_FILE_EXTENSION')
  - [LOGS_FOLDER](#F-SpyceLibrary-Debug-LOGS_FOLDER 'SpyceLibrary.Debug.LOGS_FOLDER')
  - [Instance](#P-SpyceLibrary-Debug-Instance 'SpyceLibrary.Debug.Instance')
  - [TickSpeed](#P-SpyceLibrary-Debug-TickSpeed 'SpyceLibrary.Debug.TickSpeed')
  - [ClearLogs()](#M-SpyceLibrary-Debug-ClearLogs 'SpyceLibrary.Debug.ClearLogs')
  - [Initialize(engine)](#M-SpyceLibrary-Debug-Initialize-SpyceLibrary-Engine- 'SpyceLibrary.Debug.Initialize(SpyceLibrary.Engine)')
  - [SaveLog()](#M-SpyceLibrary-Debug-SaveLog 'SpyceLibrary.Debug.SaveLog')
  - [SaveLog(path)](#M-SpyceLibrary-Debug-SaveLog-System-String- 'SpyceLibrary.Debug.SaveLog(System.String)')
  - [WriteLine(sender,message,senderColor,messageColor)](#M-SpyceLibrary-Debug-WriteLine-System-String,System-String,System-ConsoleColor,System-ConsoleColor- 'SpyceLibrary.Debug.WriteLine(System.String,System.String,System.ConsoleColor,System.ConsoleColor)')
- [Engine](#T-SpyceLibrary-Engine 'SpyceLibrary.Engine')
  - [#ctor()](#M-SpyceLibrary-Engine-#ctor 'SpyceLibrary.Engine.#ctor')
- [GameComponent](#T-SpyceLibrary-GameComponent 'SpyceLibrary.GameComponent')
  - [#ctor()](#M-SpyceLibrary-GameComponent-#ctor 'SpyceLibrary.GameComponent.#ctor')
  - [OnDestroy](#F-SpyceLibrary-GameComponent-OnDestroy 'SpyceLibrary.GameComponent.OnDestroy')
  - [OnDisable](#F-SpyceLibrary-GameComponent-OnDisable 'SpyceLibrary.GameComponent.OnDisable')
  - [OnEnable](#F-SpyceLibrary-GameComponent-OnEnable 'SpyceLibrary.GameComponent.OnEnable')
  - [Holder](#P-SpyceLibrary-GameComponent-Holder 'SpyceLibrary.GameComponent.Holder')
  - [IsEnabled](#P-SpyceLibrary-GameComponent-IsEnabled 'SpyceLibrary.GameComponent.IsEnabled')
  - [Load(init,holder)](#M-SpyceLibrary-GameComponent-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.GameComponent.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
  - [SetActive()](#M-SpyceLibrary-GameComponent-SetActive-System-Boolean- 'SpyceLibrary.GameComponent.SetActive(System.Boolean)')
  - [Unload()](#M-SpyceLibrary-GameComponent-Unload 'SpyceLibrary.GameComponent.Unload')
- [GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject')
  - [#ctor(parent)](#M-SpyceLibrary-GameObject-#ctor 'SpyceLibrary.GameObject.#ctor')
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
  - [Load(init)](#M-SpyceLibrary-GameObject-Load-SpyceLibrary-Initializer- 'SpyceLibrary.GameObject.Load(SpyceLibrary.Initializer)')
  - [SetActive(active)](#M-SpyceLibrary-GameObject-SetActive-System-Boolean- 'SpyceLibrary.GameObject.SetActive(System.Boolean)')
  - [SetParent(parent)](#M-SpyceLibrary-GameObject-SetParent-SpyceLibrary-GameObject- 'SpyceLibrary.GameObject.SetParent(SpyceLibrary.GameObject)')
  - [SetRelativeTransform(transform)](#M-SpyceLibrary-GameObject-SetRelativeTransform-SpyceLibrary-Transform- 'SpyceLibrary.GameObject.SetRelativeTransform(SpyceLibrary.Transform)')
  - [Update(dt)](#M-SpyceLibrary-GameObject-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.GameObject.Update(Microsoft.Xna.Framework.GameTime)')
- [IDrawn](#T-SpyceLibrary-IDrawn 'SpyceLibrary.IDrawn')
  - [Draw()](#M-SpyceLibrary-IDrawn-Draw 'SpyceLibrary.IDrawn.Draw')
  - [DrawOrder()](#M-SpyceLibrary-IDrawn-DrawOrder 'SpyceLibrary.IDrawn.DrawOrder')
- [IUpdated](#T-SpyceLibrary-IUpdated 'SpyceLibrary.IUpdated')
  - [Update(gameTime)](#M-SpyceLibrary-IUpdated-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.IUpdated.Update(Microsoft.Xna.Framework.GameTime)')
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
- [LogEntry](#T-SpyceLibrary-LogEntry 'SpyceLibrary.LogEntry')
  - [Message](#F-SpyceLibrary-LogEntry-Message 'SpyceLibrary.LogEntry.Message')
  - [Sender](#F-SpyceLibrary-LogEntry-Sender 'SpyceLibrary.LogEntry.Sender')
  - [Time](#F-SpyceLibrary-LogEntry-Time 'SpyceLibrary.LogEntry.Time')
- [MouseButton](#T-SpyceLibrary-MouseButton 'SpyceLibrary.MouseButton')
  - [LEFT](#F-SpyceLibrary-MouseButton-LEFT 'SpyceLibrary.MouseButton.LEFT')
  - [MIDDLE](#F-SpyceLibrary-MouseButton-MIDDLE 'SpyceLibrary.MouseButton.MIDDLE')
  - [RIGHT](#F-SpyceLibrary-MouseButton-RIGHT 'SpyceLibrary.MouseButton.RIGHT')
- [PhysicsBody](#T-SpyceLibrary-Physics-PhysicsBody 'SpyceLibrary.Physics.PhysicsBody')
  - [#ctor()](#M-SpyceLibrary-Physics-PhysicsBody-#ctor 'SpyceLibrary.Physics.PhysicsBody.#ctor')
  - [Position](#P-SpyceLibrary-Physics-PhysicsBody-Position 'SpyceLibrary.Physics.PhysicsBody.Position')
  - [Velocity](#P-SpyceLibrary-Physics-PhysicsBody-Velocity 'SpyceLibrary.Physics.PhysicsBody.Velocity')
  - [Load(init,holder)](#M-SpyceLibrary-Physics-PhysicsBody-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Physics.PhysicsBody.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
- [PhysicsEngine](#T-SpyceLibrary-Physics-PhysicsEngine 'SpyceLibrary.Physics.PhysicsEngine')
  - [#ctor()](#M-SpyceLibrary-Physics-PhysicsEngine-#ctor 'SpyceLibrary.Physics.PhysicsEngine.#ctor')
  - [RegisterBody(body)](#M-SpyceLibrary-Physics-PhysicsEngine-RegisterBody-SpyceLibrary-Physics-PhysicsBody- 'SpyceLibrary.Physics.PhysicsEngine.RegisterBody(SpyceLibrary.Physics.PhysicsBody)')
  - [Update(gameTime)](#M-SpyceLibrary-Physics-PhysicsEngine-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Physics.PhysicsEngine.Update(Microsoft.Xna.Framework.GameTime)')
- [Scene](#T-SpyceLibrary-Scene 'SpyceLibrary.Scene')
  - [#ctor()](#M-SpyceLibrary-Scene-#ctor 'SpyceLibrary.Scene.#ctor')
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
  - [Unload()](#M-SpyceLibrary-Scene-Unload 'SpyceLibrary.Scene.Unload')
  - [Update(gameTime)](#M-SpyceLibrary-Scene-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Scene.Update(Microsoft.Xna.Framework.GameTime)')
- [SceneManager](#T-SpyceLibrary-SceneManager 'SpyceLibrary.SceneManager')
  - [CurrentScene](#P-SpyceLibrary-SceneManager-CurrentScene 'SpyceLibrary.SceneManager.CurrentScene')
  - [CurrentSceneType](#P-SpyceLibrary-SceneManager-CurrentSceneType 'SpyceLibrary.SceneManager.CurrentSceneType')
  - [Instance](#P-SpyceLibrary-SceneManager-Instance 'SpyceLibrary.SceneManager.Instance')
  - [ChangeScene(scene)](#M-SpyceLibrary-SceneManager-ChangeScene-System-String- 'SpyceLibrary.SceneManager.ChangeScene(System.String)')
  - [Draw()](#M-SpyceLibrary-SceneManager-Draw 'SpyceLibrary.SceneManager.Draw')
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
  - [Load(init,holder)](#M-SpyceLibrary-Sprites-Sprite-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject- 'SpyceLibrary.Sprites.Sprite.Load(SpyceLibrary.Initializer,SpyceLibrary.GameObject)')
  - [SetOffset(offset)](#M-SpyceLibrary-Sprites-Sprite-SetOffset-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Sprites.Sprite.SetOffset(Microsoft.Xna.Framework.Vector2)')
  - [SetTexturePath(path)](#M-SpyceLibrary-Sprites-Sprite-SetTexturePath-System-String- 'SpyceLibrary.Sprites.Sprite.SetTexturePath(System.String)')
- [TestComponent](#T-SpyceLibrary-Physics-TestComponent 'SpyceLibrary.Physics.TestComponent')
  - [Update(gameTime)](#M-SpyceLibrary-Physics-TestComponent-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Physics.TestComponent.Update(Microsoft.Xna.Framework.GameTime)')
- [TestScene](#T-SpyceLibrary-Scenes-TestScene 'SpyceLibrary.Scenes.TestScene')
  - [#ctor()](#M-SpyceLibrary-Scenes-TestScene-#ctor 'SpyceLibrary.Scenes.TestScene.#ctor')
  - [NAME](#F-SpyceLibrary-Scenes-TestScene-NAME 'SpyceLibrary.Scenes.TestScene.NAME')
  - [AddObject(obj)](#M-SpyceLibrary-Scenes-TestScene-AddObject-SpyceLibrary-GameObject- 'SpyceLibrary.Scenes.TestScene.AddObject(SpyceLibrary.GameObject)')
  - [Draw()](#M-SpyceLibrary-Scenes-TestScene-Draw 'SpyceLibrary.Scenes.TestScene.Draw')
  - [Update(gameTime)](#M-SpyceLibrary-Scenes-TestScene-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Scenes.TestScene.Update(Microsoft.Xna.Framework.GameTime)')
- [Time](#T-SpyceLibrary-Time 'SpyceLibrary.Time')
  - [DeltaTime](#P-SpyceLibrary-Time-DeltaTime 'SpyceLibrary.Time.DeltaTime')
  - [GameTime](#P-SpyceLibrary-Time-GameTime 'SpyceLibrary.Time.GameTime')
  - [RawDeltaTime](#P-SpyceLibrary-Time-RawDeltaTime 'SpyceLibrary.Time.RawDeltaTime')
  - [Update(gameTime)](#M-SpyceLibrary-Time-Update-Microsoft-Xna-Framework-GameTime- 'SpyceLibrary.Time.Update(Microsoft.Xna.Framework.GameTime)')
- [Transform](#T-SpyceLibrary-Transform 'SpyceLibrary.Transform')
  - [Identity](#P-SpyceLibrary-Transform-Identity 'SpyceLibrary.Transform.Identity')
  - [SetPosition(position)](#M-SpyceLibrary-Transform-SetPosition-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Transform.SetPosition(Microsoft.Xna.Framework.Vector2)')
  - [SetScale(scale)](#M-SpyceLibrary-Transform-SetScale-Microsoft-Xna-Framework-Vector2- 'SpyceLibrary.Transform.SetScale(Microsoft.Xna.Framework.Vector2)')

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

<a name='P-SpyceLibrary-Physics-BoxCollider-Colliders'></a>
### Colliders `property`

##### Summary

The list of colliders that are associated with this game object.

<a name='M-SpyceLibrary-Physics-BoxCollider-AddCollisionRectangle-Microsoft-Xna-Framework-Rectangle-'></a>
### AddCollisionRectangle(rect) `method`

##### Summary

Adds a collision rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rect | [Microsoft.Xna.Framework.Rectangle](#T-Microsoft-Xna-Framework-Rectangle 'Microsoft.Xna.Framework.Rectangle') |  |

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

<a name='M-SpyceLibrary-Camera-GetTransformedMatrix'></a>
### GetTransformedMatrix() `method`

##### Summary

Gets the transformed viewport matrix.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Camera-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Loads the c

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='T-SpyceLibrary-Debug'></a>
## Debug `type`

##### Namespace

SpyceLibrary

##### Summary

Debugging and performance analysis tools. Singleton to be universally access throughout
the game project.

<a name='F-SpyceLibrary-Debug-LOGS_FILE_EXTENSION'></a>
### LOGS_FILE_EXTENSION `constants`

##### Summary

The file extension for the logs.

<a name='F-SpyceLibrary-Debug-LOGS_FOLDER'></a>
### LOGS_FOLDER `constants`

##### Summary

The main folder where all the logs are saved to.

<a name='P-SpyceLibrary-Debug-Instance'></a>
### Instance `property`

##### Summary

Accessor for the singleton.

<a name='P-SpyceLibrary-Debug-TickSpeed'></a>
### TickSpeed `property`

##### Summary

The measured time (milliseconds) between a draw and update function.

<a name='M-SpyceLibrary-Debug-ClearLogs'></a>
### ClearLogs() `method`

##### Summary

Clears all the logs.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debug-Initialize-SpyceLibrary-Engine-'></a>
### Initialize(engine) `method`

##### Summary

Initializes the in-game debugger.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| engine | [SpyceLibrary.Engine](#T-SpyceLibrary-Engine 'SpyceLibrary.Engine') |  |

<a name='M-SpyceLibrary-Debug-SaveLog'></a>
### SaveLog() `method`

##### Summary

Saves the log to the logs folder as a timestamped file.

##### Parameters

This method has no parameters.

<a name='M-SpyceLibrary-Debug-SaveLog-System-String-'></a>
### SaveLog(path) `method`

##### Summary

Saves the log to the specified path.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SpyceLibrary-Debug-WriteLine-System-String,System-String,System-ConsoleColor,System-ConsoleColor-'></a>
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

<a name='T-SpyceLibrary-Engine'></a>
## Engine `type`

##### Namespace

SpyceLibrary

<a name='M-SpyceLibrary-Engine-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the engine.

##### Parameters

This constructor has no parameters.

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
### #ctor(parent) `constructor`

##### Summary

Creates a new instance of a game object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [M:SpyceLibrary.GameObject.#ctor](#T-M-SpyceLibrary-GameObject-#ctor 'M:SpyceLibrary.GameObject.#ctor') |  |

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

<a name='M-SpyceLibrary-GameObject-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(dt) `method`

##### Summary

Updates the state of the game object, components, and children.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dt | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

<a name='T-SpyceLibrary-IDrawn'></a>
## IDrawn `type`

##### Namespace

SpyceLibrary

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

<a name='T-SpyceLibrary-IUpdated'></a>
## IUpdated `type`

##### Namespace

SpyceLibrary

<a name='M-SpyceLibrary-IUpdated-Update-Microsoft-Xna-Framework-GameTime-'></a>
### Update(gameTime) `method`

##### Summary

Updates the state of the object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameTime | [Microsoft.Xna.Framework.GameTime](#T-Microsoft-Xna-Framework-GameTime 'Microsoft.Xna.Framework.GameTime') |  |

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

<a name='T-SpyceLibrary-LogEntry'></a>
## LogEntry `type`

##### Namespace

SpyceLibrary

<a name='F-SpyceLibrary-LogEntry-Message'></a>
### Message `constants`

##### Summary

The content of the message.

<a name='F-SpyceLibrary-LogEntry-Sender'></a>
### Sender `constants`

##### Summary

The name of the sender.

<a name='F-SpyceLibrary-LogEntry-Time'></a>
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

<a name='T-SpyceLibrary-Physics-PhysicsBody'></a>
## PhysicsBody `type`

##### Namespace

SpyceLibrary.Physics

<a name='M-SpyceLibrary-Physics-PhysicsBody-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the physics body.

##### Parameters

This constructor has no parameters.

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

<a name='M-SpyceLibrary-Physics-PhysicsEngine-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of the physics engine.

##### Parameters

This constructor has no parameters.

<a name='M-SpyceLibrary-Physics-PhysicsEngine-RegisterBody-SpyceLibrary-Physics-PhysicsBody-'></a>
### RegisterBody(body) `method`

##### Summary

Registers the body to the engine.

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

<a name='M-SpyceLibrary-Sprites-Sprite-Load-SpyceLibrary-Initializer,SpyceLibrary-GameObject-'></a>
### Load(init,holder) `method`

##### Summary

Loads the textures of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [SpyceLibrary.Initializer](#T-SpyceLibrary-Initializer 'SpyceLibrary.Initializer') |  |
| holder | [SpyceLibrary.GameObject](#T-SpyceLibrary-GameObject 'SpyceLibrary.GameObject') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetOffset-Microsoft-Xna-Framework-Vector2-'></a>
### SetOffset(offset) `method`

##### Summary

Sets the offset of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| offset | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |

<a name='M-SpyceLibrary-Sprites-Sprite-SetTexturePath-System-String-'></a>
### SetTexturePath(path) `method`

##### Summary

Sets the texture path of the sprite.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-SpyceLibrary-Physics-TestComponent'></a>
## TestComponent `type`

##### Namespace

SpyceLibrary.Physics

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

<a name='M-SpyceLibrary-Transform-SetScale-Microsoft-Xna-Framework-Vector2-'></a>
### SetScale(scale) `method`

##### Summary

Sets the scale of the transform.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scale | [Microsoft.Xna.Framework.Vector2](#T-Microsoft-Xna-Framework-Vector2 'Microsoft.Xna.Framework.Vector2') |  |
