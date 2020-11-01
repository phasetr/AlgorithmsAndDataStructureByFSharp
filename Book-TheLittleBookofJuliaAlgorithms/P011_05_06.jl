# ## P.011 Challenge 5: Tracing If Statements
# ### Q1
# 関数の挙動, 特に if の挙動を調べる
function mystery_number(num)
  if num < 5 return 8
  elseif num < 3 return 8
  elseif num == 3 return 3
  else return num end
end
println(mystery_number(8))  # 8
println(mystery_number(3))  # 8
println(mystery_number(12)) # 12
println(mystery_number(5))  # 5

# ### Q2
# 上の関数は冗長で 2 行削れる. どの 2 行が削れるか?
function mystery_number2(num)
  if num < 5 return 8
  else return num end
end
println(mystery_number2(8))
println(mystery_number2(3))
println(mystery_number2(12))
println(mystery_number2(5))

# ### Q3
# 元の関数の 6-7 行目は 3 を入力したら 3 を返すようになっているが, 実際にはこうならない.
# 何故か説明してみよう.

# #### A
# 先に `if num < 5` の判定にはいってしまうため.

# ## P.12 Challenge 6: Refining
# Challenge 5 の関数を次のように書き換える.
#
# - `num = 3` のときに 1 を返す
# - `num` が 5 未満（かつ 3 でないとき）に 8 を返す
# - 上記以外は入力をそのまま返す
function mystery_number3(num)
  if num == 3 return num
  elseif num < 5 return 8
  else return num end
end
println(map(i -> "$i: $(mystery_number3(i))", 0:12))
