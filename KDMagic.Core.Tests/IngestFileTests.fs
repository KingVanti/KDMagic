﻿module KDMagic.Core.Tests.IngestFileTests

open System.IO
open FsCheck.Xunit
open KDMagic
open global.Xunit
open FsCheck
open IngestFile

[<Property>]
let ``Ingesting a non-existent file returns a file-not-found error`` path =
    path |> (not << File.Exists)
    ==> lazy
        (let result = tryIngestFromPath "" |> Async.RunSynchronously

         match result with
         | Error (FileNotFound _) -> true
         | _ -> false)
