﻿// Nu Game Engine.
// Copyright (C) Bryan Edds, 2013-2020.

#I __SOURCE_DIRECTORY__
#r "../../packages/FParsec.1.0.3/lib/net40-client/FParsecCS.dll" // MUST be referenced BEFORE FParsec.dll!
#r "../../packages/FParsec.1.0.3/lib/net40-client/FParsec.dll"
#r "../../packages/FsCheck.2.11.0/lib/net452/FsCheck.dll"
#r "../../packages/FsCheck.Xunit.2.11.0/lib/net452/FsCheck.Xunit.dll"
#r "../../packages/Prime.5.1.0/lib/net472/Prime.dll"
#r "../../packages/Prime.Scripting.5.1.0/lib/net472/Prime.Scripting.exe"
#r "../../Nu/Nu.Dependencies/FSharpx.Core/FSharpx.Core.dll"
#r "../../Nu/Nu.Dependencies/FSharpx.Collections/FSharpx.Collections.dll"
#r "../../Nu/Nu.Dependencies/Farseer/FarseerPhysics.dll"
#r "../../Nu/Nu.Dependencies/Magick.NET/Magick.NET-AnyCPU.dll"
#r "../../Nu/Nu.Dependencies/Nito.Collections.Deque/Nito.Collections.Deque.dll"
#r "../../Nu/Nu.Dependencies/SDL2-CS/Debug/SDL2-CS.dll"
#r "../../Nu/Nu.Dependencies/TiledSharp/Debug/TiledSharp.dll"
#r "../../Nu/Nu.Math/bin/Debug/Nu.Math.dll"
#r "../../Nu/Nu/bin/Debug/Nu.exe"

#load "Nelmish.fs"
#load "NelmishPlugin.fs"

open System.IO
open Prime
open Nu

// set current directly to local for execution in VS F# interactive
Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__ + "/bin/Debug")

// build assets
match AssetGraph.tryMakeFromFile Assets.AssetGraphFilePath with
| Right assetGraph -> AssetGraph.buildAssets "../.." "." "../../refinement" false assetGraph
| Left _ -> ()

// init nu and run game
Nu.init NuConfig.defaultConfig
World.run WorldConfig.defaultConfig (Nelmish.NelmishPlugin ())