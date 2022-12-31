#r "nuget: FsUnit"
open FsUnit

(*
let S,T = "mynavi","monday"
let S,T = "tokyo","kyoto"
let S,T = "ayjspdhcophaxrxtncpmiorropjgkskilflqnvuwahyoyzaydignjejjpipzraslrjzswbdrsqndltwbrrlildhgarroxyajliulensxvqljuniivaogvwfhisywagmzyyauritdrxnhcywiwpfcpfxsdhtatmeuokgtqwuovmrfjcwbtvqjngyiknehramlocwzyeyvfnxouyhrewgqvdalkcmpxrhhgngpwfghmpzvqfldtuwusmpgbkohhbnkbcrarpssphbnvbccfzmoytcecdgzzpgdydtdxngdercnsvraxdiiefowkfyhzoptxswdyzivgplnuagweoplvuzfjyzezhvrjcdbrujxcmqudxswbolugtxzggrrbpgqrwwnvcccczvdalzgytwevldbeslozmqwfijgyjtppgbxcinfxsfyqwtzjcfqjbvcbjtsdjopfokrrljbrxihnsloixxjlwlaqdoszmrjdnsqeafgzflikpdshigcwgcnrujwoulwglwtepzupvflfdqgdjctnvcbruqrnxogcwizlqceibcthplhtmzztevhzxtogogkqsubpzmmxlxlflytbapxculktvrnmxsrrlftnijluqisipldqorggnwvlqshgyzkxynecncpeqrxedmdteupwuiforpagvnimfdffmxhuclznxositwupllmfmyxrmoyotptuafoeiwrqplkznzubnyhgspgehabdhlvtpwxuxycgzdejaxfbkeieizqfuryllssciclnjstarxzlcnmmbuuecocprxmyhwxpawuwguerbyywfwbupatkywrbsuvkrkmcpktksiynccmpvtbidamdrwwlgeejzsgtxtcxgtkiijviifrvsveeqkv","wprmjsudodjusoexdickjchfhunplrodubzkmjlunzmjgbnwbjfxdoagpaqqnvhbmovzaezfryjmfekcueehhovmijbdzcqohambcgsczaeuuvomvydifwhakvgnjubsnpgzjrbdmizufrnoftjrqykalrwszfcrznfjqfgzmclnnjnzcsxppcghklrfuptfnpecdoxklsfpfuqjwcpewugkyrdjjosecnlomlbiiamvhlxgubxtwomqqotdboeffdqagkwvqaagbgyxfupeixesnwriceaqkbhhkmfuivnlwizrczygannqnaeqeuakabvcenmbwrjxaluimmgrkmjfsmqizfwhojzsxebcjzkhljfehprgzwrxtpdndwvnqrbhenvlgqwgfunohtiuezphzbgoibvdevrezuahpolvrczwdewoevnzkmhrioyegwhizckyxhvdohkdgxjdcqcgnwqcjyzmrcqmvmktorsauzagyvppuaqnxtvbpmndnwlsnkpmmoopfclaswlfknzwskjmkuhmifiqufhektxpnxiknehdnaokzpbwctrbxxdihfykyytvkwhjfhvwypdzmxfvnnvxvaauskszuxduiecgnzzqptqoqsvysydrmzihlsnggygdtsevwboqjxqtoxkhumxomrvzpjketdatznpfiebpdtqfakegvnrpaehlnxmuysdkgqwwmwwvdjkbnrtqavhdajrhiwzwxzabanzlrqhlqkysmroykkbhgoqzssfnjmpyzdgwlgodfuortkvunhvnkfivvxxablmnblwdoougmccocbkimscazghzvwhwbitzrdjohodybqyovqajlitbitvqtpncmkvzskkkbkfwxxqrgqcfhknxfoqjlwarapbfzeljdarzrlatlxzjvsghkjmlrxosgvjpipysxvakaiejuhcgxwtodjlgqcjrvihkpnwauzcwftkmfesduhcfjsrtcqijhohitlpplfxhqszfosofzshcsguvakgsluiixbxfyicupycxfyxfazgsodendaqauhlwsusvcozrvvxuelkcdlmbmtoejxzwcjxuijpsfbaxzakoptpahcuuxwfqfxslpxbfjkjimhhqdbgaxhosjgxztetgycgbcjmudpmfxsvdaqbgvdbdixirmsyibokgwjddmmgktbprrxpdotrslhutjrxternpkxfwcbrxzadseciomtjoyqzbydqfdlzipvrmpuebnhpfqsnclnpwvutwjpbhheyspvpbfxqjcmjkuuxeosdntiscyzkenfyvcstuiftqhxcksooesorejgdeotkptsqvpiawfeflvuknojkdryuuhtoemlmlagdktucgpeekqbtqvxbysvkdgglfydygncrcshbplpfmmmqwhegcghpgfjdmoqsjqzmwplkjlvsbazauamufgyusowzxsgyjiaypfutnhethjhhrqdzrukgyiifsxsjjgbesyeuzsqnnlwppwsvugxzzoarinbitcluxbtqottzudjddybcqbctkqyktunvvfvkppimycmxfapzvbrisyqkirxeuvsshyzljuzkqghjnidlukdcfixwtilngewdnrusilbkdwcjasidyvlftxolotkjssflucoxnkiatkpvujkwmpclfytleiwtbogawqnqogltjzavihivdpvsrrmogopwaytssafkueqdjszrulnsnjhrnkfqbergglvkgrmtziqcmrqnburdkwlmxxexyjcpwgowqinrijvhgbqvuolsprjpfhuiynhhaqbtutioztgqarpjyfjeisozeankpwknnlokyscfffponpusyilbciqkyaszyomhzzvsfkeprenfwundoyvhgjlposozhjkxcntlowokasyfwyzepcmnlyvwbjfdffaetigrwyycraudcksxpcsosggdnlvhcyozvrncxdgnulpfdxfhn"
*)
let solve S T =
  let sLen = String.length S
  let init xs = if List.length xs <= 1 then [] else xs.[0..(List.length xs-2)]
  let lcs Ss Ts =
    (Ts, List.replicate (1+sLen) 0)
    ||> List.foldBack (fun y dp ->
      let l3 = List.zip3 Ss (init dp) (List.tail dp)
      (l3, [0]) ||> List.foldBack (fun (x,n1,n2) dp ->
        if x=y then (1+n2)::dp else max n1 (List.head dp) :: dp))
    |> List.head
  lcs (S |> Seq.toList) (T |> Seq.toList)

