
A client mod to hide the game ui:

## Configuration

Once the mod installed, a configuration file will be created in the \BepInEx\config client folder where you can activate or desactivate any of the mod functions.

**HideUiMod.cfg**

```
## Settings file was created by plugin HideUiMod v1.0.0
## Plugin GUID: HideUiMod

[UIHide]

## Turn hide minimap on or off
# Setting type: Boolean
# Default value: true
MiniMap = true

## Turn hide bottom bar on or off
# Setting type: Boolean
# Default value: true
BottomBar = true

## Turn hide right menu on or off
# Setting type: Boolean
# Default value: true
RightMenu = true

## Turn hide clock on or off
# Setting type: Boolean
# Default value: true
Clock = true

## Turn hide chat window on or off
# Setting type: Boolean
# Default value: true
ChatWindow = true

## Enable to hide all UI including players/enemies name and health
# Setting type: Boolean
# Default value: false
AllUI = false
```


|SECTION|PARAM| DESCRIPTION                                                     | DEFAULT
|----------------|-------------------------------|-----------------------------------------------------------------|-----------------------------|
|UIHide|`MiniMap `            | Turn hide minimap on or off             | true
|UIHide|`BottomBar `            | Turn hide bottom bar on or off             | true
|UIHide|`RightMenu `            | Turn hide clock on or off             | true
|UIHide|`Clock `            | Turn hide minimap on or off             | true
|UIHide|`ChatWindow `            | Turn hide minimap on or off             | true
|UIHide|`AllUI `            | Enable to hide all UI including players/enemies name and health            | false