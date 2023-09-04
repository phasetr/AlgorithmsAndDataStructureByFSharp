/// 特定ディレクトリ配下の特定拡張子のファイル一覧を取得する
let rec getFilesWithExtensionRecursively directoryPath =
  let ext = ".md"
  let mutable matchingFiles =
    Directory.GetFiles(directoryPath, "*" + ext)
    |> Array.toList
  Directory.GetDirectories(directoryPath)
  |> Array.iter (fun subDirectory ->
    let subDirectoryFiles = getFilesWithExtensionRecursively subDirectory
    matchingFiles <- List.append matchingFiles subDirectoryFiles)
  matchingFiles

let rootDirectoryPath = "docs"
let matchingFiles = getFilesWithExtensionRecursively rootDirectoryPath

/// CSV読み込み
module CsvRead =
  #r "nuget: FSharp.Data"
  open FSharp.Data

  let n = 50
  // 読み込み対象を指定
  type PhraseType = CsvProvider<"uz_phrases.csv">
  printfn "%s" "** 表現・文"
  PhraseType.Load("uz_phrases.csv").Cache().Rows
  |> Seq.iteri (fun i row ->
    if i%n = 0 then printfn "%s" $"\n*** {i+1}\n"
    printfn "%s" $"??? {row.Ja}"
    printfn "%s" ""
    printfn "%s" $"    - {row.Uz}"
    if row.Info <> "" then printfn "%s" $"    - {row.Info}"
    printfn "%s" "")