let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "mynavi" "monday" |> should equal 3
solve "tokyo" "kyoto" |> should equal 3
// in01.txt
solve "bceae" "eddce" |> should equal 2
// in11.txt
solve "ayjspdhcophaxrxtncpmiorropjgkskilflqnvuwahyoyzaydignjejjpipzraslrjzswbdrsqndltwbrrlildhgarroxyajliulensxvqljuniivaogvwfhisywagmzyyauritdrxnhcywiwpfcpfxsdhtatmeuokgtqwuovmrfjcwbtvqjngyiknehramlocwzyeyvfnxouyhrewgqvdalkcmpxrhhgngpwfghmpzvqfldtuwusmpgbkohhbnkbcrarpssphbnvbccfzmoytcecdgzzpgdydtdxngdercnsvraxdiiefowkfyhzoptxswdyzivgplnuagweoplvuzfjyzezhvrjcdbrujxcmqudxswbolugtxzggrrbpgqrwwnvcccczvdalzgytwevldbeslozmqwfijgyjtppgbxcinfxsfyqwtzjcfqjbvcbjtsdjopfokrrljbrxihnsloixxjlwlaqdoszmrjdnsqeafgzflikpdshigcwgcnrujwoulwglwtepzupvflfdqgdjctnvcbruqrnxogcwizlqceibcthplhtmzztevhzxtogogkqsubpzmmxlxlflytbapxculktvrnmxsrrlftnijluqisipldqorggnwvlqshgyzkxynecncpeqrxedmdteupwuiforpagvnimfdffmxhuclznxositwupllmfmyxrmoyotptuafoeiwrqplkznzubnyhgspgehabdhlvtpwxuxycgzdejaxfbkeieizqfuryllssciclnjstarxzlcnmmbuuecocprxmyhwxpawuwguerbyywfwbupatkywrbsuvkrkmcpktksiynccmpvtbidamdrwwlgeejzsgtxtcxgtkiijviifrvsveeqkv" "wprmjsudodjusoexdickjchfhunplrodubzkmjlunzmjgbnwbjfxdoagpaqqnvhbmovzaezfryjmfekcueehhovmijbdzcqohambcgsczaeuuvomvydifwhakvgnjubsnpgzjrbdmizufrnoftjrqykalrwszfcrznfjqfgzmclnnjnzcsxppcghklrfuptfnpecdoxklsfpfuqjwcpewugkyrdjjosecnlomlbiiamvhlxgubxtwomqqotdboeffdqagkwvqaagbgyxfupeixesnwriceaqkbhhkmfuivnlwizrczygannqnaeqeuakabvcenmbwrjxaluimmgrkmjfsmqizfwhojzsxebcjzkhljfehprgzwrxtpdndwvnqrbhenvlgqwgfunohtiuezphzbgoibvdevrezuahpolvrczwdewoevnzkmhrioyegwhizckyxhvdohkdgxjdcqcgnwqcjyzmrcqmvmktorsauzagyvppuaqnxtvbpmndnwlsnkpmmoopfclaswlfknzwskjmkuhmifiqufhektxpnxiknehdnaokzpbwctrbxxdihfykyytvkwhjfhvwypdzmxfvnnvxvaauskszuxduiecgnzzqptqoqsvysydrmzihlsnggygdtsevwboqjxqtoxkhumxomrvzpjketdatznpfiebpdtqfakegvnrpaehlnxmuysdkgqwwmwwvdjkbnrtqavhdajrhiwzwxzabanzlrqhlqkysmroykkbhgoqzssfnjmpyzdgwlgodfuortkvunhvnkfivvxxablmnblwdoougmccocbkimscazghzvwhwbitzrdjohodybqyovqajlitbitvqtpncmkvzskkkbkfwxxqrgqcfhknxfoqjlwarapbfzeljdarzrlatlxzjvsghkjmlrxosgvjpipysxvakaiejuhcgxwtodjlgqcjrvihkpnwauzcwftkmfesduhcfjsrtcqijhohitlpplfxhqszfosofzshcsguvakgsluiixbxfyicupycxfyxfazgsodendaqauhlwsusvcozrvvxuelkcdlmbmtoejxzwcjxuijpsfbaxzakoptpahcuuxwfqfxslpxbfjkjimhhqdbgaxhosjgxztetgycgbcjmudpmfxsvdaqbgvdbdixirmsyibokgwjddmmgktbprrxpdotrslhutjrxternpkxfwcbrxzadseciomtjoyqzbydqfdlzipvrmpuebnhpfqsnclnpwvutwjpbhheyspvpbfxqjcmjkuuxeosdntiscyzkenfyvcstuiftqhxcksooesorejgdeotkptsqvpiawfeflvuknojkdryuuhtoemlmlagdktucgpeekqbtqvxbysvkdgglfydygncrcshbplpfmmmqwhegcghpgfjdmoqsjqzmwplkjlvsbazauamufgyusowzxsgyjiaypfutnhethjhhrqdzrukgyiifsxsjjgbesyeuzsqnnlwppwsvugxzzoarinbitcluxbtqottzudjddybcqbctkqyktunvvfvkppimycmxfapzvbrisyqkirxeuvsshyzljuzkqghjnidlukdcfixwtilngewdnrusilbkdwcjasidyvlftxolotkjssflucoxnkiatkpvujkwmpclfytleiwtbogawqnqogltjzavihivdpvsrrmogopwaytssafkueqdjszrulnsnjhrnkfqbergglvkgrmtziqcmrqnburdkwlmxxexyjcpwgowqinrijvhgbqvuolsprjpfhuiynhhaqbtutioztgqarpjyfjeisozeankpwknnlokyscfffponpusyilbciqkyaszyomhzzvsfkeprenfwundoyvhgjlposozhjkxcntlowokasyfwyzepcmnlyvwbjfdffaetigrwyycraudcksxpcsosggdnlvhcyozvrncxdgnulpfdxfhn" |> should equal 416

let solveWithSubString S T =
  let sLen = String.length S
  let nil = (0,[])
  let cons x (n,xs) = (n+1,x::xs)
  let longer ((m,_) as xs) ((n,_) as ys) = if m<n then ys else xs
  let init xs = if List.length xs <= 1 then [] else xs.[0..(List.length xs-2)]
  let lcs Ss Ts =
    (Ts, List.replicate (1+sLen) nil)
    ||> List.foldBack (fun y dp ->
      let l3 = List.zip3 Ss (init dp) (List.tail dp)
      (l3, [nil]) ||> List.foldBack (fun (x,cs1,cs2) dp ->
        if x=y then (cons x cs2)::dp else longer cs1 (List.head dp) :: dp))
    |> List.head
  lcs (S |> Seq.toList) (T |> Seq.toList) |> fst
