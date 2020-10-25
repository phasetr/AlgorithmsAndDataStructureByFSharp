# P.004 LOWEST NUMBER
module P004
  function ln()
    println("はじめの数を整数で入力してください: ")
    num1 = parse(Int, readline()) # 標準入力からパースする
    println("2 番目の数を整数で入力してください: ")
    num2 = parse(Int, readline()) # 標準入力からパースする

    lowest = num2
    if num1 <= num2 lowest = num1 end
    println("最小の数（2 つのうちの小さい方）は $lowest です.") # 文字列の埋め込み
  end
end
P004.ln()

# 変数 x が 4 から 7 の間にあることをチェックするコードを書け。

# %%
function p004_sol(x)
  ret = false
  if 4 <= x <= 7 (ret = true) end # Julia では 4 <= x && x <= 7 のように書かなくてもいい
  ret
end
map(x -> "$x: $(p004_sol(x))", 1:9)
# %%
