﻿namespace OmniBlade
open Prime
open Nu

[<RequireQualifiedAccess>]
module Events =

    let Cancel = stoa<unit> "Cancel/Event"
    let ItemSelect = stoa<string> "Item/Select/Event"
    let TargetSelect = stoa<CharacterIndex> "Target/Select/Event"