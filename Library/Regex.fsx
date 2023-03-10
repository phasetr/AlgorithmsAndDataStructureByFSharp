#r "nuget: FsUnit"
open FsUnit

@"メモ: 正規表現だけではなくパーサーを生成させてみたい"
open System.Text.RegularExpressions
let toString result = result |> Seq.toArray |> Array.map (fun m -> m.ToString())
@"https://learn.microsoft.com/ja-jp/dotnet/api/system.text.regularexpressions.regex?view=net-8.0"
@"Regular_Expression_Puzzles_and_AI_Coding"
@"P.10, xではじまりyで終わる単語"
@"貪欲: 正しくない
yは後ろの単語に登場する可能性があり,
一致は行の最後のyまで終わらない"
let pat1 = @"x.*y"
@"非貪欲: 正しくない
"
let pat2 = @"x.*?y"
let txt = """xenarthral xerically xenomorphically xebec xenomania
xenogenic xenogeny xenophobically xenon xenomenia
xylotomy xenogenies xenografts xeroxing xenons xanthous
xenoglossy xanthopterins xenoglossy xeroxed xenophoby
xenoglossies xanthoxyls xenoglossias xenomorphically
xeroxes xanthopterin xebecs xenodochiums xenodochium
xylopyrography xanthopterines xerochasy xenium xenic"""

Regex.Matches(txt, pat1)
|> toString
|> should equal [|"xenarthral xerically xenomorphically";
                 "xenogenic xenogeny xenophobically";
                 "xylotomy";
                 "xenoglossy xanthopterins xenoglossy xeroxed xenophoby";
                 "xenoglossies xanthoxyls xenoglossias xenomorphically";
                 "xylopyrography xanthopterines xerochasy"|]
Regex.Matches(txt, pat2)
|> toString
|> should equal [|"xenarthral xerically";
                 "xenomorphically";
                 "xenogenic xenogeny";
                 "xenophobically";
                 "xy";
                 "xenoglossy";
                 "xanthopterins xenoglossy";
                 "xeroxed xenophoby";
                 "xenoglossies xanthoxy";
                 "xenoglossias xenomorphically";
                 "xy";
                 "xanthopterines xerochasy"|]

@"P.12, まだ正しくない"
let pat3 = @"x[a-z]*y"
Regex.Matches(txt,pat3) |> toString
|> should equal [|"xerically";
                 "xenomorphically";
                 "xenogeny";
                 "xenophobically";
                 "xylotomy";
                 "xenoglossy";
                 "xenoglossy";
                 "xenophoby";
                 "xanthoxy";
                 "xenomorphically";
                 "xylopyrography";
                 "xerochasy"|]
let txt2 = "breathiness xenogeny randed xyxyblah xylotomy"
Regex.Matches(txt2,pat3) |> toString
|> should equal [|"xenogeny";
                 "xyxy"; // おかしい
                 "xylotomy"|]

// ChatGPT, 2023-03-10 `xで始まりyで終わる小文字を取得する正規表現を教えてください。`
let cGptPat = @"^x[a-z]*y$"
Regex.Matches(txt2,cGptPat) |> toString |> should equal [||]
// ChatGPT, 2023-03-10, `文章からxで始まりyで終わる小文字だけからなる単語を取得する正規表現を教えてください。`
let cGptPat = @"\b[x][a-z]*[y]\b"
Regex.Matches(txt2,cGptPat) |> toString |> should equal [|"xenogeny"; "xylotomy"|]
